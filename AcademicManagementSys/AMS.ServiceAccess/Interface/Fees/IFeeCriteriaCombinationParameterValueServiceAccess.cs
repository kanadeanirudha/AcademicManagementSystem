using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IFeeCriteriaCombinationParameterValueServiceAccess
    {
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> InsertFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item);
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> UpdateFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item);
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> DeleteFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item);
        IBaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue> GetBySearch(FeeCriteriaCombinationParameterValueSearchRequest searchRequest);
        IBaseEntityResponse<FeeCriteriaCombinationParameterValue> SelectByID(FeeCriteriaCombinationParameterValue item);
    }
}
