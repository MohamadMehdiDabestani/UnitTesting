using System;
using Xunit;
using Test;
namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void IsEvenTest()
        {
            var math = new Test.Math();

            int x = 5;
            int y = 8;

            var xRes = math.IsEven(x);
            var yRes = math.IsEven(y);

            Assert.False(xRes);
            Assert.True(yRes);
        }
        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(2, 3, -1)]
        public void DiffTest(int x, int y, int expected)
        {
            var math = new Test.Math();

            var res = math.IsDiff(x, y);

            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData(new int[3] {5,14,7} , 26)]
        [InlineData(new int[3] {15,14,7} , 36)]
        public void SumTest(int[] values, int expected)
        {
            var math = new Test.Math();

            var res = math.Sum(values);

            Assert.Equal(expected, res);
        }

    }
}
