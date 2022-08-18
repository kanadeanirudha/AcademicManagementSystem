using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPolicyMasterServiceAccess
    {
        IBaseEntityResponse<GeneralPolicyMaster> InsertGeneralPolicyMaster(GeneralPolicyMaster item);
        IBaseEntityResponse<GeneralPolicyMaster> UpdateGeneralPolicyMaster(GeneralPolicyMaster item);
        IBaseEntityResponse<GeneralPolicyMaster> DeleteGeneralPolicyMaster(GeneralPolicyMaster item);
        IBaseEntityCollectionResponse<GeneralPolicyMaster> GetBySearch(GeneralPolicyMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPolicyMaster> SelectByID(GeneralPolicyMaster item);
        IBaseEntityCollectionResponse<GeneralPolicyMaster> GetGeneralPolicyMasterList(GeneralPolicyMasterSearchRequest searchRequest); 
    }
}
