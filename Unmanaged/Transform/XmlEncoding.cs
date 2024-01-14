namespace diub.Transform {

	unsafe static public partial class UnmanagedTransform {

		/// <summary>
		/// Kopiert Zeichen nach Target und setzt dabei den Zeiger neu!
		/// </summary>
		/// <param name="Source"></param>
		/// <param name="Target"></param>
		/// <param name="Length"></param>
		unsafe static private void CopyChars (char* Source, ref char* Target, int Length) {
			for (int i = 0; i < Length; i++) {
				*Target = *Source;
				Source++;
				Target++;
			}
		}

		static  private char [] AMP = new char[] {'&','a','m','p' ,';'};
		static  private char [] NBSP = new char[] {'&','n','b','s','p' ,';'};
		static  private char [] APOS = new char[] {'&','a','p','o','s',';'  };
		static  private char [] DOUBLE_QUOTE = new char[] {'&','q','u','o','t',';' };
		static  private char [] LESS_THEN = new char[] {'&','l','t',';' };
		static  private char [] GREATER_THEN = new char[] {'&','g','t',';' };

		/// <summary>
		/// Ersetzt (Sonder-)Zeichen gemäß der XML-Konventionen.
		/// </summary>
		/// <param name="Source"></param>
		/// <param name="SourceOffset"></param>
		/// <param name="GranulationSize"></param>
		/// <param name="TargetOffset"></param>
		/// <param name="Length"></param>
		/// <param name="ForceUtfEncoding">True: alle Zeichen mit Codes größer 127 werden als Sonderzeichen (&#...;) kodiert.</param>
		/// <returns></returns>
		unsafe static public char [] XmlEncode (char [] Source, int SourceOffset, int GranulationSize, int TargetOffset, ref int Length, bool ForceUtfEncoding = false) {
			int i, size;
			char ch;
			char* text_ptr;
			char* target_ptr;
			char [] buf;

			size = 0;
			fixed (char* text_fixed = Source) {
				// Größe das Char-Array bestimmen.
				text_ptr = text_fixed + SourceOffset;
				for (i = 0; i < Length; i++) {
					ch = *text_ptr;
					text_ptr++;
					if (ch > 127) {
						if (ForceUtfEncoding)
							size += 7;  // &xxxxx; → nach oben abgeschätzt
						continue;
					}
					if (ch >= '?' || ch < ' ') {
						size++;
						continue;
					}
					if (ch == '&') {
						size += NBSP.Length;
						continue;
					}
					if (ch == '\'') {
						size += APOS.Length;
						continue;
					}
					if (ch == '"') {
						size += DOUBLE_QUOTE.Length;
						continue;
					}
					if (ch == '<') {
						size += LESS_THEN.Length;
						continue;
					}
					if (ch == '>') {
						size += GREATER_THEN.Length;
						continue;
					}
					// Zeichen zwischen Sonderzeichen usw.
					size++;
				}
				size = (size / GranulationSize + 1) * GranulationSize + TargetOffset;
				buf = new char [size];
				// nach XML umsetzten
				text_ptr = text_fixed + SourceOffset;
				fixed (char* target_fixed = buf) {
					target_ptr = target_fixed + TargetOffset;
					for (i = 0; i < Length; i++) {
						ch = *text_ptr;
						text_ptr++;
						if (ch > 127) {
							if (ForceUtfEncoding) {
								EncodeChar (ch, ref target_ptr);
							} else {
								*target_ptr = ch;
								target_ptr++;
							}
							continue;
						}
						if (ch >= '?' || ch < ' ') {
							*target_ptr = ch;
							target_ptr++;
							continue;
						}
						if (ch == '&') {
							fixed (char* ptr = AMP)
								CopyChars (ptr, ref target_ptr, AMP.Length);
							continue;
						}
						if (ch == '\'') {
							fixed (char* ptr = APOS)
								CopyChars (ptr, ref target_ptr, APOS.Length);
							continue;
						}
						if (ch == '"') {
							fixed (char* ptr = DOUBLE_QUOTE)
								CopyChars (ptr, ref target_ptr, DOUBLE_QUOTE.Length);
							continue;
						}
						if (ch == '<') {
							fixed (char* ptr = LESS_THEN)
								CopyChars (ptr, ref target_ptr, LESS_THEN.Length);
							continue;
						}
						if (ch == '>') {
							fixed (char* ptr = GREATER_THEN)
								CopyChars (ptr, ref target_ptr, GREATER_THEN.Length);
							continue;
						}
						// Zeichen zwischen Sonderzeichen usw.
						*target_ptr = ch;
						target_ptr++;
					}
					Length = (int) (target_ptr - target_fixed) - SourceOffset;
				}
			}
			return buf;
		}

		unsafe static private void EncodeChar (char Chr, ref char* Chars) {
			int i;

			*Chars = '&';
			Chars++;
			*Chars = '#';
			Chars++;
			i = Chr;
			do {
				*Chars = ((char) ((i % 10) + 48));
				Chars++;
				i = i / 10;
			} while (i > 10);
			*Chars = ((char) (i + 48));
			Chars++;
			*Chars = ';';
			Chars++;
		}

	}   // class

}   //	namespace	2019-04-14 - 14.18.29
