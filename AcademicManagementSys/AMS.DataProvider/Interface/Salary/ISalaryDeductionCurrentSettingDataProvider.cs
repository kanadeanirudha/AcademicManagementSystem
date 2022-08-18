using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ISalaryDeductionCurrentSettingDataProvider
	{
		IBaseEntityResponse<SalaryDeductionCurrentSetting> InsertSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item);
		IBaseEntityResponse<SalaryDeductionCurrentSetting> UpdateSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item);
		IBaseEntityResponse<SalaryDeductionCurrentSetting> DeleteSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item);
		IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetSalaryDeductionCurrentSettingBySearch(SalaryDeductionCurrentSettingSearchRequest searchRequest);
		IBaseEntityResponse<SalaryDeductionCurrentSetting> GetSalaryDeductionCurrentSettingByID(SalaryDeductionCurrentSetting item);

        IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetAllowanceHeadNameList(SalaryDeductionCurrentSettingSearchRequest searchRequest);
    }
}
