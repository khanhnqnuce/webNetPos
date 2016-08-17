using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using FDI.Simple;

namespace FDI
{
    public class Utility
    {
        static readonly Assembly Asm = Assembly.GetExecutingAssembly();

        public static List<string> GetSectsion(string layout)
        {
            var fileContents = File.ReadAllText(Path.Combine(HttpContext.Current.Server.MapPath("~/Views/Shared/" + layout + ".cshtml")));

            var listControlId = Regex.Matches(fileContents, "RenderSection(.*?),", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return (from Match item in listControlId select item.Value.Replace(@"RenderSection(""", "").Replace(@""",", "")).ToList();
        }
        
        public static List<string> GetLayout(string path)
        {
            var foder = HttpContext.Current.Server.MapPath(path);
            var filePaths = Directory.GetFiles(foder, "_*.cshtml", SearchOption.AllDirectories);
            return filePaths.Select(filePath => filePath.Split('\\').LastOrDefault()).Select(str => str.Split('.')[0]).ToList();
        }

    }
}