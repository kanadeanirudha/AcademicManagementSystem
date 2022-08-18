
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AMS.Business.BusinessRules.Interface.OnlineExam;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineExamSubjectGroupScheduleBR
    {
        IValidateBusinessRuleResponse InsertOnlineExamSubjectGroupScheduleValidate(OnlineExamSubjectGroupSchedule item);
        IValidateBusinessRuleResponse UpdateOnlineExamSubjectGroupScheduleValidate(OnlineExamSubjectGroupSchedule item);
        IValidateBusinessRuleResponse DeleteOnlineExamSubjectGroupScheduleValidate(OnlineExamSubjectGroupSchedule item);
    }
}
