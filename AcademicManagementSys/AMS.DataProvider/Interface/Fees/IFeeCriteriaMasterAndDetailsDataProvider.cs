using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IFeeCriteriaMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<FeeCriteriaMasterAndDetails> InsertFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item);
        IBaseEntityResponse<FeeCriteriaMasterAndDetails> UpdateFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item);
        IBaseEntityResponse<FeeCriteriaMasterAndDetails> DeleteFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item);
        IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> GetFeeCriteriaMasterAndDetailsBySearch(FeeCriteriaMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeTypeList(FeeTypeAndSubTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> GetCriteriaMasterList(FeeCriteriaMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<FeeCriteriaMasterAndDetails> GetFeeCriteriaMasterAndDetailsByID(FeeCriteriaMasterAndDetails item);
    }
}
