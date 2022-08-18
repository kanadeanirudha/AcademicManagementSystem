using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ISalaryGradePayMasterDataProvider
	{
		IBaseEntityResponse<SalaryGradePayMaster> InsertSalaryGradePayMaster(SalaryGradePayMaster item);
		IBaseEntityResponse<SalaryGradePayMaster> UpdateSalaryGradePayMaster(SalaryGradePayMaster item);
		IBaseEntityResponse<SalaryGradePayMaster> DeleteSalaryGradePayMaster(SalaryGradePayMaster item);
		IBaseEntityCollectionResponse<SalaryGradePayMaster> GetSalaryGradePayMasterBySearch(SalaryGradePayMasterSearchRequest searchRequest);
		IBaseEntityResponse<SalaryGradePayMaster> GetSalaryGradePayMasterByID(SalaryGradePayMaster item);
        IBaseEntityCollectionResponse<SalaryGradePayMaster> GetListGradePayAmount(SalaryGradePayMasterSearchRequest searchRequest);
	}
}
