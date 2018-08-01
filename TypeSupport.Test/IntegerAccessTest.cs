namespace TypeSupport.Test
{
    using System;
    using Xunit;

    public class IntegerAccessTest
    {
        [Fact]
        public void Test_Integer_Times_with_null()
        {

            try
            {
                5.Times((Action)null);
                5.Times((Action<int>)null);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }

            Assert.True(true);
        }

        [Fact]
        public void Test_Integer_Times_without_index()
        {
            var count = 0;
            5.Times(() => count++);
            Assert.Equal(5, count);
        }

        [Fact]
        public void Test_Integer_Times_with_index()
        {
            var index = 0;
            5.Times((i) =>
            {
                Assert.Equal(index, i);
                index++;
            });
        }

        [Fact]
        public void Test_FuzzyEqual_inside_range()
        {
            Assert.True(3.FuzzyEqual(2, 1));
        }

        [Fact]
        public void Test_FuzzyEqual_outside_range()
        {
            Assert.False(4.FuzzyEqual(2, 1));
        }
    }
}
