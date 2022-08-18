using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralLocationMasterServiceAccess : IGeneralLocationMasterServiceAccess
    {
        IGeneralLocationMasterBA _generalLocationMasterBA = null;
        public GeneralLocationMasterServiceAccess()
        {
            _generalLocationMasterBA = new GeneralLocationMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> InsertGeneralLocationMaster(GeneralLocationMaster item)
        {
            return _generalLocationMasterBA.InsertGeneralLocationMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> UpdateGeneralLocationMaster(GeneralLocationMaster item)
        {
            return _generalLocationMasterBA.UpdateGeneralLocationMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> DeleteGeneralLocationMaster(GeneralLocationMaster item)
        {
            return _generalLocationMasterBA.DeleteGeneralLocationMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralLocationMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearch(GeneralLocationMasterSearchRequest searchRequest)
        {
            return _generalLocationMasterBA.GetBySearch(searchRequest);
        }
        

        /// <summary>
        /// /// Service access of select all record from GeneralLocationMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchList(GeneralLocationMasterSearchRequest searchRequest)
        {
            return _generalLocationMasterBA.GetBySearchList(searchRequest);
        }


        /// <summary>
        /// Service access of select a record from GeneralLocationMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLocationMaster> SelectByID(GeneralLocationMaster item)
        {
            return _generalLocationMasterBA.SelectByID(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralLocationMaster table with search parameters CityID.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetByCityID(GeneralLocationMasterSearchRequest searchRequest)
        {
            return _generalLocationMasterBA.GetByCityID(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetByRegionIDAndCityID(GeneralLocationMasterSearchRequest searchRequest)
        {
            return _generalLocationMasterBA.GetByRegionIDAndCityID(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchKeyWord(GeneralLocationMasterSearchRequest searchRequest)
        {
            return _generalLocationMasterBA.GetBySearchKeyWord(searchRequest);
        }
        
    }
}
