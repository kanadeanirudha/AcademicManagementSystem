using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralUnitMasterServiceAccess : IGeneralUnitMasterServiceAccess
    {
        IGeneralUnitMasterBA _generalUnitMasterBA = null;
        public GeneralUnitMasterServiceAccess()
        {
            _generalUnitMasterBA = new GeneralUnitMasterBA();
        }
        public IBaseEntityResponse<GeneralUnitMaster> InsertGeneralUnitMaster(GeneralUnitMaster item)
        {
            return _generalUnitMasterBA.InsertGeneralUnitMaster(item);
        }
        public IBaseEntityResponse<GeneralUnitMaster> UpdateGeneralUnitMaster(GeneralUnitMaster item)
        {
            return _generalUnitMasterBA.UpdateGeneralUnitMaster(item);
        }
        public IBaseEntityResponse<GeneralUnitMaster> DeleteGeneralUnitMaster(GeneralUnitMaster item)
        {
            return _generalUnitMasterBA.DeleteGeneralUnitMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearch(GeneralUnitMasterSearchRequest searchRequest)
        {
            return _generalUnitMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearchList(GeneralUnitMasterSearchRequest searchRequest)
        {
            return _generalUnitMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralUnitMaster> SelectByID(GeneralUnitMaster item)
        {
            return _generalUnitMasterBA.SelectByID(item);
        }
    }
}
