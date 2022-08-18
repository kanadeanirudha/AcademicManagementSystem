using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralWeekDaysServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> InsertGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// Service access interface of update record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> UpdateGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// Service access interface of dalete record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> DeleteGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// Service access interface of select all record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralWeekDays> GetBySearch(GeneralWeekDaysSearchRequest searchRequest);

               /// <summary>
        /// Service access interface of select all record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralWeekDays> GetGeneralWeekDayList(GeneralWeekDaysSearchRequest searchRequest);
        
        /// <summary>
        /// Service access interface of select one record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> SelectByID(GeneralWeekDays item);
    }
}
