using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class OrganisationMemberMasterServiceAccess : IOrganisationMemberMasterServiceAccess
	{
		IOrganisationMemberMasterBA _organisationMemberMasterBA = null;
		public OrganisationMemberMasterServiceAccess()
		{
			_organisationMemberMasterBA = new OrganisationMemberMasterBA();
		}
		public IBaseEntityResponse<OrganisationMemberMaster> InsertOrganisationMemberMaster(OrganisationMemberMaster item)
		{
			return _organisationMemberMasterBA.InsertOrganisationMemberMaster(item);
		}
		public IBaseEntityResponse<OrganisationMemberMaster> UpdateOrganisationMemberMaster(OrganisationMemberMaster item)
		{
			return _organisationMemberMasterBA.UpdateOrganisationMemberMaster(item);
		}
		public IBaseEntityResponse<OrganisationMemberMaster> DeleteOrganisationMemberMaster(OrganisationMemberMaster item)
		{
			return _organisationMemberMasterBA.DeleteOrganisationMemberMaster(item);
		}
		public IBaseEntityCollectionResponse<OrganisationMemberMaster> GetBySearch(OrganisationMemberMasterSearchRequest searchRequest)
		{
			return _organisationMemberMasterBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<OrganisationMemberMaster> GetUserEntityCentrewiseSearchList(OrganisationMemberMasterSearchRequest searchRequest)
        {
            return _organisationMemberMasterBA.GetUserEntityCentrewiseSearchList(searchRequest);
        }
		public IBaseEntityResponse<OrganisationMemberMaster> SelectByID(OrganisationMemberMaster item)
		{
			return _organisationMemberMasterBA.SelectByID(item);
		}
	}
}
