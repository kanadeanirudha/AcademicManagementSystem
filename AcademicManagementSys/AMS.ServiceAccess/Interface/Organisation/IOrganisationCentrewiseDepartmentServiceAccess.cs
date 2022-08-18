using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOrganisationCentrewiseDepartmentServiceAccess
    {
        IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> UpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertUpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> DeleteOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item);
        IBaseEntityCollectionResponse<OrganisationCentrewiseDepartment> GetBySearch(OrganisationCentrewiseDepartmentSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationCentrewiseDepartment> SelectByID(OrganisationCentrewiseDepartment item);
    }
}
