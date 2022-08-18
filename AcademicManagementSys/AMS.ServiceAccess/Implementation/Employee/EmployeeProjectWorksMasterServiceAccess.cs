using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class EmployeeProjectWorksMasterServiceAccess : IEmployeeProjectWorksMasterServiceAccess
	{
		IEmployeeProjectWorksMasterBA _employeeProjectWorksMasterBA = null;
		public EmployeeProjectWorksMasterServiceAccess()
		{
			_employeeProjectWorksMasterBA = new EmployeeProjectWorksMasterBA();
		}
		public IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item)
		{
			return _employeeProjectWorksMasterBA.InsertEmployeeProjectWorksMaster(item);
		}
		public IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item)
		{
			return _employeeProjectWorksMasterBA.UpdateEmployeeProjectWorksMaster(item);
		}
		public IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item)
		{
			return _employeeProjectWorksMasterBA.DeleteEmployeeProjectWorksMaster(item);
		}
		public IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetBySearch(EmployeeProjectWorksMasterSearchRequest searchRequest)
		{
			return _employeeProjectWorksMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<EmployeeProjectWorksMaster> SelectByID(EmployeeProjectWorksMaster item)
		{
			return _employeeProjectWorksMasterBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetAppliedDetails(EmployeeProjectWorksMasterSearchRequest searchRequest)
		{
            return _employeeProjectWorksMasterBA.GetAppliedDetails(searchRequest);
		}
        

        public IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item)
        {
            return _employeeProjectWorksMasterBA.InsertEmployeeProjectWorksDetails(item);
        }
        public IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item)
        {
            return _employeeProjectWorksMasterBA.UpdateEmployeeProjectWorksDetails(item);
        }
        public IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item)
        {
            return _employeeProjectWorksMasterBA.DeleteEmployeeProjectWorksDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetBySearchEmployeeProjectWorksDetails(EmployeeProjectWorksMasterSearchRequest searchRequest)
        {
            return _employeeProjectWorksMasterBA.GetBySearchEmployeeProjectWorksDetails(searchRequest);
        }
        public IBaseEntityResponse<EmployeeProjectWorksMaster> SelectEmployeeCentreCode(EmployeeProjectWorksMaster item)
        {
            return _employeeProjectWorksMasterBA.SelectEmployeeCentreCode(item);
        }
	}
}

