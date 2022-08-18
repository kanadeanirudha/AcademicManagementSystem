using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class GeneralGroupMasterServiceAccess : IGeneralGroupMasterServiceAccess
    {
        IGeneralGroupMasterBA _generalGroupMasterBA = null;
        public GeneralGroupMasterServiceAccess()
        {
            _generalGroupMasterBA = new GeneralGroupMasterBA();
        }
        public IBaseEntityResponse<GeneralGroupMaster> InsertGeneralGroupMaster(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.InsertGeneralGroupMaster(item);
        }
        public IBaseEntityResponse<GeneralGroupMaster> UpdateGeneralGroupMaster(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.UpdateGeneralGroupMaster(item);
        }
        public IBaseEntityResponse<GeneralGroupMaster> DeleteGeneralGroupMaster(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.DeleteGeneralGroupMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralGroupMaster> GetBySearch(GeneralGroupMasterSearchRequest searchRequest)
        {
            return _generalGroupMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralGroupMaster> SelectByID(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.SelectByID(item);
        }
        public IBaseEntityResponse<GeneralGroupMaster> InsertGroupDetails(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.InsertGroupDetails(item);
        }
        public IBaseEntityCollectionResponse<GeneralGroupMaster> EmployeeGroupDetailsGetBySearch(GeneralGroupMasterSearchRequest searchRequest)
        {
            return _generalGroupMasterBA.EmployeeGroupDetailsGetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralGroupMaster> SelectEmployeeGroupDetailsByID(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.SelectEmployeeGroupDetailsByID(item);
        }
        public IBaseEntityResponse<GeneralGroupMaster> UpdateGroupDetails(GeneralGroupMaster item)
        {
            return _generalGroupMasterBA.UpdateGroupDetails(item);
        }
        
    }
}
