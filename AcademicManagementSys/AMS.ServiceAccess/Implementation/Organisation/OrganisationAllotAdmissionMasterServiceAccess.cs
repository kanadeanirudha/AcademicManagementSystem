using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationAllotAdmissionMasterServiceAccess : IOrganisationAllotAdmissionMasterServiceAccess
    {
        IOrganisationAllotAdmissionMasterBA _OrganisationAllotAdmissionMasterBA = null;
        public OrganisationAllotAdmissionMasterServiceAccess()
        {
            _OrganisationAllotAdmissionMasterBA = new OrganisationAllotAdmissionMasterBA();
        }
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> InsertOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item)
        {
            return _OrganisationAllotAdmissionMasterBA.InsertOrganisationAllotAdmissionMaster(item);
        }
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> UpdateOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item)
        {
            return _OrganisationAllotAdmissionMasterBA.UpdateOrganisationAllotAdmissionMaster(item);
        }
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> DeleteOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item)
        {
            return _OrganisationAllotAdmissionMasterBA.DeleteOrganisationAllotAdmissionMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetBySearch(OrganisationAllotAdmissionMasterSearchRequest searchRequest)
        {
            return _OrganisationAllotAdmissionMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> SelectByID(OrganisationAllotAdmissionMaster item)
        {
            return _OrganisationAllotAdmissionMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetBySearchList(OrganisationAllotAdmissionMasterSearchRequest searchRequest)
        {
            return _OrganisationAllotAdmissionMasterBA.GetBySearchList(searchRequest);
        }
    }
}
