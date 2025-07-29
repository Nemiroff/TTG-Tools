/*
 * Статьи для изучения декодинга
 * https://docs.microsoft.com/en-us/windows/win32/direct3d11/bc6h-format
 * https://docs.microsoft.com/en-us/windows/win32/direct3d11/bc7-format
 * 
 * https://github.com/Toneygames/gimp-dds
 * */

using TTG_Tools.ClassesStructs;
using static TTG_Tools.Graphics.DDS.Dds;

namespace TTG_Tools.Graphics.DDS
{
    static class Decompress
    {
        internal static byte[] Expand(Dds.Header header, byte[] data, uint pixelFormat)
        {
            // allocate bitmap
            byte[] rawData = null;

            switch (pixelFormat)
            {
                case (uint)TextureClass.NewTextureFormat.BC5:
                    rawData = DecompressDXT5(header, data, pixelFormat);
                    break;
                /*case PixelFormat.RGBA:
                    rawData = DecompressRGBA(header, data, pixelFormat);
                    break;
                case PixelFormat.RGB:
                    rawData = DecompressRGB(header, data, pixelFormat);
                    break;
                case PixelFormat.LUMINANCE:
                case PixelFormat.LUMINANCE_ALPHA:
                    rawData = DecompressLum(header, data, pixelFormat);
                    break;
                case PixelFormat.DXT1:
                    rawData = DecompressDXT1(header, data, pixelFormat);
                    break;
                case PixelFormat.DXT2:
                    rawData = DecompressDXT2(header, data, pixelFormat);
                    break;
                case PixelFormat.DXT3:
                    rawData = DecompressDXT3(header, data, pixelFormat);
                    break;
                case PixelFormat.DXT4:
                    rawData = DecompressDXT4(header, data, pixelFormat);
                    break;
                case PixelFormat.DXT5:
                    rawData = DecompressDXT5(header, data, pixelFormat);
                    break;
                case PixelFormat.THREEDC:
                    rawData = Decompress3Dc(header, data, pixelFormat);
                    break;
                case PixelFormat.ATI1N:
                    rawData = DecompressAti1n(header, data, pixelFormat);
                    break;
                case PixelFormat.RXGB:
                    rawData = DecompressRXGB(header, data, pixelFormat);
                    break;
                case PixelFormat.R16F:
                case PixelFormat.G16R16F:
                case PixelFormat.A16B16G16R16F:
                case PixelFormat.R32F:
                case PixelFormat.G32R32F:
                case PixelFormat.A32B32G32R32F:
                    rawData = DecompressFloat(header, data, pixelFormat);
                    break;
                */
                default:
                    break;
            }
            return rawData;
        }

        private static unsafe byte[] DecompressDXT5(Dds.Header header, byte[] data, uint pixelFormat)
        {
            // allocate bitmap
            int bpp = (int)(SomeActions.PixelFormatToBpp(pixelFormat, header.PF.RgbBitCount));
            int bps = (int)(header.Width * bpp * SomeActions.PixelFormatToBpc(pixelFormat));
            int sizeofplane = (int)(bps * header.Height);
            int width = (int)header.Width;
            int height = (int)header.Height;
            int depth = (int)header.Depth;

            byte[] rawData = new byte[depth * sizeofplane + height * bps + width * bpp];
            Colour8888[] colours = new Colour8888[4];
            ushort[] alphas = new ushort[8];

            fixed (byte* bytePtr = data)
            {
                byte* temp = bytePtr;
                for (int z = 0; z < depth; z++)
                {
                    for (int y = 0; y < height; y += 4)
                    {
                        for (int x = 0; x < width; x += 4)
                        {
                            if (y >= height || x >= width) break;

                            alphas[0] = temp[0];
                            alphas[1] = temp[1];
                            byte* alphamask = (temp + 2);
                            temp += 8;

                            SomeActions.DxtcReadColors(temp, ref colours);
                            uint bitmask = ((uint*)temp)[1];
                            temp += 8;

                            // Four-color block: derive the other two colors.
                            // 00 = color_0, 01 = color_1, 10 = color_2, 11	= color_3
                            // These 2-bit codes correspond to the 2-bit fields
                            // stored in the 64-bit block.
                            colours[2].blue = (byte)((2 * colours[0].blue + colours[1].blue + 1) / 3);
                            colours[2].green = (byte)((2 * colours[0].green + colours[1].green + 1) / 3);
                            colours[2].red = (byte)((2 * colours[0].red + colours[1].red + 1) / 3);
                            //colours[2].alpha = 0xFF;

                            colours[3].blue = (byte)((colours[0].blue + 2 * colours[1].blue + 1) / 3);
                            colours[3].green = (byte)((colours[0].green + 2 * colours[1].green + 1) / 3);
                            colours[3].red = (byte)((colours[0].red + 2 * colours[1].red + 1) / 3);
                            //colours[3].alpha = 0xFF;

                            int k = 0;
                            for (int j = 0; j < 4; j++)
                            {
                                for (int i = 0; i < 4; k++, i++)
                                {
                                    int select = (int)((bitmask & (0x03 << k * 2)) >> k * 2);
                                    Colour8888 col = colours[select];
                                    // only put pixels out < width or height
                                    if (((x + i) < width) && ((y + j) < height))
                                    {
                                        uint offset = (uint)(z * sizeofplane + (y + j) * bps + (x + i) * bpp);
                                        rawData[offset] = (byte)col.red;
                                        rawData[offset + 1] = (byte)col.green;
                                        rawData[offset + 2] = (byte)col.blue;
                                    }
                                }
                            }

                            // 8-alpha or 6-alpha block?
                            if (alphas[0] > alphas[1])
                            {
                                // 8-alpha block:  derive the other six alphas.
                                // Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
                                alphas[2] = (ushort)((6 * alphas[0] + 1 * alphas[1] + 3) / 7); // bit code 010
                                alphas[3] = (ushort)((5 * alphas[0] + 2 * alphas[1] + 3) / 7); // bit code 011
                                alphas[4] = (ushort)((4 * alphas[0] + 3 * alphas[1] + 3) / 7); // bit code 100
                                alphas[5] = (ushort)((3 * alphas[0] + 4 * alphas[1] + 3) / 7); // bit code 101
                                alphas[6] = (ushort)((2 * alphas[0] + 5 * alphas[1] + 3) / 7); // bit code 110
                                alphas[7] = (ushort)((1 * alphas[0] + 6 * alphas[1] + 3) / 7); // bit code 111
                            }
                            else
                            {
                                // 6-alpha block.
                                // Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
                                alphas[2] = (ushort)((4 * alphas[0] + 1 * alphas[1] + 2) / 5); // Bit code 010
                                alphas[3] = (ushort)((3 * alphas[0] + 2 * alphas[1] + 2) / 5); // Bit code 011
                                alphas[4] = (ushort)((2 * alphas[0] + 3 * alphas[1] + 2) / 5); // Bit code 100
                                alphas[5] = (ushort)((1 * alphas[0] + 4 * alphas[1] + 2) / 5); // Bit code 101
                                alphas[6] = 0x00; // Bit code 110
                                alphas[7] = 0xFF; // Bit code 111
                            }

                            // Note: Have to separate the next two loops,
                            // it operates on a 6-byte system.

                            // First three bytes
                            //uint bits = (uint)(alphamask[0]);
                            uint bits = (uint)((alphamask[0]) | (alphamask[1] << 8) | (alphamask[2] << 16));
                            for (int j = 0; j < 2; j++)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    // only put pixels out < width or height
                                    if (((x + i) < width) && ((y + j) < height))
                                    {
                                        uint offset = (uint)(z * sizeofplane + (y + j) * bps + (x + i) * bpp + 3);
                                        rawData[offset] = (byte)alphas[bits & 0x07];
                                    }
                                    bits >>= 3;
                                }
                            }

                            // Last three bytes
                            //bits = (uint)(alphamask[3]);
                            bits = (uint)((alphamask[3]) | (alphamask[4] << 8) | (alphamask[5] << 16));
                            for (int j = 2; j < 4; j++)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    // only put pixels out < width or height
                                    if (((x + i) < width) && ((y + j) < height))
                                    {
                                        uint offset = (uint)(z * sizeofplane + (y + j) * bps + (x + i) * bpp + 3);
                                        rawData[offset] = (byte)alphas[bits & 0x07];
                                    }
                                    bits >>= 3;
                                }
                            }
                        }
                    }
                }
            }
            return rawData;
        }

    }
}
