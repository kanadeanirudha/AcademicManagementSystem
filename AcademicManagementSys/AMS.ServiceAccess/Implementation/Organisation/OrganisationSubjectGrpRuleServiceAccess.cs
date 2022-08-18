using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationSubjectGrpRuleServiceAccess : IOrganisationSubjectGrpRuleServiceAccess
    {
        IOrganisationSubjectGrpRuleBA _organisationSubjectGrpRuleBA = null;
        public OrganisationSubjectGrpRuleServiceAccess()
        {
            _organisationSubjectGrpRuleBA = new OrganisationSubjectGrpRuleBA();
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.InsertOrganisationSubjectGrpRule(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.UpdateOrganisationSubjectGrpRule(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> DeleteOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.DeleteOrganisationSubjectGrpRule(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            return _organisationSubjectGrpRuleBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetForOrgSubGrpRuleSessionwise(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            return _organisationSubjectGrpRuleBA.GetForOrgSubGrpRuleSessionwise(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectByID(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.SelectByID(item);
        }


        // methods for table OrgElectiveGrpMaster
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.InsertOrgElectiveGrpMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.UpdateOrgElectiveGrpMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            return _organisationSubjectGrpRuleBA.GetOrgElectiveGrpMasterBySearch(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgElectiveGrpMasterByID(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.SelectOrgElectiveGrpMasterByID(item);
        }


        // methods for table OrgSubElectiveGrpMaster
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.InsertOrgSubElectiveGrpMaster(item);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.UpdateOrgSubElectiveGrpMaster(item);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            return _organisationSubjectGrpRuleBA.GetOrgSubElectiveGrpMasterBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubjectGroupRuleSearchList(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            return _organisationSubjectGrpRuleBA.GetOrgSubjectGroupRuleSearchList(searchRequest);
        }
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgSubElectiveGrpMasterByID(OrganisationSubjectGrpRule item)
        {
            return _organisationSubjectGrpRuleBA.SelectOrgSubElectiveGrpMasterByID(item);
        }

    }
}
