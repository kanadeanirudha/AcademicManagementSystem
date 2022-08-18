using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralRegionMasterServiceAccess : IGeneralRegionMasterServiceAccess
    {
        IGeneralRegionMasterBA _generalRegionMasterBA = null;

        public GeneralRegionMasterServiceAccess()
        {
            _generalRegionMasterBA = new GeneralRegionMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRegionMaster> InsertGeneralRegionMaster(GeneralRegionMaster item)
        {
            return _generalRegionMasterBA.InsertGeneralRegionMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRegionMaster> UpdateGeneralRegionMaster(GeneralRegionMaster item)
        {
            return _generalRegionMasterBA.UpdateGeneralRegionMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRegionMaster> DeleteGeneralRegionMaster(GeneralRegionMaster item)
        {
            return _generalRegionMasterBA.DeleteGeneralRegionMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralRegionMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRegionMaster> GetBySearch(GeneralRegionMasterSearchRequest searchRequest)
        {
            return _generalRegionMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralRegionMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRegionMaster> GetByCountryID(GeneralRegionMasterSearchRequest searchRequest)
        {
            return _generalRegionMasterBA.GetByCountryID(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralRegionMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRegionMaster> SelectByID(GeneralRegionMaster item)
        {
            return _generalRegionMasterBA.SelectByID(item);    
        }
    }
}

