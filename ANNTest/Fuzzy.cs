using System;
using System.Globalization;

namespace ANNTest
{

    public class Fuzzy : IEquatable<Fuzzy>
    {
        public static double Delta { get; set; } = 1e-6;

        private readonly double _value;

        private Fuzzy(double value)
        {
            _value = value;
        }

        public bool Equals(Fuzzy other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value - other._value < Delta;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Fuzzy)) return false;
            return Equals((Fuzzy)obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }

        public static implicit operator Fuzzy(double d)
        {
            if (d < 0 || 1 < d) throw new ArgumentException();
            return new Fuzzy(d);
        }

        public static implicit operator Fuzzy(bool b)
        {
            return b ? new Fuzzy(1) : new Fuzzy(0);
        }

        public static implicit operator double(Fuzzy f)
        {
            return f._value;
        }

        public static explicit operator bool(Fuzzy f)
        {
            return !(f._value < 0.5);
        }

        public static bool operator true(Fuzzy f) => !(f._value < 0.5);

        public static bool operator false(Fuzzy f) => f._value < 0.5;

        public static Fuzzy operator !(Fuzzy f) => 1 - f._value;

        public static Fuzzy operator &(Fuzzy l, Fuzzy r)
            => (Math.Abs(l._value - r._value) < Delta && Math.Abs(r._value) < Delta) ? 0 : (l._value * r._value) / (l._value + r._value - l._value * r._value); // l._value * r._value;

        public static Fuzzy operator |(Fuzzy l, Fuzzy r) => !(!l & !r); // l._value + r._value - (l & r)._value;

        public static Fuzzy operator ^(Fuzzy l, Fuzzy r) => (l & !r) | (!l & r);

        public static Fuzzy operator %(Fuzzy l, Fuzzy r) => l & !r;

        public static Fuzzy operator !=(Fuzzy left, Fuzzy right) => left ^ right;

        public static Fuzzy operator ==(Fuzzy left, Fuzzy right) => !(left != right);

    }

}
