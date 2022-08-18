using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class FeeCriteriaParametersAndValuesServiceAccess : IFeeCriteriaParametersAndValuesServiceAccess
    {
        IFeeCriteriaParametersAndValuesBA _feeCriteriaParametersAndValuesBA = null;
        public FeeCriteriaParametersAndValuesServiceAccess()
        {
            _feeCriteriaParametersAndValuesBA = new FeeCriteriaParametersAndValuesBA();
        }
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> InsertFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            return _feeCriteriaParametersAndValuesBA.InsertFeeCriteriaParametersAndValues(item);
        }
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> UpdateFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            return _feeCriteriaParametersAndValuesBA.UpdateFeeCriteriaParametersAndValues(item);
        }
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> DeleteFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            return _feeCriteriaParametersAndValuesBA.DeleteFeeCriteriaParametersAndValues(item);
        }
        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetBySearch(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            return _feeCriteriaParametersAndValuesBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> SearchList(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            return _feeCriteriaParametersAndValuesBA.SearchList(searchRequest);
        }
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> SelectByID(FeeCriteriaParametersAndValues item)
        {
            return _feeCriteriaParametersAndValuesBA.SelectByID(item);
        }
       
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters>GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            return _feeCriteriaParametersAndValuesBA.GetFeePredefinedCriteriaParametersList(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues>GetPredefinedCriteriaParametersValueList(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            return _feeCriteriaParametersAndValuesBA.GetPredefinedCriteriaParametersValueList(searchRequest);
        }
    }
}
