using System;

namespace diub.Unmanaged {

	static public partial class Hashes {

		//
		// Abgeleitet von: 	https://stackoverflow.com/questions/1650395/faster-string-gethashcode-e-g-using-multicore-or-gpu
		//

		unsafe static public Int32 GetHashCode (String Text) {
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

		// 2018-08-01
		//public void TestHashCode () {
		//	Int32 s, t, b;

		//	String str;
		//	Text text;
		//	char ch;

		//	text = "";
		//	ch = '0';
		//	for (int i = 0; i < 67 * 1024 + 13; i++) {
		//		text.Append (ch);
		//		str = text;
		//		s = Hash.GetRealHashCode (str);
		//		t = Hash.GetRealHashCode (text);
		//		b = diub.x86.UnsafeFixes.GetHashCodeChar (text.CharArray, text.Offset, text.Length );
		//		if (s != t || s != b || t != b) {
		//		}
		//		ch++;
		//		if (ch > '9')
		//			ch = '0';
		//	}
		//}

	}   // class

}   //	namespace	2017-11-29_10.45.00