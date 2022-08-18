
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class FeePredefinedCriteriaParametersServiceAccess : IFeePredefinedCriteriaParametersServiceAccess
    {
        IFeePredefinedCriteriaParametersBA _FeePredefinedCriteriaParametersBA = null;
        public FeePredefinedCriteriaParametersServiceAccess()
        {
            _FeePredefinedCriteriaParametersBA = new FeePredefinedCriteriaParametersBA();
        }
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> InsertFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item)
        {
            return _FeePredefinedCriteriaParametersBA.InsertFeePredefinedCriteriaParameters(item);
        }
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> UpdateFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item)
        {
            return _FeePredefinedCriteriaParametersBA.UpdateFeePredefinedCriteriaParameters(item);
        }
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> DeleteFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item)
        {
            return _FeePredefinedCriteriaParametersBA.DeleteFeePredefinedCriteriaParameters(item);
        }
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetBySearch(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            return _FeePredefinedCriteriaParametersBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            return _FeePredefinedCriteriaParametersBA.GetFeePredefinedCriteriaParametersList(searchRequest);
        }
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> SelectByID(FeePredefinedCriteriaParameters item)
        {
            return _FeePredefinedCriteriaParametersBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetTableEntityNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            return _FeePredefinedCriteriaParametersBA.GetTableEntityNameList(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetPrimaryKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            return _FeePredefinedCriteriaParametersBA.GetPrimaryKeyFieldNameList(searchRequest);
        }
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetDisplayKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            return _FeePredefinedCriteriaParametersBA.GetDisplayKeyFieldNameList(searchRequest);
        }
    }
}
