using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IStudentChangeCourseRequestApplicationDataProvider
    {
        IBaseEntityResponse<StudentChangeCourseRequestApplication> InsertStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item);
        IBaseEntityResponse<StudentChangeCourseRequestApplication> UpdateStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item);
        IBaseEntityResponse<StudentChangeCourseRequestApplication> DeleteStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item);
        IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetStudentChangeCourseRequestApplicationBySearch(StudentChangeCourseRequestApplicationSearchRequest searchRequest);
        IBaseEntityResponse<StudentChangeCourseRequestApplication> GetStudentChangeCourseRequestApplicationByID(StudentChangeCourseRequestApplication item);
        IBaseEntityResponse<StudentChangeCourseRequestApplication> SelectByUserLoginId(StudentChangeCourseRequestApplication item);
        IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetBySearchlist(StudentChangeCourseRequestApplicationSearchRequest searchRequest);

        
    }
}
