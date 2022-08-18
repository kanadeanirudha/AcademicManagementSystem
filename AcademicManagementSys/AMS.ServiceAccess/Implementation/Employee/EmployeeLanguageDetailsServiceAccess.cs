using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeLanguageDetailsServiceAccess : IEmployeeLanguageDetailsServiceAccess
    {
        IEmployeeLanguageDetailsBA _employeeLanguageDetailsBA = null;
        public EmployeeLanguageDetailsServiceAccess()
        {
            _employeeLanguageDetailsBA = new EmployeeLanguageDetailsBA();
        }
        public IBaseEntityResponse<EmployeeLanguageDetails> InsertEmployeeLanguageDetails(EmployeeLanguageDetails item)
        {
            return _employeeLanguageDetailsBA.InsertEmployeeLanguageDetails(item);
        }
        public IBaseEntityResponse<EmployeeLanguageDetails> UpdateEmployeeLanguageDetails(EmployeeLanguageDetails item)
        {
            return _employeeLanguageDetailsBA.UpdateEmployeeLanguageDetails(item);
        }
        public IBaseEntityResponse<EmployeeLanguageDetails> DeleteEmployeeLanguageDetails(EmployeeLanguageDetails item)
        {
            return _employeeLanguageDetailsBA.DeleteEmployeeLanguageDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetBySearch(EmployeeLanguageDetailsSearchRequest searchRequest)
        {
            return _employeeLanguageDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetBySearchList(EmployeeLanguageDetailsSearchRequest searchRequest)
        {
            return _employeeLanguageDetailsBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetEmployeeLanguageDetailsByID(EmployeeLanguageDetailsSearchRequest searchRequest)
        {
            return _employeeLanguageDetailsBA.GetEmployeeLanguageDetailsByID(searchRequest);
        }
        public IBaseEntityResponse<EmployeeLanguageDetails> SelectByID(EmployeeLanguageDetails item)
        {
            return _employeeLanguageDetailsBA.SelectByID(item);
        }
        
    }
}
