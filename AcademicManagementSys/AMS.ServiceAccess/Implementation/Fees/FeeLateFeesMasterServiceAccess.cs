using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
	public class FeeLateFeesMasterServiceAccess : IFeeLateFeesMasterServiceAccess
	{
		IFeeLateFeesMasterBA _feeLateFeesMasterBA = null;
		public FeeLateFeesMasterServiceAccess()
		{
			_feeLateFeesMasterBA = new FeeLateFeesMasterBA();
		}
		public IBaseEntityResponse<FeeLateFeesMaster> InsertFeeLateFeesMaster(FeeLateFeesMaster item)
		{
			return _feeLateFeesMasterBA.InsertFeeLateFeesMaster(item);
		}
		public IBaseEntityResponse<FeeLateFeesMaster> UpdateFeeLateFeesMaster(FeeLateFeesMaster item)
		{
			return _feeLateFeesMasterBA.UpdateFeeLateFeesMaster(item);
		}
		public IBaseEntityResponse<FeeLateFeesMaster> DeleteFeeLateFeesMaster(FeeLateFeesMaster item)
		{
			return _feeLateFeesMasterBA.DeleteFeeLateFeesMaster(item);
		}
		public IBaseEntityCollectionResponse<FeeLateFeesMaster> GetBySearch(FeeLateFeesMasterSearchRequest searchRequest)
		{
			return _feeLateFeesMasterBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<FeeLateFeesMaster> GetPeriodSearchList(FeeLateFeesMasterSearchRequest searchRequest)
        {
            return _feeLateFeesMasterBA.GetPeriodSearchList(searchRequest);
        }
		public IBaseEntityResponse<FeeLateFeesMaster> SelectByID(FeeLateFeesMaster item)
		{
			return _feeLateFeesMasterBA.SelectByID(item);
		}
	}
}
