using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
	public interface ISalaryAllowanceMasterServiceAccess
	{
		IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceMaster(SalaryAllowanceMaster item);
		IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceMaster(SalaryAllowanceMaster item);
		IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceMaster(SalaryAllowanceMaster item);
		IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearch(SalaryAllowanceMasterSearchRequest searchRequest);
		IBaseEntityResponse<SalaryAllowanceMaster> SelectByID(SalaryAllowanceMaster item);
        IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetAllowanceHeadNameList(SalaryAllowanceMasterSearchRequest searchRequest);
	}
}
