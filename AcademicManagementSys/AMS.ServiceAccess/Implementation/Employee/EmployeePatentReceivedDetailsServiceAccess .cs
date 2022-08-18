using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeePatentReceivedDetailsServiceAccess : IEmployeePatentReceivedDetailsServiceAccess
    {
        IEmployeePatentReceivedDetailsBA _employeePatentReceivedDetailsBA = null;
        public EmployeePatentReceivedDetailsServiceAccess()
        {
            _employeePatentReceivedDetailsBA = new EmployeePatentReceivedDetailsBA();
        }
        public IBaseEntityResponse<EmployeePatentReceivedDetails> InsertEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item)
        {
            return _employeePatentReceivedDetailsBA.InsertEmployeePatentReceivedDetails(item);
        }
        public IBaseEntityResponse<EmployeePatentReceivedDetails> UpdateEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item)
        {
            return _employeePatentReceivedDetailsBA.UpdateEmployeePatentReceivedDetails(item);
        }
        public IBaseEntityResponse<EmployeePatentReceivedDetails> DeleteEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item)
        {
            return _employeePatentReceivedDetailsBA.DeleteEmployeePatentReceivedDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeePatentReceivedDetails> GetBySearch(EmployeePatentReceivedDetailsSearchRequest searchRequest)
        {
            return _employeePatentReceivedDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeePatentReceivedDetails> SelectByID(EmployeePatentReceivedDetails item)
        {
            return _employeePatentReceivedDetailsBA.SelectByID(item);
        }
    }
}
