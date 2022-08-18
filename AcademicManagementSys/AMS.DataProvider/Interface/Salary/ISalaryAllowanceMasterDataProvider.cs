using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ISalaryAllowanceMasterDataProvider
	{
		IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceMaster(SalaryAllowanceMaster item);
		IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceMaster(SalaryAllowanceMaster item);
		IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceMaster(SalaryAllowanceMaster item);
		IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetSalaryAllowanceMasterBySearch(SalaryAllowanceMasterSearchRequest searchRequest);
		IBaseEntityResponse<SalaryAllowanceMaster> GetSalaryAllowanceMasterByID(SalaryAllowanceMaster item);

        IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetAllowanceHeadNameList(SalaryAllowanceMasterSearchRequest searchRequest);
    }
}
