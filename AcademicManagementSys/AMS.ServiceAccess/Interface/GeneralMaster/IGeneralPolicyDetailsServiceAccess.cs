using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPolicyDetailsServiceAccess
    {
        IBaseEntityResponse<GeneralPolicyDetails> InsertGeneralPolicyDetails(GeneralPolicyDetails item);
        IBaseEntityResponse<GeneralPolicyDetails> UpdateGeneralPolicyDetails(GeneralPolicyDetails item);
        IBaseEntityResponse<GeneralPolicyDetails> DeleteGeneralPolicyDetails(GeneralPolicyDetails item);
        IBaseEntityCollectionResponse<GeneralPolicyDetails> GetBySearch(GeneralPolicyDetailsSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPolicyDetails> SelectByID(GeneralPolicyDetails item);
        IBaseEntityCollectionResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsList(GeneralPolicyDetailsSearchRequest searchRequest); 
    }
}
