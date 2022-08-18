using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOnlineExamQuestionBankMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertOnlineExamQuestionBankMasterAndDetailsValidate(OnlineExamQuestionBankMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateOnlineExamQuestionBankMasterAndDetailsValidate(OnlineExamQuestionBankMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteOnlineExamQuestionBankMasterAndDetailsValidate(OnlineExamQuestionBankMasterAndDetails item);
    }
}
