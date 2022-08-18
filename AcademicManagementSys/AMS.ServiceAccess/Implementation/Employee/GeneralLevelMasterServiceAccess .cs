using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralLevelMasterServiceAccess : IGeneralLevelMasterServiceAccess
    {
        IGeneralLevelMasterBA _GeneralLevelMasterBA = null;

        public GeneralLevelMasterServiceAccess()
        {
            _GeneralLevelMasterBA = new GeneralLevelMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> InsertGeneralLevelMaster(GeneralLevelMaster item)
        {
            return _GeneralLevelMasterBA.InsertGeneralLevelMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> UpdateGeneralLevelMaster(GeneralLevelMaster item)
        {
            return _GeneralLevelMasterBA.UpdateGeneralLevelMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> DeleteGeneralLevelMaster(GeneralLevelMaster item)
        {
            return _GeneralLevelMasterBA.DeleteGeneralLevelMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralLevelMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearch(GeneralLevelMasterSearchRequest searchRequest)
        {
            return _GeneralLevelMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralLevelMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearchList(GeneralLevelMasterSearchRequest searchRequest)
        {
            return _GeneralLevelMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralLevelMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLevelMaster> SelectByID(GeneralLevelMaster item)
        {
            return _GeneralLevelMasterBA.SelectByID(item);
        }
    }
}

