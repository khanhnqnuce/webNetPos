//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDI.Base
{
    using System;
    
    public partial class sp_findCard_Result
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CardNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public string CardTypeCode { get; set; }
        public Nullable<bool> IsRelease { get; set; }
        public Nullable<bool> IsLockCard { get; set; }
        public bool IsEdit { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string CardStatus { get; set; }
        public string OwnerCode { get; set; }
        public Nullable<System.DateTime> DateIssue { get; set; }
        public string NameType { get; set; }
    }
}
