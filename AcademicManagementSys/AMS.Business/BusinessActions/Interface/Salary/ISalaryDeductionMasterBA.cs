using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface ISalaryDeductionMasterBA
	{
		IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item);
		IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item);
		IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item);
		IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearch(SalaryDeductionMasterSearchRequest searchRequest);
		IBaseEntityResponse<SalaryDeductionMaster> SelectByID(SalaryDeductionMaster item);
        IBaseEntityCollectionResponse<SalaryDeductionMaster> GetAllowanceHeadNameList(SalaryDeductionMasterSearchRequest searchRequest);

	}
}
