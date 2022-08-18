using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationAdmissionTypeMasterServiceAccess : IOrganisationAdmissionTypeMasterServiceAccess
    {
        IOrganisationAdmissionTypeMasterBA _OrganisationAdmissionTypeMasterBA = null;
        public OrganisationAdmissionTypeMasterServiceAccess()
        {
            _OrganisationAdmissionTypeMasterBA = new OrganisationAdmissionTypeMasterBA();
        }
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> InsertOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item)
        {
            return _OrganisationAdmissionTypeMasterBA.InsertOrganisationAdmissionTypeMaster(item);
        }
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> UpdateOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item)
        {
            return _OrganisationAdmissionTypeMasterBA.UpdateOrganisationAdmissionTypeMaster(item);
        }
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> DeleteOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item)
        {
            return _OrganisationAdmissionTypeMasterBA.DeleteOrganisationAdmissionTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetBySearch(OrganisationAdmissionTypeMasterSearchRequest searchRequest)
        {
            return _OrganisationAdmissionTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> SelectByID(OrganisationAdmissionTypeMaster item)
        {
            return _OrganisationAdmissionTypeMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetBySearchList(OrganisationAdmissionTypeMasterSearchRequest searchRequest)
        {
            return _OrganisationAdmissionTypeMasterBA.GetBySearchList(searchRequest);
        }
    }
}
