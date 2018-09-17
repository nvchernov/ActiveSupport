using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TypeSupport
{
    public static class ByteArray
    {
        private const string BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE = "Byte array has not enough elements to assign Int32";

        private const string BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE = "Byte array cannot be null";

        /// <summary>
        /// Assign <see cref="Int16"/> to array by specified offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="value">Value to assign</param>
        /// <param name="offset">Byte array offset</param>
        public static void AssignInt16(this byte[] source, short value, int offset)
        {
            if (source == null)
                throw new ArgumentNullException(BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE);

            if (source.Length - offset < 2)
                throw new ArgumentException(BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE);

            var union = new Type2ByteUnion();

            union.Value = value;

            source[offset] = union.b0;
            source[offset + 1] = union.b1;
        }

        /// <summary>
        /// Assign <see cref="UInt16"/> to array by specified offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="value">Value to assign</param>
        /// <param name="offset">Byte array offset</param>
        public static void AssignInt16(this byte[] source, ushort value, int offset) =>
             source.AssignInt16(unchecked((short)value), offset);

        /// <summary>
        /// Assign <see cref="Int32"/> to array by specified offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="value">Value to assign</param>
        /// <param name="offset">Byte array offset</param>
        public static void AssignInt32(this byte[] source, int value, int offset)
        {
            if (source == null)
                throw new ArgumentNullException(BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE);

            if (source.Length - offset < 4)
                throw new ArgumentException(BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE);

            var union = new Type4ByteUnion();

            union.Value = value;

            source[offset] = union.b0;
            source[offset + 1] = union.b1;
            source[offset + 2] = union.b2;
            source[offset + 3] = union.b3;
        }

        /// <summary>
        /// Assign <see cref="UInt32"/> to array by specified offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="value">Value to assign</param>
        /// <param name="offset">Byte array offset</param>
        public static void AssignInt32(this byte[] source, uint value, int offset) =>
            source.AssignInt32(unchecked((int)value), offset);

        /// <summary>
        /// Assign <see cref="UInt64"/> to array by specified offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="value">Value to assign</param>
        /// <param name="offset">Byte array offset</param>
        public static void AssignInt64(this byte[] source, long value, int offset)
        {
            if (source == null)
                throw new ArgumentNullException(BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE);

            if (source.Length - offset < 8)
                throw new ArgumentException(BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE);

            var union = new Type8ByteUnion();

            union.Value = value;

            source[offset] = union.b0;
            source[offset + 1] = union.b1;
            source[offset + 2] = union.b2;
            source[offset + 3] = union.b3;
            source[offset + 4] = union.b4;
            source[offset + 5] = union.b5;
            source[offset + 6] = union.b6;
            source[offset + 7] = union.b7;
        }

        /// <summary>
        /// Assign <see cref="UInt64"/> to array by specified offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="value">Value to assign</param>
        /// <param name="offset">Byte array offset</param>
        public static void AssignInt64(this byte[] source, ulong value, int offset) =>
            source.AssignInt64(unchecked((long)value), offset);


        /// <summary>
        /// Get <see cref="Int16"/> from array by array offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="offset">Byte array offset</param>
        /// <returns>Returns value converted from byte array</returns>
        public static short GetInt16(this byte[] source, int offset)
        {
            if (source == null)
                throw new ArgumentNullException(BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE);

            if (source.Length - offset < 2)
                throw new ArgumentException(BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE);

            var union = new Type2ByteUnion();

            union.b0 = source[offset];
            union.b1 = source[offset + 1];

            return union.Value;
        }

        /// <summary>
        /// Get <see cref="UInt16"/> from array by array offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="offset">Byte array offset</param>
        /// <returns>Returns value converted from byte array</returns>
        public static ushort GetUInt16(this byte[] source, int offset) =>
            unchecked((ushort)source.GetInt16(offset));

        /// <summary>
        /// Get <see cref="Int32"/> from array by array offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="offset">Byte array offset</param>
        /// <returns>Returns value converted from byte array</returns>
        public static int GetInt32(this byte[] source, int offset)
        {
            if (source == null)
                throw new ArgumentNullException(BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE);

            if (source.Length - offset < 4)
                throw new ArgumentException(BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE);

            var union = new Type4ByteUnion();

            union.b0 = source[offset];
            union.b1 = source[offset + 1];
            union.b2 = source[offset + 2];
            union.b3 = source[offset + 3];

            return union.Value;
        }

        /// <summary>
        /// Get <see cref="UInt32"/> from array by array offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="offset">Byte array offset</param>
        /// <returns>Returns value converted from byte array</returns>
        public static uint GetUInt32(this byte[] source, int offset) =>
            unchecked((uint)source.GetInt32(offset));

        /// <summary>
        /// Get <see cref="Int64"/> from array by array offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="offset">Byte array offset</param>
        /// <returns>Returns value converted from byte array</returns>
        public static long GetInt64(this byte[] source, int offset)
        {
            if (source == null)
                throw new ArgumentNullException(BYTE_ARRAY_CANNOT_BE_NULL_EXCEPTION_MESSAGE);

            if (source.Length - offset < 8)
                throw new ArgumentException(BYTE_ARRAY_TOO_SMALL_EXCEPTION_MESSAGE);

            var union = new Type8ByteUnion();

            union.b0 = source[offset];
            union.b1 = source[offset + 1];
            union.b2 = source[offset + 2];
            union.b3 = source[offset + 3];
            union.b4 = source[offset + 4];
            union.b5 = source[offset + 5];
            union.b6 = source[offset + 6];
            union.b7 = source[offset + 7];

            return union.Value;
        }

        /// <summary>
        /// Get <see cref="UInt64"/> from array by array offset
        /// </summary>
        /// <param name="source">Source byte array</param>
        /// <param name="offset">Byte array offset</param>
        /// <returns>Returns value converted from byte array</returns>
        public static ulong GetUInt64(this byte[] source, int offset) =>
            unchecked((uint)source.GetInt64(offset));

    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct Type2ByteUnion
    {
        [FieldOffset(0)]
        public short Value;

        [FieldOffset(0)]
        public byte b0;

        [FieldOffset(1)]
        public byte b1;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct Type4ByteUnion
    {
        [FieldOffset(0)]
        public int Value;

        [FieldOffset(0)]
        public byte b0;

        [FieldOffset(1)]
        public byte b1;

        [FieldOffset(2)]
        public byte b2;

        [FieldOffset(3)]
        public byte b3;
    }


    [StructLayout(LayoutKind.Explicit)]
    internal struct Type8ByteUnion
    {
        [FieldOffset(0)]
        public long Value;

        [FieldOffset(0)]
        public byte b0;

        [FieldOffset(1)]
        public byte b1;

        [FieldOffset(2)]
        public byte b2;

        [FieldOffset(3)]
        public byte b3;

        [FieldOffset(4)]
        public byte b4;

        [FieldOffset(5)]
        public byte b5;

        [FieldOffset(6)]
        public byte b6;

        [FieldOffset(7)]
        public byte b7;
    }

}
