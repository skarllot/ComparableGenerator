using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Raiqub.Generators.Comparable;

public partial class ComparableGenerator
{
    private const string ComparableAttributeName = "Raiqub.Generators.Comparable.ComparableAttribute";

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node, CancellationToken cancellationToken)
    {
        return node is TypeDeclarationSyntax { AttributeLists.Count: > 0 };
    }

    private static TypeDeclarationSyntax? GetSemanticTargetForGeneration(
        GeneratorSyntaxContext context,
        CancellationToken cancellationToken)
    {
        var semanticModel = context.SemanticModel;
        var syntax = (TypeDeclarationSyntax)context.Node;

        if (syntax.Modifiers.Any(SyntaxKind.PartialKeyword) is false ||
            syntax.Modifiers.Any(SyntaxKind.InterfaceDeclaration) ||
            HasComparableAttribute(semanticModel, syntax, cancellationToken) is false)
        {
            return null;
        }

        return syntax;
    }

    private static bool HasComparableAttribute(
        SemanticModel semanticModel,
        TypeDeclarationSyntax syntax,
        CancellationToken cancellationToken)
    {
        foreach (var attributeList in syntax.AttributeLists)
        {
            foreach (var attribute in attributeList.Attributes)
            {
                if (ModelExtensions.GetSymbolInfo(semanticModel, attribute, cancellationToken).Symbol is not
                    IMethodSymbol ctorSymbol)
                {
                    continue;
                }

                var attributeSymbol = ctorSymbol.ContainingType;
                string attributeName = attributeSymbol.ToDisplayString();

                if (attributeName == ComparableAttributeName)
                {
                    return true;
                }
            }
        }

        return false;
    }
}