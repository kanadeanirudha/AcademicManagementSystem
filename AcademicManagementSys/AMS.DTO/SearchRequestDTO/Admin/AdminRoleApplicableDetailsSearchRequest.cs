﻿using AMS.Base.DTO;

namespace AMS.DTO
{
    public class AdminRoleApplicableDetailsSearchRequest : Request
    {
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

        public int DepartmentID
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

        public int RowLength
        {
            get;
            set;
        }

        public int EndRow
        {
            get;
            set;
        }

        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public int StageSequenceNumber { get; set; }
        public int GeneralTaskReportingMstID { get; set; }
        public int PersonId
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
        public int EmployeeID
        {
            get;
            set;
        }
    }
}