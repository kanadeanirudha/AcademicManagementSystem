using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryDumpAndShrinkMasterAndDetailsSearchRequest : Request
	{
        public int ID
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        public int LocationID { get; set; }
        public int BalancesheetID { get; set; }
        public int PersonID { get; set; }
        public int TaskNotificationMasterID { get; set; }
	}
}
