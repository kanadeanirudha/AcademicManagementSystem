using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSubElectiveGrpMasterServiceAccess : IOrganisationSubElectiveGrpMasterServiceAccess
    {
        IOrganisationSubElectiveGrpMasterBA _organisationSubElectiveGrpMasterBA = null;
        public OrganisationSubElectiveGrpMasterServiceAccess()
        {
            _organisationSubElectiveGrpMasterBA = new OrganisationSubElectiveGrpMasterBA();
        }
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> InsertOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
        {
            return _organisationSubElectiveGrpMasterBA.InsertOrganisationSubElectiveGrpMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> UpdateOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
        {
            return _organisationSubElectiveGrpMasterBA.UpdateOrganisationSubElectiveGrpMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> DeleteOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
        {
            return _organisationSubElectiveGrpMasterBA.DeleteOrganisationSubElectiveGrpMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster> GetBySearch(OrganisationSubElectiveGrpMasterSearchRequest searchRequest)
        {
            return _organisationSubElectiveGrpMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> SelectByID(OrganisationSubElectiveGrpMaster item)
        {
            return _organisationSubElectiveGrpMasterBA.SelectByID(item);
        }
    }
}
