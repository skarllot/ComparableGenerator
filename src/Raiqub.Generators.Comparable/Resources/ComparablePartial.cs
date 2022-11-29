﻿#nullable enable

using System;

namespace NAMESPACE
{
    partial class CLASS : IComparable, IComparable<CLASS>, IEquatable<CLASS>
    {
        public static bool operator <(CLASS? left, CLASS? right) => Compare(left, right) < 0;
        public static bool operator >(CLASS? left, CLASS? right) => Compare(left, right) > 0;
        public static bool operator <=(CLASS? left, CLASS? right) => Compare(left, right) <= 0;
        public static bool operator >=(CLASS? left, CLASS? right) => Compare(left, right) >= 0;
        public static bool operator ==(CLASS? left, CLASS? right) => Compare(left, right) == 0;
        public static bool operator !=(CLASS? left, CLASS? right) => Compare(left, right) != 0;

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is CLASS other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(CLASS)}");
        }

        public virtual bool Equals(CLASS? other) => CompareTo(other) == 0;

        public override bool Equals(object? obj)
        {
            return obj is CLASS other ? Equals(other) : throw new ArgumentException($"Object must be of type {nameof(CLASS)}");
        }

        private static int Compare(CLASS? left, CLASS? right)
        {
            if (ReferenceEquals(left, right)) return 0;
            if (left is null) return -1;
            return left.CompareTo(right);
        }
    }
}