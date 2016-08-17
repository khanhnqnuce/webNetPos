using System;
using System.Drawing;

namespace FDI.Utils
{
    public class CaptchaImage
    {
        public CaptchaImage()
        {
            
        }

        public static BackgroundNoiseLevel BackgroundNoise { get; set; }
        public static double CacheTimeOut { get; set; }
        public static FontWarpFactor FontWarp { get; set; }
        public int Height { get; set; }
        public static LineNoiseLevel LineNoise { get; set; }
        public DateTime RenderedAt { get; set; }
        public string Text { get; set; }
        public static string TextChars { get; set; }
        public static int TextLength { get; set; }
        public string UniqueId { get; set; }
        public int Width { get; set; }

        //public static CaptchaImage GetCachedCaptcha(string guid);
        //public Bitmap RenderImage();
    }
}
