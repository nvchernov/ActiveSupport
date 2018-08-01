namespace TypeSupport.Test
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Xunit;

    public class StringToNumberConversionTest
    {

        #region IsNumber tests

        private readonly string point = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        private readonly string currency = NumberFormatInfo.CurrentInfo.CurrencySymbol;

        [Fact]
        public void Test_IsNumber_with_null()
        {
            string nullString = null;

            Assert.Equal(false, nullString.IsNumber());
        }

        [Fact]
        public void Test_IsNumber_for_valid_strings()
        {

            var validValues = new string[]
            {
                int.MaxValue.ToString(),
                int.MinValue.ToString(),

                uint.MaxValue.ToString(),
                uint.MinValue.ToString(),

                ulong.MaxValue.ToString(),
                ulong.MinValue.ToString(),

                decimal.MaxValue.ToString(),
                decimal.MinValue.ToString(),

                float.MaxValue.ToString(),
                float.MinValue.ToString(),

                double.MaxValue.ToString("r"),
                double.MinValue.ToString("r"),

                $"1{point}1e1",
                $"1{point}1e1",
                $"1{point}1e-1",
                $"1{point}1e+1",

                $"+1{point}1e1",
                $"+1{point}1e1",
                $"+1{point}1e-1",
                $"+1{point}1e+1",

                $"-1{point}1e1",
                $"-1{point}1e1",
                $"-1{point}1e-1",
                $"-1{point}1e+1",
            };

            foreach (var value in validValues)
                Assert.True(value.IsNumber(), string.Format($"'{value}' should be valid number but it is not"));

        }

        [Fact]
        public void Test_IsNumber_for_invalid_strings()
        {
            var invalidValues = new string[] {
                null as string,
                string.Empty,
                " ",

                "1234sfds",
                " 234",
                $"1234{point}3243{point}",
                $"{currency}1234",
                $"12{point}34{point}0",
                "-+2134",
                "++23{point}343",
                $"1{point}000{point}a",

                $"1{point}797693134862329E+308"
            };

            foreach (var value in invalidValues)
                Assert.False(value.IsNumber(), $"'{value}' should NOT be valid number but it is");

        }

        [Fact]
        public void Test_IsNumber_with_NumberStyles_for_valid_strings()
        {
            var validValues = new string[] {
                "1234",
                "+2134",
                "-23343"
            };

            foreach (var value in validValues)
                Assert.True(value.IsNumber(NumberStyles.Integer), $"'{value}' should be valid number but now it is not.");

        }

        [Fact]
        public void Test_IsNumber_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new string[] {
                $"0xabc",
                $"1000a ",
                $"  1234{point}",
                $"1234{point}32   ",
                $"1234   {point}"
            };

            foreach (var value in invalidValues)
                Assert.False(value.IsNumber(NumberStyles.Integer), $"'{value}' should NOT be valid number but now it is.");
        }

        #endregion


        #region ToInt32

        [Fact]
        public void Test_ToInt32_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToInt32());
        }

        [Fact]
        public void Test_ToInt32_for_valid_strings()
        {
            var validValues = new Dictionary<string, int>() {
                { "1234", 1234 },
                { "+67867678", 67867678 },
                { int.MaxValue.ToString(), int.MaxValue },
                { int.MinValue.ToString(), int.MinValue },
                { "+0", 0 },
                { "-0", 0 },
                { $"-1234", -1234 },
            };

            foreach (var kv in validValues)
                Assert.Equal(kv.Key.ToInt32(), kv.Value);
        }

        [Fact]
        public void Test_ToInt32_for_invalid_strings()
        {
            var invalidValues = new string[] {
                $"a1{point}000a",
                $" - 1234",
                $"  {currency}1234  "
            };

            foreach (var value in invalidValues)
            {
                Assert.Throws<FormatException>(() =>
                {
                    value.ToInt32();
                });
            }
        }

        [Fact]
        public void Test_ToInt32_with_NumberStyles_for_null_string()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => nullString.ToInt32(NumberStyles.Integer));
        }

        [Fact]
        public void Test_ToInt32_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, int>[]{
                new Tuple<string, NumberStyles, int>($"123{point}0", NumberStyles.AllowDecimalPoint, 123),
                new Tuple<string, NumberStyles, int>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123),
                new Tuple<string, NumberStyles, int>($"{currency}123{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 123),
            };

            foreach (var kv in validValues)
                Assert.True(kv.Item1.ToInt32(kv.Item2) == kv.Item3, $"expected value '{kv.Item1}' is not equal to '{kv.Item3}'");

        }

        #endregion

        #region AsInt32 method

        [Fact]
        public void Test_AsInt32_for_valid_strings()
        {
            var validValues = new Dictionary<string, int>() {
                { "1234", 1234 },
                { "-1234", -1234 },
                { "+1234", 1234},
                { $"-1{point}234e3", -1234}
            };

            foreach (var kv in validValues)
                Assert.True(kv.Value == kv.Key.ToInt32(), $"expected value '{kv.Value}' is not equal to '{kv.Key}'");

        }

        [Fact]
        public void Test_AsInt32_for_invalid_strings()
        {
            var invalidValues = new string[] {
                null,
                $"1{point}{point}000",
                $"  1234{point}a",
                $"{currency}1234{point}32",
                $"   {currency}1234  "
            };

            foreach (var value in invalidValues)
                Assert.True(value.AsInt32() == null, $"expected value '{value}' is not equal to 'null'");

        }

        [Fact]
        public void Test_AsInt32_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, int>[]{
                new Tuple<string, NumberStyles, int>($"123{point}0", NumberStyles.AllowDecimalPoint, 123),
                new Tuple<string, NumberStyles, int>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123),
                new Tuple<string, NumberStyles, int>($"{currency}123{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 123),
            };

            foreach (var kv in validValues)
                Assert.True(kv.Item1.AsInt32(kv.Item2) == kv.Item3, $"expected value '{kv.Item1}' is not equal to '{kv.Item3}'");

        }

        [Fact]
        public void Test_AsInt32_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123{point}0", NumberStyles.AllowDecimalPoint },
                { $"123{point}0", NumberStyles.AllowCurrencySymbol },
                { $"+123{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            string nullString = null;
            Assert.Null(nullString.AsInt32(NumberStyles.AllowDecimalPoint));

            foreach (var kv in invalidValues)
                Assert.True(kv.Key.AsInt32(kv.Value) == null, $"expected value '{kv.Key}' is not equal to 'null'");

        }

        #endregion

        [Fact]
        public void Test_ToInt64_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToInt64());
        }

        [Fact]
        public void Test_ToInt64_for_valid_strings()
        {
            var validValues = new Dictionary<string, long>() {
                { "1234", 1234 },
                { "+1234", 1234 },
                { "-1234", -1234 },
                { "9223372036854", 9223372036854 },
                { $"2{point}2e4", 22000 }
            };

            foreach (var kv in validValues)
            {
                Assert.Equal(kv.Value, kv.Key.ToInt64());
            }
        }

        [Fact]
        public void Test_ToInt64_for_invalid_strings()
        {
            var invalidValues = new string[] {
                $"  1234{point}",
                $" 1234{point}32   ",
                $"{currency}1234"
            };

            Assert.Throws<OverflowException>(() => $"1{point}001".ToInt32());

            foreach (var value in invalidValues)
                Assert.Throws<FormatException>(() => { value.ToInt64(); });
        }

        [Fact]
        public void Test_ToInt64_with_NumberStyles_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToInt64(NumberStyles.AllowDecimalPoint));
        }

        [Fact]
        public void Test_ToInt64_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, long>[]{
                new Tuple<string, NumberStyles, long>($"123{point}0", NumberStyles.AllowDecimalPoint, 123),
                new Tuple<string, NumberStyles, long>($"{currency}9223372036854", NumberStyles.AllowCurrencySymbol, 9223372036854),
                new Tuple<string, NumberStyles, long>($"{currency}123{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 123),
            };

            foreach (var value in validValues)
            {
                Assert.Equal(value.Item3, value.Item1.ToInt64(value.Item2));
            }
        }

        [Fact]
        public void Test_ToInt64_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123{point}0", NumberStyles.AllowDecimalPoint },
                { $"123{point}0", NumberStyles.AllowCurrencySymbol },
                { $"+9223372036854{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues)
            {
                Assert.Throws<FormatException>(() =>
                {
                    kv.Key.ToInt64(kv.Value);
                });
            }
        }

        [Fact]
        public void Test_AsInt64_for_valid_strings()
        {
            var validValues = new Dictionary<string, long>() {
                { $"1234", 1234 },
                { $"+1234", 1234 },
                { $"-9223372036854", -9223372036854 },
                { $"+1{point}4234e4", 14234 }
            };

            foreach (var kv in validValues)
            {
                Assert.Equal(kv.Value, kv.Key.AsInt64());
            }
        }

        [Fact]
        public void Test_AsInt64_for_invalid_strings()
        {
            var invalidValues = new string[] {
                null,
                $"1{point}{point}000",
                $"  1234{point}",
                $" 1234{point}32   ",
                $"   {currency}9223372036854  "
            };

            foreach (var value in invalidValues)
            {
                Assert.Null(value.AsInt64());
            }
        }

        [Fact]
        public void Test_AsInt64_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, long>[]{
                new Tuple<string, NumberStyles, long>($"123{point}0", NumberStyles.AllowDecimalPoint, 123),
                new Tuple<string, NumberStyles, long>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123),
                new Tuple<string, NumberStyles, long>($"{currency}9223372036854{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 9223372036854),
            };

            foreach (var value in validValues)
            {
                Assert.Equal(value.Item3, value.Item1.AsInt64(value.Item2));
            }
        }

        [Fact]
        public void Test_AsInt64_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123{point}0", NumberStyles.AllowDecimalPoint },
                { $"123{point}0", NumberStyles.AllowCurrencySymbol },
                { $"+9223372036854{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            string nullString = null;
            Assert.Null(nullString.AsInt64(NumberStyles.AllowDecimalPoint));

            foreach (var kv in invalidValues)
            {
                Assert.Null(kv.Key.AsInt64(kv.Value));
            }
        }

        [Fact]
        public void Test_ToDouble_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToDouble());

            Assert.Equal(ex.ParamName, "source");
        }

        [Fact]
        public void Test_ToDouble_for_valid_strings()
        {
            var validValues = new Dictionary<string, double>() {
                { $"1234{point}25", 1234.25 },
                { $"+1234{point}25", 1234.25 },
                { $"-1234{point}25", -1234.25 },
                { $"1{point}3333e2", 133.33},
            };

            foreach (var kv in validValues)
                Assert.Equal(kv.Value, kv.Key.ToDouble());

        }

        [Fact]
        public void Test_ToDouble_for_invalid_strings()
        {
            var invalidValues = new string[] {
                $"1{point}{point}000",
                $"  1234{point}{point}",
                $"1234{point}32{point}00   ",
                $"   {currency}1234  "
            };

            foreach (var value in invalidValues)
            {
                Assert.Throws<FormatException>(() =>
                {
                    value.ToDouble();
                });
            }
        }

        [Fact]
        public void Test_ToDouble_with_NumberStyles_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToDouble(NumberStyles.AllowDecimalPoint));

            Assert.Equal(ex.ParamName, "source");
        }

        [Fact]
        public void Test_ToDouble_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, double>[]{
                new Tuple<string, NumberStyles, double>($"123{point}25", NumberStyles.AllowDecimalPoint, 123.25),
                new Tuple<string, NumberStyles, double>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123),
                new Tuple<string, NumberStyles, double>($"{currency}123{point}25", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 123.25),
            };

            foreach (var value in validValues)
            {
                Assert.Equal(value.Item3, value.Item1.ToDouble(value.Item2));
            }
        }

        [Fact]
        public void Test_ToDouble_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123", NumberStyles.AllowDecimalPoint },
                { $"123{point}25", NumberStyles.AllowCurrencySymbol },
                { $"+123{point}25", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues)
            {
                Assert.Throws<FormatException>(() =>
                {
                    kv.Key.ToDouble(kv.Value);
                });
            }
        }

        [Fact]
        public void Test_AsDouble_for_valid_strings()
        {
            var validValues = new Dictionary<string, double>() {
                { $"1234{point}25", 1234.25 },
                { $"-9999{point}25", -9999.25 },
                { $"876{point}25", 876.25 },
                { $"263{point}25", 263.25 },
                { $"+1236{point}25", 1236.25},
            };

            foreach (var kv in validValues)
            {
                Assert.Equal(kv.Value, kv.Key.AsDouble());
            }
        }

        [Fact]
        public void Test_AsDouble_for_invalid_strings()
        {
            var invalidValues = new string[] {
                null,
                $"1{point}{point}000",
                $"  1234{point}{point}",
                $"1234{point}32{point}00   ",
                $"   {currency}1234  "
            };

            foreach (var value in invalidValues)
            {
                Assert.Null(value.AsDouble());
            }
        }

        [Fact]
        public void Test_AsDouble_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, double>[]{
                new Tuple<string, NumberStyles, double>($"123{point}0", NumberStyles.AllowDecimalPoint, 123),
                new Tuple<string, NumberStyles, double>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123),
                new Tuple<string, NumberStyles, double>($"{currency}9223372036854{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 9223372036854),
            };

            foreach (var value in validValues)
            {
                Assert.Equal(value.Item3, value.Item1.AsDouble(value.Item2));
            }
        }

        [Fact]
        public void Test_AsDouble_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123", NumberStyles.AllowDecimalPoint },
                { $"123{point}25", NumberStyles.AllowCurrencySymbol },
                { $"+123{point}25", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            string nullString = null;
            Assert.Null(nullString.AsDouble(NumberStyles.AllowDecimalPoint));

            foreach (var kv in invalidValues)
            {
                Assert.Null(kv.Key.AsDouble(kv.Value));
            }
        }

        [Fact]
        public void Test_ToDecimal_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToDecimal());

            Assert.Equal(ex.ParamName, "source");
        }

        [Fact]
        public void Test_ToDecimal_for_valid_strings()
        {
            var validValues = new Dictionary<string, decimal>() {
                { $"1234{point}25", 1234.25m },
                { $"-1234{point}25", -1234.25m },
                { $"+1234{point}25", 1234.25m},
                { $"+1{point}123425e3", 1123.425m},
                { $"-1{point}123425e3", -1123.425m},
            };

            foreach (var kv in validValues)
            {
                Assert.Equal(kv.Value, kv.Key.ToDecimal());
            }
        }

        [Fact]
        public void Test_ToDecimal_for_invalid_strings()
        {
            var invalidValues = new string[] {
                $"1{point}{point}000",
                $"  1234{point}{point}",
                $"1234{point}32{point}00   ",
                $"   {currency}1234  "
            };

            foreach (var value in invalidValues)
            {
                Assert.Throws<FormatException>(() =>
                {
                    value.ToDecimal();
                });
            }
        }

        [Fact]
        public void Test_ToDecimal_with_NumberStyles_for_null_string()
        {
            string nullString = null;
            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToDecimal(NumberStyles.AllowDecimalPoint));

            Assert.Equal(ex.ParamName, "source");
        }

        [Fact]
        public void Test_ToDecimal_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, decimal>[]{
                new Tuple<string, NumberStyles, decimal>($"123{point}25", NumberStyles.AllowDecimalPoint, 123.25m),
                new Tuple<string, NumberStyles, decimal>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123m),
                new Tuple<string, NumberStyles, decimal>($"{currency}123{point}25", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 123.25m),
            };

            foreach (var value in validValues)
            {
                Assert.Equal(value.Item3, value.Item1.ToDecimal(value.Item2));
            }
        }

        [Fact]
        public void Test_ToDecimal_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123", NumberStyles.AllowDecimalPoint },
                { $"123{point}25", NumberStyles.AllowCurrencySymbol },
                { $"+123{point}25", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            foreach (var kv in invalidValues)
            {
                Assert.Throws<FormatException>(() =>
                {
                    kv.Key.ToDecimal(kv.Value);
                });
            }
        }

        [Fact]
        public void Test_AsDecimal_for_valid_strings()
        {
            var validValues = new Dictionary<string, decimal>() {
                { $"1234{point}25", 1234.25m },
                { $"+1234{point}25", 1234.25m },
                { $"-1234{point}25", -1234.25m },
                { $"1{point}2e5", 120000m }
            };

            foreach (var kv in validValues)
                Assert.Equal(kv.Value, kv.Key.AsDecimal());
        }

        [Fact]
        public void Test_AsDecimal_for_invalid_strings()
        {
            var invalidValues = new string[] {
                null,
                $"1{point}{point}000",
                $"  1234{point}{point}",
                $"1234{point}32{point}00   ",
                $"   {currency}1234  "
            };

            foreach (var value in invalidValues)
            {
                Assert.Null(value.AsDecimal());
            }
        }

        [Fact]
        public void Test_AsDecimal_with_NumberStyles_for_valid_strings()
        {
            var validValues = new Tuple<string, NumberStyles, decimal>[]{
                new Tuple<string, NumberStyles, decimal>($"123{point}0", NumberStyles.AllowDecimalPoint, 123),
                new Tuple<string, NumberStyles, decimal>($"{currency}123", NumberStyles.AllowCurrencySymbol, 123),
                new Tuple<string, NumberStyles, decimal>($"{currency}9223372036854{point}0", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, 9223372036854),
            };

            foreach (var value in validValues)
            {
                Assert.Equal(value.Item3, value.Item1.AsDecimal(value.Item2));
            }
        }

        [Fact]
        public void Test_AsDecimal_with_NumberStyles_for_invalid_strings()
        {
            var invalidValues = new Dictionary<string, NumberStyles> {
                { $"{currency}123", NumberStyles.AllowDecimalPoint },
                { $"123{point}25", NumberStyles.AllowCurrencySymbol },
                { $"+123{point}25", NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol }
            };

            string nullString = null;
            Assert.Null(nullString.AsDecimal(NumberStyles.AllowDecimalPoint));

            foreach (var kv in invalidValues)
            {
                Assert.Null(kv.Key.AsDecimal(kv.Value));
            }
        }

    }
}
