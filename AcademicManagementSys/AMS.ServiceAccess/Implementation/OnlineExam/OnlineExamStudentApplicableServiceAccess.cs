using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Business.BusinessActions;
using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OnlineExamStudentApplicableServiceAccess : IOnlineExamStudentApplicableServiceAccess
    {
        IOnlineExamStudentApplicableBA _OnlineExamStudentApplicableBA = null;
        public OnlineExamStudentApplicableServiceAccess()
        {
            _OnlineExamStudentApplicableBA = new OnlineExamStudentApplicableBA();
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> CourseYearListOnlineExaminationMasterWise(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            return _OnlineExamStudentApplicableBA.CourseYearListOnlineExaminationMasterWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> SubjectListOnlineCourseYearWise(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            return _OnlineExamStudentApplicableBA.SubjectListOnlineCourseYearWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> SectionListOnlineCourseYearWise(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            return _OnlineExamStudentApplicableBA.SectionListOnlineCourseYearWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> GetOnlineExamStudentApplicableList(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            return _OnlineExamStudentApplicableBA.GetOnlineExamStudentApplicableList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamStudentAllotedList(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            return _OnlineExamStudentApplicableBA.OnlineExamStudentAllotedList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamStudentApplicable> AddStudentForExam(OnlineExamStudentApplicable item)
        {
            return _OnlineExamStudentApplicableBA.AddStudentForExam(item);
        }
        public IBaseEntityResponse<OnlineExamStudentApplicable> RemoveStudentFromExam(OnlineExamStudentApplicable item)
        {
            return _OnlineExamStudentApplicableBA.RemoveStudentFromExam(item);
        }
    }
}
