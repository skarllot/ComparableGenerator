using System.IO;
using System.Reflection;
using System.Text;

namespace Raiqub.Generators.Comparable;

internal static class ResourceReader
{
    private static readonly Assembly _assembly = typeof(ResourceReader).Assembly;

    public static string ComparablePartial()
    {
        const string resourceName = "Raiqub.Generators.Comparable.Resources.ComparablePartial.cs";
        return GetString(resourceName) ?? "// Not found";
    }

    private static string? GetString(string resourceName)
    {
        using var stream = _assembly.GetManifestResourceStream(resourceName);
        if (stream is null)
            return null;

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}