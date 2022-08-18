using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralTimeSlotMasterServiceAccess
    {
        IBaseEntityResponse<GeneralTimeSlotMaster> InsertGeneralTimeSlotMaster(GeneralTimeSlotMaster item);
        IBaseEntityResponse<GeneralTimeSlotMaster> UpdateGeneralTimeSlotMaster(GeneralTimeSlotMaster item);
        IBaseEntityResponse<GeneralTimeSlotMaster> DeleteGeneralTimeSlotMaster(GeneralTimeSlotMaster item);
        IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetBySearch(GeneralTimeSlotMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTimeSlotMaster> SelectByID(GeneralTimeSlotMaster item);
        IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterSearchList(GeneralTimeSlotMasterSearchRequest searchRequest);

        // For GeneralTimeZoneMaster Searchlist
        IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetGeneralTimeZoneMasterSearchlist(GeneralTimeSlotMasterSearchRequest searchRequest);
    }
}
