using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineEntranceExamQuestionBankMasterBR
    {
        IValidateBusinessRuleResponse InsertSubjectOnlineExamQuestionBankValidate(OnlineEntranceExamQuestionBankMaster item);
        IValidateBusinessRuleResponse InsertOnlineEntranceExamQuestionBankMasterValidate(OnlineEntranceExamQuestionBankMaster item);
        IValidateBusinessRuleResponse UpdateOnlineEntranceExamQuestionBankMasterValidate(OnlineEntranceExamQuestionBankMaster item);
        IValidateBusinessRuleResponse DeleteOnlineEntranceExamQuestionBankMasterValidate(OnlineEntranceExamQuestionBankMaster item);
    }
}
