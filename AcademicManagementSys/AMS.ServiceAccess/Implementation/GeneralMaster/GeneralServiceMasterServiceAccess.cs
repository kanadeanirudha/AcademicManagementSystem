using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralServiceMasterServiceAccess : IGeneralServiceMasterServiceAccess
    {
        IGeneralServiceMasterBA _generalCountryMasterBA = null;

        public GeneralServiceMasterServiceAccess()
        {
            _generalCountryMasterBA = new GeneralServiceMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> InsertGeneralServiceMaster(GeneralServiceMaster item)
        {
            return _generalCountryMasterBA.InsertGeneralServiceMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> UpdateGeneralServiceMaster(GeneralServiceMaster item)
        {
            return _generalCountryMasterBA.UpdateGeneralServiceMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralServiceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> DeleteGeneralServiceMaster(GeneralServiceMaster item)
        {
            return _generalCountryMasterBA.DeleteGeneralServiceMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralServiceMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralServiceMaster> GetBySearch(GeneralServiceMasterSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralServiceMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralServiceMaster> GetBySearchList(GeneralServiceMasterSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralServiceMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralServiceMaster> SelectByID(GeneralServiceMaster item)
        {
            return _generalCountryMasterBA.SelectByID(item);
        }
    }
}

