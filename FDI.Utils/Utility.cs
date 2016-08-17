using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
namespace FDI.Utils
{
    public static class Utility
    {
        private static readonly string[] VietnameseSigns =
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"

        };

        public static int GetIntForm(string key)
        {
            try
            {

                return int.Parse(HttpContext.Current.Request.Form[key]);
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public static string RemoveSign4VietnameseString(this string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (var i = 1; i < VietnameseSigns.Length; i++)
            {

                for (var j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str;

        }

        public static string GetUrlRootPicture(string pictureName)
        { 
            return WebConfig.RootUrlImage + pictureName;
        }
        
        public static string GetUrlOriginalPicture(string pictureName)
        { 
            return WebConfig.UrlOriginalImage + pictureName;
        }
        
        public static string GetUrlPictureMediums(string pictureName)
        {
            
            return WebConfig.UrlImagePromotion + pictureName;

        }
        
        public static string GetUrlPicture(string pictureName)
        {
            
            return WebConfig.UrlImage + pictureName;
        }

        public static string FormatPrice(decimal? price)
        {
            if (price.HasValue && price != 0)
            {
                string result;
                if (price >= 1)
                {
                    result = price.Value.ToString("##.####");
                }
                else
                {
                    result = "0" + price.Value.ToString("##.####");
                }
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        public static string FormatPrice(double? price)
        {
            if (price.HasValue && price != 0)
            {
                string result;
                if (price >= 1)
                {
                    result = price.Value.ToString("##.####");
                }
                else
                {
                    result = "0" + price.Value.ToString("##.####");
                }
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        public static string FormatDecimalPrice(decimal? price)
        {
            if (price.HasValue && price != 0)
            {
                var result = price.Value.ToString("##.####");
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        public static string TrimLength(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                maxLength -= "...".Length;
                maxLength = input.Length < maxLength ? input.Length : maxLength;
                var isLastSpace = input[maxLength] == ' ';
                var part = input.Substring(0, maxLength);
                if (isLastSpace)
                    return part + "...";
                var lastSpaceIndexBeforeMax = part.LastIndexOf(' ');
                if (lastSpaceIndexBeforeMax == -1)
                    return part + "...";
                return input.Substring(0, lastSpaceIndexBeforeMax) + "...";
            }
            return input;
        }

        public static bool CheckChamTraLoiComment(DateTime ngayGuiComment, DateTime? ngayTraLoi)
        {

            if (ngayTraLoi.HasValue)
            {
                var minute = (ngayTraLoi.Value - ngayGuiComment).Minutes;
                var day = (ngayTraLoi.Value - ngayGuiComment).Days;
                var hour = (ngayTraLoi.Value - ngayGuiComment).Hours;


                return minute > 15 || hour > 0 || day > 0;
            }
            else
            {
                var minute = (DateTime.Now - ngayGuiComment).Minutes;
                var day = (DateTime.Now - ngayGuiComment).Days;
                var hour = (DateTime.Now - ngayGuiComment).Hours;
                return minute > 15 || hour > 0 || day > 0;
            }

        }

        public static string FormatPriceVnd(decimal? price)
        {
            if (price.HasValue && price != 0)
            {
                var result = price.Value.ToString("#,#");
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        public static string FormatPriceVnd(double? price)
        {
            if (price.HasValue && price != 0)
            {
                var result = price.Value.ToString("#,#");
                if (result.Contains(","))
                    result = result.Replace(',', '.');
                return result;
            }
            return "0";
        }

        public static string GetBackDate(DateTime date)
        {
            var day = (DateTime.Now - date).Days;
            var hour = (DateTime.Now - date).Hours;
            var minute = (DateTime.Now - date).Minutes;
            var second = (DateTime.Now - date).Seconds;

            var result = second + " giây trước";

            if (minute > 0)
            {
                result = minute + " phút trước";
            }

            if (hour > 0)
            {
                result = hour + " giờ trước";
            }

            if (day > 0)
            {
                result = day + " ngày trước";
            }

            if (day > 30)
            {
                result = "vào ngày " + date.ToString("dd/MM/yyyy");
            }

            return result;
        }

        public static string GetClassHtmlProduct(int labelId)
        {
            var classResult = string.Empty;
            switch (labelId)
            {
                case 1:
                    classResult = "gift";
                    break;
                case 2:
                    classResult = "preorder";
                    break;
                case 3:
                    classResult = "hot";
                    break;
            }
            return classResult;
        }

        public static string GetPublicIp()
        {
            try
            {
                string direction;
                var request = WebRequest.Create("http://checkip.dyndns.org/");
                using (var response = request.GetResponse())
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    direction = stream.ReadToEnd();
                }

                //Search for the ip in the html
                var first = direction.IndexOf("Address: ") + 9;
                var last = direction.LastIndexOf("</body>");
                direction = direction.Substring(first, last - first);

                return direction;
            }
            catch (Exception)
            {
                return "";
            }

        }

        public static string GetIPnew()
        {
            var context = HttpContext.Current;
            var ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                var addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static void SendEmail(string emailToAddress, string userName, string providerName, string password)
        {
            const string emailFromAddress = "frt.contact";
            const string emailSubject = "Tài khoản và mật khẩu từ ";
            var emailBody = "Xin chào bạn " + userName + " ,\n Bạn vừa đăng nhập vào FptShop bằng dịch vụ " + providerName + ",\n Chúng tôi đã tạo cho bạn một tài khoản mặc " +
                                     "định với username:" + emailToAddress + ",password:" + password + ".\n" +
                                     "Bạn có thể đăng nhập vào tài khoản được cấp để thay đổi thông tin cá nhân.\n Xin chân thành cảm ơn.";
            const int portServer = 587;

            try
            {
                var mailMessage = new MailMessage();
                var smtpServer = new SmtpClient("mail.fpt.com.vn");

                mailMessage.From = new MailAddress(emailFromAddress);
                mailMessage.To.Add(emailToAddress);
                mailMessage.Subject = emailSubject;
                mailMessage.Body = emailBody;

                smtpServer.Port = portServer;
                smtpServer.Credentials = new NetworkCredential("frt.contact@fpt.com.vn", "online123");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SendEmail(string email, string userName, string pass)
        {
            const string emailFromAddress = "frt.contact";
            const string emailSubject = "Tài khoản và mật khẩu từ ";
            var emailBody = "Xin chào bạn " + userName + ".\nEmail của bạn dường như chưa tồn tại trong hệ thống tài khoản của chúng tôi." +
                            "Để thuận lợi cho việc đăng nhập chúng tôi đã tạo cho bạn một tài khoản mặc định với email của bạn.\n" +
                            "Username:" + email + ",Password:" + pass + ".\n" +
                            "Bạn có thể đăng nhập vào tài khoản được cấp để thay đổi thông tin cá nhân.\nXin chân thành cảm ơn.";
            const int portServer = 587;
            const string smtpServer = "mail.fpt.com.vn";

            try
            {
                var mailMessage = new MailMessage();
                var smtpServerClient = new SmtpClient(smtpServer);

                mailMessage.From = new MailAddress(emailFromAddress);
                mailMessage.To.Add(email);
                mailMessage.Subject = emailSubject;
                mailMessage.Body = emailBody;

                smtpServerClient.Port = portServer;
                smtpServerClient.Credentials = new NetworkCredential("frt.contact@fpt.com.vn", "online123");
                smtpServerClient.EnableSsl = true;

                smtpServerClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static string TrimSpecialCharacterPhone(string numberPhone)
        {
            var returnStringNumber = numberPhone.Select((t, i) => numberPhone.ElementAt(i)).Where(c => c != '-').Aggregate("", (current, c) => current + c);
            return returnStringNumber;
        }

        public static string CreateRandomKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[15];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            // Has 18 character.
            var tickOfTime = DateTime.Now.Ticks.ToString();

            // Has 2 character.
            var date = string.Format("{0:ss}", DateTime.Now);

            date = date.Replace(":", String.Empty);

            // Has 35 character.
            var key = finalString + date + tickOfTime;
            return key;
        }

        public static string CreateRandomKey(string email)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[3];
            var emailChars = new char[3];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            email = email.Replace("@", string.Empty);
            email = email.Replace(".", string.Empty);

            for (var e = 0; e < emailChars.Length; e++)
            {
                emailChars[e] = email[random.Next(email.Length)];
            }

            var emailArrayNews = new String(emailChars);

            var pass = emailArrayNews + finalString + string.Format("{0:mm:ss}", DateTime.Now);

            pass = pass.Replace(":", string.Empty);

            return pass;
        }
    }
}
