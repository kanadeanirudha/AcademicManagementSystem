using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralRelationshipTypeMasterServiceAccess : IGeneralRelationshipTypeMasterServiceAccess
    {
        IGeneralRelationshipTypeMasterBA _GeneralRelationshipTypeMasterBA = null;

        public GeneralRelationshipTypeMasterServiceAccess()
        {
            _GeneralRelationshipTypeMasterBA = new GeneralRelationshipTypeMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralRelationshipTypeMsaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> InsertGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item)
        {
            return _GeneralRelationshipTypeMasterBA.InsertGeneralRelationshipTypeMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> UpdateGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item)
        {
            return _GeneralRelationshipTypeMasterBA.UpdateGeneralRelationshipTypeMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralRelationshipTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> DeleteGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item)
        {
            return _GeneralRelationshipTypeMasterBA.DeleteGeneralRelationshipTypeMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralRelationshipTypeMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearch(GeneralRelationshipTypeMasterSearchRequest searchRequest)
        {
            return _GeneralRelationshipTypeMasterBA.GetBySearch(searchRequest);
        }


        public IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest)
        {
            return _GeneralRelationshipTypeMasterBA.GetGeneralRelationshipTypeMasterGetBySearchList(searchRequest);
        }

        ///// <summary>
        ///// /// Service access of select all record from GeneralRelationshipTypeMaster table with search parameters.
        ///// </summary>
        ///// <param name="searchRequest"></param>
        ///// <returns></returns>
        //public IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest)
        //{
        //    return _GeneralRelationshipTypeMasterBA.GetBySearchList(searchRequest);
        //}

        /// <summary>
        /// Service access of select a record from GeneralRelationshipTypeMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> SelectByID(GeneralRelationshipTypeMaster item)
        {
            return _GeneralRelationshipTypeMasterBA.SelectByID(item);
        }
    }
}

