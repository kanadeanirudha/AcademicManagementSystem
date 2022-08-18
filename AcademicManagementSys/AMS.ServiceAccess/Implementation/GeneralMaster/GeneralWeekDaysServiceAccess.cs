using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralWeekDaysServiceAccess : IGeneralWeekDaysServiceAccess
    {
        IGeneralWeekDaysBA _GeneralWeekDaysBA = null;

        public GeneralWeekDaysServiceAccess()
        {
            _GeneralWeekDaysBA = new GeneralWeekDaysBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> InsertGeneralWeekDays(GeneralWeekDays item)
        {
            return _GeneralWeekDaysBA.InsertGeneralWeekDays(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> UpdateGeneralWeekDays(GeneralWeekDays item)
        {
            return _GeneralWeekDaysBA.UpdateGeneralWeekDays(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> DeleteGeneralWeekDays(GeneralWeekDays item)
        {
            return _GeneralWeekDaysBA.DeleteGeneralWeekDays(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralWeekDays table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralWeekDays> GetBySearch(GeneralWeekDaysSearchRequest searchRequest)
        {
            return _GeneralWeekDaysBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralWeekDays table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralWeekDays> GetGeneralWeekDayList(GeneralWeekDaysSearchRequest searchRequest)
        {
            return _GeneralWeekDaysBA.GetGeneralWeekDayList(searchRequest);
        }        


        /// <summary>
        /// Service access of select a record from GeneralWeekDays table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> SelectByID(GeneralWeekDays item)
        {
            return _GeneralWeekDaysBA.SelectByID(item);
        }
    }
}

