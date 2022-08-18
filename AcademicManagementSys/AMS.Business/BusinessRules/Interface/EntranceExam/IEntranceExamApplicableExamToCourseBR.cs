using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IEntranceExamApplicableExamToCourseBR
    {
        IValidateBusinessRuleResponse InsertEntranceExamApplicableExamToCourseValidate(EntranceExamApplicableExamToCourse item);
        IValidateBusinessRuleResponse UpdateEntranceExamApplicableExamToCourseValidate(EntranceExamApplicableExamToCourse item);
        IValidateBusinessRuleResponse DeleteEntranceExamApplicableExamToCourseValidate(EntranceExamApplicableExamToCourse item);
    }
}
