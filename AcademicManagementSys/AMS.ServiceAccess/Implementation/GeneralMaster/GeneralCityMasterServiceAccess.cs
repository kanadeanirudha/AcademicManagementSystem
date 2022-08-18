using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class GeneralCityMasterServiceAccess : IGeneralCityMasterServiceAccess
    {

       IGeneralCityMasterBA _generalCityMasterBA = null;

        public GeneralCityMasterServiceAccess()
        {
            _generalCityMasterBA = new GeneralCityMasterBA();
        }
         /// <summary>
         /// Service access of create new record of GeneralCityMaster.
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> InsertGeneralCityMaster(GeneralCityMaster item)
        {
            return _generalCityMasterBA.InsertGeneralCityMaster(item);
        }

         /// <summary>
         /// Service access of update a specific record of GeneralCityMaster.
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> UpdateGeneralCityMaster(GeneralCityMaster item)
        {
            return _generalCityMasterBA.UpdateGeneralCityMaster(item);
        }

         /// <summary>
         /// Service access of delete a selected record from GeneralCityMaster.
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> DeleteGeneralCityMaster(GeneralCityMaster item)
        {
            return _generalCityMasterBA.DeleteGeneralCityMaster(item);
        }

         /// <summary>
         /// /// Service access of select all record from GeneralCityMaster table with search parameters.
         /// </summary>
         /// <param name="searchRequest"></param>
         /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearch(GeneralCityMasterSearchRequest searchRequest)
        {
            return _generalCityMasterBA.GetBySearch(searchRequest);
        }

         /// <summary>
         /// /// Service access of select all record from GeneralCityMaster table with search parameters.
         /// </summary>
         /// <param name="searchRequest"></param>
         /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCityMaster> GetByRegionID(GeneralCityMasterSearchRequest searchRequest)
        {
            return _generalCityMasterBA.GetByRegionID(searchRequest);
        }
       
         /// <summary>
         /// Service access of select a record from GeneralCityMaster table by ID
         /// </summary>
         /// <param name="item"></param>
         /// <returns></returns>
        public IBaseEntityResponse<GeneralCityMaster> SelectByID(GeneralCityMaster item)
        {
            return _generalCityMasterBA.SelectByID(item);
        }
        //searchlist For General City Master
        public IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearchList(GeneralCityMasterSearchRequest searchRequest)
        {
            return _generalCityMasterBA.GetBySearchList(searchRequest);
        }
    }
}
