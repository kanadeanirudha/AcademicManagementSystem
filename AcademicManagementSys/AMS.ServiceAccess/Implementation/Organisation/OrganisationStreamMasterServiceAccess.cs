using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;


namespace AMS.ServiceAccess
{
   public class OrganisationStreamMasterServiceAccess : IOrganisationStreamMasterServiceAccess
    {
                IOrganisationStreamMasterBA _orgStreamMasterBA = null;

        public OrganisationStreamMasterServiceAccess()
        {
            _orgStreamMasterBA = new OrganisationStreamMasterBA();
        }

        public IBaseEntityResponse<OrganisationStreamMaster> InsertOrganisationStreamMaster(OrganisationStreamMaster item)
        {
            return _orgStreamMasterBA.InsertOrganisationStreamMaster(item);
        }

        public IBaseEntityResponse<OrganisationStreamMaster> UpdateOrganisationStreamMaster(OrganisationStreamMaster item)
        {
            return _orgStreamMasterBA.UpdateOrganisationStreamMaster(item);
        }

        public IBaseEntityResponse<OrganisationStreamMaster> DeleteOrganisationStreamMaster(OrganisationStreamMaster item)
        {
            return _orgStreamMasterBA.DeleteOrganisationStreamMaster(item);
        }

        public IBaseEntityCollectionResponse<OrganisationStreamMaster> GetBySearch(OrganisationStreamMasterSearchRequest searchRequest)
        {
            return _orgStreamMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationStreamMaster> GetBySearchList(OrganisationStreamMasterSearchRequest searchRequest)
        {
            return _orgStreamMasterBA.GetBySearchList(searchRequest);
        }


        public IBaseEntityResponse<OrganisationStreamMaster> SelectByID(OrganisationStreamMaster item)
        {
            return _orgStreamMasterBA.SelectByID(item);
        }
    }
}
