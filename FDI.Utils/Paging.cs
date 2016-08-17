using System.Collections.Generic;
using System.Globalization;

namespace FDI.Utils
{
    public class PageItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Current { get; set; }
        public bool Span { get; set; }
        public bool Link { get; set; }
    }

    public class Paging
    {
        public static int PageStep { get; set; }

        public static int TotalPage { get; set; }

        public static int CurrentPage { get; set; }

        public static string LinkPage { get; set; }

        public static string LinkPageExt { get; set; }
        

        /// <summary>
        /// Hàm Constructer
        /// </summary>
        public Paging()
        {
            CurrentPage = 1;
            LinkPage = string.Empty;
            TotalPage = 1;
            PageStep = 3;
            LinkPageExt = "";
        }

        ///  <summary>
        ///  Hàm lấy về mã html phân trang
        ///  </summary>
        ///  <param name="linkPage">đường link của trang</param>
        /// <param name="pageStep"></param>
        /// <param name="currentPage">Trang hiện tại</param>
        ///  <param name="rowPerPage">Số bản ghi trên trang</param>
        ///  <param name="totalRow">Tổng số bản ghi</param>
        public string GetHtmlPage(string linkPage, int pageStep, int currentPage, int rowPerPage, int totalRow)
        {
            PageStep = pageStep;
            CurrentPage = currentPage;
            LinkPage = linkPage;
            if (rowPerPage == 0)
                rowPerPage = 5;
            TotalPage = (totalRow % rowPerPage == 0) ? totalRow / rowPerPage : ((totalRow - (totalRow % rowPerPage)) / rowPerPage) + 1;
            return WriteHtmlPage();
        }

        /// <summary>
        /// Hàm lấy về phân trang, hỗ trợ cho urlRewrite
        /// </summary>
        /// <param name="linkPage">đường link của trang - Phía trước page</param>
        /// <param name="linkPageExt">đường link của trang - Phía sau page</param>
        /// <param name="pageStep"></param>
        /// <param name="currentPage">Trang hiện tại</param>
        /// <param name="rowPerPage">Số bản ghi trên trang</param>
        /// <param name="totalRow">Tổng số bản ghi</param>
        public string GetHtmlPage(string linkPage, string linkPageExt, int pageStep, int currentPage, int rowPerPage, int totalRow)
        {
            PageStep = pageStep;
            CurrentPage = currentPage;
            LinkPage = linkPage;
            LinkPageExt = linkPageExt;
            TotalPage = (totalRow % rowPerPage == 0) ? totalRow / rowPerPage : ((totalRow - (totalRow % rowPerPage)) / rowPerPage) + 1;
            return WriteHtmlPage();
        }

        /// <summary>
        /// Phân trang version 3
        /// </summary>
        /// <param name="pageStep"></param>
        /// <param name="currentPage"></param>
        /// <param name="rowPerPage"></param>
        /// <param name="totalRow"></param>
        /// <returns></returns>
        public List<PageItem> GetPageItems(int pageStep, int currentPage, int rowPerPage, int totalRow)
        {
            PageStep = pageStep;
            CurrentPage = currentPage;
            LinkPage = LinkPage;
            LinkPageExt = LinkPageExt;
            TotalPage = (totalRow % rowPerPage == 0) ? totalRow / rowPerPage : ((totalRow - (totalRow % rowPerPage)) / rowPerPage) + 1;
            var pageItems = new List<PageItem>();
            PageItem page;

            if (CurrentPage > PageStep + 1)
            {
                page = new PageItem {Text = "« Đầu", Value = "1", Link = true};
                pageItems.Add(page);

                page = new PageItem {Text = "Trước", Value = (CurrentPage - 1).ToString(CultureInfo.InvariantCulture), Link = true};
                pageItems.Add(page);

                page = new PageItem {Span = true, Text = "..."};
                pageItems.Add(page);

            }
            var beginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            var endFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (var pNumber = beginFor; pNumber <= endFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                {
                    page = new PageItem {Text = pNumber.ToString(), Current = true};
                    pageItems.Add(page);
                }
                else
                {
                    page = new PageItem {Text = pNumber.ToString(), Value = pNumber.ToString(), Link = true};
                    pageItems.Add(page);
                }
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                page = new PageItem {Span = true, Text = "..."};
                pageItems.Add(page);

                page = new PageItem {Text = "Sau", Value = (CurrentPage + 1).ToString(), Link = true};
                pageItems.Add(page);

                page = new PageItem {Text = "Cuối »", Value = TotalPage.ToString(), Link = true};
                pageItems.Add(page);
            }

            return pageItems;
        }

        /// <summary>
        /// Hàm write mã HTML phân trang
        /// </summary>
        private static string WriteHtmlPageForum()
        {
            var strPageHtml = "<li><span>Trang " + CurrentPage + "/" + TotalPage + "</span></li>";

            if (CurrentPage > PageStep + 1)
            {
                strPageHtml += "<li><a href=\"" + LinkPage + 1 + LinkPageExt + "\">Đầu</a></li>";
                strPageHtml += "<li><a href=\"" + LinkPage + (CurrentPage - 1) + LinkPageExt + "\">Sau</a></li>";
                strPageHtml += "<li><span>...</span></li>";
            }

            var beginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            var endFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (var pNumber = beginFor; pNumber <= endFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    strPageHtml += "<li><a href=\"javascript:;\" class=\"active\">" + pNumber + "</a></li>";
                else
                    strPageHtml += "<li><a href=\"" + LinkPage + pNumber + LinkPageExt + "\">" + pNumber + "</a></li>";
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                strPageHtml += "<li><span>...</span></li>";
                strPageHtml += "<li><a href=\"" + LinkPage + (CurrentPage + 1) + LinkPageExt + "\">Tiếp</a></li>";
                strPageHtml += "<li><a href=\"" + LinkPage + TotalPage + LinkPageExt + "\">Cuối</a></li>";

            }
            strPageHtml += "";
            return TotalPage > 1 ? strPageHtml : string.Empty;
        }

        ///  <summary>
        ///  Hàm lấy về mã html phân trang
        ///  </summary>
        ///  <param name="linkPage">đường link của trang</param>
        /// <param name="pageStep"></param>
        /// <param name="currentPage">Trang hiện tại</param>
        ///  <param name="rowPerPage">Số bản ghi trên trang</param>
        ///  <param name="totalRow">Tổng số bản ghi</param>
        ///  <Modified>        
        /// 	Name		Date		    Comment 
        ///  dongdt     10/11/2011      Tạo mới
        ///  </Modified>
        public static string GetHtmlPageForum(string linkPage, int pageStep, int currentPage, int rowPerPage, int totalRow)
        {
            PageStep = pageStep;
            CurrentPage = currentPage;
            LinkPage = linkPage;
            if (rowPerPage == 0)
                rowPerPage = 5;
            TotalPage = (totalRow % rowPerPage == 0) ? totalRow / rowPerPage : ((totalRow - (totalRow % rowPerPage)) / rowPerPage) + 1;
            return WriteHtmlPageForum();
        }

        /// <summary>
        /// Hàm write mã HTML phân trang
        /// </summary>
        private string WriteHtmlPage()
        {
            var strPageHtml = "<div class=\"paging\">";

            if (CurrentPage > PageStep + 1)
            {
                strPageHtml += "<a href=\"" + LinkPage + 1 + LinkPageExt + "\">« Đầu</a>";
                strPageHtml += "<a href=\"" + LinkPage + (CurrentPage - 1) + LinkPageExt + "\">Trước</a>";
                strPageHtml += "<span>...</span>";
            }

            var beginFor = ((CurrentPage - PageStep) > 1) ? (CurrentPage - PageStep) : 1;
            var endFor = ((CurrentPage + PageStep) > TotalPage) ? TotalPage : (CurrentPage + PageStep);

            for (var pNumber = beginFor; pNumber <= endFor; pNumber++)
            {
                if (pNumber == CurrentPage)
                    strPageHtml += "<a href=\"javascript:;\" class=\"current\">" + pNumber + "</a>";
                else
                    strPageHtml += "<a href=\"" + LinkPage + pNumber + LinkPageExt + "\">" + pNumber + "</a>";
            }

            if (CurrentPage < (TotalPage - PageStep))
            {
                strPageHtml += "<span>...</span>";
                strPageHtml += "<a href=\"" + LinkPage + (CurrentPage + 1) + LinkPageExt + "\">Sau</a>";
                strPageHtml += "<a href=\"" + LinkPage + TotalPage + LinkPageExt + "\">Cuối »</a>";

            }
            strPageHtml += "</div>";
            return TotalPage > 1 ? strPageHtml : string.Empty;
        }
    }
}
