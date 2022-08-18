using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamStudentApplicableServiceAccess
    {

        IBaseEntityCollectionResponse<OnlineExamStudentApplicable> CourseYearListOnlineExaminationMasterWise(OnlineExamStudentApplicableSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamStudentApplicable> SubjectListOnlineCourseYearWise(OnlineExamStudentApplicableSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamStudentApplicable> SectionListOnlineCourseYearWise(OnlineExamStudentApplicableSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamStudentApplicable> GetOnlineExamStudentApplicableList(OnlineExamStudentApplicableSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamStudentAllotedList(OnlineExamStudentApplicableSearchRequest searchRequest);

        IBaseEntityResponse<OnlineExamStudentApplicable> AddStudentForExam(OnlineExamStudentApplicable item);
        IBaseEntityResponse<OnlineExamStudentApplicable> RemoveStudentFromExam(OnlineExamStudentApplicable item);
    }
}
