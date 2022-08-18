using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IFeeCriteriaParametersAndValuesServiceAccess
    {
        IBaseEntityResponse<FeeCriteriaParametersAndValues> InsertFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item);
        IBaseEntityResponse<FeeCriteriaParametersAndValues> UpdateFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item);
        IBaseEntityResponse<FeeCriteriaParametersAndValues> DeleteFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item);
        IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetBySearch(FeeCriteriaParametersAndValuesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> SearchList(FeeCriteriaParametersAndValuesSearchRequest searchRequest);
        IBaseEntityResponse<FeeCriteriaParametersAndValues> SelectByID(FeeCriteriaParametersAndValues item);
        
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetPredefinedCriteriaParametersValueList(FeeCriteriaParametersAndValuesSearchRequest searchRequest);
    }
}
