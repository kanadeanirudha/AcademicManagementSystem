using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class AdminRoleModuleAccess : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int AdminRoleDetailsID
        {
            get;
            set;
        } 
               
        public int DptBshtSecnStrID
        {
            get;
            set;
        }

        public string AccessibleCentreCode
        {
            get;
            set;
        }

        public DateTime? EnableDate
        {
            get;
            set;
        }

        public DateTime? DisableDate
        {
            get;
            set;
        }

        public string DisablePurpose
        {
            get;
            set;
        }

        public bool IsSuperUser
        {
            get;
            set;
        }

        public bool IsAcadMgr
        {
            get;
            set;
        }

        public bool IsEstMgr
        {
            get;
            set;
        }

        public bool IsFinMgr
        {
            get;
            set;
        }
         
        public bool IsAdmMgr
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

        public int? ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int? DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public int NoOfPosts
        {
            get;
            set;
        }

        public string AdminRoleCode
        {
            get;
            set;
        }

        public int AdminRoleMasterID
        {
            get;
            set;
        }

        public string EntityType
        {
            get;
            set;
        }

        public string CentreName
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get;
            set;
        }

        public string DesignationType
        {
            get;
            set;
        }

        public int EntityID
        {
            get;
            set;
        }

        public string MonitoringLevel
        {
            get;
            set;
        }

        public string Entity
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }

        public int OrgCentrewiseDepartmentID
        {
            get;
            set;
        }

        public bool status
        {
            get;
            set;
        }

        public string Section
        {
            get;
            set;
        }

        public string CourseYear
        {
            get;    
            set;
        }

        public string balSheetName
        {
            get;
            set;
        }

        public string StoreName
        {
            get;
            set;
        }
        public string Acad
        {
            get;
            set;
        }
        public string Est
        {
            get;
            set;
        }
        public string Fin
        {
            get;
            set;
        }
        public string Adm
        {
            get;
            set;
        }
        public string super
        {
            get;
            set;
        }

        public string IDs
        {
            get;
            set;
        }

        public int BalSheetID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        
        public int Status
        {
            get;
            set;
        }
    }
}
