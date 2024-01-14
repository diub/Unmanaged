// 
// ArrayCompare - © Copyright diub - Dipl.-Ing. Uwe Barth - 2019-11-02
// 
// Vergleiche für 'Unmanaged Type'-Arrays via Pointer auf UInt32; ein "Length-Missmatch" wird ausgeglichen.
//
// 'Unmanaged-Type' sind: sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, bool
//

namespace diub.Universal;

static public partial class Comparing {


	/// <summary>
	/// Vergleicht Arrays vom Typ 'sbyte'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this sbyte [] Left, Int32 LeftStart, sbyte [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<sbyte> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this sbyte [] Left, sbyte [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<sbyte> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'byte'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this byte [] Left, Int32 LeftStart, byte [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<byte> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this byte [] Left, byte [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<byte> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'short'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this short [] Left, Int32 LeftStart, short [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<short> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this short [] Left, short [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<short> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'ushort'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this ushort [] Left, Int32 LeftStart, ushort [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<ushort> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this ushort [] Left, ushort [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<ushort> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'int'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this int [] Left, Int32 LeftStart, int [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<int> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this int [] Left, int [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<int> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'uint'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this uint [] Left, Int32 LeftStart, uint [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<uint> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this uint [] Left, uint [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<uint> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'long'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this long [] Left, Int32 LeftStart, long [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<long> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this long [] Left, long [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<long> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'ulong'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this ulong [] Left, Int32 LeftStart, ulong [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<ulong> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this ulong [] Left, ulong [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<ulong> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'char'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this char [] Left, Int32 LeftStart, char [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<char> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this char [] Left, char [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<char> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'float'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this float [] Left, Int32 LeftStart, float [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<float> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this float [] Left, float [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<float> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'double'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this double [] Left, Int32 LeftStart, double [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<double> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this double [] Left, double [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<double> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'decimal'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this decimal [] Left, Int32 LeftStart, decimal [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<decimal> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this decimal [] Left, decimal [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<decimal> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

	/// <summary>
	/// Vergleicht Arrays vom Typ 'bool'.
	/// </summary>
	/// <param name="Left">Linkes/Erstes Array für Vergleich.</param>
	/// <param name="LeftStart">Startpunkt innerhalb des linken Array.</param>
	/// <param name="Right">Rechtes/Zweites Array für Vergleich.</param>
	/// <param name="RightStart">Startpunkt innerhalb des rechten Array.</param>
	/// <param name="Length">Anzahl der zu vergleichenden Elemente.</param>
	/// <returns>True: falls vollständig gleich; sonst False.</returns>
	unsafe static public int CompareArray (this bool [] Left, Int32 LeftStart, bool [] Right, Int32 RightStart, Int32 Length) {
		return CompareUnmanaged<bool> (Left, LeftStart, Right, RightStart, Length);
	}

	unsafe static public int CompareArray (this bool [] Left, bool [] Right) {
		int i, len;

		len = Left.Length;
		if (Left.Length > Right.Length)
			len = Right.Length;
		i = CompareUnmanaged<bool> (Left, 0, Right, 0, len);
		if (i == 0 && Left.Length != Right.Length)
			return Left.Length - Right.Length;
		return i;
	}

}   // class

//	namespace	2019-11-02 - 14.48.53