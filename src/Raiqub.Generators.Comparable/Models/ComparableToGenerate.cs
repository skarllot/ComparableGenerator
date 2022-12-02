namespace Raiqub.Generators.Comparable.Models;

public record ComparableToGenerate(TypeKind Kind, bool IsSealed, string Namespace, string Name)
{
    public bool IsValueType => Kind == TypeKind.Struct;
    public bool IsReferenceType => Kind != TypeKind.Struct;
    public bool HasEqualityOperators => Kind == TypeKind.Record;
    public bool HasObjectEquals => Kind == TypeKind.Record;

    public string TypeKeyword => Kind switch
    {
        TypeKind.Class => "class",
        TypeKind.Record => "record",
        TypeKind.Struct => "struct",
        _ => "class"
    };
}

public enum TypeKind
{
    Class = 1,
    Record,
    Struct
}