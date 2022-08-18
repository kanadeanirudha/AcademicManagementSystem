using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ISalaryAllowanceCurrentSettingDataProvider
	{
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> InsertSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item);
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> UpdateSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item);
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> DeleteSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item);
		IBaseEntityCollectionResponse<SalaryAllowanceCurrentSetting> GetSalaryAllowanceCurrentSettingBySearch(SalaryAllowanceCurrentSettingSearchRequest searchRequest);
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> GetSalaryAllowanceCurrentSettingByID(SalaryAllowanceCurrentSetting item);
	}
}
