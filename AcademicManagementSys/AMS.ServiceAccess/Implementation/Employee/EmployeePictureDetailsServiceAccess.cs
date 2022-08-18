using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeePictureDetailsServiceAccess : IEmployeePictureDetailsServiceAccess
    {
        IEmployeePictureDetailsBA _employeePictureDetailsBA = null;
        public EmployeePictureDetailsServiceAccess()
        {
            _employeePictureDetailsBA = new EmployeePictureDetailsBA();
        }
        public IBaseEntityResponse<EmployeePictureDetails> InsertEmployeePictureDetails(EmployeePictureDetails item)
        {
            return _employeePictureDetailsBA.InsertEmployeePictureDetails(item);
        }
        public IBaseEntityResponse<EmployeePictureDetails> UpdateEmployeePictureDetails(EmployeePictureDetails item)
        {
            return _employeePictureDetailsBA.UpdateEmployeePictureDetails(item);
        }
        public IBaseEntityResponse<EmployeePictureDetails> DeleteEmployeePictureDetails(EmployeePictureDetails item)
        {
            return _employeePictureDetailsBA.DeleteEmployeePictureDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeePictureDetails> GetBySearch(EmployeePictureDetailsSearchRequest searchRequest)
        {
            return _employeePictureDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeePictureDetails> SelectByID(EmployeePictureDetails item)
        {
            return _employeePictureDetailsBA.SelectByID(item);
        }
    }
}
