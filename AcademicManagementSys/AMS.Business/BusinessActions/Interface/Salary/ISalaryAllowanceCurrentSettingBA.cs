using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface ISalaryAllowanceCurrentSettingBA
	{
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> InsertSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item);
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> UpdateSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item);
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> DeleteSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item);
		IBaseEntityCollectionResponse<SalaryAllowanceCurrentSetting> GetBySearch(SalaryAllowanceCurrentSettingSearchRequest searchRequest);
		IBaseEntityResponse<SalaryAllowanceCurrentSetting> SelectByID(SalaryAllowanceCurrentSetting item);
	}
}
