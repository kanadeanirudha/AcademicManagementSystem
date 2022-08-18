using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralCountryMasterServiceAccess : IGeneralCountryMasterServiceAccess
    {
        IGeneralCountryMasterBA _generalCountryMasterBA = null;

        public GeneralCountryMasterServiceAccess()
        {
            _generalCountryMasterBA = new GeneralCountryMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> InsertGeneralCountryMaster(GeneralCountryMaster item)
        {
            return _generalCountryMasterBA.InsertGeneralCountryMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> UpdateGeneralCountryMaster(GeneralCountryMaster item)
        {
            return _generalCountryMasterBA.UpdateGeneralCountryMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> DeleteGeneralCountryMaster(GeneralCountryMaster item)
        {
            return _generalCountryMasterBA.DeleteGeneralCountryMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralCountryMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearch(GeneralCountryMasterSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralCountryMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearchList(GeneralCountryMasterSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralCountryMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCountryMaster> SelectByID(GeneralCountryMaster item)
        {
            return _generalCountryMasterBA.SelectByID(item);
        }
    }
}

