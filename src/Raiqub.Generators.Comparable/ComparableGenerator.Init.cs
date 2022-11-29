using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Raiqub.Generators.Comparable;

public partial class ComparableGenerator
{
    private static void AddAttribute(IncrementalGeneratorPostInitializationContext context)
    {
        string sourceText = ResourceReader.ComparableAttribute();
        context.AddSource("ComparableAttribute.g.cs", SourceText.From(sourceText, Encoding.UTF8));
    }
}