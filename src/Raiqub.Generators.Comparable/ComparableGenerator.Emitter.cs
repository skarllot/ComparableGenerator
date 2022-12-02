using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Raiqub.Generators.Comparable.Common;
using Raiqub.Generators.Comparable.Models;
using Stubble.Core;
using Stubble.Core.Builders;
using TypeKind = Raiqub.Generators.Comparable.Models.TypeKind;

namespace Raiqub.Generators.Comparable;

public partial class ComparableGenerator
{
    private static readonly StubbleVisitorRenderer Stubble = new StubbleBuilder().Build();

    private static void Emit(
        SourceProductionContext context,
        (ImmutableArray<TypeDeclarationSyntax> Types, Compilation Compilation) data)
    {
        Emit(data.Compilation, context, data.Types);
    }

    private static void Emit(
        Compilation compilation,
        SourceProductionContext context,
        ImmutableArray<TypeDeclarationSyntax> types)
    {
        if (types.IsDefaultOrEmpty)
        {
            return;
        }

        var typesToGenerate = GetTypesToGenerate(compilation, types, context.CancellationToken);

        foreach (var comparableToGenerate in typesToGenerate)
        {
            string filename = GetFilename(comparableToGenerate);
            string fileContent = GetFileContent(comparableToGenerate);
            context.AddSource(filename, SourceText.From(fileContent, Encoding.UTF8));
        }
    }

    private static List<ComparableToGenerate> GetTypesToGenerate(
        Compilation compilation,
        ImmutableArray<TypeDeclarationSyntax> types,
        CancellationToken cancellationToken)
    {
        var typesToGenerate = new List<ComparableToGenerate>();

        var comparableAttribute = compilation.GetTypeByMetadataName(ComparableAttributeName);
        if (comparableAttribute is null)
        {
            return typesToGenerate;
        }

        foreach (var type in types)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var semanticModel = compilation.GetSemanticModel(type.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(type) is not INamedTypeSymbol typeSymbol)
            {
                continue;
            }

            var compareToMember = typeSymbol.GetMembers("CompareTo")
                .SingleOrDefault(
                    it => it is IMethodSymbol methodSymbol &&
                          methodSymbol.ReturnType.Name == nameof(Int32) &&
                          methodSymbol.Parameters.Length == 1 &&
                          methodSymbol.Parameters[0].Type.Name == typeSymbol.Name);

            if (compareToMember is null)
            {
                continue;
            }

            var kind = typeSymbol switch
            {
                { IsRecord: true } => TypeKind.Record,
                { IsReferenceType: true } => TypeKind.Class,
                { IsValueType: true } => TypeKind.Struct,
                _ => (TypeKind)0
            };

            typesToGenerate.Add(
                new ComparableToGenerate(
                    kind,
                    typeSymbol.IsSealed,
                    type.GetNamespace(),
                    typeSymbol.Name));
        }

        return typesToGenerate;
    }

    private static string GetFilename(ComparableToGenerate type)
    {
        return type.Name + ".Comparable.g.cs";
    }

    private static string GetFileContent(ComparableToGenerate type)
    {
        string kind = type.Kind switch
        {
            TypeKind.Class => "class",
            TypeKind.Record => "record",
            TypeKind.Struct => "struct",
            _ => "class"
        };

        return new StringBuilder(ResourceProvider.ComparablePartial)
            .RemoveFragmentIf("NamespaceBegin", string.IsNullOrEmpty(type.Namespace))
            .RemoveFragmentIf("NamespaceEnd", string.IsNullOrEmpty(type.Namespace))
            .RemoveFragmentIf("EqualityOperators", type.Kind == TypeKind.Record)
            .RemoveFragmentIf("IsByRef", type.Kind == TypeKind.Struct)
            .RemoveFragmentIf("IsValue", type.Kind != TypeKind.Struct)
            .RemoveFragmentIf("ObjectEquals", type.Kind == TypeKind.Record)
            .Replace("NAMESPACE", type.Namespace)
            .Replace("class", kind)
            .Replace("CLASS", type.Name)
            .ReplaceIf(type.IsSealed, " virtual", "")
            .ReplaceIf(type.Kind == TypeKind.Struct, type.Name + "?", type.Name)
            .ToString();
    }
}