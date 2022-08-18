using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class ScholarShipMasterServiceAccess : IScholarShipMasterServiceAccess
    {
        IScholarShipMasterBA _scholarShipMasterBA = null;
        public ScholarShipMasterServiceAccess()
        {
            _scholarShipMasterBA = new ScholarShipMasterBA();
        }
        public IBaseEntityResponse<ScholarShipMaster> InsertScholarShipMaster(ScholarShipMaster item)
        {
            return _scholarShipMasterBA.InsertScholarShipMaster(item);
        }
        public IBaseEntityResponse<ScholarShipMaster> UpdateScholarShipMaster(ScholarShipMaster item)
        {
            return _scholarShipMasterBA.UpdateScholarShipMaster(item);
        }
        public IBaseEntityResponse<ScholarShipMaster> DeleteScholarShipMaster(ScholarShipMaster item)
        {
            return _scholarShipMasterBA.DeleteScholarShipMaster(item);
        }
        public IBaseEntityCollectionResponse<ScholarShipMaster> GetBySearch(ScholarShipMasterSearchRequest searchRequest)
        {
            return _scholarShipMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<ScholarShipMaster> GetAccountTypeList(ScholarShipMasterSearchRequest searchRequest)
        {
            return _scholarShipMasterBA.GetAccountTypeList(searchRequest);
        }
        public IBaseEntityResponse<ScholarShipMaster> SelectByID(ScholarShipMaster item)
        {
            return _scholarShipMasterBA.SelectByID(item);
        }
    }
}
