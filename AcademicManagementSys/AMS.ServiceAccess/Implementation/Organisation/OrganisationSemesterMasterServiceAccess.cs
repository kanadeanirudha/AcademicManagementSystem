using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSemesterMasterServiceAccess : IOrganisationSemesterMasterServiceAccess
    {
        IOrganisationSemesterMasterBA _organisationSemesterMasterBA = null;
        public OrganisationSemesterMasterServiceAccess()
        {
            _organisationSemesterMasterBA = new OrganisationSemesterMasterBA();
        }
        public IBaseEntityResponse<OrganisationSemesterMaster> InsertOrganisationSemesterMaster(OrganisationSemesterMaster item)
        {
            return _organisationSemesterMasterBA.InsertOrganisationSemesterMaster(item);
        }
        public IBaseEntityResponse<OrganisationSemesterMaster> UpdateOrganisationSemesterMaster(OrganisationSemesterMaster item)
        {
            return _organisationSemesterMasterBA.UpdateOrganisationSemesterMaster(item);
        }
        public IBaseEntityResponse<OrganisationSemesterMaster> DeleteOrganisationSemesterMaster(OrganisationSemesterMaster item)
        {
            return _organisationSemesterMasterBA.DeleteOrganisationSemesterMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetBySearch(OrganisationSemesterMasterSearchRequest searchRequest)
        {
            return _organisationSemesterMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSemesterMaster> SelectByID(OrganisationSemesterMaster item)
        {
            return _organisationSemesterMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetBySearchList(OrganisationSemesterMasterSearchRequest searchRequest)
        {
            return _organisationSemesterMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetSemester(OrganisationSemesterMasterSearchRequest searchRequest)
        {
            return _organisationSemesterMasterBA.GetSemester(searchRequest);
        }
    }
}
