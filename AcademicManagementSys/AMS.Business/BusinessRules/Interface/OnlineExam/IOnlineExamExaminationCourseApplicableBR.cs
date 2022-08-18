using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineExamExaminationCourseApplicableBR
    {
        IValidateBusinessRuleResponse InsertOnlineExamExaminationCourseApplicableValidate(OnlineExamExaminationCourseApplicable item);
        IValidateBusinessRuleResponse UpdateOnlineExamExaminationCourseApplicableValidate(OnlineExamExaminationCourseApplicable item);
        IValidateBusinessRuleResponse DeleteOnlineExamExaminationCourseApplicableValidate(OnlineExamExaminationCourseApplicable item);
    }
}
