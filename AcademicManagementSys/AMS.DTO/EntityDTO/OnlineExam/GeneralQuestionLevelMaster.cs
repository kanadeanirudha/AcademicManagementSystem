
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralQuestionLevelMaster : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }

        public string LevelCode
        {
            get;
            set;
        }
        public String LevelDescription
        {
            get;
            set;
        }
        public bool IsActive
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
        public int GeneralQuestionLevelMasterID { get; set; }
    }
}
