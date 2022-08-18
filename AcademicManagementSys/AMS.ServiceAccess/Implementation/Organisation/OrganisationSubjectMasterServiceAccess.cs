using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSubjectMasterServiceAccess : IOrganisationSubjectMasterServiceAccess
    {
        IOrganisationSubjectMasterBA _organisationSubjectMasterBA = null;
        public OrganisationSubjectMasterServiceAccess()
        {
            _organisationSubjectMasterBA = new OrganisationSubjectMasterBA();
        }
        public IBaseEntityResponse<OrganisationSubjectMaster> InsertOrganisationSubjectMaster(OrganisationSubjectMaster item)
        {
            return _organisationSubjectMasterBA.InsertOrganisationSubjectMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubjectMaster> UpdateOrganisationSubjectMaster(OrganisationSubjectMaster item)
        {
            return _organisationSubjectMasterBA.UpdateOrganisationSubjectMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubjectMaster> DeleteOrganisationSubjectMaster(OrganisationSubjectMaster item)
        {
            return _organisationSubjectMasterBA.DeleteOrganisationSubjectMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetBySearch(OrganisationSubjectMasterSearchRequest searchRequest)
        {
            return _organisationSubjectMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetBySearchList(OrganisationSubjectMasterSearchRequest searchRequest)
        {
            return _organisationSubjectMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetSubjectList(OrganisationSubjectMasterSearchRequest searchRequest)
        {
            return _organisationSubjectMasterBA.GetSubjectList(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectMaster> SelectByID(OrganisationSubjectMaster item)
        {
            return _organisationSubjectMasterBA.SelectByID(item);
        }
    }
}
