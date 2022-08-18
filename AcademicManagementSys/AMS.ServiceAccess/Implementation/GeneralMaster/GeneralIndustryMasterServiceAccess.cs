using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralIndustryMasterServiceAccess : IGeneralIndustryMasterServiceAccess
    {
        IGeneralIndustryMasterBA _generalCountryMasterBA = null;

        public GeneralIndustryMasterServiceAccess()
        {
            _generalCountryMasterBA = new GeneralIndustryMasterBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralIndustryMaster> InsertGeneralIndustryMaster(GeneralIndustryMaster item)
        {
            return _generalCountryMasterBA.InsertGeneralIndustryMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralIndustryMaster> UpdateGeneralIndustryMaster(GeneralIndustryMaster item)
        {
            return _generalCountryMasterBA.UpdateGeneralIndustryMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralIndustryMaster> DeleteGeneralIndustryMaster(GeneralIndustryMaster item)
        {
            return _generalCountryMasterBA.DeleteGeneralIndustryMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralIndustryMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralIndustryMaster> GetBySearch(GeneralIndustryMasterSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralIndustryMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralIndustryMaster> GetBySearchList(GeneralIndustryMasterSearchRequest searchRequest)
        {
            return _generalCountryMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralIndustryMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralIndustryMaster> SelectByID(GeneralIndustryMaster item)
        {
            return _generalCountryMasterBA.SelectByID(item);
        }
    }
}

