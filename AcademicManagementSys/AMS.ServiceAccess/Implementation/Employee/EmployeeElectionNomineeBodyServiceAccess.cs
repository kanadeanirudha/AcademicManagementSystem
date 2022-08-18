using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeElectionNomineeBodyServiceAccess : IEmployeeElectionNomineeBodyServiceAccess
    {
        IEmployeeElectionNomineeBodyBA _employeeElectionNomineeBodyBA = null;
        public EmployeeElectionNomineeBodyServiceAccess()
        {
            _employeeElectionNomineeBodyBA = new EmployeeElectionNomineeBodyBA();
        }
        public IBaseEntityResponse<EmployeeElectionNomineeBody> InsertEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item)
        {
            return _employeeElectionNomineeBodyBA.InsertEmployeeElectionNomineeBody(item);
        }
        public IBaseEntityResponse<EmployeeElectionNomineeBody> UpdateEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item)
        {
            return _employeeElectionNomineeBodyBA.UpdateEmployeeElectionNomineeBody(item);
        }
        public IBaseEntityResponse<EmployeeElectionNomineeBody> DeleteEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item)
        {
            return _employeeElectionNomineeBodyBA.DeleteEmployeeElectionNomineeBody(item);
        }
        public IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> GetBySearch(EmployeeElectionNomineeBodySearchRequest searchRequest)
        {
            return _employeeElectionNomineeBodyBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeElectionNomineeBody> SelectByID(EmployeeElectionNomineeBody item)
        {
            return _employeeElectionNomineeBodyBA.SelectByID(item);
        }
    }
}
