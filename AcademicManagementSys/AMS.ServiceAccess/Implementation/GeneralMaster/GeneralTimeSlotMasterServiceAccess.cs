using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralTimeSlotMasterServiceAccess : IGeneralTimeSlotMasterServiceAccess
    {
        IGeneralTimeSlotMasterBA _generalTimeSlotMasterBA = null;
        public GeneralTimeSlotMasterServiceAccess()
        {
            _generalTimeSlotMasterBA = new GeneralTimeSlotMasterBA();
        }
        public IBaseEntityResponse<GeneralTimeSlotMaster> InsertGeneralTimeSlotMaster(GeneralTimeSlotMaster item)
        {
            return _generalTimeSlotMasterBA.InsertGeneralTimeSlotMaster(item);
        }
        public IBaseEntityResponse<GeneralTimeSlotMaster> UpdateGeneralTimeSlotMaster(GeneralTimeSlotMaster item)
        {
            return _generalTimeSlotMasterBA.UpdateGeneralTimeSlotMaster(item);
        }
        public IBaseEntityResponse<GeneralTimeSlotMaster> DeleteGeneralTimeSlotMaster(GeneralTimeSlotMaster item)
        {
            return _generalTimeSlotMasterBA.DeleteGeneralTimeSlotMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetBySearch(GeneralTimeSlotMasterSearchRequest searchRequest)
        {
            return _generalTimeSlotMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralTimeSlotMaster> SelectByID(GeneralTimeSlotMaster item)
        {
            return _generalTimeSlotMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterSearchList(GeneralTimeSlotMasterSearchRequest searchRequest)
        {
            return _generalTimeSlotMasterBA.GeneralTimeSlotMasterSearchList(searchRequest);
        }

        //For GeneralTimeSlotMaster searchlist
        public IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetGeneralTimeZoneMasterSearchlist(GeneralTimeSlotMasterSearchRequest searchRequest)
        {
            return _generalTimeSlotMasterBA.GetGeneralTimeZoneMasterSearchlist(searchRequest);
        }
    }
}
