using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OrganisationStandardMasterServiceAccess : IOrganisationStandardMasterServiceAccess
    {

               IOrganisationStandardMasterBA _OrganisationStandardMasterBA = null;

        public OrganisationStandardMasterServiceAccess()
        {
            _OrganisationStandardMasterBA = new OrganisationStandardMasterBA();
        }

        public IBaseEntityResponse<OrganisationStandardMaster> InsertOrganisationStandardMaster(OrganisationStandardMaster item)
        {
            return _OrganisationStandardMasterBA.InsertOrganisationStandardMaster(item);
        }

        public IBaseEntityResponse<OrganisationStandardMaster> UpdateOrganisationStandardMaster(OrganisationStandardMaster item)
        {
            return _OrganisationStandardMasterBA.UpdateOrganisationStandardMaster(item);
        }

        public IBaseEntityResponse<OrganisationStandardMaster> DeleteOrganisationStandardMaster(OrganisationStandardMaster item)
        {
            return _OrganisationStandardMasterBA.DeleteOrganisationStandardMaster(item);
        }

        public IBaseEntityCollectionResponse<OrganisationStandardMaster> GetBySearch(OrganisationStandardMasterSearchRequest searchRequest)
        {
            return _OrganisationStandardMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<OrganisationStandardMaster> SelectByID(OrganisationStandardMaster item)
        {
            return _OrganisationStandardMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<OrganisationStandardMaster> GetBySearchList(OrganisationStandardMasterSearchRequest searchRequest)
        {
            return _OrganisationStandardMasterBA.GetBySearchList(searchRequest);
        }
    }
}

