using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralQuestionLevelMaster : BaseDTO
    {
        public int GeneralQuestionLevelMasterID { get; set; }
        public string LevelCode { get; set; }
        public string LevelDescription { get; set; }
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
