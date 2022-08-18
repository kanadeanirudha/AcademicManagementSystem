using System;
using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class GeneralReligionMasterServiceAccess : IGeneralReligionMasterServiceAccess
    {
        IGeneralReligionMasterBA _generalReligionMasterBA = null;

        public GeneralReligionMasterServiceAccess()
        {
            _generalReligionMasterBA = new GeneralReligionMasterBA();
        }

        public IBaseEntityResponse<GeneralReligionMaster> InsertGeneralReligionMaster(GeneralReligionMaster item)
        {
            return _generalReligionMasterBA.InsertGeneralReligionMaster(item);
        }

        public IBaseEntityResponse<GeneralReligionMaster> UpdateGeneralReligionMaster(GeneralReligionMaster item)
        {
            return _generalReligionMasterBA.UpdateGeneralReligionMaster(item);
        }

        public IBaseEntityResponse<GeneralReligionMaster> DeleteGeneralReligionMaster(GeneralReligionMaster item)
        {
            return _generalReligionMasterBA.DeleteGeneralReligionMaster(item);
        }

        public IBaseEntityCollectionResponse<GeneralReligionMaster> GetBySearch(GeneralReligionMasterSearchRequest searchRequest)
        {
            return _generalReligionMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<GeneralReligionMaster> SelectByID(GeneralReligionMaster item)
        {
            return _generalReligionMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<GeneralReligionMaster> GetBySearchList(GeneralReligionMasterSearchRequest searchRequest)
        {
            return _generalReligionMasterBA.GetBySearchList(searchRequest);
        }
    }
}
