using System;
using System.Text;

namespace Raiqub.Generators.Comparable.Common;

public static class StringBuilderExtensions
{
    private const string FragmentBeginPrefix = "// +";
    private const string FragmentEndPrefix = "// -";

    public static int IndexOf(
        this StringBuilder builder,
        ReadOnlySpan<char> value,
        int startIndex)
    {
        int len = value.Length;
        int max = builder.Length - len + 1;
        for (int i1 = startIndex; i1 < max; ++i1)
        {
            if (builder[i1] != value[0])
            {
                continue;
            }

            int i2 = 1;
            while (i2 < len && builder[i1 + i2] == value[i2])
            {
                ++i2;
            }

            if (i2 == len)
            {
                return i1;
            }
        }

        return -1;
    }

    public static StringBuilder RemoveAll(
        this StringBuilder builder,
        ReadOnlySpan<char> value)
    {
        int startIndex = 0;
        while (startIndex < builder.Length)
        {
            int index = builder.IndexOf(value, startIndex);
            if (index == -1)
                return builder;

            builder.Remove(index, value.Length);
            startIndex += value.Length;
        }

        return builder;
    }

    public static StringBuilder ReplaceIf(this StringBuilder builder, bool condition, string oldValue, string newValue)
    {
        return condition
            ? builder.Replace(oldValue, newValue)
            : builder;
    }

    public static StringBuilder RemoveFragmentIf(this StringBuilder builder, string fragmentName, bool condition)
    {
        return condition
            ? RemoveFragment(builder, fragmentName)
            : ConfirmFragment(builder, fragmentName);
    }

    private static StringBuilder ConfirmFragment(StringBuilder builder, string fragmentName)
    {
        var fragmentBegin = stackalloc char[512].WriteAll(Environment.NewLine, FragmentBeginPrefix, fragmentName);
        var fragmentEnd = stackalloc char[512].WriteAll(Environment.NewLine, FragmentEndPrefix, fragmentName);

        return builder
            .RemoveAll(fragmentBegin)
            .RemoveAll(fragmentEnd);
    }

    private static StringBuilder RemoveFragment(StringBuilder builder, string fragmentName)
    {
        var fragmentBegin = stackalloc char[512].WriteAll(Environment.NewLine, FragmentBeginPrefix, fragmentName);
        var fragmentEnd = stackalloc char[512].WriteAll(Environment.NewLine, FragmentEndPrefix, fragmentName);

        int startIndex = 0;
        while (startIndex < builder.Length)
        {
            int indexBegin = builder.IndexOf(fragmentBegin, startIndex);
            if (indexBegin == -1)
                return builder;

            int indexEnd = builder.IndexOf(fragmentEnd, indexBegin + fragmentBegin.Length);
            if (indexEnd == -1)
                return builder;

            int count = indexEnd + fragmentEnd.Length - indexBegin;
            builder.Remove(indexBegin, count);
            startIndex += count;
        }

        return builder;
    }
}