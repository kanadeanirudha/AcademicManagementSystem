using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeCourseSubjectTaughtServiceAccess : IEmployeeCourseSubjectTaughtServiceAccess
    {
        IEmployeeCourseSubjectTaughtBA _employeeCourseSubjectTaughtBA = null;
        public EmployeeCourseSubjectTaughtServiceAccess()
        {
            _employeeCourseSubjectTaughtBA = new EmployeeCourseSubjectTaughtBA();
        }
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> InsertEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item)
        {
            return _employeeCourseSubjectTaughtBA.InsertEmployeeCourseSubjectTaught(item);
        }
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> UpdateEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item)
        {
            return _employeeCourseSubjectTaughtBA.UpdateEmployeeCourseSubjectTaught(item);
        }
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> DeleteEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item)
        {
            return _employeeCourseSubjectTaughtBA.DeleteEmployeeCourseSubjectTaught(item);
        }
        public IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> GetBySearch(EmployeeCourseSubjectTaughtSearchRequest searchRequest)
        {
            return _employeeCourseSubjectTaughtBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> SelectByID(EmployeeCourseSubjectTaught item)
        {
            return _employeeCourseSubjectTaughtBA.SelectByID(item);
        }
    }
}
