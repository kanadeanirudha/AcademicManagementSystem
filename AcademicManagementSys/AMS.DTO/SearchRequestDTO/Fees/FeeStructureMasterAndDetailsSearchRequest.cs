using AMS.Base.DTO;

namespace AMS.DTO
{
    public class FeeStructureMasterAndDetailsSearchRequest : Request
    {
        public int FeeStructureMasterID { get; set; }
        public int FeeCriteriaMasterID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int RowLength { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public int AccBalsheetMstID { get; set; }

        //------------------------------FeeAccountTypeMaster Table--------------
        public int FeeAccountTypeMasterID { get; set; }
        public string FeeAccountTypeDesc { get; set; }
        public int FeeAccountTypeCode { get; set; }

        //------------------------------FeeAccountSubTypeMaster Table-----------------
        public int FeeAccountSubTypeMasterID { get; set; }
        public string FeeAccountSubTypeDesc { get; set; }
        public string FeeAccountSubTypeCode { get; set; }
        public int AccountID { get; set; }

        public string SearchWord { get; set; }       

    }
}
