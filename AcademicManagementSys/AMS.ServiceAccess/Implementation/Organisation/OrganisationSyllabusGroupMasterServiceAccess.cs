using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSyllabusGroupMasterServiceAccess : IOrganisationSyllabusGroupMasterServiceAccess
    {

        // methods for table OrgSyllabusGroupMaster

        IOrganisationSyllabusGroupMasterBA _organisationSyllabusGroupMasterBA = null;
        public OrganisationSyllabusGroupMasterServiceAccess()
        {
            _organisationSyllabusGroupMasterBA = new OrganisationSyllabusGroupMasterBA();
        }
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.InsertOrganisationSyllabusGroupMaster(item);
        }
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.UpdateOrganisationSyllabusGroupMaster(item);
        }
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> DeleteOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.DeleteOrganisationSyllabusGroupMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            return _organisationSyllabusGroupMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectByID(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.SelectByID(item);
        }



        //methods for table OrgSyllabusGroupDetails

        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusDetails(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.InsertOrganisationSyllabusDetails(item);
        }
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusDetails(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.UpdateOrganisationSyllabusDetails(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusDetailsBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            return _organisationSyllabusGroupMasterBA.GetOrganisationSyllabusDetailsBySearch(searchRequest);
        }

        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectOrganisationSyllabusDetailsByID(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.SelectOrganisationSyllabusDetailsByID(item);
        }

        //methods for table OrgSyllabusGroupTopics


        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusTopics(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.InsertOrganisationSyllabusTopics(item);
        }

        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusTopics(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.UpdateOrganisationSyllabusTopics(item);
        }

        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusTopicsBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            return _organisationSyllabusGroupMasterBA.GetOrganisationSyllabusTopicsBySearch(searchRequest);
        }

        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectOrganisationSyllabusTopicsByID(OrganisationSyllabusGroupMaster item)
        {
            return _organisationSyllabusGroupMasterBA.SelectOrganisationSyllabusTopicsByID(item);
        }


    }
}
