using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class OrganisationSubGrpRuleSessionwiseServiceAccess : IOrganisationSubGrpRuleSessionwiseServiceAccess
	{
		IOrganisationSubGrpRuleSessionwiseBA _organisationSubGrpRuleSessionwiseBA = null;
		public OrganisationSubGrpRuleSessionwiseServiceAccess()
		{
			_organisationSubGrpRuleSessionwiseBA = new OrganisationSubGrpRuleSessionwiseBA();
		}
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> InsertOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item)
		{
			return _organisationSubGrpRuleSessionwiseBA.InsertOrganisationSubGrpRuleSessionwise(item);
		}
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> UpdateOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item)
		{
			return _organisationSubGrpRuleSessionwiseBA.UpdateOrganisationSubGrpRuleSessionwise(item);
		}
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> DeleteOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item)
		{
			return _organisationSubGrpRuleSessionwiseBA.DeleteOrganisationSubGrpRuleSessionwise(item);
		}
		public IBaseEntityCollectionResponse<OrganisationSubGrpRuleSessionwise> GetBySearch(OrganisationSubGrpRuleSessionwiseSearchRequest searchRequest)
		{
			return _organisationSubGrpRuleSessionwiseBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> SelectByID(OrganisationSubGrpRuleSessionwise item)
		{
			return _organisationSubGrpRuleSessionwiseBA.SelectByID(item);
		}
	}
}
