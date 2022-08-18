using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSubjectTypeMasterServiceAccess : IOrganisationSubjectTypeMasterServiceAccess
    {
        IOrganisationSubjectTypeMasterBA _organisationSubjectTypeMasterBA = null;
        public OrganisationSubjectTypeMasterServiceAccess()
        {
            _organisationSubjectTypeMasterBA = new OrganisationSubjectTypeMasterBA();
        }
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> InsertOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item)
        {
            return _organisationSubjectTypeMasterBA.InsertOrganisationSubjectTypeMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> UpdateOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item)
        {
            return _organisationSubjectTypeMasterBA.UpdateOrganisationSubjectTypeMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> DeleteOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item)
        {
            return _organisationSubjectTypeMasterBA.DeleteOrganisationSubjectTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetBySearch(OrganisationSubjectTypeMasterSearchRequest searchRequest)
        {
            return _organisationSubjectTypeMasterBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetBySubjectTypeMaterList(OrganisationSubjectTypeMasterSearchRequest searchRequest)
        {
            return _organisationSubjectTypeMasterBA.GetBySubjectTypeMaterList(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> SelectByID(OrganisationSubjectTypeMaster item)
        {
            return _organisationSubjectTypeMasterBA.SelectByID(item);
        }
    }
}
