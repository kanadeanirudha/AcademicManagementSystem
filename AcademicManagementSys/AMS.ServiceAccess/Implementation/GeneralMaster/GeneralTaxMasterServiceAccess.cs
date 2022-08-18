using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralTaxMasterServiceAccess : IGeneralTaxMasterServiceAccess
    {
        IGeneralTaxMasterBA _GeneralTaxMasterBA = null;

        public GeneralTaxMasterServiceAccess()
        {
            _GeneralTaxMasterBA = new GeneralTaxMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> InsertGeneralTaxMaster(GeneralTaxMaster item)
        {
            return _GeneralTaxMasterBA.InsertGeneralTaxMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> UpdateGeneralTaxMaster(GeneralTaxMaster item)
        {
            return _GeneralTaxMasterBA.UpdateGeneralTaxMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> DeleteGeneralTaxMaster(GeneralTaxMaster item)
        {
            return _GeneralTaxMasterBA.DeleteGeneralTaxMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralTaxMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearch(GeneralTaxMasterSearchRequest searchRequest)
        {
            return _GeneralTaxMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralTaxMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearchList(GeneralTaxMasterSearchRequest searchRequest)
        {
            return _GeneralTaxMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralTaxMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> SelectByID(GeneralTaxMaster item)
        {
            return _GeneralTaxMasterBA.SelectByID(item);
        }
    }
}

