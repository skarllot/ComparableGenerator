using Microsoft.CodeAnalysis;
using Raiqub.Generators.Comparable.Common;

namespace Raiqub.Generators.Comparable;

[Generator]
public partial class ComparableGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(AddAttribute);

        var provider = context.SyntaxProvider
            .CreateSyntaxProvider(IsSyntaxTargetForGeneration, GetSemanticTargetForGeneration)
            .WhereNotNull()
            .Collect()
            .Combine(context.CompilationProvider);

        context.RegisterImplementationSourceOutput(provider, Emit);
    }
}