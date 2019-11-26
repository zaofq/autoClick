using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace ZMECG
{
    static class CutImageClass
    {
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(
            string lpszDriver,
            string lpszDevice,
            string lpszoutput,
            IntPtr lpdate);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(
            IntPtr hdcDest,
            int x,
            int y,
            int width,
            int height,
            IntPtr hdcsrc,
            int xsrc,
            int ysrc,
            System.Int32 dw);

        public static Bitmap GetImage(int x,int y,int width,int height)
        {/*
           IntPtr dc1 = CreateDC("display", null, null, (IntPtr)null);
            Graphics g1 = Graphics.FromHdc(dc1);
           // Graphics g1 = g;
            Bitmap my=new Bitmap(width,height,g1);
            Graphics g2 = Graphics.FromImage(my);
            IntPtr dc3 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, x, y, width, height, dc3, 0, 0, 13369376);
            g1.ReleaseHdc(dc3);
            g2.ReleaseHdc(dc2);
            */
            System.Drawing.Bitmap bitmap = new Bitmap(width , height);
            using (System.Drawing.Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width , height));
            }
            return bitmap;
        }
    }
}
