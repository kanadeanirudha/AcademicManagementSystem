using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class FeeCriteriaCombinationParameterValueServiceAccess : IFeeCriteriaCombinationParameterValueServiceAccess
    {
        IFeeCriteriaCombinationParameterValueBA _feeCriteriaCombinationParameterValueBA = null;
        public FeeCriteriaCombinationParameterValueServiceAccess()
        {
            _feeCriteriaCombinationParameterValueBA = new FeeCriteriaCombinationParameterValueBA();
        }
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> InsertFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item)
        {
            return _feeCriteriaCombinationParameterValueBA.InsertFeeCriteriaCombinationParameterValue(item);
        }
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> UpdateFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item)
        {
            return _feeCriteriaCombinationParameterValueBA.UpdateFeeCriteriaCombinationParameterValue(item);
        }
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> DeleteFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item)
        {
            return _feeCriteriaCombinationParameterValueBA.DeleteFeeCriteriaCombinationParameterValue(item);
        }
        public IBaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue> GetBySearch(FeeCriteriaCombinationParameterValueSearchRequest searchRequest)
        {
            return _feeCriteriaCombinationParameterValueBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> SelectByID(FeeCriteriaCombinationParameterValue item)
        {
            return _feeCriteriaCombinationParameterValueBA.SelectByID(item);
        }
    }
}
