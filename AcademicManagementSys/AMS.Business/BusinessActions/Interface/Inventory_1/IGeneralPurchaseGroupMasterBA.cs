using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralPurchaseGroupMasterBA
    {
        IBaseEntityResponse<GeneralPurchaseGroupMaster> InsertGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> UpdateGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> DeleteGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetBySearch(GeneralPurchaseGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> SelectByID(GeneralPurchaseGroupMaster item);
        IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterSearchList(GeneralPurchaseGroupMasterSearchRequest searchRequest);

    }
}
