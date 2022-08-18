using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IEntranceExamPaymentDetailsBR
    {
        // EntranceExamPaymentDetails Method
        IValidateBusinessRuleResponse InsertEntranceExamPaymentDetailsValidate(EntranceExamPaymentDetails item);
        IValidateBusinessRuleResponse UpdateEntranceExamPaymentDetailsValidate(EntranceExamPaymentDetails item);
        IValidateBusinessRuleResponse DeleteEntranceExamPaymentDetailsValidate(EntranceExamPaymentDetails item);
    }
}
