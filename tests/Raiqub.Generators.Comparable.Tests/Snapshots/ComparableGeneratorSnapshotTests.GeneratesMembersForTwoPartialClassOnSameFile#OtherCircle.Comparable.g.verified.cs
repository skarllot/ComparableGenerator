//HintName: OtherCircle.Comparable.g.cs
// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

namespace TestNamespace
{
    partial class OtherCircle
        : IComparable, IComparable<OtherCircle?>, IEquatable<OtherCircle?>
    {
        public static bool operator <(OtherCircle? left, OtherCircle? right) => Compare(left, right) < 0;
        public static bool operator >(OtherCircle? left, OtherCircle? right) => Compare(left, right) > 0;
        public static bool operator <=(OtherCircle? left, OtherCircle? right) => Compare(left, right) <= 0;
        public static bool operator >=(OtherCircle? left, OtherCircle? right) => Compare(left, right) >= 0;
        public static bool operator ==(OtherCircle? left, OtherCircle? right) => Compare(left, right) == 0;
        public static bool operator !=(OtherCircle? left, OtherCircle? right) => Compare(left, right) != 0;

        public virtual int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is OtherCircle other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(OtherCircle)}");
        }

        public virtual bool Equals(OtherCircle? other) => CompareTo(other) == 0;

        public override bool Equals(object? obj)
        {
            return obj is OtherCircle other ? Equals(other) : throw new ArgumentException($"Object must be of type {nameof(OtherCircle)}");
        }

        private static int Compare(OtherCircle? left, OtherCircle? right)
        {
            if (ReferenceEquals(left, right)) return 0;
            if (left is null) return -1;
            return left.CompareTo(right);
        }
    }
}
