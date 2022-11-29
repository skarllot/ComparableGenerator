using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Raiqub.Generators.Comparable.Common;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this ImmutableArray<T?> source)
        where T : class
    {
        return source.Where(it => it is not null)!;
    }
}