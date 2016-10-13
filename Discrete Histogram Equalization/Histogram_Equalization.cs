using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Discrete_Histogram_Equalization
{
    class Histogram_Equalization :Form1
    {
        static int[,,] Image_Pixel;
        static int Image_Height, Image_Width;
        public static void Handle(string FilePath,PictureBox Source,PictureBox Answer)
        {
            Bitmap Source_Image = new Bitmap(FilePath);
            Source.Image = Source_Image;
            Image_Pixel = GetRGBData(Source_Image);
            Image_Height = Source_Image.Height;
            Image_Width = Source_Image.Width;
            int[,] Pixel_Count = new int[3, 256];
            Recolor(Count_Correspond(Count_Pixel_Times()));
            Answer.Image = SetRGBData(Image_Pixel);
        }

        //Get and Set image RGB
        private static int[,,] GetRGBData(Bitmap bitImg)
        {
            int height = bitImg.Height;
            int width = bitImg.Width;
            //locking
            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            // get the starting memory place
            IntPtr imgPtr = bitmapData.Scan0;
            //scan width
            int stride = bitmapData.Stride;
            //scan ectual
            int widthByte = width * 3;
            // the byte num of padding
            int skipByte = stride - widthByte;
            //set the place to save values
            int[,,] rgbData = new int[height, width, 3];
            #region
            unsafe//專案－＞屬性－＞建置－＞容許Unsafe程式碼須選取。
            {
                byte* p = (byte*)(void*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        //B channel
                        rgbData[j, i, 2] = p[0];
                        p++;
                        //g channel
                        rgbData[j, i, 1] = p[0];
                        p++;
                        //R channel
                        rgbData[j, i, 0] = p[0];
                        p++;
                    }
                    p += skipByte;
                }
            }
            bitImg.UnlockBits(bitmapData);
            #endregion
            return rgbData;
        }
        private static Bitmap SetRGBData(int[,,] rgbData)
        {
            //宣告Bitmap變數
            Bitmap bitImg;
            int width = rgbData.GetLength(1);
            int height = rgbData.GetLength(0);

            //依陣列長寬設定Bitmap新的物件
            bitImg = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            //鎖住Bitmap整個影像內容
            BitmapData bitmapData = bitImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            //取得影像資料的起始位置
            IntPtr imgPtr = bitmapData.Scan0;
            //影像scan的寬度
            int stride = bitmapData.Stride;
            //影像陣列的實際寬度
            int widthByte = width * 3;
            //所Padding的Byte數
            int skipByte = stride - widthByte;

            #region 設定RGB資料
            //注意C#的GDI+內的影像資料順序為BGR, 非一般熟悉的順序RGB
            //因此我們把順序調回GDI+的設定值, RGB->BGR
            unsafe
            {
                byte* p = (byte*)(void*)imgPtr;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        //B Channel
                        p[0] = (byte)rgbData[j, i, 2];
                        p++;
                        //G Channel
                        p[0] = (byte)rgbData[j, i, 1];
                        p++;
                        //B Channel
                        p[0] = (byte)rgbData[j, i, 0];
                        p++;
                    }
                    p += skipByte;
                }
            }

            //解開記憶體鎖
            bitImg.UnlockBits(bitmapData);

            #endregion

            return bitImg;
        }


        //Count each RGB times.
        private static int[,] Count_Pixel_Times()
        {
            int[,] Temp_Count = new int[3, 256];

            for (int Index_Hieght = 0; Index_Hieght < Image_Height; Index_Hieght++)
                for (int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                        Temp_Count[Index_RGB, Image_Pixel[Index_Hieght, Index_Width, Index_RGB]]++;
            return Temp_Count;
        }

        //Count correspond Color pixel.
        private static List<Dictionary<int,int>> Count_Correspond(int[,]Piexl_Times)
        {
            int[,] RGB_CDF = new int[3,256];
            for (int Index_Color = 0; Index_Color < 3; Index_Color++)
            {
                RGB_CDF[Index_Color, 0] = Piexl_Times[Index_Color, 0];
                for (int Index_Pixel = 1; Index_Pixel < 256; Index_Pixel++)
                    RGB_CDF[Index_Color, Index_Pixel] = Piexl_Times[Index_Color, Index_Pixel] + RGB_CDF[Index_Color, Index_Pixel - 1];
            }
                
            //Count correspond number.
            List<Dictionary<int, int>> Temp_Equalized = new List<Dictionary<int, int>>();
            for (int Index_Color = 0; Index_Color < 3; Index_Color++)
            {
                Dictionary<int, int> OneColor_Equalized = new Dictionary<int, int>();
                double Rnage = RGB_CDF[Index_Color,255] - Piexl_Times[Index_Color, 0];
                for(int Index_Piexl = 0; Index_Piexl < 256; Index_Piexl++)
                {
                    int Nes_Piexl = Convert.ToInt32( Math.Round(Convert.ToDouble(RGB_CDF[Index_Color, Index_Piexl]- RGB_CDF[Index_Color, 0])*255/ Rnage, MidpointRounding.AwayFromZero));
                    OneColor_Equalized.Add(Index_Piexl, Nes_Piexl);
                }
                Temp_Equalized.Add(OneColor_Equalized);
            }
            return Temp_Equalized;
        }
         
        //Recolor
        private static void Recolor(List<Dictionary<int, int>> Correspond)
        {
            for (int Index_Color = 0; Index_Color < 3; Index_Color++)
                for (int Index_Hieght = 0; Index_Hieght < Image_Height; Index_Hieght++)
                    for (int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
                        Image_Pixel[Index_Hieght, Index_Width, Index_Color] = Correspond[Index_Color][Image_Pixel[Index_Hieght, Index_Width, Index_Color]];
        }
    }
}
