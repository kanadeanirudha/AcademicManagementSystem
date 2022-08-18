using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
	public interface IOrganisationCentrewiseSessionServiceAccess
	{
		IBaseEntityResponse<OrganisationCentrewiseSession> InsertOrganisationCentrewiseSession(OrganisationCentrewiseSession item);
		IBaseEntityResponse<OrganisationCentrewiseSession> UpdateOrganisationCentrewiseSession(OrganisationCentrewiseSession item);
		IBaseEntityResponse<OrganisationCentrewiseSession> DeleteOrganisationCentrewiseSession(OrganisationCentrewiseSession item);
		IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetBySearch(OrganisationCentrewiseSessionSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationCentrewiseSession> SelectByID(OrganisationCentrewiseSession item);
        IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCentreWiseSessionListRoleWise(OrganisationCentrewiseSessionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCurrentSession(OrganisationCentrewiseSessionSearchRequest searchRequest);
	}
}
