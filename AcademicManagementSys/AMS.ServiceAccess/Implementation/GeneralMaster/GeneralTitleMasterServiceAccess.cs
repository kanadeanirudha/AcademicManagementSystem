using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralTitleMasterServiceAccess : IGeneralTitleMasterServiceAccess
    {
        IGeneralTitleMasterBA _GeneralTitleMasterBA = null;

        public GeneralTitleMasterServiceAccess()
        {
            _GeneralTitleMasterBA = new GeneralTitleMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> InsertGeneralTitleMaster(GeneralTitleMaster item)
        {
            return _GeneralTitleMasterBA.InsertGeneralTitleMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> UpdateGeneralTitleMaster(GeneralTitleMaster item)
        {
            return _GeneralTitleMasterBA.UpdateGeneralTitleMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> DeleteGeneralTitleMaster(GeneralTitleMaster item)
        {
            return _GeneralTitleMasterBA.DeleteGeneralTitleMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralTitleMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearch(GeneralTitleMasterSearchRequest searchRequest)
        {
            return _GeneralTitleMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralTitleMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearchList(GeneralTitleMasterSearchRequest searchRequest)
        {
            return _GeneralTitleMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralTitleMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTitleMaster> SelectByID(GeneralTitleMaster item)
        {
            return _GeneralTitleMasterBA.SelectByID(item);
        }
    }
}

