using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessRules
{
	public interface IEntranceExamBR
	{
		IValidateBusinessRuleResponse InsertEntranceExamValidate(EntranceExam item);
		IValidateBusinessRuleResponse UpdateEntranceExamValidate(EntranceExam item);
		IValidateBusinessRuleResponse DeleteEntranceExamValidate(EntranceExam item);
	}
}
