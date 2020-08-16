using System;

namespace diub.Unmanaged {

	unsafe static public class ValueToArray {

		/// <summary>
		/// C# pointers not really pointers!!!!
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Array"></param>
		/// <param name="Offset"></param>
		/// <param name="Value"></param>
		//static public void Value<T> (byte [] Array, Int32 Offset, T Value) where T : struct {
		//	fixed (byte* ptr = Array) {
		//		byte* vp = ptr + Offset;
		//		*(T*) vp = Value;
		//	}
		//}

		static public void Value (this byte [] Array, Int32 Offset, Int16 Value) {
			fixed (byte* ptr = Array) {
				Int16* vp = (Int16*) (ptr + Offset);
				*vp = Value;
			}
		}

		static public void Value (this byte [] Array, ref Int32 Offset, Int16 Value) {
			fixed (byte* ptr = Array) {
				Int32* vp = (Int32*) (ptr + Offset);
				*vp = Value;
				Offset += 2;
			}
		}

		static public void Value (this byte [] Array, Int32 Offset, Int32 Value) {
			fixed (byte* ptr = Array) {
				Int32* vp = (Int32*) (ptr + Offset);
				*vp = Value;
			}
		}

		static public void Value (this byte [] Array, ref Int32 Offset, Int32 Value) {
			fixed (byte* ptr = Array) {
				Int32* vp = (Int32*) (ptr + Offset);
				*vp = Value;
				Offset += 4;
			}
		}

		static public void Value (this byte [] Array, Int32 Offset, Int64 Value) {
			fixed (byte* ptr = Array) {
				Int64* vp = (Int64*) (ptr + Offset);
				*vp = Value;
			}
		}

		static public void Value (this byte [] Array, ref Int32 Offset, Int64 Value) {
			fixed (byte* ptr = Array) {
				Int64* vp = (Int64*) (ptr + Offset);
				*vp = Value;
				Offset += 8;
			}
		}

		//

		static public dynamic Value<T> (this byte [] Array, Int32 Offset) where T : struct {

			fixed (byte* ptr = Array) {
				switch (Type.GetTypeCode (typeof (T))) {
					case TypeCode.Int16:
						Int16* vp16 = (Int16*) (ptr + Offset);
						return *vp16;
					case TypeCode.Int32:
						Int32* vp32 = (Int32*) (ptr + Offset);
						return *vp32;
					case TypeCode.Int64:
						Int64* vp64 = (Int64*) (ptr + Offset);
						return *vp64;
				}
			}
			throw new Exception ("Not implemented!");
		}

		static public dynamic Value<T> (this byte [] Array, ref Int32 Offset) where T : struct {
			fixed (byte* ptr = Array) {
				switch (Type.GetTypeCode (typeof (T))) {
					case TypeCode.Int16:
						Int16* vp16 = (Int16*) (ptr + Offset);
						Offset += 2;
						return *vp16;
					case TypeCode.Int32:
						Int32* vp32 = (Int32*) (ptr + Offset);
						Offset += 4;
						return *vp32;
					case TypeCode.Int64:
						Int64* vp64 = (Int64*) (ptr + Offset);
						Offset += 8;
						return *vp64;
				}
			}
			throw new Exception ("Not implemented!");
		}

		static public Int64 Value (this byte [] Array, Int32 Offset) {
			fixed (byte* ptr = Array) {
				Int64* vp = (Int64*) (ptr + Offset);
				return *vp;
			}
		}


	}   // class

}   //	namespace	2019-06-26 - 11.21.17