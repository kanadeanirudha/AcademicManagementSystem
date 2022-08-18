using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralOperatorRelatedRoleServiceAccess : IGeneralOperatorRelatedRoleServiceAccess
    {
        IGeneralOperatorRelatedRoleBA _GeneralOperatorRelatedRoleBA = null;

        public GeneralOperatorRelatedRoleServiceAccess()
        {
            _GeneralOperatorRelatedRoleBA = new GeneralOperatorRelatedRoleBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> InsertGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item)
        {
            return _GeneralOperatorRelatedRoleBA.InsertGeneralOperatorRelatedRole(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> UpdateGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item)
        {
            return _GeneralOperatorRelatedRoleBA.UpdateGeneralOperatorRelatedRole(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralOperatorRelatedRole.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> DeleteGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item)
        {
            return _GeneralOperatorRelatedRoleBA.DeleteGeneralOperatorRelatedRole(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralOperatorRelatedRole table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetBySearch(GeneralOperatorRelatedRoleSearchRequest searchRequest)
        {
            return _GeneralOperatorRelatedRoleBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralOperatorRelatedRole table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetGeneralOperatorRelatedRoleList(GeneralOperatorRelatedRoleSearchRequest searchRequest)
        {
            return _GeneralOperatorRelatedRoleBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralOperatorRelatedRole table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> SelectByID(GeneralOperatorRelatedRole item)
        {
            return _GeneralOperatorRelatedRoleBA.SelectByID(item);
        }


        public IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetAdminRoleCodeList(GeneralOperatorRelatedRoleSearchRequest searchRequest)
        {
            return _GeneralOperatorRelatedRoleBA.GetAdminRoleCodeList(searchRequest);
        }
    }
}

