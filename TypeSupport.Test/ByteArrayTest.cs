namespace TypeSupport.Test
{

    using System;
    using Xunit;
    using TypeSupport;

    public class AssignByteArrayTest
    {
        // ---------- TEST FOR INT16 ----------

        [Fact]
        public void Test_AssignInt16()
        {
            byte[] bytes = new byte[4];

            bytes.AssignInt16(0x1011, 0);

            Assert.Equal(bytes[0], 0x11);
            Assert.Equal(bytes[1], 0x10);
            Assert.Equal(bytes[2], 0);
            Assert.Equal(bytes[3], 0);
        }

        [Fact]
        public void Test_AssignUInt16()
        {
            byte[] bytes = new byte[4];

            bytes.AssignInt16((ushort)0x1011, 0);

            Assert.Equal(bytes[0], 0x11);
            Assert.Equal(bytes[1], 0x10);
            Assert.Equal(bytes[2], 0);
            Assert.Equal(bytes[3], 0);
        }

        [Fact]
        public void Test_AssignInt16_offset()
        {
            byte[] bytes = new byte[4];

            bytes.AssignInt16(0x1011, 2);

            Assert.Equal(bytes[0], 0);
            Assert.Equal(bytes[1], 0);
            Assert.Equal(bytes[2], 0x11);
            Assert.Equal(bytes[3], 0x10);
        }

        [Fact]
        public void Test_AssignInt16_offset_overflow()
        {
            byte[] bytes = new byte[4];

            Assert.Throws<ArgumentException>(() => bytes.AssignInt16(0x1011, 3));
            Assert.Throws<ArgumentException>(() => bytes.AssignInt16(0x1011, 3));

            //TODO
            //Assert.Throws<ArgumentException>(() => bytes.AssignInt16(0x5555, -1));
        }

        // ---------- TEST FOR INT32 ----------

        [Fact]
        public void Test_AssignInt32()
        {
            byte[] bytes = new byte[4];

            bytes.AssignInt32(0x1011_1213, 0);

            Assert.Equal(bytes[0], 0x13);
            Assert.Equal(bytes[1], 0x12);
            Assert.Equal(bytes[2], 0x11);
            Assert.Equal(bytes[3], 0x10);
        }

        [Fact]
        public void Test_AssignUInt32()
        {
            byte[] bytes = new byte[4];

            bytes.AssignInt32((uint)0x1011_1213, 0);

            Assert.Equal(bytes[0], 0x13);
            Assert.Equal(bytes[1], 0x12);
            Assert.Equal(bytes[2], 0x11);
            Assert.Equal(bytes[3], 0x10);
        }

        [Fact]
        public void Test_AssignInt32_offset()
        {
            byte[] bytes = new byte[8];

            bytes.AssignInt32(0x1011_1213, 2);

            Assert.Equal(bytes[0], 0);
            Assert.Equal(bytes[1], 0);
            Assert.Equal(bytes[2], 0x13);
            Assert.Equal(bytes[3], 0x12);
            Assert.Equal(bytes[4], 0x11);
            Assert.Equal(bytes[5], 0x10);
            Assert.Equal(bytes[6], 0);
            Assert.Equal(bytes[7], 0);
        }

        [Fact]
        public void Test_AssignInt32_offset_overflow()
        {
            byte[] bytes = new byte[8];

            Assert.Throws<ArgumentException>(() => bytes.AssignInt32(0x1011_1213, 5));
            Assert.Throws<ArgumentException>(() => bytes.AssignInt32(0x1011_1213, 6));

            //TODO
            //Assert.Throws<ArgumentException>(() => bytes.AssignInt16(0x5555, -1));
        }

        // ---------- TEST FOR INT64 ----------

        [Fact]
        public void Test_AssignInt64()
        {
            byte[] bytes = new byte[10];

            bytes.AssignInt64(0x1011_1213_1415_1617, 0);

            Assert.Equal(bytes[0], 0x17);
            Assert.Equal(bytes[1], 0x16);
            Assert.Equal(bytes[2], 0x15);
            Assert.Equal(bytes[3], 0x14);
            Assert.Equal(bytes[4], 0x13);
            Assert.Equal(bytes[5], 0x12);
            Assert.Equal(bytes[6], 0x11);
            Assert.Equal(bytes[7], 0x10);
            Assert.Equal(bytes[8], 0);
            Assert.Equal(bytes[9], 0);

        }

        [Fact]
        public void Test_AssignUInt64()
        {
            byte[] bytes = new byte[10];

            bytes.AssignInt64((ulong)0x1011_1213_1415_1617, 0);

            Assert.Equal(bytes[0], 0x17);
            Assert.Equal(bytes[1], 0x16);
            Assert.Equal(bytes[2], 0x15);
            Assert.Equal(bytes[3], 0x14);
            Assert.Equal(bytes[4], 0x13);
            Assert.Equal(bytes[5], 0x12);
            Assert.Equal(bytes[6], 0x11);
            Assert.Equal(bytes[7], 0x10);
            Assert.Equal(bytes[8], 0);
            Assert.Equal(bytes[9], 0);
        }

        [Fact]
        public void Test_AssignInt64_offset()
        {
            byte[] bytes = new byte[18];

            bytes.AssignInt64(0x1011_1213_1415_1617, 2);

            Assert.Equal(bytes[0], 0);
            Assert.Equal(bytes[1], 0);
            Assert.Equal(bytes[2], 0x17);
            Assert.Equal(bytes[3], 0x16);
            Assert.Equal(bytes[4], 0x15);
            Assert.Equal(bytes[5], 0x14);
            Assert.Equal(bytes[6], 0x13);
            Assert.Equal(bytes[7], 0x12);
            Assert.Equal(bytes[8], 0x11);
            Assert.Equal(bytes[9], 0x10);
            Assert.Equal(bytes[10], 0);
            Assert.Equal(bytes[11], 0);
        }

        [Fact]
        public void Test_AssignInt64_offset_overflow()
        {
            byte[] bytes = new byte[20];

            byte[] oneElementByteArray = new byte[1];

            Assert.Throws<ArgumentException>(() => bytes.AssignInt64(0x1011_1213_1415_1617, 16));
            Assert.Throws<ArgumentException>(() => bytes.AssignInt64(0x1011_1213_1415_1617, 17));

            Assert.Throws<ArgumentException>(() => oneElementByteArray.AssignInt64(0x55555555_55555555, 0));

            //TODO
            //Assert.Throws<ArgumentException>(() => bytes.AssignInt16(0x5555, -1));
        }


    }


    public class GetIntFromByteArray
    {
        private byte[] m_Bytes = new byte[] { 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0, 0, 0, 0, 0, 0 };

        [Fact]
        public void Test_GetInt16()
        {
            Assert.Equal(0x1110, m_Bytes.GetInt16(0));
        }

        [Fact]
        public void Test_GetInt16_with_offset()
        {
            Assert.Equal(0x1211, m_Bytes.GetInt16(1));
        }

        [Fact]
        public void Test_GetInt16_offset_overflow()
        {
            Assert.Throws<ArgumentException>(() => m_Bytes.GetInt16(m_Bytes.Length - 1));
        }



        [Fact]
        public void Test_GetInt32()
        {
            Assert.Equal(0x1312_1110, m_Bytes.GetInt32(0));
        }

        [Fact]
        public void Test_GetInt32_with_offset()
        {
            Assert.Equal(0x1413_1211, m_Bytes.GetInt32(1));
        }

        [Fact]
        public void Test_GetInt32_offset_overflow()
        {
            Assert.Throws<ArgumentException>(() => m_Bytes.GetInt32(m_Bytes.Length - 3));
        }



        [Fact]
        public void Test_GetInt64()
        {
            Assert.Equal(0x1716_1514_1312_1110, m_Bytes.GetInt64(0));
        }

        [Fact]
        public void Test_GetInt64_with_offset()
        {
            Assert.Equal(0x1817_1615_1413_1211, m_Bytes.GetInt64(1));
        }

        [Fact]
        public void Test_GetInt64_offset_overflow()
        {
            Assert.Throws<ArgumentException>(() => m_Bytes.GetInt64(m_Bytes.Length - 4));
        }



    }
}
