using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalaryDeductionMasterSearchRequest : Request
    {
        public Int32 ID { get; set; }
        public string DeductionHeadName { get; set; }
        public string DeductionType { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }

        public string SortDirection { get; set; }
    }
}
