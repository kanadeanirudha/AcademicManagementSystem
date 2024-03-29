﻿using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryLocationMaster : BaseDTO
	{
        //---------------------------------------IssueMaster-----------------------------
		public int ID
		{
			get;
			set;
		}

        public string CentreCode
        {
            get;
            set;
        }
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public int AccBalanceSheetID
        {
            get;
            set;
        }
    
        public string LocationName
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
        public string SelectedBalanceSheet { get; set; }
        public bool IsActive { get; set; }
	}
}
