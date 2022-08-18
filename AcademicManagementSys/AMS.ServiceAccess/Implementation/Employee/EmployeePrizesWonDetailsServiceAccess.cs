using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeePrizesWonDetailsServiceAccess : IEmployeePrizesWonDetailsServiceAccess
    {
        IEmployeePrizesWonDetailsBA _employeePrizesWonDetailsBA = null;
        public EmployeePrizesWonDetailsServiceAccess()
        {
            _employeePrizesWonDetailsBA = new EmployeePrizesWonDetailsBA();
        }
        public IBaseEntityResponse<EmployeePrizesWonDetails> InsertEmployeePrizesWonDetails(EmployeePrizesWonDetails item)
        {
            return _employeePrizesWonDetailsBA.InsertEmployeePrizesWonDetails(item);
        }
        public IBaseEntityResponse<EmployeePrizesWonDetails> UpdateEmployeePrizesWonDetails(EmployeePrizesWonDetails item)
        {
            return _employeePrizesWonDetailsBA.UpdateEmployeePrizesWonDetails(item);
        }
        public IBaseEntityResponse<EmployeePrizesWonDetails> DeleteEmployeePrizesWonDetails(EmployeePrizesWonDetails item)
        {
            return _employeePrizesWonDetailsBA.DeleteEmployeePrizesWonDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeePrizesWonDetails> GetBySearch(EmployeePrizesWonDetailsSearchRequest searchRequest)
        {
            return _employeePrizesWonDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeePrizesWonDetails> SelectByID(EmployeePrizesWonDetails item)
        {
            return _employeePrizesWonDetailsBA.SelectByID(item);
        }
    }
}
