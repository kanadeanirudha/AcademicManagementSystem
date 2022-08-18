using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface ISalaryGradePayMasterBA
	{
		IBaseEntityResponse<SalaryGradePayMaster> InsertSalaryGradePayMaster(SalaryGradePayMaster item);
		IBaseEntityResponse<SalaryGradePayMaster> UpdateSalaryGradePayMaster(SalaryGradePayMaster item);
		IBaseEntityResponse<SalaryGradePayMaster> DeleteSalaryGradePayMaster(SalaryGradePayMaster item);
		IBaseEntityCollectionResponse<SalaryGradePayMaster> GetBySearch(SalaryGradePayMasterSearchRequest searchRequest);
		IBaseEntityResponse<SalaryGradePayMaster> SelectByID(SalaryGradePayMaster item);
        IBaseEntityCollectionResponse<SalaryGradePayMaster> GetListGradePayAmount(SalaryGradePayMasterSearchRequest searchRequest);
	}
}
