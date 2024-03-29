﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralHolidaysServiceAccess
    {
        IBaseEntityResponse<GeneralHolidays> InsertGeneralHolidays(GeneralHolidays item);
        IBaseEntityResponse<GeneralHolidays> UpdateGeneralHolidays(GeneralHolidays item);
        IBaseEntityResponse<GeneralHolidays> DeleteGeneralHolidays(GeneralHolidays item);
        IBaseEntityCollectionResponse<GeneralHolidays> GetBySearch(GeneralHolidaysSearchRequest searchRequest);
        IBaseEntityResponse<GeneralHolidays> SelectByID(GeneralHolidays item);
        IBaseEntityCollectionResponse<GeneralHolidays> GetHolidayAndWeeklyOffDayByEmployeeID(GeneralHolidaysSearchRequest searchRequest);
    }
}
