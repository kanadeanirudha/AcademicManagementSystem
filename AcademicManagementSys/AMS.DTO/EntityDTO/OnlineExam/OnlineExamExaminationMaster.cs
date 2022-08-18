
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamExaminationMaster : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }

        public string ExaminationName
        {
            get;
            set;
        }
        public String Purpose
        {
            get;
            set;
        }
        public Int32 AcadSessionId
        {
            get;
            set;
        }
        public String ExaminationFor
        {
            get;
            set;
        }
        public String SessionName
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
        // public string MenuCode { get; set; }
    }
}
