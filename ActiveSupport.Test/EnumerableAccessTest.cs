namespace ActiveSupport.Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class EnumerableAccessTest
    {
        [Fact]
        public void Test_From_with_null()
        {
            string[] source = null;
            var ex = Assert.Throws<ArgumentNullException>(() => source.From(0));

            Assert.Equal(ex.ParamName, "source");
        }

        [Fact]
        public void Test_From_with_index_0()
        {
            var array = new string[] { "a", "b", "c", "d" }.From(0);

            Assert.Equal(4, array.Count());
            Assert.Single(array, "a");
            Assert.Single(array, "b");
            Assert.Single(array, "c");
            Assert.Single(array, "d");
        }

        [Fact]
        public void Test_From_in_range_index()
        {
            var array = new string[] { "a", "b", "c", "d" }.From(2);

            Assert.Equal(2, array.Count());
            Assert.DoesNotContain("a", array);
            Assert.DoesNotContain("b", array);
            Assert.Single(array, "c");
            Assert.Single(array, "d");
        }

        [Fact]
        public void Test_From_out_range_index()
        {
            var array = new string[] { "a", "b", "c", "d" }.From(4);
            Assert.Empty(array);
        }

        [Fact]
        public void Test_To_with_null()
        {
            string[] source = null;
            var ex = Assert.Throws<ArgumentNullException>(() => source.To(1));

            Assert.Equal(ex.ParamName, "source");
        }

        [Fact]
        public void Test_To_out_range_index()
        {
            var array = new string[] { "a", "b", "c", "d" }.To(10);

            Assert.Equal(4, array.Count());
            Assert.Single(array, "a");
            Assert.Single(array, "b");
            Assert.Single(array, "c");
            Assert.Single(array, "d");
        }

        [Fact]
        public void Test_To_in_range_index()
        {
            var array = new string[] { "a", "b", "c", "d" }.To(1);

            Assert.Equal(2, array.Count());
            Assert.Single(array, "a");
            Assert.Single(array, "b");
            Assert.DoesNotContain("c", array);
            Assert.DoesNotContain("d", array);
        }

        [Fact]
        public void Test_To_with_zero_index()
        {
            var array = new string[] { "a", "b", "c", "d" }.To(0);
            Assert.Equal(1, array.Count());
            Assert.Single(array, "a");
        }

        [Fact]
        public void Test_IsEmpty_with_null_collection()
        {
            int[] nullArray = null;
            Assert.Throws<ArgumentNullException>(() =>nullArray.IsEmpty());
        }

        [Fact]
        public void Test_IsEmpty_with_empty_collection()
        {
            var emptyCol = Enumerable.Empty<int>();

            Assert.Equal(true, emptyCol.IsEmpty());
        }

        [Fact]
        public void Test_IsEmpty_with_non_empty_collection()
        {
            var col = new int[] { 1 };

            Assert.Equal(false, col.IsEmpty());
        }


        [Fact]
        public void Test_IsBlank_with_null()
        {
            int[] ints = null;

            Assert.Equal(true, ints.IsBlank());
        }

        [Fact]
        public void Test_IsBlank_with_no_elements()
        {
            IEnumerable ints = new int[0];

            Assert.Equal(true, ints.IsBlank());
        }

        [Fact]
        public void Test_IsBlank_with_elements()
        {
            IEnumerable ints = new int[1] { 1 };

            Assert.Equal(false, ints.IsBlank());
        }

        [Fact]
        public void Test_IsPresent_with_null()
        {
            IEnumerable ints = null;

            Assert.Equal(false, ints.IsPresent());
        }

        [Fact]
        public void Test_IsPresent_with_no_elements()
        {
            IEnumerable ints = new int[0];

            Assert.Equal(false, ints.IsPresent());
        }

        [Fact]
        public void Test_IsPresent_with_elements()
        {
            IEnumerable ints = new int[1] { 1 };

            Assert.Equal(true, ints.IsPresent());
        }

        [Fact]
        public void Test_IndexOf_T_with_existed_element()
        {
            IEnumerable<int> ints = new List<int>() { 1, 2, 3, 4 };

            Assert.Equal(1, ints.IndexOf(x => x == 2));
        }

        [Fact]
        public void Test_IndexOf_T_with_not_existed_element()
        {
            IEnumerable<int> ints = new List<int>() { 1, 2, 3, 4 };

            Assert.Equal(-1, ints.IndexOf(x => x == 5));
        }

        [Fact]
        public void Test_IndexOf_T_with_null()
        {
            IEnumerable<int> ints = null;

            Assert.Equal(-1, ints.IndexOf(x => x == 5));
        }

        [Fact]
        public void Test_IndexOf_with_existed_element()
        {
            IEnumerable ints = new List<int>() { 1, 2, 3, 4 };

            Assert.Equal(1, ints.IndexOf(x => (int)x == 2));
        }

        [Fact]
        public void Test_IndexOf_with_not_existed_element()
        {
            IEnumerable ints = new List<int>() { 1, 2, 3, 4 };

            Assert.Equal(-1, ints.IndexOf(x => (int)x == 5));
        }

        [Fact]
        public void Test_IndexOf_with_null()
        {
            IEnumerable ints = null;

            Assert.Equal(-1, ints.IndexOf(x => (int)x == 5));
        }

    }
}
