using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationElectiveGrpMasterServiceAccess : IOrganisationElectiveGrpMasterServiceAccess
    {
        IOrganisationElectiveGrpMasterBA _organisationElectiveGrpMasterBA = null;
        public OrganisationElectiveGrpMasterServiceAccess()
        {
            _organisationElectiveGrpMasterBA = new OrganisationElectiveGrpMasterBA();
        }
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> InsertOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item)
        {
            return _organisationElectiveGrpMasterBA.InsertOrganisationElectiveGrpMaster(item);
        }
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> UpdateOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item)
        {
            return _organisationElectiveGrpMasterBA.UpdateOrganisationElectiveGrpMaster(item);
        }
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> DeleteOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item)
        {
            return _organisationElectiveGrpMasterBA.DeleteOrganisationElectiveGrpMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationElectiveGrpMaster> GetBySearch(OrganisationElectiveGrpMasterSearchRequest searchRequest)
        {
            return _organisationElectiveGrpMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> SelectByID(OrganisationElectiveGrpMaster item)
        {
            return _organisationElectiveGrpMasterBA.SelectByID(item);
        }
    }
}
 