using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ANNTest
{
    [TestClass]
    public class FuzzyTest
    {
        [TestMethod]
        public void TestBoolean()
        {
            Fuzzy a = 0.9;
            Debug.WriteLine($"{nameof(a)}:{a}");
            Fuzzy b = 0.1;
            Debug.WriteLine($"{nameof(b)}:{b}");
            var and = a & b;
            Debug.WriteLine($"{nameof(and)}:{and}");
            var or = a | b;
            Debug.WriteLine($"{nameof(or)}:{or}");
            var not = !a;
            Debug.WriteLine($"{nameof(not)}:{not}");
            var xor = a ^ b;
            Debug.WriteLine($"{nameof(xor)}:{xor}");
            var diff = a % b;
            Debug.WriteLine($"{nameof(diff)}:{diff}");

            Debug.WriteLine($"a | !a:{a | !a}");
            Debug.WriteLine($"a & !a:{a & !a}");
            Debug.WriteLine($"a ^ !a:{a ^ !a}");
            Debug.WriteLine($"a % !a:{a % !a}");
            Debug.WriteLine($"a == !a:{a == !a}");
            Debug.WriteLine($"a != !a:{a != !a}");
        }
    }
}
