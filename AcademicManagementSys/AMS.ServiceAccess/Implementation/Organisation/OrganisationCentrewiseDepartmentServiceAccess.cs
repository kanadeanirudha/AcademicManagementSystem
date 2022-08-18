using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OrganisationCentrewiseDepartmentServiceAccess : IOrganisationCentrewiseDepartmentServiceAccess
    {
        IOrganisationCentrewiseDepartmentBA _organisationCentrewiseDepartmentBA = null;
        public OrganisationCentrewiseDepartmentServiceAccess()
        {
            _organisationCentrewiseDepartmentBA = new OrganisationCentrewiseDepartmentBA();
        }

        /// <summary>
        /// Service access of create new record of organisation centrewise department.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            return _organisationCentrewiseDepartmentBA.InsertOrganisationCentrewiseDepartment(item);
        }

        /// <summary>
        /// Service access of update a specific record of organisation centrewise department.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> UpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            return _organisationCentrewiseDepartmentBA.UpdateOrganisationCentrewiseDepartment(item);
        }

        /// <summary>
        /// Service access of insert and update record in xml formate of organisation centrewise department.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertUpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            return _organisationCentrewiseDepartmentBA.InsertUpdateOrganisationCentrewiseDepartment(item);
        }

        /// <summary>
        /// Service access of delete a selected record from organisation centrewise department.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> DeleteOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            return _organisationCentrewiseDepartmentBA.DeleteOrganisationCentrewiseDepartment(item);
        }

        /// <summary>
        /// /// Service access of select all record from organisation centrewise department table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCentrewiseDepartment> GetBySearch(OrganisationCentrewiseDepartmentSearchRequest searchRequest)
        {
            return _organisationCentrewiseDepartmentBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from organisation centrewise department table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> SelectByID(OrganisationCentrewiseDepartment item)
        {
            return _organisationCentrewiseDepartmentBA.SelectByID(item);
        }
    }
}