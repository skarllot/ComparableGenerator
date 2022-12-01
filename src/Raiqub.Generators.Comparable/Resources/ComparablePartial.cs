﻿// <auto-generated />
#nullable enable

using System;

#pragma warning disable CS1591 // publicly visible type or member must be documented

// +NamespaceBegin
namespace NAMESPACE
{
// -NamespaceBegin
    partial class CLASS
        : IComparable, IComparable<CLASS?>, IEquatable<CLASS?>
// +IsValue
        , IComparable<CLASS??>, IEquatable<CLASS??>
// -IsValue
    {
        public static bool operator <(CLASS? left, CLASS? right) => Compare(left, right) < 0;
        public static bool operator >(CLASS? left, CLASS? right) => Compare(left, right) > 0;
        public static bool operator <=(CLASS? left, CLASS? right) => Compare(left, right) <= 0;
        public static bool operator >=(CLASS? left, CLASS? right) => Compare(left, right) >= 0;
// +EqualityOperators
        public static bool operator ==(CLASS? left, CLASS? right) => Compare(left, right) == 0;
        public static bool operator !=(CLASS? left, CLASS? right) => Compare(left, right) != 0;
// -EqualityOperators
// +IsValue
        public static bool operator <(CLASS?? left, CLASS?? right) => Compare(left, right) < 0;
        public static bool operator >(CLASS?? left, CLASS?? right) => Compare(left, right) > 0;
        public static bool operator <=(CLASS?? left, CLASS?? right) => Compare(left, right) <= 0;
        public static bool operator >=(CLASS?? left, CLASS?? right) => Compare(left, right) >= 0;
        public static bool operator ==(CLASS?? left, CLASS?? right) => Compare(left, right) == 0;
        public static bool operator !=(CLASS?? left, CLASS?? right) => Compare(left, right) != 0;
// -IsValue

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is CLASS other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(CLASS)}");
        }
// +IsValue

        public int CompareTo(CLASS?? other)
        {
            if (!other.HasValue) return 1;
            return CompareTo(other.Value);
        }
// -IsValue

        public virtual bool Equals(CLASS? other) => CompareTo(other) == 0;
// +IsValue
        public virtual bool Equals(CLASS?? other) => CompareTo(other) == 0;
// -IsValue
// +ObjectEquals

        public override bool Equals(object? obj)
        {
            return obj is CLASS other ? Equals(other) : throw new ArgumentException($"Object must be of type {nameof(CLASS)}");
        }
// -ObjectEquals

        private static int Compare(CLASS? left, CLASS? right)
        {
// +IsByRef
            if (ReferenceEquals(left, right)) return 0;
            if (left is null) return -1;
// -IsByRef
            return left.CompareTo(right);
        }
// +IsValue

        private static int Compare(CLASS?? left, CLASS?? right)
        {
            if (!left.HasValue && !right.HasValue) return 0;
            if (left is null) return -1;
            return left.Value.CompareTo(right);
        }
// -IsValue
    }
// +NamespaceEnd
}
// -NamespaceEnd