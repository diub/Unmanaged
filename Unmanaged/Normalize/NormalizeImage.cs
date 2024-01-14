namespace diub.Normalize;

public class NormalizeImage {

	public static Bitmap ContrastStretch (Bitmap Image, double BlackPointPercent = 0.02, double WhitePointPercent = 0.01) {
		BitmapData srcData = Image.LockBits (new Rectangle (0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly,
			PixelFormat.Format32bppArgb);
		Bitmap destImage = new Bitmap (Image.Width, Image.Height);
		BitmapData destData = destImage.LockBits (new Rectangle (0, 0, destImage.Width, destImage.Height),
			ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		int stride = srcData.Stride;
		IntPtr srcScan0 = srcData.Scan0;
		IntPtr destScan0 = destData.Scan0;
		var freq = new int [256];

		unsafe {
			byte* src = (byte*) srcScan0;
			for (int y = 0; y < Image.Height; ++y) {
				for (int x = 0; x < Image.Width; ++x) {
					++freq [src [y * stride + x * 4]];
				}
			}

			int numPixels = Image.Width * Image.Height;
			int minI = 0;
			var blackPixels = numPixels * BlackPointPercent;
			int accum = 0;

			while (minI < 255) {
				accum += freq [minI];
				if (accum > blackPixels)
					break;
				++minI;
			}

			int maxI = 255;
			var whitePixels = numPixels * WhitePointPercent;
			accum = 0;

			while (maxI > 0) {
				accum += freq [maxI];
				if (accum > whitePixels)
					break;
				--maxI;
			}
			double spread = 255d / (maxI - minI);
			byte* dst = (byte*) destScan0;
			for (int y = 0; y < Image.Height; ++y) {
				for (int x = 0; x < Image.Width; ++x) {
					int i = y * stride + x * 4;

					byte val = (byte) Clamp (Math.Round ((src [i] - minI) * spread), 0, 255);
					dst [i] = val;
					dst [i + 1] = val;
					dst [i + 2] = val;
					dst [i + 3] = 255;
				}
			}
		}

		Image.UnlockBits (srcData);
		destImage.UnlockBits (destData);

		return destImage;
	}

	static double Clamp (double val, double min, double max) {
		return Math.Min (Math.Max (val, min), max);
	}

}   // class

//	namespace	2023-03-22 - 13.33.37

