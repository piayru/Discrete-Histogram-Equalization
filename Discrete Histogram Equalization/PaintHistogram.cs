using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Discrete_Histogram_Equalization
{
    class PaintHistogram
    {
        static int[,,] Image_Pixel,Source_Pixel;
        static int Image_Height, Image_Width;
        static int[] Max_RGB = new int[3];
        static int Paint_Start_x = 25, Paint_Start_y = 275;
        
        public static void Paint_Source(string FilePath,PictureBox Source,int Index)
        {
            Bitmap Base_Image = new Bitmap("..//..//..//Histogram.jpg");
            Bitmap Source_Image = new Bitmap(FilePath);
            Image_Pixel = GetRGBData(Base_Image);
            Source_Pixel = GetRGBData(Source_Image);
            Image_Height = Source_Image.Height;
            Image_Width = Source_Image.Width;
            Initial_Bar();
            
            Paint_Color_Number(Image_Pixel, Count_Pixel_Times(Source_Pixel), Index);
            Source.Image = Base_Image = SetRGBData(Image_Pixel);
        }

        public static void Paint_Answer(string FilePath, PictureBox Source, PictureBox Answer, int Index)
        {
            Bitmap Base_Image = new Bitmap("..//..//..//Histogram.jpg");
            Bitmap Source_Image = new Bitmap(Answer.Image);
            Image_Pixel = GetRGBData(Base_Image);
            Source_Pixel = GetRGBData(Source_Image);
            Image_Height = Source_Image.Height;
            Image_Width = Source_Image.Width;
            Initial_Bar();

            Paint_Color_Number(Image_Pixel, Count_Pixel_Times(Source_Pixel), Index);
            Source.Image = Base_Image = SetRGBData(Image_Pixel);
        }

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
        private static int[,] Count_Pixel_Times(int[,,] Image_Pixel)
        {
            int[,] Temp_Count = new int[3, 256];

            for (int Index_Hieght = 0; Index_Hieght < Image_Height; Index_Hieght++)
                for (int Index_Width = 0; Index_Width < Image_Width; Index_Width++)
                    for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                        Temp_Count[Index_RGB, Image_Pixel[Index_Hieght, Index_Width, Index_RGB]]++;

            for (int Index_Pixel = 0; Index_Pixel < 256; Index_Pixel++)
                for (int Index_RGB = 0; Index_RGB < 3; Index_RGB++)
                {
                    if (Max_RGB[Index_RGB] < Temp_Count[Index_RGB, Index_Pixel])
                        Max_RGB[Index_RGB] = Temp_Count[Index_RGB, Index_Pixel];
                }
            return Temp_Count;
        }
        private static void Initial_Bar()
        {
            //paint X bar
            for (int Index_X = 0; Index_X < 256; Index_X++)
            {
                Image_Pixel[Paint_Start_y, Paint_Start_x + Index_X, 0] = 0;
                Image_Pixel[Paint_Start_y, Paint_Start_x + Index_X, 1] = 0;
                Image_Pixel[Paint_Start_y, Paint_Start_x + Index_X, 2] = 0;
            }
            //paint Y bar
            for (int Index_Y = 0; Index_Y < 250; Index_Y++)
            {
                Image_Pixel[Paint_Start_x + Index_Y, Paint_Start_x, 0] = 0;
                Image_Pixel[Paint_Start_x + Index_Y, Paint_Start_x, 1] = 0;
                Image_Pixel[Paint_Start_x + Index_Y, Paint_Start_x, 2] = 0;
            }
        }
        private static void Paint_Color_Number(int[,,] Target, int[,] Pixel_Times,int Index)
        {
            for(int Index_Pixel = 0;Index_Pixel < 256; Index_Pixel++)
            {
                int One_Piexl_Height = Convert.ToInt32(Math.Round((Convert.ToDouble(Pixel_Times[Index, Index_Pixel]) * 255 / Convert.ToDouble(Max_RGB[Index])), MidpointRounding.AwayFromZero) );
                for (int Index_OnePixel = 0; Index_OnePixel < One_Piexl_Height; Index_OnePixel++)
                {
                    Target[Paint_Start_y - 1 - Index_OnePixel, Paint_Start_x + Index_Pixel + 1, 0] = 0;
                    Target[Paint_Start_y - 1 - Index_OnePixel, Paint_Start_x + Index_Pixel + 1, 1] = 0;
                    Target[Paint_Start_y - 1 - Index_OnePixel, Paint_Start_x + Index_Pixel + 1, 2] = 0;

                    Target[Paint_Start_y - 1 - Index_OnePixel, Paint_Start_x + Index_Pixel + 1, Index] = Index_Pixel;
                }
                    
            }
                
        }
    }
}
