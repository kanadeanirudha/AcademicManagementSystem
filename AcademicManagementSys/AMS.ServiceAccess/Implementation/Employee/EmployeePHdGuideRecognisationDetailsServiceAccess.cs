using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class EmployeePHdGuideRecognisationDetailsServiceAccess : IEmployeePHdGuideRecognisationDetailsServiceAccess
	{
		IEmployeePHdGuideRecognisationDetailsBA _employeePHdGuideRecognisationDetailsBA = null;
		public EmployeePHdGuideRecognisationDetailsServiceAccess()
		{
			_employeePHdGuideRecognisationDetailsBA = new EmployeePHdGuideRecognisationDetailsBA();
		}
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			return _employeePHdGuideRecognisationDetailsBA.InsertEmployeePHdGuideRecognisationDetails(item);
		}
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			return _employeePHdGuideRecognisationDetailsBA.UpdateEmployeePHdGuideRecognisationDetails(item);
		}
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			return _employeePHdGuideRecognisationDetailsBA.DeleteEmployeePHdGuideRecognisationDetails(item);
		}
		public IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest)
		{
			return _employeePHdGuideRecognisationDetailsBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> SelectByID(EmployeePHdGuideRecognisationDetails item)
		{
			return _employeePHdGuideRecognisationDetailsBA.SelectByID(item);
		}

        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            return _employeePHdGuideRecognisationDetailsBA.InsertEmployeePHdGuideStudentsDetails(item);
        }
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            return _employeePHdGuideRecognisationDetailsBA.UpdateEmployeePHdGuideStudentsDetails(item);
        }
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            return _employeePHdGuideRecognisationDetailsBA.DeleteEmployeePHdGuideStudentsDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetBySearchEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest)
        {
            return _employeePHdGuideRecognisationDetailsBA.GetBySearchEmployeePHdGuideStudentsDetails(searchRequest);
        }
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> SelectByIDEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            return _employeePHdGuideRecognisationDetailsBA.SelectByIDEmployeePHdGuideStudentsDetails(item);
        }
	}
}