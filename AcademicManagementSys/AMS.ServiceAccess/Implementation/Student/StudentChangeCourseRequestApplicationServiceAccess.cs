using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class StudentChangeCourseRequestApplicationServiceAccess : IStudentChangeCourseRequestApplicationServiceAccess
    {
        IStudentChangeCourseRequestApplicationBA _StudentChangeCourseRequestApplicationBA = null;
        public StudentChangeCourseRequestApplicationServiceAccess()
        {
            _StudentChangeCourseRequestApplicationBA = new StudentChangeCourseRequestApplicationBA();
        }
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> InsertStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            return _StudentChangeCourseRequestApplicationBA.InsertStudentChangeCourseRequestApplication(item);
        }
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> UpdateStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            return _StudentChangeCourseRequestApplicationBA.UpdateStudentChangeCourseRequestApplication(item);
        }
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> DeleteStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            return _StudentChangeCourseRequestApplicationBA.DeleteStudentChangeCourseRequestApplication(item);
        }
        public IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetBySearch(StudentChangeCourseRequestApplicationSearchRequest searchRequest)
        {
            return _StudentChangeCourseRequestApplicationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> SelectByID(StudentChangeCourseRequestApplication item)
        {
            return _StudentChangeCourseRequestApplicationBA.SelectByID(item);
        }
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> SelectByUserLoginId(StudentChangeCourseRequestApplication item)
        {
            return _StudentChangeCourseRequestApplicationBA.SelectByUserLoginId(item);
        }
        public IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetBySearchlist(StudentChangeCourseRequestApplicationSearchRequest searchRequest)
        {
            return _StudentChangeCourseRequestApplicationBA.GetBySearchlist(searchRequest);
        }
       
        
    }
}
