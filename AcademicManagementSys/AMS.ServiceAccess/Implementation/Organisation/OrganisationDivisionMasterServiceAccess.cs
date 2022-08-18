using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OrganisationDivisionMasterServiceAccess :IOrganisationDivisionMasterServiceAccess
    {
               IOrganisationDivisionMasterBA _orgDivisionMasterBA = null;

        public OrganisationDivisionMasterServiceAccess()
        {
            _orgDivisionMasterBA = new OrganisationDivisionMasterBA();
        }

        public IBaseEntityResponse<OrganisationDivisionMaster> InsertOrganisationDivisionMaster(OrganisationDivisionMaster item)
        {
            return _orgDivisionMasterBA.InsertOrganisationDivisionMaster(item);
        }

        public IBaseEntityResponse<OrganisationDivisionMaster> UpdateOrganisationDivisionMaster(OrganisationDivisionMaster item)
        {
            return _orgDivisionMasterBA.UpdateOrganisationDivisionMaster(item);
        }

        public IBaseEntityResponse<OrganisationDivisionMaster> DeleteOrganisationDivisionMaster(OrganisationDivisionMaster item)
        {
            return _orgDivisionMasterBA.DeleteOrganisationDivisionMaster(item);
        }

        public IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetBySearch(OrganisationDivisionMasterSearchRequest searchRequest)
        {
            return _orgDivisionMasterBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetBySearchList(OrganisationDivisionMasterSearchRequest searchRequest)
        {
            return _orgDivisionMasterBA.GetBySearchList(searchRequest);
        }

        public IBaseEntityResponse<OrganisationDivisionMaster> SelectByID(OrganisationDivisionMaster item)
        {
            return _orgDivisionMasterBA.SelectByID(item);
        }
    }
}
