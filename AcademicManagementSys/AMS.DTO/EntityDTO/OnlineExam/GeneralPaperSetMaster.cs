using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPaperSetMaster : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public string PaperSetCode
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
