

using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralPolicyDetailsServiceAccess : IGeneralPolicyDetailsServiceAccess
    {
        IGeneralPolicyDetailsBA  _GeneralPolicyDetailsBA = null;

        public GeneralPolicyDetailsServiceAccess()
        {
            _GeneralPolicyDetailsBA = new GeneralPolicyDetailsBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> InsertGeneralPolicyDetails(GeneralPolicyDetails item)
        {
            return _GeneralPolicyDetailsBA.InsertGeneralPolicyDetails(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> UpdateGeneralPolicyDetails(GeneralPolicyDetails item)
        {
            return _GeneralPolicyDetailsBA.UpdateGeneralPolicyDetails(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralPolicyDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> DeleteGeneralPolicyDetails(GeneralPolicyDetails item)
        {
            return _GeneralPolicyDetailsBA.DeleteGeneralPolicyDetails(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralPolicyDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyDetails> GetBySearch(GeneralPolicyDetailsSearchRequest searchRequest)
        {
            return _GeneralPolicyDetailsBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralPolicyDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsList(GeneralPolicyDetailsSearchRequest searchRequest)
        {
            return _GeneralPolicyDetailsBA.GetGeneralPolicyDetailsList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralPolicyDetails table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> SelectByID(GeneralPolicyDetails item)
        {
            return _GeneralPolicyDetailsBA.SelectByID(item);
        }
    }
}

