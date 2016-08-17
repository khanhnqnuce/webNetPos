using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FDI.DA;
using FDI.MvcMembership;
using FDI.Simple;
using FDI.Utils;
using Resources;

namespace FDI.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {
        protected static SystemActionItem SystemActionItem { get; set; }
        protected static List<ActionActiveItem> LtsModuleActive { get; set; }

        protected bool CheckAdmin(string nameRole)
        {
            var lstAdmin = WebConfig.ListAdmin.ToLower();
            var moduleArr = lstAdmin.Split(',');
            return moduleArr.Any(s => s == nameRole.ToLower());
        }

        protected string ActionText
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["do"]))
                {
                    switch (Request["do"].Trim().ToLower())
                    {
                        default:
                        case "add":
                            return CSResourceString.Add;
                        case "delete":
                            return CSResourceString.Delete;

                        case "edit":
                            return CSResourceString.Edit;

                        case "update":
                            return CSResourceString.Update;

                        case "usermodule":
                            return CSResourceString.UserModule;

                        case "ronemodule":
                            return CSResourceString.RoleModule;

                        case "show":
                            return CSResourceString.Show;

                        case "hide":
                            return CSResourceString.Hide;

                        case "order":
                            return CSResourceString.Order;

                        case "active":
                            return CSResourceString.Active;

                        case "public":
                            return CSResourceString.Public;

                        case "complete":
                            return CSResourceString.Complete;
                    }
                }
                return CSResourceString.View;
            }
        }

        protected ActionType DoAction
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["do"]))
                {
                    switch (Request["do"].Trim().ToLower())
                    {
                        default:
                        case "add":
                            return ActionType.Add;

                        case "delete":
                            return ActionType.Delete;

                        case "update":
                            return ActionType.Update;
                        case "edit":
                            return ActionType.Edit;

                        case "show":
                            return ActionType.Show;

                        case "usermodule":
                            return ActionType.UserModule;

                        case "rolemodule":
                            return ActionType.RoleModule;

                        case "hide":
                            return ActionType.Hide;

                        case "order":
                            return ActionType.Order;

                        case "active":
                            return ActionType.Active;

                        case "public":
                            return ActionType.Public;

                        case "complete":
                            return ActionType.Complete;
                        case "excel":
                            return ActionType.Excel;
                    }
                }
                return ActionType.View;
            }
        }

        protected List<int> ArrId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["itemID"]))
                {
                    if (Request["ItemID"].Contains(","))
                    {
                        return Request["ItemID"].Trim().Split(',').Select(o => Convert.ToInt32(o)).ToList();
                    }
                    var ltsTemp = new List<int> { Convert.ToInt32(Request["ItemID"]) };
                    return ltsTemp;
                }
                return new List<int>();
            }
        }
        
        protected string UserName
        {
            get
            {
                var user = Membership.GetUser();
                return user != null ? user.UserName : null;
            }
        }

        public string LanguageId
        {
            get
            {
                //var obj = Request.Cookies["Language"];
                return "vi";
            }
        }

    }

    public enum ActionType
    {
        View = 0,
        Add = 1,
        Edit = 2,
        Update = 10,
        Delete = 3,
        Show = 4,
        Hide = 5,
        Order = 6,
        Active = 7,
        Public = 8,
        Complete = 9,
        UserModule = 11,
        RoleModule = 12,
        Excel = 13,
    }
}
