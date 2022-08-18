using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
	public class OrganisationCentrewiseSessionServiceAccess : IOrganisationCentrewiseSessionServiceAccess
	{
		IOrganisationCentrewiseSessionBA _organisationCentrewiseSessionBA = null;
		public OrganisationCentrewiseSessionServiceAccess()
		{
			_organisationCentrewiseSessionBA = new OrganisationCentrewiseSessionBA();
		}
		public IBaseEntityResponse<OrganisationCentrewiseSession> InsertOrganisationCentrewiseSession(OrganisationCentrewiseSession item)
		{
			return _organisationCentrewiseSessionBA.InsertOrganisationCentrewiseSession(item);
		}
		public IBaseEntityResponse<OrganisationCentrewiseSession> UpdateOrganisationCentrewiseSession(OrganisationCentrewiseSession item)
		{
			return _organisationCentrewiseSessionBA.UpdateOrganisationCentrewiseSession(item);
		}
		public IBaseEntityResponse<OrganisationCentrewiseSession> DeleteOrganisationCentrewiseSession(OrganisationCentrewiseSession item)
		{
			return _organisationCentrewiseSessionBA.DeleteOrganisationCentrewiseSession(item);
		}
		public IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetBySearch(OrganisationCentrewiseSessionSearchRequest searchRequest)
		{
			return _organisationCentrewiseSessionBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<OrganisationCentrewiseSession> SelectByID(OrganisationCentrewiseSession item)
		{
			return _organisationCentrewiseSessionBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCurrentSession(OrganisationCentrewiseSessionSearchRequest searchRequest)
        {
            return _organisationCentrewiseSessionBA.GetCurrentSession(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCentreWiseSessionListRoleWise(OrganisationCentrewiseSessionSearchRequest searchRequest)
        {
            return _organisationCentrewiseSessionBA.GetCentreWiseSessionListRoleWise(searchRequest);
        }
	}
}
