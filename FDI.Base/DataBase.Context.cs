﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class FDIEntities : DbContext
    {
        public FDIEntities()
            : base("name=FDIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tblArea> tblAreas { get; set; }
        public DbSet<tblBlackList> tblBlackLists { get; set; }
        public DbSet<tblBuiding> tblBuidings { get; set; }
        public DbSet<tblCard> tblCards { get; set; }
        public DbSet<tblCardProcess> tblCardProcesses { get; set; }
        public DbSet<tblCardType> tblCardTypes { get; set; }
        public DbSet<tblCustomer> tblCustomers { get; set; }
        public DbSet<tblCustomerClass> tblCustomerClasses { get; set; }
        public DbSet<tblDBInfo> tblDBInfoes { get; set; }
        public DbSet<tblEvent> tblEvents { get; set; }
        public DbSet<tblEventAlarm> tblEventAlarms { get; set; }
        public DbSet<tblEventCode> tblEventCodes { get; set; }
        public DbSet<tblFunction> tblFunctions { get; set; }
        public DbSet<tblLine> tblLines { get; set; }
        public DbSet<tblLog> tblLogs { get; set; }
        public DbSet<tblObject> tblObjects { get; set; }
        public DbSet<tblPC> tblPCs { get; set; }
        public DbSet<tblRecord> tblRecords { get; set; }
        public DbSet<tblSystemConfig> tblSystemConfigs { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
    
        public virtual int DeleteIssuedCard(string cardnumber)
        {
            var cardnumberParameter = cardnumber != null ?
                new ObjectParameter("cardnumber", cardnumber) :
                new ObjectParameter("cardnumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteIssuedCard", cardnumberParameter);
        }
    
        public virtual int InsertIntoCard(string code, string cardNumber, string accountName, Nullable<int> balance, string cardTypeCode, Nullable<bool> isRelease, Nullable<bool> isLockCard, Nullable<bool> isEdit, Nullable<System.DateTime> dateModified, string cardStatus, string ownerCode, Nullable<System.DateTime> dateIssue)
        {
            var codeParameter = code != null ?
                new ObjectParameter("Code", code) :
                new ObjectParameter("Code", typeof(string));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("CardNumber", cardNumber) :
                new ObjectParameter("CardNumber", typeof(string));
    
            var accountNameParameter = accountName != null ?
                new ObjectParameter("AccountName", accountName) :
                new ObjectParameter("AccountName", typeof(string));
    
            var balanceParameter = balance.HasValue ?
                new ObjectParameter("Balance", balance) :
                new ObjectParameter("Balance", typeof(int));
    
            var cardTypeCodeParameter = cardTypeCode != null ?
                new ObjectParameter("CardTypeCode", cardTypeCode) :
                new ObjectParameter("CardTypeCode", typeof(string));
    
            var isReleaseParameter = isRelease.HasValue ?
                new ObjectParameter("IsRelease", isRelease) :
                new ObjectParameter("IsRelease", typeof(bool));
    
            var isLockCardParameter = isLockCard.HasValue ?
                new ObjectParameter("IsLockCard", isLockCard) :
                new ObjectParameter("IsLockCard", typeof(bool));
    
            var isEditParameter = isEdit.HasValue ?
                new ObjectParameter("IsEdit", isEdit) :
                new ObjectParameter("IsEdit", typeof(bool));
    
            var dateModifiedParameter = dateModified.HasValue ?
                new ObjectParameter("DateModified", dateModified) :
                new ObjectParameter("DateModified", typeof(System.DateTime));
    
            var cardStatusParameter = cardStatus != null ?
                new ObjectParameter("CardStatus", cardStatus) :
                new ObjectParameter("CardStatus", typeof(string));
    
            var ownerCodeParameter = ownerCode != null ?
                new ObjectParameter("OwnerCode", ownerCode) :
                new ObjectParameter("OwnerCode", typeof(string));
    
            var dateIssueParameter = dateIssue.HasValue ?
                new ObjectParameter("DateIssue", dateIssue) :
                new ObjectParameter("DateIssue", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertIntoCard", codeParameter, cardNumberParameter, accountNameParameter, balanceParameter, cardTypeCodeParameter, isReleaseParameter, isLockCardParameter, isEditParameter, dateModifiedParameter, cardStatusParameter, ownerCodeParameter, dateIssueParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertIntoEvent(Nullable<System.DateTime> date, string cardNumber, string mID, string fID, Nullable<int> value, Nullable<int> balance, string action, string eventCode, string buidingCode, string pCCode, string lineCode, string areaCode, string objectCode, string cardTypeCode, string userCode, string eventID)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("CardNumber", cardNumber) :
                new ObjectParameter("CardNumber", typeof(string));
    
            var mIDParameter = mID != null ?
                new ObjectParameter("MID", mID) :
                new ObjectParameter("MID", typeof(string));
    
            var fIDParameter = fID != null ?
                new ObjectParameter("FID", fID) :
                new ObjectParameter("FID", typeof(string));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(int));
    
            var balanceParameter = balance.HasValue ?
                new ObjectParameter("Balance", balance) :
                new ObjectParameter("Balance", typeof(int));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var eventCodeParameter = eventCode != null ?
                new ObjectParameter("EventCode", eventCode) :
                new ObjectParameter("EventCode", typeof(string));
    
            var buidingCodeParameter = buidingCode != null ?
                new ObjectParameter("BuidingCode", buidingCode) :
                new ObjectParameter("BuidingCode", typeof(string));
    
            var pCCodeParameter = pCCode != null ?
                new ObjectParameter("PCCode", pCCode) :
                new ObjectParameter("PCCode", typeof(string));
    
            var lineCodeParameter = lineCode != null ?
                new ObjectParameter("LineCode", lineCode) :
                new ObjectParameter("LineCode", typeof(string));
    
            var areaCodeParameter = areaCode != null ?
                new ObjectParameter("AreaCode", areaCode) :
                new ObjectParameter("AreaCode", typeof(string));
    
            var objectCodeParameter = objectCode != null ?
                new ObjectParameter("ObjectCode", objectCode) :
                new ObjectParameter("ObjectCode", typeof(string));
    
            var cardTypeCodeParameter = cardTypeCode != null ?
                new ObjectParameter("CardTypeCode", cardTypeCode) :
                new ObjectParameter("CardTypeCode", typeof(string));
    
            var userCodeParameter = userCode != null ?
                new ObjectParameter("UserCode", userCode) :
                new ObjectParameter("UserCode", typeof(string));
    
            var eventIDParameter = eventID != null ?
                new ObjectParameter("EventID", eventID) :
                new ObjectParameter("EventID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertIntoEvent", dateParameter, cardNumberParameter, mIDParameter, fIDParameter, valueParameter, balanceParameter, actionParameter, eventCodeParameter, buidingCodeParameter, pCCodeParameter, lineCodeParameter, areaCodeParameter, objectCodeParameter, cardTypeCodeParameter, userCodeParameter, eventIDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertIntoRecord(Nullable<System.DateTime> date, string cardNumber, string mID, string fID, Nullable<int> value, Nullable<int> bonus, Nullable<int> balance, string action, string eventCode, string buidingCode, string pCCode, string lineCode, string areaCode, string objectCode, string cardTypeCode, string shiftCode, string userCode, Nullable<bool> isServer1, Nullable<bool> isServer2, string eventID, string productCode, Nullable<int> cardDeposit, Nullable<int> returnVal)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("CardNumber", cardNumber) :
                new ObjectParameter("CardNumber", typeof(string));
    
            var mIDParameter = mID != null ?
                new ObjectParameter("MID", mID) :
                new ObjectParameter("MID", typeof(string));
    
            var fIDParameter = fID != null ?
                new ObjectParameter("FID", fID) :
                new ObjectParameter("FID", typeof(string));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(int));
    
            var bonusParameter = bonus.HasValue ?
                new ObjectParameter("Bonus", bonus) :
                new ObjectParameter("Bonus", typeof(int));
    
            var balanceParameter = balance.HasValue ?
                new ObjectParameter("Balance", balance) :
                new ObjectParameter("Balance", typeof(int));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var eventCodeParameter = eventCode != null ?
                new ObjectParameter("EventCode", eventCode) :
                new ObjectParameter("EventCode", typeof(string));
    
            var buidingCodeParameter = buidingCode != null ?
                new ObjectParameter("BuidingCode", buidingCode) :
                new ObjectParameter("BuidingCode", typeof(string));
    
            var pCCodeParameter = pCCode != null ?
                new ObjectParameter("PCCode", pCCode) :
                new ObjectParameter("PCCode", typeof(string));
    
            var lineCodeParameter = lineCode != null ?
                new ObjectParameter("LineCode", lineCode) :
                new ObjectParameter("LineCode", typeof(string));
    
            var areaCodeParameter = areaCode != null ?
                new ObjectParameter("AreaCode", areaCode) :
                new ObjectParameter("AreaCode", typeof(string));
    
            var objectCodeParameter = objectCode != null ?
                new ObjectParameter("ObjectCode", objectCode) :
                new ObjectParameter("ObjectCode", typeof(string));
    
            var cardTypeCodeParameter = cardTypeCode != null ?
                new ObjectParameter("CardTypeCode", cardTypeCode) :
                new ObjectParameter("CardTypeCode", typeof(string));
    
            var shiftCodeParameter = shiftCode != null ?
                new ObjectParameter("ShiftCode", shiftCode) :
                new ObjectParameter("ShiftCode", typeof(string));
    
            var userCodeParameter = userCode != null ?
                new ObjectParameter("UserCode", userCode) :
                new ObjectParameter("UserCode", typeof(string));
    
            var isServer1Parameter = isServer1.HasValue ?
                new ObjectParameter("IsServer1", isServer1) :
                new ObjectParameter("IsServer1", typeof(bool));
    
            var isServer2Parameter = isServer2.HasValue ?
                new ObjectParameter("IsServer2", isServer2) :
                new ObjectParameter("IsServer2", typeof(bool));
    
            var eventIDParameter = eventID != null ?
                new ObjectParameter("EventID", eventID) :
                new ObjectParameter("EventID", typeof(string));
    
            var productCodeParameter = productCode != null ?
                new ObjectParameter("ProductCode", productCode) :
                new ObjectParameter("ProductCode", typeof(string));
    
            var cardDepositParameter = cardDeposit.HasValue ?
                new ObjectParameter("CardDeposit", cardDeposit) :
                new ObjectParameter("CardDeposit", typeof(int));
    
            var returnValParameter = returnVal.HasValue ?
                new ObjectParameter("ReturnVal", returnVal) :
                new ObjectParameter("ReturnVal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertIntoRecord", dateParameter, cardNumberParameter, mIDParameter, fIDParameter, valueParameter, bonusParameter, balanceParameter, actionParameter, eventCodeParameter, buidingCodeParameter, pCCodeParameter, lineCodeParameter, areaCodeParameter, objectCodeParameter, cardTypeCodeParameter, shiftCodeParameter, userCodeParameter, isServer1Parameter, isServer2Parameter, eventIDParameter, productCodeParameter, cardDepositParameter, returnValParameter);
        }
    
        public virtual int SelectFromRecord()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SelectFromRecord");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_BCTheoDoiTuong_Result> sp_BCTheoDoiTuong()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BCTheoDoiTuong_Result>("sp_BCTheoDoiTuong");
        }
    
        public virtual ObjectResult<sp_BCTheoKhuVuc_Result> sp_BCTheoKhuVuc()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BCTheoKhuVuc_Result>("sp_BCTheoKhuVuc");
        }
    
        public virtual int sp_capnhatsodu()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_capnhatsodu");
        }
    
        public virtual ObjectResult<sp_CardProcess_Result> sp_CardProcess()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CardProcess_Result>("sp_CardProcess");
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_DTBanHang_Result> sp_DTBanHang(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string buiding, string area, string @object)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var buidingParameter = buiding != null ?
                new ObjectParameter("buiding", buiding) :
                new ObjectParameter("buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("object", @object) :
                new ObjectParameter("object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DTBanHang_Result>("sp_DTBanHang", startDateParameter, endDateParameter, buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual ObjectResult<sp_DTBanHangTongHop_Result> sp_DTBanHangTongHop(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string buiding, string area, string @object)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var buidingParameter = buiding != null ?
                new ObjectParameter("Buiding", buiding) :
                new ObjectParameter("Buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("Object", @object) :
                new ObjectParameter("Object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DTBanHangTongHop_Result>("sp_DTBanHangTongHop", startDateParameter, endDateParameter, buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual ObjectResult<sp_DTBanThe_Result> sp_DTBanThe(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string buiding, string area, string @object)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var buidingParameter = buiding != null ?
                new ObjectParameter("buiding", buiding) :
                new ObjectParameter("buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("object", @object) :
                new ObjectParameter("object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DTBanThe_Result>("sp_DTBanThe", startDateParameter, endDateParameter, buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual ObjectResult<sp_DTBanTheTongHop_Result> sp_DTBanTheTongHop(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string buiding, string area, string @object)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var buidingParameter = buiding != null ?
                new ObjectParameter("Buiding", buiding) :
                new ObjectParameter("Buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("Object", @object) :
                new ObjectParameter("Object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DTBanTheTongHop_Result>("sp_DTBanTheTongHop", startDateParameter, endDateParameter, buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual ObjectResult<sp_EventAlarm_Result> sp_EventAlarm()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_EventAlarm_Result>("sp_EventAlarm");
        }
    
        public virtual ObjectResult<sp_findCard_Result> sp_findCard(string code, string cardNumber, string name, string cardType)
        {
            var codeParameter = code != null ?
                new ObjectParameter("Code", code) :
                new ObjectParameter("Code", typeof(string));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("CardNumber", cardNumber) :
                new ObjectParameter("CardNumber", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var cardTypeParameter = cardType != null ?
                new ObjectParameter("CardType", cardType) :
                new ObjectParameter("CardType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_findCard_Result>("sp_findCard", codeParameter, cardNumberParameter, nameParameter, cardTypeParameter);
        }
    
        public virtual ObjectResult<sp_GetBackList_Result> sp_GetBackList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetBackList_Result>("sp_GetBackList");
        }
    
        public virtual ObjectResult<sp_GetCard_Result> sp_GetCard(string ch)
        {
            var chParameter = ch != null ?
                new ObjectParameter("ch", ch) :
                new ObjectParameter("ch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCard_Result>("sp_GetCard", chParameter);
        }
    
        public virtual ObjectResult<sp_GetListCard_Result> sp_GetListCard(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetListCard_Result>("sp_GetListCard", idParameter);
        }
    
        public virtual ObjectResult<sp_GiaoDichGanNhat_Result> sp_GiaoDichGanNhat(string cardNumber, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("CardNumber", cardNumber) :
                new ObjectParameter("CardNumber", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GiaoDichGanNhat_Result>("sp_GiaoDichGanNhat", cardNumberParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_LocCard_Result> sp_LocCard(string buiding, string area, string @object, string typeCard, string cardNumber, string cusID, string cusName, string status)
        {
            var buidingParameter = buiding != null ?
                new ObjectParameter("buiding", buiding) :
                new ObjectParameter("buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("object", @object) :
                new ObjectParameter("object", typeof(string));
    
            var typeCardParameter = typeCard != null ?
                new ObjectParameter("typeCard", typeCard) :
                new ObjectParameter("typeCard", typeof(string));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("cardNumber", cardNumber) :
                new ObjectParameter("cardNumber", typeof(string));
    
            var cusIDParameter = cusID != null ?
                new ObjectParameter("CusID", cusID) :
                new ObjectParameter("CusID", typeof(string));
    
            var cusNameParameter = cusName != null ?
                new ObjectParameter("CusName", cusName) :
                new ObjectParameter("CusName", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LocCard_Result>("sp_LocCard", buidingParameter, areaParameter, objectParameter, typeCardParameter, cardNumberParameter, cusIDParameter, cusNameParameter, statusParameter);
        }
    
        public virtual ObjectResult<sp_Log_Result> sp_Log()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Log_Result>("sp_Log");
        }
    
        public virtual ObjectResult<sp_Login_Result> sp_Login(string user, string pass)
        {
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Login_Result>("sp_Login", userParameter, passParameter);
        }
    
        public virtual ObjectResult<sp_Record_Result> sp_Record(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string buiding, string area, string pC, string @object, string function, string eventCode, string typeCard, string cardNumber, string user)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var buidingParameter = buiding != null ?
                new ObjectParameter("Buiding", buiding) :
                new ObjectParameter("Buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(string));
    
            var pCParameter = pC != null ?
                new ObjectParameter("PC", pC) :
                new ObjectParameter("PC", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("Object", @object) :
                new ObjectParameter("Object", typeof(string));
    
            var functionParameter = function != null ?
                new ObjectParameter("Function", function) :
                new ObjectParameter("Function", typeof(string));
    
            var eventCodeParameter = eventCode != null ?
                new ObjectParameter("EventCode", eventCode) :
                new ObjectParameter("EventCode", typeof(string));
    
            var typeCardParameter = typeCard != null ?
                new ObjectParameter("TypeCard", typeCard) :
                new ObjectParameter("TypeCard", typeof(string));
    
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("CardNumber", cardNumber) :
                new ObjectParameter("CardNumber", typeof(string));
    
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Record_Result>("sp_Record", startDateParameter, endDateParameter, buidingParameter, areaParameter, pCParameter, objectParameter, functionParameter, eventCodeParameter, typeCardParameter, cardNumberParameter, userParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<sp_TatCaGiaoDich_Result> sp_TatCaGiaoDich(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string buiding, string area, string @object)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var buidingParameter = buiding != null ?
                new ObjectParameter("buiding", buiding) :
                new ObjectParameter("buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("object", @object) :
                new ObjectParameter("object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TatCaGiaoDich_Result>("sp_TatCaGiaoDich", startDateParameter, endDateParameter, buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual ObjectResult<sp_TheTrungNhau_Result> sp_TheTrungNhau()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TheTrungNhau_Result>("sp_TheTrungNhau");
        }
    
        public virtual ObjectResult<sp_ThongKeThe_Result> sp_ThongKeThe(string buiding, string area, string @object)
        {
            var buidingParameter = buiding != null ?
                new ObjectParameter("buiding", buiding) :
                new ObjectParameter("buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("object", @object) :
                new ObjectParameter("object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ThongKeThe_Result>("sp_ThongKeThe", buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual ObjectResult<sp_ThongKeTheChiTiet_Result> sp_ThongKeTheChiTiet(string buiding, string area, string @object)
        {
            var buidingParameter = buiding != null ?
                new ObjectParameter("buiding", buiding) :
                new ObjectParameter("buiding", typeof(string));
    
            var areaParameter = area != null ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(string));
    
            var objectParameter = @object != null ?
                new ObjectParameter("object", @object) :
                new ObjectParameter("object", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ThongKeTheChiTiet_Result>("sp_ThongKeTheChiTiet", buidingParameter, areaParameter, objectParameter);
        }
    
        public virtual int sp_UpdateCard(string ch, string card)
        {
            var chParameter = ch != null ?
                new ObjectParameter("ch", ch) :
                new ObjectParameter("ch", typeof(string));
    
            var cardParameter = card != null ?
                new ObjectParameter("Card", card) :
                new ObjectParameter("Card", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateCard", chParameter, cardParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
