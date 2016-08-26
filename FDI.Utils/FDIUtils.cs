using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace FDI.Utils
{
    public static class FDIUtils
    {
        public static List<int> StringToListInt(string source)
        {
            var lst = new List<int>();
            if (string.IsNullOrEmpty(source)) return lst;
            lst = source.Split(',').Select(int.Parse).ToList();
            return lst;
        }

        public static string FormatBytes(int bytes)
        {
            const int scale = 1024;
            var orders = new[] { "GB", "MB", "KB", "Bytes" };
            var max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (var order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }

        public static string GetYoutubeId(string source)
        {
            if (source.IndexOf("?v=", StringComparison.Ordinal) < 0)
                return string.Empty;
            var start = source.IndexOf("?v=", StringComparison.Ordinal) + 3;
            var end = source.IndexOf("&", StringComparison.Ordinal) < 0 ? source.Length : source.IndexOf("&", StringComparison.Ordinal);
            return source.Substring(start, end - start);
        }

        public static string GetYoutubeLink(string source)
        {
            if (source.IndexOf("?v=") < 0)
                return string.Empty;
            const string temp = "http://www.youtube.com/v/";
            return temp + GetYoutubeId(source);
        }

        public static string GetPercent(int voteCount, int totalVote)
        {
            try
            {
                var value = ((double)voteCount / totalVote);
                return (value.ToString("0.0%") == "NaN") ? "0" : value.ToString("0.0%");
            }
            catch { return string.Empty; }
        }

        public static string GetDataVoteWidthCss(int voteCount, int totalVote)
        {
            try
            {
                var value = ((double)voteCount / totalVote);
                return (value.ToString("0.0%") == "NaN") ? "0" : value.ToString("0.0%").Replace("%", "");
            }
            catch { return string.Empty; }
        }

        // add substring product name
        public static string GetSubstringName(string name)
        {
            const int lengthName = 30;
            return name.Length < lengthName ? name : name.Substring(0, lengthName);
        }

        /// <summary>
        /// Lấy về danh sách ID
        /// </summary>
        /// <param name="arrId"></param>
        /// <returns></returns>
        public static List<int> GetDanhSachIDsQuaFormPost(string arrId)
        {
            var dsId = new List<int>();
            if (!string.IsNullOrEmpty(arrId)) // Nếu không rỗng
            {
                if (arrId.IndexOf(',') > 0) //nếu nhiều hơn 1
                {
                    var tempIDs = arrId.Split(',');
                    dsId.AddRange(tempIDs.Select(idConvert => Convert.ToInt32(idConvert)));
                }
                else
                    dsId.Add(Convert.ToInt32(arrId));
            }
            return dsId;
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                var length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                var sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu
        /// </summary>
        /// <param name="unicode">xâu tiếng việt có dấu</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013      Tạo mới
        /// </Modified>
        public static string UnicodeToAscii(string unicode)
        {
            unicode = Regex.Replace(unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+]", "", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[^A-Za-z0-9-]", "");

            return unicode;
        }

        public static string NewUnicodeToAscii(string unicode)
        {
            unicode = Regex.Replace(unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–]", "", RegexOptions.IgnoreCase);

            return unicode;
        }

        public static string RemoveSpecialCharacter(string unicode)
        {
            unicode = Regex.Replace(unicode, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–]", "-", RegexOptions.IgnoreCase);

            return unicode;
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu (không bỏ dấu cách)
        /// </summary>
        /// <param name="unicode">xâu tiếng việt có dấu</param>
        public static string UnicodeToEng(string unicode)
        {
            unicode = Regex.Replace(unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);


            return unicode;
        }

        /// <summary>
        /// Hàm chuyển một chuỗi tiếng việt có dấu thành tiếng việt không dấu (không bỏ dấu cách) - chuyển dấu,->cách
        /// </summary>
        /// <param name="unicode">xâu tiếng việt có dấu</param>
        public static string UnicodeToEngSearch(string unicode)
        {
            unicode = Regex.Replace(unicode, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[ ,]", " ", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[, ]", " ", RegexOptions.IgnoreCase);
            unicode = Regex.Replace(unicode, "[,]", " ", RegexOptions.IgnoreCase);

            return unicode;
        }
        /// <summary>
        /// hàm Conver rewrite url
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        public static string Slug(string unicode)
        {
            unicode = NewUnicodeToAscii(unicode);
            unicode = unicode.ToLower().Trim();
            unicode = Regex.Replace(unicode, @"\s+", " ");
            unicode = Regex.Replace(unicode, "[\\s]", "-");
            unicode = Regex.Replace(unicode, @"-+", "-");
            return unicode;
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) { return value; }

            return value.Substring(0, Math.Min(value.Length, maxLength));
        }

        /// <summary>
        /// Hàm tạo Mã SHA1 lấy từ hệ thống cũ
        /// Name		Date		    Comment         
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string CreateSaltKey(int size)
        {
            // Generate a cryptographic random number
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public static string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1")
        {
            if (String.IsNullOrEmpty(passwordFormat))
                passwordFormat = "SHA1";
            var saltAndPassword = String.Concat(password, saltkey);
            var hashedPassword =
                FormsAuthentication.HashPasswordForStoringInConfigFile(
                    saltAndPassword, passwordFormat);
            return hashedPassword;
        }

        public static string GetMd5Sum(string str)
        {
            str = str + "FDI@2016";
            var enc = Encoding.Unicode.GetEncoder();
            var unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            var result = md5.ComputeHash(unicodeText);
            var sb = new StringBuilder();
            foreach (var t in result)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string Md5ByPhp(string password)
        {
            var textBytes = Encoding.Default.GetBytes(password);
            var cryptHandler = new MD5CryptoServiceProvider();
            var hash = cryptHandler.ComputeHash(textBytes);
            var ret = "";
            foreach (var a in hash)
            {
                if (a < 16)
                    ret += "0" + a.ToString("x");
                else
                    ret += a.ToString("x");
            }
            return ret;
        }
        /// <summary>
        /// Hàm tạo mã hóa của hệ thống Service
        /// DongDT
        /// 04/03/2014 
        /// </summary>
        /// <param name="clearData"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] clearData, byte[] key, byte[] iv)
        {
            // Create a MemoryStream to accept the encrypted bytes 
            var ms = new MemoryStream();
            var alg = Rijndael.Create();
            alg.Key = key;
            alg.IV = iv;
            var cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            var encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static string Encrypt1(string userName, string password)
        {
            var clearBytes =
              Encoding.Unicode.GetBytes(userName);
            var pdb = new PasswordDeriveBytes(password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            var encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        private const string PassPhrase = "k";

        public static string Encrypt(string plainText)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(PassPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        public static string Decrypt(string cipherText)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();
            using (var password = new Rfc2898DeriveBytes(PassPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        public static string CreateRandomKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            var key = finalString;
            return key;
        }

        public static string CreateRandom(string name)
        {
            var stringdate = DateTime.Now.ToString("ddMMyy");
            const string chars = "0123456789";
            var stringChars = new char[4];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            var key = stringdate + name + finalString;
            return key;
        }

        /// <summary>
        /// Xóa thẻ HTML
        /// </summary>
        /// <param name="source">xâu có chứa HTML</param>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// TuNT        13/09/2013    Tạo mới
        /// LinhTX      13/01/2014    Check null
        /// </Modified>
        public static string RemoveHtmlTag(string source)
        {
            if (string.IsNullOrEmpty(source) == false)
            {
                return Regex.Replace(source, "<.*?>", "");
            }
            return string.Empty;
        }

        public static string RemoveAscii(string source)
        {
            return Regex.Replace(RemoveHtmlTag(source), @"\t*\n*\r*\s*", "");
        }

        /// <summary>
        /// get small hightlightsDes default three line
        /// </summary>
        /// <param name="hightlightsDes"></param>
        /// <returns></returns>
        public static string GetSmallHightlightsShortDes(string hightlightsDes)
        {
            var result = hightlightsDes;
            if (!string.IsNullOrEmpty(hightlightsDes))
            {
                var regex = new Regex(@"<\s*li[^>]*>(.*?)<\s*/li\s*>", RegexOptions.IgnoreCase);
                var collection = regex.Matches(Regex.Replace(hightlightsDes, @"\t*\n*\r*", ""));
                if (collection.Count > 0)
                {
                    result = "<div class='hightlight-des'><ul>";
                    for (var i = 0; i < collection.Count; i++)
                    {
                        if (i < 3)
                        {
                            result += "<li>" + collection[i].Groups[1].Value + "</li>";
                        }
                    }
                    result += "</ul></div>";
                }
            }

            return result;
        }

        /// <summary> 
        /// boi dam tu khoa trong ket qua tim kiem
        /// </summary>
        /// <datemodified> 14-Jan-2014 </datemodified>
        /// <param name="source">result search</param>
        /// <param name="keyword">keyword search</param>
        /// <returns>string</returns>
        public static string ReplaceSuggestKeyword(string source, string keyword)
        {
            if (string.IsNullOrEmpty(source) == false)
            {
                source = source.ToLower();
                keyword = keyword.ToLower();

                return source.Replace(keyword, "<b>" + keyword + "</b>");
            }
            return string.Empty;
        }

        public static string GetFileExtend(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal));
        }

        public static string GetFileNameNoneExtent(string fileName)
        {
            return fileName.Substring(0, fileName.LastIndexOf(".", StringComparison.Ordinal));
        }

        /// <summary>
        /// add by BienLV 18-12-2013
        /// get random string
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string RandomString(int size)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        /// <summary>
        /// Hàm render ra AutoTag
        /// </summary>
        /// <param name="containerName">Tên container cần render</param>
        /// <param name="valuesSelected">Giá trị đã selected</param>
        /// <returns></returns>
        public static string GetHtmlAuToTag(string containerName, List<ListItem> valuesSelected)
        {
            var stbBuilder = new StringBuilder();
            stbBuilder.AppendFormat("					<input type=\"hidden\" name=\"{0}\" id=\"{0}\"/>", containerName);
            stbBuilder.AppendFormat("                    <input type=\"text\" name=\"{0}_Input\" id=\"{0}_Input\" value=\"Nhập vào từ khóa để tìm kiếm, nhấn enter để xác nhận !\" onblur=\"if(this.value=='') this.value='Nhập vào từ khóa để tìm kiếm, nhấn enter để xác nhận !';\" onfocus=\"if(this.value=='Nhập vào từ khóa để tìm kiếm, nhấn enter để xác nhận !') this.value='';\" />", containerName);
            stbBuilder.AppendFormat("                    <ul id=\"{0}_Value\" class=\"{0} listValues\">", containerName);

            foreach (var item in valuesSelected)
            {
                stbBuilder.AppendFormat("                            <li id=\"{0}_Value{1}\" name=\"{1}\" key=\"\">", containerName, item.ID);
                stbBuilder.AppendFormat("                                <span>{0}</span><a href=\"javascript:deletevalues('{1}_Value{2}');\">", item.Title, containerName, item.ID);
                stbBuilder.AppendFormat("                                <img border=\"0\" src=\"/Content/Admin/images/gridview/act_filedelete.png\" /></a>");
                stbBuilder.AppendFormat("                            </li>");
            }
            stbBuilder.AppendFormat("                    </ul>");
            return stbBuilder.ToString();
        }

        public static string Divide(decimal giamoi, decimal giacu)
        {

            var ketqua = "giảm " + Convert.ToString((int)(((giamoi - giacu) / giamoi) * 100)) + "% so với máy mới";


            return ketqua;
        }

        public static void CheckTime(string control, int time)
        {
            var file = !File.Exists(@"D:\TimeCheck.txt") ? new FileStream(@"D:\TimeCheck.txt", FileMode.CreateNew, FileAccess.Write) : new FileStream(@"D:\TimeCheck.txt", FileMode.Append, FileAccess.Write);
            var sw = new StreamWriter(file);
            sw.WriteLine(control + ":" + time);
            sw.WriteLine();
            sw.Close();
            file.Close();
        }
    }
}
