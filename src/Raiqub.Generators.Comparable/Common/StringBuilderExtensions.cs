using System.Text;

namespace Raiqub.Generators.Comparable.Common;

public static class StringBuilderExtensions
{
    public static StringBuilder ReplaceIf(this StringBuilder builder, bool condition, string oldValue, string newValue)
    {
        return condition
            ? builder.Replace(oldValue, newValue)
            : builder;
    }
}