namespace diub.Crypt;

static public partial class Hashes {

	//
	// Abgeleitet von: 	https://stackoverflow.com/questions/1650395/faster-string-gethashcode-e-g-using-multicore-or-gpu
	//

	unsafe static public Int32 GetHashCode (string Text) {
		int num0 = 352654597;
		int num1 = num0;
		int* ptr;

		if (Text == null)
			return (num0 + (num1 * 1566083941));
		fixed (char* char_ptr = Text) {
			ptr = (int*) char_ptr;
			for (int i = Text.Length; i > 0; i -= 4) {
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;
				// 32 Bit Zugriffe; es gibt aber bestenfalls eine 0 / ein Zeichen '0' am Ende.
				if (i <= 2)
					break;
				ptr++;  // Integer-Zeiger → 2 Char Schritt
				num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *ptr;
				ptr++;  // Integer-Zeiger → 2 Char Schritt
			}
			return (num0 + (num1 * 1566083941));
		}
	}


	unsafe static public Int32 GetHashCode (char [] Text, int Offset, int Length) {
		int num0 = 352654597;
		int num1 = num0;
		int* ptr;

		if (Text == null)
			return (num0 + (num1 * 1566083941));
		fixed (char* array_ptr = Text) {
			ptr = (int*) (array_ptr + Offset);
			// 32 Bit Zugriffe! Am Ende von Text keine Nullen garantiert!
			for (int i = 0; i < Length / 4; i++) {
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;
				ptr++;  // Integer-Zeiger → 2 Char Schritt
				num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *ptr;
				ptr++;  // Integer-Zeiger → 2 Char Schritt
			}
			// Eventuell überschüssige Zeichen a 16 Bit nachholen
			switch (Length % 4) {
				case 0:
					// nichts überstehend
					break;
				case 1:
					num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *(Int16*) ptr;// holt 16 Bit
					break;
				case 2:
					num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;  // holt 32 Bit
					break;
				case 3:
					num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;  // holt 32 Bit
					ptr++;
					num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *(Int16*) ptr;  // holt 16 Bit
					break;
			}
			return (num0 + (num1 * 1566083941));
		}
	}

	unsafe static public Int32 GetHashCode2 (char [] Text, int Offset, int Length) {
		const int p = 16777619;

		unchecked {
			int hash = (int) 2166136261;
			for (int i = Offset; i < Offset + Length; i++)
				hash = (hash ^ Text [i]) * p;
			hash += hash << 13;
			hash ^= hash >> 7;
			hash += hash << 3;
			hash ^= hash >> 17;
			hash += hash << 5;
			return hash;
		}
	}

	unsafe static public Int32 GetHashCodeChar (char [] Buffer, int Offset, int Length) {
		fixed (void* void_ptr = Buffer) {
			return GetHashCode ((byte*) void_ptr, Offset << 1, Length << 1, false);
		}
	}

	unsafe static public Int32 GetHashCode (byte [] Buffer, int Offset, int Length) {
		fixed (byte* byte_ptr = Buffer) {
			return GetHashCode (byte_ptr, Offset, Length);
		}
	}

	unsafe static public Int32 GetHashCode (byte* Buffer, int Offset, int Length) {
		return GetHashCode (Buffer, Offset, Length, true);
	}

	unsafe static public Int32 GetHashCode (byte* Buffer, int Offset, int Length, bool HandleZeroSignIssue) {
		int num0 = 352654597;
		int num1 = num0;
		int* ptr;

		ptr = (int*) (Buffer + Offset);
		// 32 Bit Zugriffe! Am Ende von Buffer keine Nullen garantiert!
		for (int i = 0; i < Length / 8; i++) {
			num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;
			ptr++;  // Integer-Zeiger → 4 Byte Schritt
			num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *ptr;
			ptr++;  // Integer-Zeiger → 4 Byte Schritt
		}
		// Eventuell überschüssige Bytes a 8 Bit nachholen
		switch (Length % 8) {
			case 0:
				// nichts überstehend
				break;
			case 1:
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *(byte*) ptr;    // holt 8 Bit
				break;
			case 2:
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *(Int16*) ptr;   // holt 16 Bit
				break;
			case 3:
				num0 = *(Int16*) ptr;  // holt 16 Bit
				num0 = ((((num0 << 5) + num0) + (num0 >> 27)) ^ (num0 | ((int) (((byte*) ptr) [2])) << 16));  // holt weitere 8 Bit
				break;
			case 4:
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;    // holt 32 Bit
				break;
			case 5:
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;    // holt 32 Bit
				ptr++;  // Integer-Zeiger → 4 Byte Schritt
				num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *(byte*) ptr;    // holt 8 Bit
				break;
			case 6:
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;    // holt 32 Bit
				ptr++;  // Integer-Zeiger → 4 Byte Schritt
				num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *(Int16*) ptr;// holt 16 Bit
				break;
			case 7:
				num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ *ptr;    // holt 32 Bit
				ptr++;  // Integer-Zeiger → 4 Byte Schritt
				num1 = (((num1 << 5) + num1) + (num1 >> 27)) ^ *(Int16*) ptr;   // holt 16 Bit
				num1 = ((((num1 << 5) + num1) + (num1 >> 27)) ^ (num1 | ((int) (((byte*) ptr) [2])) << 16));  // holt weitere 8 Bit
				break;
		}
		// 32 Bit Zugriffe und impliziete Ergänzung mit Nullen (0) ist nur bei Char Arrays zulässig!!!
		// Für normale Arrays die mit Null(en) enden sind die Hashs uneindeutig.
		// Beispiel: byte [] = {1} / byte [] = {1, 0} /  byte [] = {1, 0, 0} usw.
		if (HandleZeroSignIssue)
			num0 = (((num0 << 5) + num0) + (num0 >> 27)) ^ Length;    // Länge als zusätzlicher Faktor korrigiert das
		return (num0 + (num1 * 1566083941));
	}

	unsafe static public Int32 GetHashCode2 (byte [] Value) {
		const int p = 16777619;

		unchecked {
			int hash = (int) 2166136261;
			for (int i = 0; i < Value.Length; i++)
				hash = (hash ^ Value [i]) * p;
			hash += hash << 13;
			hash ^= hash >> 7;
			hash += hash << 3;
			hash ^= hash >> 17;
			hash += hash << 5;
			return hash;
		}
	}

	// Quelle:
	// http://www.java2s.com/example/csharp/security/generates-a-3264bit-hash-for-the-given-string.html

	private static ulong Offest_basis = 14695981039346656037;

	public static UInt64 Get64HashCode (string str) {

		ulong hash = Offest_basis;
		foreach (char c in str) {
			hash ^= (ulong) c;

			/* multiply by the 64 bit FNV magic prime mod 2^64 */
			hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
		}
		return hash;
	}

	unsafe static public UInt64 Get64HashCode (byte [] Bytes, int Offset, int Length) {
		fixed (void* ptr = Bytes) {
			return Get64HashCode ((byte*) ptr, Offset, Length);
		}
	}

	unsafe static public UInt64 Get64HashCode (byte* Bytes, int Offset, int Length) {
		UInt64 hash, buffer;
		UInt16* ptr16;
		UInt32* ptr32;

		ptr32 = (UInt32*) (Bytes + Offset);
		hash = Offest_basis;
		// 32 Bit Zugriffe! Am Ende von Buffer keine Nullen garantiert!
		for (int i = 0; i < Length / 4; i++) {
			hash ^= (UInt64) (*ptr32);
			/* multiply by the 64 bit FNV magic prime mod 2^64 */
			hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
			ptr32++;
		}
		// Eventuell überschüssige Bytes a 8 Bit nachholen
		ptr16 = (UInt16*) ptr32;
		switch (Length % 4) {
			case 0:
				// nichts überstehend
				break;
			case 1:
				hash ^= (UInt64) (*(byte*) ptr16);
				hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
				break;
			case 2:
				hash ^= (UInt64) (*ptr16);
				hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
				break;
			case 3:
				buffer = (UInt64) (*ptr16);
				buffer |= ((UInt64) (*(byte*) ptr16)) << 16;
				hash ^= buffer;
				hash += (hash << 1) + (hash << 4) + (hash << 5) + (hash << 7) + (hash << 8) + (hash << 40);
				break;
		}
		return hash;
	}

}   // class

//	namespace	2017-11-29_10.45.00