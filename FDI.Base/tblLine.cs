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
    using System.Collections.Generic;
    
    public partial class tblLine
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string BuidingCode { get; set; }
        public string PCCode { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string ComPort { get; set; }
        public Nullable<int> BaudRate { get; set; }
        public Nullable<byte> CommunicationType { get; set; }
        public Nullable<int> LineTypeID { get; set; }
        public bool IsInActive { get; set; }
    }
}