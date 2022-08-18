using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExaminationMasterAndCourseApplicableServiceAccess
    {
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> InsertOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item);
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> UpdateOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item);
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> DeleteOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item);
        IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> GetOnlineExaminationMasterAndCourseApplicableSelectAll(OnlineExaminationMasterAndCourseApplicableSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> SelectOnlineExaminationMasterAndCourseApplicableByID(OnlineExaminationMasterAndCourseApplicable item);
    }
}
