using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface ISalaryDeductionCurrentSettingBA
	{
		IBaseEntityResponse<SalaryDeductionCurrentSetting> InsertSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item);
		IBaseEntityResponse<SalaryDeductionCurrentSetting> UpdateSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item);
		IBaseEntityResponse<SalaryDeductionCurrentSetting> DeleteSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item);
		IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetBySearch(SalaryDeductionCurrentSettingSearchRequest searchRequest);
		IBaseEntityResponse<SalaryDeductionCurrentSetting> SelectByID(SalaryDeductionCurrentSetting item);
        IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetAllowanceHeadNameList(SalaryDeductionCurrentSettingSearchRequest searchRequest);

	}
}
