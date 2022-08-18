using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OrganisationDepartmentMasterServiceAccess : IOrganisationDepartmentMasterServiceAccess
    {
        IOrganisationDepartmentMasterBA _organisationDepartmentMaster = null;

        public OrganisationDepartmentMasterServiceAccess()
        {
            _organisationDepartmentMaster = new OrganisationDepartmentMasterBA();
        }

        public IBaseEntityResponse<OrganisationDepartmentMaster> InsertOrganisationDepartmentMaster(OrganisationDepartmentMaster item)
        {
            return _organisationDepartmentMaster.InsertOrganisationDepartmentMaster(item);
        }

        public IBaseEntityResponse<OrganisationDepartmentMaster> UpdateOrganisationDepartmentMaster(OrganisationDepartmentMaster item)
        {
            return _organisationDepartmentMaster.UpdateOrganisationDepartmentMaster(item);
        }

        public IBaseEntityResponse<OrganisationDepartmentMaster> DeleteOrganisationDepartmentMaster(OrganisationDepartmentMaster item)
        {
            return _organisationDepartmentMaster.DeleteOrganisationDepartmentMaster(item);
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByCentreCode(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetByCentreCode(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByCentrewise(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetByCentrewise(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetBySearch(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetBySearch(searchRequest);
        }

        public IBaseEntityResponse<OrganisationDepartmentMaster> SelectByID(OrganisationDepartmentMaster item)
        {
            return _organisationDepartmentMaster.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetBySearchList(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetBySearchList(searchRequest);
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetDepartmentListRoleWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListCentreAndRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetDepartmentListCentreAndRoleWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByDepartmentNameSearchList_ForPurchase(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetByDepartmentNameSearchList_ForPurchase(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartment(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            return _organisationDepartmentMaster.GetDepartment(searchRequest);
        }
    }
}
