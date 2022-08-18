using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralPolicyMasterServiceAccess : IGeneralPolicyMasterServiceAccess
    {
        IGeneralPolicyMasterBA  _GeneralPolicyMasterBA = null;

        public GeneralPolicyMasterServiceAccess()
        {
            _GeneralPolicyMasterBA = new GeneralPolicyMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> InsertGeneralPolicyMaster(GeneralPolicyMaster item)
        {
            return _GeneralPolicyMasterBA.InsertGeneralPolicyMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> UpdateGeneralPolicyMaster(GeneralPolicyMaster item)
        {
            return _GeneralPolicyMasterBA.UpdateGeneralPolicyMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralPolicyMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> DeleteGeneralPolicyMaster(GeneralPolicyMaster item)
        {
            return _GeneralPolicyMasterBA.DeleteGeneralPolicyMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralPolicyMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyMaster> GetBySearch(GeneralPolicyMasterSearchRequest searchRequest)
        {
            return _GeneralPolicyMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralPolicyMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyMaster> GetGeneralPolicyMasterList(GeneralPolicyMasterSearchRequest searchRequest)
        {
            return _GeneralPolicyMasterBA.GetGeneralPolicyMasterList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralPolicyMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> SelectByID(GeneralPolicyMaster item)
        {
            return _GeneralPolicyMasterBA.SelectByID(item);
        }
    }
}

