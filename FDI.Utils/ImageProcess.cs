using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace FDI.Utils
{
    public static class ImageProcess
    {
        public static Image CropImage(Image img, Rectangle cropArea)
        {
            var bmpImage = new Bitmap(img);
            var bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return bmpCrop;
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            var sourceWidth = imgToResize.Width;
            var sourceHeight = imgToResize.Height;

            var nPercentW = (size.Width / (float)sourceWidth);
            var nPercentH = (size.Height / (float)sourceHeight);

            var nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var b = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.Clear(Color.White);
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }

        public static Image ResizeImagebackgroupWhite(Image imgToResize, Size size)
        {
            
            var destWidth = imgToResize.Width;
            var destHeight = imgToResize.Height;

            var b = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.Clear(Color.White);
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }

        public static void CreateForder(string link)
        {
            //link = ConfigData.IMAGE_UPLOAD_THUMBS_FOLDER;
            var forderyear = link + DateTime.Now.Year;
            var fordermonth = forderyear + "\\" + DateTime.Now.Month;
            var forderdate = fordermonth + "\\" + DateTime.Now.Day;
            if (!Directory.Exists(forderyear))
            {
                Directory.CreateDirectory(forderyear);
                Directory.CreateDirectory(fordermonth);
                Directory.CreateDirectory(forderdate);
            }
            else
            {
                if (!Directory.Exists(fordermonth))
                {
                    Directory.CreateDirectory(fordermonth);
                    Directory.CreateDirectory(forderdate);
                }
                else
                {
                    if (!Directory.Exists(forderdate))
                    {
                        Directory.CreateDirectory(forderdate);
                    }
                }
            }
        }

        public static void SaveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality
            var qualityParam =
                new EncoderParameter(Encoder.Quality, quality);

            // Jpeg image codec
            var jpegCodec = GetEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            var codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            return codecs.FirstOrDefault(t => t.MimeType == mimeType);
        }
    }
}
