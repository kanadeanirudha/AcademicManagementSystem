using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryItemMasterSearchRequest : Request
    {
        public int ID
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
        public int ItemID{ get; set; }
        public int LocationID{ get; set; }
        public Int16 AccBalsheetMstID { get;set; }
        public string ItemFamily { get; set; }
        public string PackingUnit { get; set; }
        public string PackingType { get; set; }
        public decimal MinIndentLevel { get; set; }

        //Extra Property
        public int ItemFamilyMasterID { get; set; }
        public int ItemPackingUnitMasterID { get; set; }
        public int ItemPackingTypeMasterID { get; set; }

        // for tax template applicable
        public string PolicyDefaultAnswer
        {
            get;
            set;
        }
    }
}
