using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralEducationMasterServiceAccess : IGeneralEducationMasterServiceAccess
    {
        IGeneralEducationMasterBA _generalEducationMaster = null;

        public GeneralEducationMasterServiceAccess()
        {
            _generalEducationMaster = new GeneralEducationMasterBA();
        }

        public IBaseEntityResponse<GeneralEducationMaster> InsertGeneralEducationMaster(GeneralEducationMaster item)
        {
            return _generalEducationMaster.InsertGeneralEducationMaster(item);
        }

        public IBaseEntityResponse<GeneralEducationMaster> UpdateGeneralEducationMaster(GeneralEducationMaster item)
        {
            return _generalEducationMaster.UpdateGeneralEducationMaster(item);
        }

        public IBaseEntityResponse<GeneralEducationMaster> DeleteGeneralEducationMaster(GeneralEducationMaster item)
        {
            return _generalEducationMaster.DeleteGeneralEducationMaster(item);
        }

        public IBaseEntityCollectionResponse<GeneralEducationMaster> GetBySearch(GeneralEducationMasterSearchRequest searchRequest)
        {
            return _generalEducationMaster.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<GeneralEducationMaster> SelectByID(GeneralEducationMaster item)
        {
            return _generalEducationMaster.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralEducationMaster> GetByEducationTypeID(GeneralEducationMasterSearchRequest searchRequest)
        {
            return _generalEducationMaster.GetByEducationTypeID(searchRequest);
        }

    }
}
