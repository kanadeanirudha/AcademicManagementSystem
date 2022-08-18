using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralQuestionLevelMasterSearchRequest : Request
    {
        public int GeneralQuestionLevelMasterID { get; set; }
        public string LevelCode { get; set; }
        public string LevelDescription { get; set; }
        public bool IsActive { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
