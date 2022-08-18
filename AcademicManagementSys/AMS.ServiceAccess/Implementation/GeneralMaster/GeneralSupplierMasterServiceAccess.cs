using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralSupplierMasterServiceAccess : IGeneralSupplierMasterServiceAccess
    {
        IGeneralSupplierMasterBA _generalSupplierMasterBA = null;

        public GeneralSupplierMasterServiceAccess() 
        {
            _generalSupplierMasterBA = new GeneralSupplierMasterBA();
        }

        /// <summary>
        /// Service access of create new record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> InsertGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            return _generalSupplierMasterBA.InsertGeneralSupplierMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> UpdateGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            return _generalSupplierMasterBA.UpdateGeneralSupplierMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> DeleteGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            return _generalSupplierMasterBA.DeleteGeneralSupplierMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account balance sheet master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearch(GeneralSupplierMasterSearchRequest searchRequest)
        {
            return _generalSupplierMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account balance sheet master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> SelectByID(GeneralSupplierMaster item)
        {
            return _generalSupplierMasterBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearchList(GeneralSupplierMasterSearchRequest searchRequest)
        {
            return _generalSupplierMasterBA.GetBySearchList(searchRequest);
        }
    }
}
