using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Math : IEnumerable<object[]>
    {
        public bool IsEven(int number) => number % 2 == 0;
        public int IsDiff(int x, int y) => x - y;
        public int Add(int x, int y) => x + y;
        public int Sum(params int[] values)
        {
            int sum = 0;
            foreach (var item in values)
            {
                sum +=item;
            }
            return sum;
        }
        public int Avergae(params int[] values)
        {
            int sum = 0;
            foreach (var item in values)
            {
                sum += item;
            }
            return sum / values.Length;
        }
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {5,0,7},
            new object[] {14,20,80},
            new object[] {1,0,0},
            new object[] {int.MaxValue,-1,int.MinValue}
        };
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 5, 0, 7 };
            yield return new object[] { 14, 20, 80 };
            yield return new object[] { 1, 0, 0 };
            yield return new object[] { int.MaxValue, -1, int.MinValue };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
