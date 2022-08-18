using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ISalaryDeductionMasterDataProvider
	{
		IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item);
		IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item);
		IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item);
		IBaseEntityCollectionResponse<SalaryDeductionMaster> GetSalaryDeductionMasterBySearch(SalaryDeductionMasterSearchRequest searchRequest);
		IBaseEntityResponse<SalaryDeductionMaster> GetSalaryDeductionMasterByID(SalaryDeductionMaster item);

        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetAllowanceHeadNameList(SalaryDeductionMasterSearchRequest searchRequest);
    }
}
