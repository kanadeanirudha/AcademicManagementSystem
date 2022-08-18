using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralExperienceTypeMasterServiceAccess : IGeneralExperienceTypeMasterServiceAccess
    {
        IGeneralExperienceTypeMasterBA _GeneralExperienceTypeMasterBA = null;

        public GeneralExperienceTypeMasterServiceAccess()
        {
            _GeneralExperienceTypeMasterBA = new GeneralExperienceTypeMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> InsertGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item)
        {
            return _GeneralExperienceTypeMasterBA.InsertGeneralExperienceTypeMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> UpdateGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item)
        {
            return _GeneralExperienceTypeMasterBA.UpdateGeneralExperienceTypeMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> DeleteGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item)
        {
            return _GeneralExperienceTypeMasterBA.DeleteGeneralExperienceTypeMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralExperienceTypeMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearch(GeneralExperienceTypeMasterSearchRequest searchRequest)
        {
            return _GeneralExperienceTypeMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralExperienceTypeMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearchList(GeneralExperienceTypeMasterSearchRequest searchRequest)
        {
            return _GeneralExperienceTypeMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralExperienceTypeMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralExperienceTypeMaster> SelectByID(GeneralExperienceTypeMaster item)
        {
            return _GeneralExperienceTypeMasterBA.SelectByID(item);
        }
    }
}

