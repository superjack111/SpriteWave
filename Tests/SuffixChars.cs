using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpriteWave
{
	class Characters
	{
		static byte[][] tileset = new byte[][]
		{
			new byte[] {
				0x38, 0x4C, 0xC6, 0xC6, 0xC6, 0x64, 0x38, 0x00
			}, new byte[] {
				0x18, 0x38, 0x18, 0x18, 0x18, 0x18, 0x7E, 0x00,
			}, new byte[] {
				0x7C, 0xC6, 0x0E, 0x3C, 0x78, 0xE0, 0xFE, 0x00,
			}, new byte[] {
				0x7E, 0x0C, 0x18, 0x3C, 0x06, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0x1C, 0x3C, 0x6C, 0xCC, 0xFE, 0x0C, 0x0C, 0x00,
			}, new byte[] {
				0xFC, 0xC0, 0xFC, 0x06, 0x06, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0x3C, 0x60, 0xC0, 0xFC, 0xC6, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0xFE, 0xC6, 0x0C, 0x18, 0x30, 0x30, 0x30, 0x00,
			}, new byte[] {
				0x7C, 0xC6, 0xC6, 0x7C, 0xC6, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0x7C, 0xC6, 0xC6, 0x7E, 0x06, 0x0C, 0x78, 0x00,
			}, new byte[] {
				0x38, 0x6C, 0xC6, 0xC6, 0xFE, 0xC6, 0xC6, 0x00,
			}, new byte[] {
				0xFC, 0xC6, 0xC6, 0xFC, 0xC6, 0xC6, 0xFC, 0x00,
			}, new byte[] {
				0x3C, 0x66, 0xC0, 0xC0, 0xC0, 0x66, 0x3C, 0x00,
			}, new byte[] {
				0xF8, 0xCC, 0xC6, 0xC6, 0xC6, 0xCC, 0xF8, 0x00,
			}, new byte[] {
				0xFE, 0xC0, 0xC0, 0xFC, 0xC0, 0xC0, 0xFE, 0x00,
			}, new byte[] {
				0xFE, 0xC0, 0xC0, 0xFC, 0xC0, 0xC0, 0xC0, 0x00,
			}, new byte[] {
				0x3E, 0x60, 0xC0, 0xCE, 0xC6, 0x66, 0x3E, 0x00,
			}, new byte[] {
				0xC6, 0xC6, 0xC6, 0xFE, 0xC6, 0xC6, 0xC6, 0x00,
			}, new byte[] {
				0x7E, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7E, 0x00,
			}, new byte[] {
				0x1E, 0x06, 0x06, 0x06, 0xC6, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0xC6, 0xCC, 0xD8, 0xF0, 0xF8, 0xDC, 0xCE, 0x00,
			}, new byte[] {
				0x60, 0x60, 0x60, 0x60, 0x60, 0x60, 0x7E, 0x00,
			}, new byte[] {
				0xC6, 0xEE, 0xFE, 0xFE, 0xD6, 0xC6, 0xC6, 0x00,
			}, new byte[] {
				0xC6, 0xE6, 0xF6, 0xFE, 0xDE, 0xCE, 0xC6, 0x00,
			}, new byte[] {
				0x7C, 0xC6, 0xC6, 0xC6, 0xC6, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0xFC, 0xC6, 0xC6, 0xC6, 0xFC, 0xC0, 0xC0, 0x00,
			}, new byte[] {
				0x7C, 0xC6, 0xC6, 0xC6, 0xDE, 0xCC, 0x7A, 0x00,
			}, new byte[] {
				0xFC, 0xC6, 0xC6, 0xCE, 0xF8, 0xDC, 0xCE, 0x00,
			}, new byte[] {
				0x78, 0xCC, 0xC0, 0x7C, 0x06, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0x7E, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x00,
			}, new byte[] {
				0xC6, 0xC6, 0xC6, 0xC6, 0xC6, 0xC6, 0x7C, 0x00,
			}, new byte[] {
				0xC6, 0xC6, 0xC6, 0xEE, 0x7C, 0x38, 0x10, 0x00,
			}, new byte[] {
				0xC6, 0xC6, 0xD6, 0xFE, 0xFE, 0xEE, 0xC6, 0x00,
			}, new byte[] {
				0xC6, 0xEE, 0x7C, 0x38, 0x7C, 0xEE, 0xC6, 0x00,
			}, new byte[] {
				0x66, 0x66, 0x66, 0x3C, 0x18, 0x18, 0x18, 0x00,
			}, new byte[] {
				0xFE, 0x0E, 0x1C, 0x38, 0x70, 0xE0, 0xFE, 0x00
			}
		};

		static byte[] bmpHeader = new byte[]
		{
			(byte)'B', (byte)'M',
			0, 0, 0, 0, // file size
			0, 0, 0, 0,
			0x3E, 0, 0, 0, // data offset
			0x28, 0, 0, 0, // dib header size
			0, 0, 0, 0, // width
			8, 0, 0, 0, // height
			1, 0,
			1, 0, // bits per pixel
			0, 0, 0, 0,
			0, 0, 0, 0, // data size
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 0xFF, // palette - black
			0xFF, 0xFF, 0xFF, 0xFF // white
		};

		const int Scale = 10;

		void Embed(byte[] array, int n, int offset)
		{
			uint val = (uint)n;
			// not sure how effective loop rolling is in .NET but let's give it a go
			array[offset+3] = (byte)((val >> 24) & 0xff);
			array[offset+2] = (byte)((val >> 16) & 0xff);
			array[offset+1] = (byte)((val >> 8) & 0xff);
			array[offset] = (byte)(val & 0xff);
		}

		void ProduceImage(Graphics g, Suffix suff, int num)
		{
			var tiles = new int[suff.Digits];
			int n = num;
			for (int i = 0; i < suff.Digits; i++)
			{
				tiles[suff.Digits-i-1] = n % suff.Base;
				n /= suff.Base;
			}

			int rowLen = suff.Digits;
			rowLen += (4 - (suff.Digits % 4)) % 4;
			int pixSize = rowLen * 8;

			var bmp = new byte[bmpHeader.Length + pixSize];
			Buffer.BlockCopy(bmpHeader, 0, bmp, 0, bmpHeader.Length);

			Embed(bmp, bmp.Length, 2);
			Embed(bmp, suff.Digits * 8, 18);
			Embed(bmp, pixSize, 34);

			for (int i = 7; i >= 0; i--)
			{
				int idx = bmpHeader.Length + i * rowLen;
				for (int j = 0; j < suff.Digits; j++)
					bmp[idx+j] = Characters.tileset[tiles[j]][7-i];
			}

			using (var ms = new MemoryStream(bmp))
			{
				using (var img = new Bitmap(ms))
					g.DrawImage(img, 0, 0, suff.Digits * 8 * Scale, 8 * Scale);
			}
		}

		public void Generate(Suffix suff, string path, int count)
		{
			var img = new Bitmap(suff.Digits * 8 * Scale, 8 * Scale);
			using (var g = Graphics.FromImage(img))
			{
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = PixelOffsetMode.Half;

				for (int i = 0; i < count; i++)
				{
					string name = suff.Generate(i);
					ProduceImage(g, suff, i);
					img.Save(path + name);
				}
			}
		}
	}

	class MainClass
	{
		static void Main()
		{
			Console.Write("Number Tile Generator\nSuffix Format:\n> ");

			Suffix suffix;
			try {
				string sufStr = Console.ReadLine();
				suffix = new Suffix(sufStr);
				if (!suffix.HasInsert)
					throw new ArgumentException("\"" + sufStr + "\" does not contain an insert");
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				Console.ReadLine();
				return;
			}

			Console.Write("Number of tiles:\n> ");
			int nTiles = 0;
			try {
				nTiles = Convert.ToInt32(Console.ReadLine());
				if (nTiles <= 0)
					throw new ArgumentException("The number of tiles must be positive");
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
				Console.ReadLine();
				return;
			}

			Console.Write("Output folder:\n> ");
			string dir = Console.ReadLine();
			if (dir[dir.Length - 1] != '\\')
				dir += "\\";

			new Characters().Generate(suffix, dir, nTiles);
		}
	}
}