using System;

namespace Raiqub.Generators.Comparable.Common;

public static class SpanExtensions
{
    public static Span<T> WriteAll<T>(
        this Span<T> span,
        ReadOnlySpan<T> item1,
        ReadOnlySpan<T> item2,
        ReadOnlySpan<T> item3)
    {
        int count = 0;
        item1.CopyTo(span);
        count += item1.Length;
        item2.CopyTo(span.Slice(count));
        count += item2.Length;
        item3.CopyTo(span.Slice(count));
        count += item3.Length;

        return span.Slice(0, count);
    }

    public static Span<char> WriteAll(
        this Span<char> span,
        string item1,
        string item2,
        string item3)
    {
        return WriteAll(span, item1.AsSpan(), item2.AsSpan(), item3.AsSpan());
    }
}