using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OrganisationDirectorMasterServiceAccess : IOrganisationDirectorMasterServiceAccess
    {
        IOrganisationDirectorMasterBA _organisationDirectorMasterBA = null;
        public OrganisationDirectorMasterServiceAccess()
        {
            _organisationDirectorMasterBA = new OrganisationDirectorMasterBA();
        }
        public IBaseEntityResponse<OrganisationDirectorMaster> InsertOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            return _organisationDirectorMasterBA.InsertOrganisationDirectorMaster(item);
        }
        public IBaseEntityResponse<OrganisationDirectorMaster> UpdateOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            return _organisationDirectorMasterBA.UpdateOrganisationDirectorMaster(item);
        }
        public IBaseEntityResponse<OrganisationDirectorMaster> DeleteOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            return _organisationDirectorMasterBA.DeleteOrganisationDirectorMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetBySearch(OrganisationDirectorMasterSearchRequest searchRequest)
        {
            return _organisationDirectorMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationDirectorMaster> SelectByID(OrganisationDirectorMaster item)
        {
            return _organisationDirectorMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetUserEntityCentrewiseSearchList(OrganisationDirectorMasterSearchRequest searchRequest)
        {
            return _organisationDirectorMasterBA.GetUserEntityCentrewiseSearchList(searchRequest);
        }
    }
}
