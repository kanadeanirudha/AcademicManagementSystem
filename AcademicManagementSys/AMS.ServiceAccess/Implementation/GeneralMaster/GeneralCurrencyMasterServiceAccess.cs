using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralCurrencyMasterServiceAccess : IGeneralCurrencyMasterServiceAccess
    {
        IGeneralCurrencyMasterBA _GeneralCurrencyMasterBA = null;

        public GeneralCurrencyMasterServiceAccess()
        {
            _GeneralCurrencyMasterBA = new GeneralCurrencyMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> InsertGeneralCurrencyMaster(GeneralCurrencyMaster item)
        {
            return _GeneralCurrencyMasterBA.InsertGeneralCurrencyMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> UpdateGeneralCurrencyMaster(GeneralCurrencyMaster item)
        {
            return _GeneralCurrencyMasterBA.UpdateGeneralCurrencyMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralCurrencyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> DeleteGeneralCurrencyMaster(GeneralCurrencyMaster item)
        {
            return _GeneralCurrencyMasterBA.DeleteGeneralCurrencyMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralCurrencyMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetBySearch(GeneralCurrencyMasterSearchRequest searchRequest)
        {
            return _GeneralCurrencyMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralCurrencyMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCurrencyMaster> GetGeneralCurrencyMasterList(GeneralCurrencyMasterSearchRequest searchRequest)
        {
            return _GeneralCurrencyMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralCurrencyMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCurrencyMaster> SelectByID(GeneralCurrencyMaster item)
        {
            return _GeneralCurrencyMasterBA.SelectByID(item);
        }
    }
}

