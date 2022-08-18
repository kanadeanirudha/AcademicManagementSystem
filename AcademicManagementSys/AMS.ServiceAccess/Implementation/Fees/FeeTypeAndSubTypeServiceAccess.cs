using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FeeTypeAndSubTypeServiceAccess : IFeeTypeAndSubTypeServiceAccess
    {
		IFeeTypeAndSubTypeBA _FeeTypeAndSubTypeBA = null;
		public FeeTypeAndSubTypeServiceAccess()
		{
			_FeeTypeAndSubTypeBA = new FeeTypeAndSubTypeBA();
		}
		public IBaseEntityResponse<FeeTypeAndSubType> InsertFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			return _FeeTypeAndSubTypeBA.InsertFeeTypeAndSubType(item);
		}
		public IBaseEntityResponse<FeeTypeAndSubType> UpdateFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			return _FeeTypeAndSubTypeBA.UpdateFeeTypeAndSubType(item);
		}
		public IBaseEntityResponse<FeeTypeAndSubType> DeleteFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			return _FeeTypeAndSubTypeBA.DeleteFeeTypeAndSubType(item);
		}
		public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetBySearch(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
			return _FeeTypeAndSubTypeBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeList(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
            return _FeeTypeAndSubTypeBA.GetFeeSubTypeList(searchRequest);
		}
		public IBaseEntityResponse<FeeTypeAndSubType> SelectByID(FeeTypeAndSubType item)
		{
			return _FeeTypeAndSubTypeBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeSearchList(FeeTypeAndSubTypeSearchRequest searchRequest)
        {
            return _FeeTypeAndSubTypeBA.GetFeeSubTypeSearchList(searchRequest);
        }
    }
}
