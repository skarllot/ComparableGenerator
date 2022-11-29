namespace Raiqub.Generators.Comparable.Models;

public readonly record struct ComparableToGenerate(TypeKind Kind, bool IsSealed, string Namespace, string Name);

public enum TypeKind
{
    Class = 1,
    Record,
    Struct
}