using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessRules
{
	public interface IOnlineExaminationMasterBR
	{
		IValidateBusinessRuleResponse InsertOnlineExaminationMasterValidate(OnlineExaminationMaster item);
		IValidateBusinessRuleResponse UpdateOnlineExaminationMasterValidate(OnlineExaminationMaster item);
		IValidateBusinessRuleResponse DeleteOnlineExaminationMasterValidate(OnlineExaminationMaster item);
	}
}
