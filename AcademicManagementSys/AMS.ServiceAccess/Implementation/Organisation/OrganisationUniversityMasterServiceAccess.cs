using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class OrganisationUniversityMasterServiceAccess : IOrganisationUniversityMasterServiceAccess
    {
        IOrganisationUniversityMasterBA _organisationUniversityMasterBA = null;

        public OrganisationUniversityMasterServiceAccess()
        {
            _organisationUniversityMasterBA = new OrganisationUniversityMasterBA();
        }
        /// <summary>
        /// Service access of create new record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> InsertOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            return _organisationUniversityMasterBA.InsertOrganisationUniversityMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> UpdateOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            return _organisationUniversityMasterBA.UpdateOrganisationUniversityMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> DeleteOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            return _organisationUniversityMasterBA.DeleteOrganisationUniversityMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from OrganisationUniversityMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearch(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            return _organisationUniversityMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from OrganisationUniversityMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearchList(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            return _organisationUniversityMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from OrganisationUniversityMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> SelectByID(OrganisationUniversityMaster item)
        {
            return _organisationUniversityMasterBA.SelectByID(item);    
        }
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetByCentreCode(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            return _organisationUniversityMasterBA.GetByCentreCode(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from OrganisationUniversityMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearchListWithoutCenterCode(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            return _organisationUniversityMasterBA.GetBySearchListWithoutCenterCode(searchRequest);
        }
    }
}

