using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FeeCriteriaMasterAndDetailsServiceAccess : IFeeCriteriaMasterAndDetailsServiceAccess
    {
		IFeeCriteriaMasterAndDetailsBA _FeeCriteriaMasterAndDetailsBA = null;
		public FeeCriteriaMasterAndDetailsServiceAccess()
		{
			_FeeCriteriaMasterAndDetailsBA = new FeeCriteriaMasterAndDetailsBA();
		}
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> InsertFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item)
		{
			return _FeeCriteriaMasterAndDetailsBA.InsertFeeCriteriaMasterAndDetails(item);
		}
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> UpdateFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item)
		{
			return _FeeCriteriaMasterAndDetailsBA.UpdateFeeCriteriaMasterAndDetails(item);
		}
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> DeleteFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item)
		{
			return _FeeCriteriaMasterAndDetailsBA.DeleteFeeCriteriaMasterAndDetails(item);
		}
		public IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> GetBySearch(FeeCriteriaMasterAndDetailsSearchRequest searchRequest)
		{
			return _FeeCriteriaMasterAndDetailsBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeTypeList(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
            return _FeeCriteriaMasterAndDetailsBA.GetFeeTypeList(searchRequest);
		}
        public IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> GetCriteriaMasterList(FeeCriteriaMasterAndDetailsSearchRequest searchRequest)
		{
            return _FeeCriteriaMasterAndDetailsBA.GetCriteriaMasterList(searchRequest);
		}
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> SelectByID(FeeCriteriaMasterAndDetails item)
		{
			return _FeeCriteriaMasterAndDetailsBA.SelectByID(item);
		}
    }
}
