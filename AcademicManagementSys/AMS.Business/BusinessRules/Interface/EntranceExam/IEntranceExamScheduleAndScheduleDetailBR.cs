using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
     public interface IEntranceExamScheduleAndScheduleDetailBR
    {
        //EntranceExamSchedule Table Method
         IValidateBusinessRuleResponse InsertEntranceExamScheduleValidate(EntranceExamScheduleAndScheduleDetail item);
         IValidateBusinessRuleResponse UpdateEntranceExamScheduleValidate(EntranceExamScheduleAndScheduleDetail item);
         IValidateBusinessRuleResponse DeleteEntranceExamScheduleValidate(EntranceExamScheduleAndScheduleDetail item);

         //EntranceExamScheduleDetail Table Method
         IValidateBusinessRuleResponse InsertEntranceExamScheduleDetailValidate(EntranceExamScheduleAndScheduleDetail item);
         IValidateBusinessRuleResponse UpdateEntranceExamScheduleDetailValidate(EntranceExamScheduleAndScheduleDetail item);
         IValidateBusinessRuleResponse DeleteEntranceExamScheduleDetailValidate(EntranceExamScheduleAndScheduleDetail item);

    }
}
