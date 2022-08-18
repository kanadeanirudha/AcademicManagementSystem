using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralTaxGroupMasterServiceAccess : IGeneralTaxGroupMasterServiceAccess
    {
        IGeneralTaxGroupMasterBA _GeneralTaxGroupMasterBA = null;

        public GeneralTaxGroupMasterServiceAccess()
        {
            _GeneralTaxGroupMasterBA = new GeneralTaxGroupMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> InsertGeneralTaxGroupMaster(GeneralTaxGroupMaster item)
        {
            return _GeneralTaxGroupMasterBA.InsertGeneralTaxGroupMaster(item);
        }
        /// <summary>
        /// Service access of update a specific record of GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> UpdateGeneralTaxGroupMaster(GeneralTaxGroupMaster item)
        {
            return _GeneralTaxGroupMasterBA.UpdateGeneralTaxGroupMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralTaxGroupMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> DeleteGeneralTaxGroupMaster(GeneralTaxGroupMaster item)
        {
            return _GeneralTaxGroupMasterBA.DeleteGeneralTaxGroupMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralTaxGroupMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetBySearch(GeneralTaxGroupMasterSearchRequest searchRequest)
        {
            return _GeneralTaxGroupMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralTaxGroupMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterList(GeneralTaxGroupMasterSearchRequest searchRequest)
        {
            return _GeneralTaxGroupMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralTaxGroupMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> SelectByID(GeneralTaxGroupMaster item)
        {
            return _GeneralTaxGroupMasterBA.SelectByID(item);
        }
    }
}

