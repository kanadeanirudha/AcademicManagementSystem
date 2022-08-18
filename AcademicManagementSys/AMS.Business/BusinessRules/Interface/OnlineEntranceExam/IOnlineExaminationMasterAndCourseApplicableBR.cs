using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineExaminationMasterAndCourseApplicableBR
    {
        IValidateBusinessRuleResponse InsertOnlineExaminationMasterAndCourseApplicableValidate(OnlineExaminationMasterAndCourseApplicable item);
        IValidateBusinessRuleResponse UpdateOnlineExaminationMasterAndCourseApplicableValidate(OnlineExaminationMasterAndCourseApplicable item);
        IValidateBusinessRuleResponse DeleteOnlineExaminationMasterAndCourseApplicableValidate(OnlineExaminationMasterAndCourseApplicable item);
    }
}
