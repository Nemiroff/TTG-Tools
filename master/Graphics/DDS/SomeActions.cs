using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using TTG_Tools.ClassesStructs;
using static TTG_Tools.Graphics.DDS.Dds;

namespace TTG_Tools.Graphics.DDS
{
    public class SomeActions
    {
        public static byte[] ConvertARGBtoBGRA(byte[] data)
        {
            byte[] result = new byte[data.Length];
            uint offset = 0;

            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    for (int i = 0; i < data.Length; i += 4)
                    {
                        byte[] argb = br.ReadBytes(4);

                        byte[] bgra = new byte[4];
                        bgra[0] = argb[3];
                        bgra[1] = argb[2];
                        bgra[2] = argb[1];
                        bgra[3] = argb[0];

                        Array.Copy(bgra, 0, result, offset, bgra.Length);
                        offset += 4;
                    }
                }
            }

            return result;
        }

        public static byte[] ConvertBGRAtoARGB(byte[] data)
        {
            byte[] result = new byte[data.Length];
            uint offset = 0;

            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    for (int i = 0; i < data.Length; i += 4)
                    {
                        byte[] bgra = br.ReadBytes(4);

                        byte[] argb = new byte[4];
                        argb[0] = bgra[3];
                        argb[1] = bgra[1];
                        argb[2] = bgra[2];
                        argb[3] = bgra[0];

                        Array.Copy(argb, 0, result, offset, argb.Length);
                        offset += 4;
                    }
                }
            }

            return result;
        }

        public enum PixelFormat
        {
            RGBA, RGB, DXT1, DXT2, DXT3, DXT4, DXT5,
            THREEDC, ATI1N, LUMINANCE, LUMINANCE_ALPHA, RXGB, A16B16G16R16,
            R16F, G16R16F, A16B16G16R16F, R32F, G32R32F, A32B32G32R32F, UNKNOWN
        }

        // iCompFormatToBpp
        internal static uint PixelFormatToBpp(uint pf, uint rgbbitcount)
        {
            switch (pf)
            {
                case (uint)PixelFormat.LUMINANCE:
                case (uint)PixelFormat.LUMINANCE_ALPHA:
                case (uint)PixelFormat.RGBA:
                case (uint)PixelFormat.RGB:
                    return rgbbitcount / 8;
                case (uint)PixelFormat.THREEDC:
                case (uint)PixelFormat.RXGB:
                    return 3;
                case (uint)PixelFormat.ATI1N:
                    return 1;
                case (uint)PixelFormat.R16F:
                    return 2;
                case (uint)PixelFormat.A16B16G16R16:
                case (uint)PixelFormat.A16B16G16R16F:
                case (uint)PixelFormat.G32R32F:
                    return 8;
                case (uint)PixelFormat.A32B32G32R32F:
                    return 16;
                default:
                    return 4;
            }
        }

        // iCompFormatToBpc
        internal static uint PixelFormatToBpc(uint pf)
        {
            switch (pf)
            {
                case (uint)PixelFormat.R16F:
                case (uint)PixelFormat.G16R16F:
                case (uint)PixelFormat.A16B16G16R16F:
                    return 4;
                case (uint)PixelFormat.R32F:
                case (uint)PixelFormat.G32R32F:
                case (uint)PixelFormat.A32B32G32R32F:
                    return 4;
                case (uint)PixelFormat.A16B16G16R16:
                    return 2;
                default:
                    return 1;
            }
        }

        internal static unsafe void DxtcReadColors(byte* data, ref Colour8888[] op)
        {
            byte r0, g0, b0, r1, g1, b1;

            b0 = (byte)(data[0] & 0x1F);
            g0 = (byte)(((data[0] & 0xE0) >> 5) | ((data[1] & 0x7) << 3));
            r0 = (byte)((data[1] & 0xF8) >> 3);

            b1 = (byte)(data[2] & 0x1F);
            g1 = (byte)(((data[2] & 0xE0) >> 5) | ((data[3] & 0x7) << 3));
            r1 = (byte)((data[3] & 0xF8) >> 3);

            op[0].red = (byte)(r0 << 3 | r0 >> 2);
            op[0].green = (byte)(g0 << 2 | g0 >> 3);
            op[0].blue = (byte)(b0 << 3 | b0 >> 2);

            op[1].red = (byte)(r1 << 3 | r1 >> 2);
            op[1].green = (byte)(g1 << 2 | g1 >> 3);
            op[1].blue = (byte)(b1 << 3 | b1 >> 2);
        }

        internal static void DxtcReadColor(ushort data, ref Colour8888 op)
        {
            byte r, g, b;

            b = (byte)(data & 0x1f);
            g = (byte)((data & 0x7E0) >> 5);
            r = (byte)((data & 0xF800) >> 11);

            op.red = (byte)(r << 3 | r >> 2);
            op.green = (byte)(g << 2 | g >> 3);
            op.blue = (byte)(b << 3 | r >> 2);
        }

        internal static unsafe void DxtcReadColors(byte* data, ref Colour565 color_0, ref Colour565 color_1)
        {
            color_0.blue = (byte)(data[0] & 0x1F);
            color_0.green = (byte)(((data[0] & 0xE0) >> 5) | ((data[1] & 0x7) << 3));
            color_0.red = (byte)((data[1] & 0xF8) >> 3);

            color_0.blue = (byte)(data[2] & 0x1F);
            color_0.green = (byte)(((data[2] & 0xE0) >> 5) | ((data[3] & 0x7) << 3));
            color_0.red = (byte)((data[3] & 0xF8) >> 3);
        }

        internal static Bitmap ToImage(byte[] content)
        {
            using (MemoryStream stream = new MemoryStream(content.Length))
            {
                stream.Write(content, 0, content.Length);
                stream.Seek(0, SeekOrigin.Begin);

                using (BinaryReader reader = new BinaryReader(stream))
                {
                    Dds.Header header = new Dds.Header();
                    byte[] signature = reader.ReadBytes(4);
                    if (!(signature[0] == 'D' && signature[1] == 'D' && signature[2] == 'S' && signature[3] == ' '))
                        return null;

                    header.Size = reader.ReadUInt32();
                    if (header.Size != 124)
                        return null;

                    //convert the data
                    header.Flags = reader.ReadUInt32();
                    header.Height = reader.ReadUInt32();
                    header.Width = reader.ReadUInt32();
                    header.PitchOrLinearSize = reader.ReadUInt32();
                    header.Depth = reader.ReadUInt32();
                    if(header.Depth == 0) header.Depth = 1;
                    header.MipMapCount = reader.ReadUInt32();
                    header.AlphaBitDepth = reader.ReadUInt32();

                    header.Reserved = new uint[10];
                    for (int i = 0; i < 10; i++)
                    {
                        header.Reserved[i] = reader.ReadUInt32();
                    }

                    //pixelfromat
                    header.PF.Size = reader.ReadUInt32();
                    header.PF.Flags = reader.ReadUInt32();
                    header.PF.FourCC = Encoding.ASCII.GetString(reader.ReadBytes(4));
                    header.PF.RgbBitCount = reader.ReadUInt32();
                    header.PF.RBitMask = reader.ReadUInt32();
                    header.PF.GBitMask = reader.ReadUInt32();
                    header.PF.BBitMask = reader.ReadUInt32();
                    header.PF.ABitMask = reader.ReadUInt32();

                    //caps
                    header.Caps1 = reader.ReadUInt32();
                    header.Caps2 = reader.ReadUInt32();
                    header.Caps3 = reader.ReadUInt32();
                    header.Caps4 = reader.ReadUInt32();
                    header.TextureStage = reader.ReadUInt32();
                    byte[] compdata = null;
                    uint compsize = 0;

                    if ((header.Flags & Flags.DDSD_LINEARSIZE) > 1)
                    {
                        compdata = reader.ReadBytes((int)header.PitchOrLinearSize);
                        compsize = (uint)compdata.Length;
                    }
                    else
                    {
                        uint bps = header.Width * header.PF.RgbBitCount / 8;
                        compsize = bps * header.Height * header.Depth;
                        compdata = new byte[compsize];

                        MemoryStream mem = new MemoryStream((int)compsize);

                        byte[] temp;
                        for (int z = 0; z < header.Depth; z++)
                        {
                            for (int y = 0; y < header.Height; y++)
                            {
                                temp = reader.ReadBytes((int)bps);
                                mem.Write(temp, 0, temp.Length);
                            }
                        }
                        mem.Seek(0, SeekOrigin.Begin);

                        mem.Read(compdata, 0, compdata.Length);
                        mem.Close();
                    }
                    if (compdata != null)
                    {
                        byte[] rawData = Decompress.Expand(header, compdata, (uint)TextureClass.NewTextureFormat.BC5);
                        return CreateBitmap((int)header.Width, (int)header.Height, rawData);
                    }
                    return null;
                }
            }
        }

        private static Bitmap CreateBitmap(int width, int height, byte[] rawData)
        {
            var pxFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb;

            Bitmap bitmap = new Bitmap(width, height, pxFormat);

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, pxFormat);
            IntPtr scan = data.Scan0;
            int size = bitmap.Width * bitmap.Height * 4;

            unsafe
            {
                byte* p = (byte*)scan;
                for (int i = 0; i < size; i += 4)
                {
                    // iterate through bytes.
                    // Bitmap stores it's data in RGBA order.
                    // DDS stores it's data in BGRA order.
                    p[i] = rawData[i + 2]; // blue
                    p[i + 1] = rawData[i + 1]; // green
                    p[i + 2] = rawData[i];   // red
                    p[i + 3] = rawData[i + 3]; // alpha
                }
            }

            bitmap.UnlockBits(data);
            return bitmap;
        }
    }
}
