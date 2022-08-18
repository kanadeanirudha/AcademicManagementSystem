using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
	public interface IFeeLateFeesMasterServiceAccess
	{
		IBaseEntityResponse<FeeLateFeesMaster> InsertFeeLateFeesMaster(FeeLateFeesMaster item);
		IBaseEntityResponse<FeeLateFeesMaster> UpdateFeeLateFeesMaster(FeeLateFeesMaster item);
		IBaseEntityResponse<FeeLateFeesMaster> DeleteFeeLateFeesMaster(FeeLateFeesMaster item);
		IBaseEntityCollectionResponse<FeeLateFeesMaster> GetBySearch(FeeLateFeesMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeLateFeesMaster> GetPeriodSearchList(FeeLateFeesMasterSearchRequest searchRequest);
		IBaseEntityResponse<FeeLateFeesMaster> SelectByID(FeeLateFeesMaster item);
	}
}
