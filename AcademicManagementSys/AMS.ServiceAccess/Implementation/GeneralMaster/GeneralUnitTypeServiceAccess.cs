using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralUnitTypeServiceAccess : IGeneralUnitTypeServiceAccess
    {
        IGeneralUnitTypeBA _GeneralUnitTypeBA = null;

        public GeneralUnitTypeServiceAccess()
        {
            _GeneralUnitTypeBA = new GeneralUnitTypeBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>                                                               
        public IBaseEntityResponse<GeneralUnitType> InsertGeneralUnitType(GeneralUnitType item)
        {
            return _GeneralUnitTypeBA.InsertGeneralUnitType(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitType> UpdateGeneralUnitType(GeneralUnitType item)
        {
            return _GeneralUnitTypeBA.UpdateGeneralUnitType(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitType> DeleteGeneralUnitType(GeneralUnitType item)
        {
            return _GeneralUnitTypeBA.DeleteGeneralUnitType(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralUnitType table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralUnitType> GetBySearch(GeneralUnitTypeSearchRequest searchRequest)
        {
            return _GeneralUnitTypeBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralUnitType table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralUnitType> GetBySearchList(GeneralUnitTypeSearchRequest searchRequest)
        {
            return _GeneralUnitTypeBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralUnitType table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitType> SelectByID(GeneralUnitType item)
        {
            return _GeneralUnitTypeBA.SelectByID(item);
        }
    }
}

