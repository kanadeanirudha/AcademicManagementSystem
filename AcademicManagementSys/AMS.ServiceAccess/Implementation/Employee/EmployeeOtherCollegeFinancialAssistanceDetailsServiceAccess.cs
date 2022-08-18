using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeOtherCollegeFinancialAssistanceDetailsServiceAccess : IEmployeeOtherCollegeFinancialAssistanceDetailsServiceAccess
    {
        IEmployeeOtherCollegeFinancialAssistanceDetailsBA _employeeOtherCollegeFinancialAssistanceDetailsBA = null;
        public EmployeeOtherCollegeFinancialAssistanceDetailsServiceAccess()
        {
            _employeeOtherCollegeFinancialAssistanceDetailsBA = new EmployeeOtherCollegeFinancialAssistanceDetailsBA();
        }
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> InsertEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            return _employeeOtherCollegeFinancialAssistanceDetailsBA.InsertEmployeeOtherCollegeFinancialAssistanceDetails(item);
        }
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> UpdateEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            return _employeeOtherCollegeFinancialAssistanceDetailsBA.UpdateEmployeeOtherCollegeFinancialAssistanceDetails(item);
        }
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> DeleteEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            return _employeeOtherCollegeFinancialAssistanceDetailsBA.DeleteEmployeeOtherCollegeFinancialAssistanceDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails> GetBySearch(EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest searchRequest)
        {
            return _employeeOtherCollegeFinancialAssistanceDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> SelectByID(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            return _employeeOtherCollegeFinancialAssistanceDetailsBA.SelectByID(item);
        }
    }
}
