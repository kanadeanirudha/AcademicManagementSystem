using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class HMOPDHealthCentre : BaseDTO
	{
		public Int16 ID
		{
			get;
			set;
		}

        public string OPDName
		{
			get;
			set;
		}
        public string CentreCode
		{
			get;
			set;
		}
        public Int32 DepartmentID
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        
        public int RoleApplicableID
        {
            get;
            set;
        }

        public Int16 HMOPDHealthCentreID { get; set; }
        public string OPDID { get; set; }

        //public string AdminRoleCode
        //{
        //    get;
        //    set;
        //}

       

       
        public string DepartmentIdWithName
        {
            get;
            set;
        }

      
        //public string WorkFromDate
        //{
        //    get;
        //    set;
        //}

        //public string WorkToDate
        //{
        //    get;
        //    set;
        //}

        //public string RoleType
        //{
        //    get;
        //    set;
        //}

        //public string Reason
        //{
        //    get;
        //    set;
        //}

        //public bool IsActive
        //{
        //    get;
        //    set;
        //}

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
         public bool IsDeleted
        {
            get;
            set;
        }
       
        public string EmployeeName
        {
            get;
            set;
        }

       

        //public string EmployeeFirstName
        //{
        //    get;
        //    set;
        //}

        //public string EmployeeMiddleName
        //{
        //    get;
        //    set;
        //}

        //public string EmployeeLastName
        //{
        //    get;
        //    set;
        //}

        public string DesignationName
        {
            get;
            set;
        }

        public int AdminSnPostsID
        {
            get;
            set;
        }

        public bool StatusFlag
        {
            get;
            set;
        }

        public string SelectedIDs
        {
            get;
            set;
        }

        public int DefaultRoleID
        {
            get;
            set;
        }

        public string DefaultRoleCode 
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        //public int Status
        //{
        //    get;
        //    set;
        //}
        public string CentreName { get; set; }
        public int IsSuperUser { get; set; }
        public int IsAcadMgr { get; set; }
        public int IsEstMgr { get; set; }
        public int IsFinMgr { get; set; }
        public int IsAdmMgr { get; set; }
        public string ScopeIdentity { get; set; }
    }
}

	