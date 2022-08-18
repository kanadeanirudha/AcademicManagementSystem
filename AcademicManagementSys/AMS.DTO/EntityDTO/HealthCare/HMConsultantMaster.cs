using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class HMConsultantMaster : BaseDTO
	{
		public Int32 ID
		{
			get;
			set;
		}

        public Int16 ConsultantTypeMasterID 
		{
			get;
			set;
		}
       public string CentreCode
        {
            get;
            set;
        }
       public string Name
       {
           get;
           set;
       }
      
        
        public Int32 EmployeeID
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
      

        //public int AdminRoleMasterIDOld
        //{
        //    get;
        //    set;
        //}

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
     
        public string errorMessage { get; set; }

      
        public string CentreName { get; set; }
       
    }
}

	
