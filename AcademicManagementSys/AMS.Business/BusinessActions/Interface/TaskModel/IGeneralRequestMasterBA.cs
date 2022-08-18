using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralRequestMasterBA
    {
        IBaseEntityResponse<GeneralRequestMaster> InsertGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityResponse<GeneralRequestMaster> UpdateGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityResponse<GeneralRequestMaster> DeleteGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetBySearch(GeneralRequestMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetRequestCode(GeneralRequestMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetGeneralRequestMasterSearchList(GeneralRequestMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralRequestMaster> SelectByID(GeneralRequestMaster item);
    }
}

