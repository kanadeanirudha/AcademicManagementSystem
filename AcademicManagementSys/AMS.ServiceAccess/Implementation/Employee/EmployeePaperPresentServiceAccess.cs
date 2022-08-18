using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeePaperPresentServiceAccess : IEmployeePaperPresentServiceAccess
    {
        IEmployeePaperPresentBA _employeePaperPresentBA = null;
        public EmployeePaperPresentServiceAccess()
        {
            _employeePaperPresentBA = new EmployeePaperPresentBA();
        }
        public IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresent(EmployeePaperPresent item)
        {
            return _employeePaperPresentBA.InsertEmployeePaperPresent(item);
        }
        public IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresent(EmployeePaperPresent item)
        {
            return _employeePaperPresentBA.UpdateEmployeePaperPresent(item);
        }
        public IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresent(EmployeePaperPresent item)
        {
            return _employeePaperPresentBA.DeleteEmployeePaperPresent(item);
        }
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetBySearch(EmployeePaperPresentSearchRequest searchRequest)
        {
            return _employeePaperPresentBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeePaperPresent> SelectByID(EmployeePaperPresent item)
        {
            return _employeePaperPresentBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetAppliedDetails(EmployeePaperPresentSearchRequest searchRequest)
        {
            return _employeePaperPresentBA.GetAppliedDetails(searchRequest);
        }
        



        
		public IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresenter(EmployeePaperPresent item)
		{
			return _employeePaperPresentBA.InsertEmployeePaperPresenter(item);
		}
		public IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresenter(EmployeePaperPresent item)
		{
			return _employeePaperPresentBA.UpdateEmployeePaperPresenter(item);
		}
		public IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresenter(EmployeePaperPresent item)
		{
			return _employeePaperPresentBA.DeleteEmployeePaperPresenter(item);
		}
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetBySearchEmployeePaperPresenter(EmployeePaperPresentSearchRequest searchRequest)
		{
            return _employeePaperPresentBA.GetBySearchEmployeePaperPresenter(searchRequest);
		}
        public IBaseEntityResponse<EmployeePaperPresent> SelectByIDEmployeePaperPresenter(EmployeePaperPresent item)
		{
            return _employeePaperPresentBA.SelectByIDEmployeePaperPresenter(item);
		}

    }
}
