using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IFeeCriteriaCombinationParameterValueBA
    {
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> InsertFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item);
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> UpdateFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item);
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> DeleteFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item);
        IBaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue> GetBySearch(FeeCriteriaCombinationParameterValueSearchRequest searchRequest);
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> SelectByID(FeeCriteriaCombinationParameterValue item);
    }
}
