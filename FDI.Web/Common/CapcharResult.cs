using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Mvc;
using FDI.Utils;

namespace Contact
{
    public class CapcharResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var ci = new CaptchaImage { Height = Convert.ToInt32(context.HttpContext.Request.QueryString["height"]), Width = Convert.ToInt32(context.HttpContext.Request.QueryString["width"]) };

            var guid = ci.Text;
            if (context.HttpContext.Session != null) context.HttpContext.Session["RandomCode"] = guid;

            //using (Bitmap b = ci.RenderImage())
            //{
            //    b.Save(context.HttpContext.Response.OutputStream, ImageFormat.Gif);
            //}

            context.HttpContext.Response.ContentType = "image/png";
            context.HttpContext.Response.StatusCode = 200;
            context.HttpContext.Response.StatusDescription = "OK";
            context.HttpContext.ApplicationInstance.CompleteRequest();
        }
    }
}