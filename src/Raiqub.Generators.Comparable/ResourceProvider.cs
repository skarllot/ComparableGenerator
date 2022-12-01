using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Raiqub.Generators.Comparable;

internal static class ResourceProvider
{
    private const string ResourcePrefix = "Raiqub.Generators.Comparable.Resources.";
    private static readonly Assembly ThisAssembly = typeof(ResourceProvider).Assembly;
    private static string? comparablePartial;

    public static string ComparablePartial =>
        comparablePartial ??= LoadEmbeddedResource(ResourcePrefix + "ComparablePartial.cs");

    private static string LoadEmbeddedResource(string resourceName)
    {
        using var stream = ThisAssembly.GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            string[] resourceNames = ThisAssembly.GetManifestResourceNames();
            throw new ArgumentException(
                $"Could not find embedded resource {resourceName}. " +
                $"Available names: {string.Join(", ", resourceNames)}.");
        }

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}