using Microsoft.CodeAnalysis;

namespace Raiqub.Generators.Comparable.Common;

public static class CodeAnalysisExtensions
{
    public static IncrementalValuesProvider<TSource> WhereNotNull<TSource>(
        this IncrementalValuesProvider<TSource?> source)
    {
        return source.Where(static it => it is not null)!;
    }
}