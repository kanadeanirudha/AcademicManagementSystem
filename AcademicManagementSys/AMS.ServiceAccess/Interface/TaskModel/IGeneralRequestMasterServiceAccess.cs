using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralRequestMasterServiceAccess
    {
        IBaseEntityResponse<GeneralRequestMaster> InsertGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityResponse<GeneralRequestMaster> UpdateGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityResponse<GeneralRequestMaster> DeleteGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetBySearch(GeneralRequestMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetRequestCode(GeneralRequestMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralRequestMaster> SelectByID(GeneralRequestMaster item);
       IBaseEntityCollectionResponse<GeneralRequestMaster> GetGeneralRequestMasterSearchList(GeneralRequestMasterSearchRequest searchRequest);
    }
}
