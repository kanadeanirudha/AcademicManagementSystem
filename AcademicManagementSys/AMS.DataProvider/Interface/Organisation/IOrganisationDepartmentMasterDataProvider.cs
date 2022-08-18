using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IOrganisationDepartmentMasterDataProvider
    {
        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetOrganisationDepartmentMasterBySearch(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetOrganisationDepartmentMasterByCentreCode(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetOrganisationDepartmentMasterByCentrewise(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetOrganisationDepartmentMasterGetBySearchList(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationDepartmentMaster> GetOrganisationDepartmentMasterByID(OrganisationDepartmentMaster item);

        IBaseEntityResponse<OrganisationDepartmentMaster> InsertOrganisationDepartmentMaster(OrganisationDepartmentMaster item);

        IBaseEntityResponse<OrganisationDepartmentMaster> UpdateOrganisationDepartmentMaster(OrganisationDepartmentMaster item);

        IBaseEntityResponse<OrganisationDepartmentMaster> DeleteOrganisationDepartmentMaster(OrganisationDepartmentMaster item);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListCentreAndRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetOrganisationDepartmentMasterGetBySearchList_ForPurchase(OrganisationDepartmentMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartment(OrganisationDepartmentMasterSearchRequest searchRequest);
    }
}
