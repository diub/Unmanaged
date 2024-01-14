namespace diub.Transform;

unsafe static public partial class UnmanagedTransform {

	/// <summary>
	/// Schreibt die Byte-Darstellung von <paramref name="Value"/> an der Position <paramref name="Offset"/> 
	/// in das Byte-Array <paramref name="Array"/>.
	/// </summary>
	/// <typeparam name="T">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool</typeparam>
	/// <param name="Array"></param>
	/// <param name="Offset"></param>
	/// <param name="Value">Wert vom Type sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool.</param>
	static public void Value<T> (this byte [] Array, Int32 Offset, T Value)
		where T : unmanaged {
		fixed (byte* ptr = Array) {
			T* vp = (T*) (ptr + Offset);
			*vp = Value;
		}
	}

	/// <summary>
	/// Schreibt die Byte-Darstellung von <paramref name="Value"/> an der Position <paramref name="Offset"/> 
	/// in das Byte-Array <paramref name="Array"/>.<para></para>
	/// Der Wert der Variablen <paramref name="Offset"/> wird dabei um der Anzahl der gelesenen Bytes vergrößert.
	/// </summary>
	/// <typeparam name="T">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool</typeparam>
	/// <param name="Array"></param>
	/// <param name="Offset"></param>
	/// <param name="Value">Wert vom Type sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool.</param>
	static public void Value<T> (this byte [] Array, ref Int32 Offset, T Value)
		where T : unmanaged {
		fixed (byte* ptr = Array) {
			T* vp = (T*) (ptr + Offset);
			*vp = Value;
		}
		Offset += sizeof (T);
	}

	/// <summary>
	/// Liest den Rückgabe-Wert aus der Byte-Darstellung ab der Position <paramref name="Offset"/> aus dem Byte-Array <paramref name="Array"/>.
	/// </summary>
	/// <typeparam name="T">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool.</typeparam>
	/// <param name="Array"></param>
	/// <param name="Offset"></param>
	/// <returns></returns>
	static public T Value<T> (this byte [] Array, Int32 Offset)
		where T : unmanaged {
		fixed (byte* ptr = Array) {
			T* vp = (T*) (ptr + Offset);
			return *vp;
		}
	}

	/// <summary>
	/// Liest den Rückgabe-Wert aus der Byte-Darstellung ab der Position <paramref name="Offset"/> aus dem Byte-Array <paramref name="Array"/>.
	/// <para></para>
	/// Der Wert der Variablen <paramref name="Offset"/> wird dabei um der Anzahl der gelesenen Bytes vergrößert.
	/// </summary>
	/// <typeparam name="T">sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool</typeparam>
	/// <param name="Array"></param>
	/// <param name="Offset"></param>
	/// <returns></returns>
	static public T Value<T> (this byte [] Array, ref Int32 Offset)
		where T : unmanaged {
		fixed (byte* ptr = Array) {
			T* vp = (T*) (ptr + Offset);
			Offset += sizeof (T);
			return *vp;
		}
	}

}   // class

//	namespace	2019-06-26 - 11.21.17