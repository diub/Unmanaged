namespace diub.Transform {

	unsafe static public partial class UnmanagedTransform {

		/// <summary>
		/// Ersetzt Zeichen in UTF-(Sonderzeichen-)Kodierungen (&...;) durch normale Zeichen.
		/// </summary>
		/// <param name="Source"></param>
		/// <param name="SourceOffset"></param>
		/// <param name="GranulationSize"></param>
		/// <param name="TargetOffset"></param>
		/// <param name="Length"></param>
		/// <returns></returns>
		unsafe static public char [] XmlDecode (char [] Source, int SourceOffset, int GranulationSize, int TargetOffset, ref int Length) {
			int size;
			char ch;
			char [] buf;
			char* source_ptr;
			char* target_ptr;
			char* last_source_ptr;

			size = (Length / GranulationSize + 1) * GranulationSize + TargetOffset;
			buf = new char [size];
			fixed (char* source_fixed = Source) {
				source_ptr = source_fixed + SourceOffset;
				last_source_ptr = source_ptr + Length;
				fixed (char* target_fixed = buf) {
					target_ptr = target_fixed + TargetOffset;
					while (source_ptr < last_source_ptr) {
						ch = *source_ptr;
						source_ptr++;
						if (ch != '&') {
							*target_ptr = ch;
							target_ptr++;
							continue;
						}
						ch = *source_ptr;
						source_ptr++;
						if (ch == '#') {
							*target_ptr = DecodeChar (ref source_ptr);
							target_ptr++;
							continue;
						}
						if (ch == 'a') {
							ch = *source_ptr;
							source_ptr++;
							if (ch == 'm') {
								*target_ptr = '&';
								target_ptr++;
								source_ptr += AMP.Length - 3;
								continue;
							}
							if (ch == 'p') {
								*target_ptr = '\'';
								target_ptr++;
								source_ptr += APOS.Length - 3;
								continue;
							}
						}
						if (ch == 'q') {
							*target_ptr = '\"';
							target_ptr++;
							source_ptr += DOUBLE_QUOTE.Length - 2;
							continue;
						}
						if (ch == 'l') {
							*target_ptr = '<';
							target_ptr++;
							source_ptr += LESS_THEN.Length - 2;
							continue;
						}
						if (ch == 'g') {
							*target_ptr = '>';
							target_ptr++;
							source_ptr += GREATER_THEN.Length - 2;
							continue;
						}
					}
					Length = (int) (target_ptr - target_fixed);
					Length -= TargetOffset;
				}
			}
			return buf;
		}

		unsafe static private char DecodeChar (ref char* Source) {
			int i;
			char ch;

			i = 0;
			ch = *Source;
			do {
				i = i * 10;
				i += (ch - 48);
				Source++;
			} while ((ch = *Source) != ';');
			Source++;   // Semikolon überspringen
			return (char) i;
		}

	}   // class

}   //	namespace	2019-04-14 - 14.18.29
