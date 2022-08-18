using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IFeePredefinedCriteriaParametersDataProvider
    {
        IBaseEntityResponse<FeePredefinedCriteriaParameters> InsertFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item);
        IBaseEntityResponse<FeePredefinedCriteriaParameters> UpdateFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item);
        IBaseEntityResponse<FeePredefinedCriteriaParameters> DeleteFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersBySearch(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersByID(FeePredefinedCriteriaParameters item);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetTableEntityNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetPrimaryKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetDisplayKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest);
    }
}
