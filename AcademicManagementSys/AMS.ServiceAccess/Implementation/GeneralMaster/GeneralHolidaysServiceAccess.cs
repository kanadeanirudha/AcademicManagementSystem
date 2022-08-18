using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralHolidaysServiceAccess : IGeneralHolidaysServiceAccess
    {
        IGeneralHolidaysBA _generalHolidaysBA = null;
        public GeneralHolidaysServiceAccess()
        {
            _generalHolidaysBA = new GeneralHolidaysBA();
        }
        public IBaseEntityResponse<GeneralHolidays> InsertGeneralHolidays(GeneralHolidays item)
        {
            return _generalHolidaysBA.InsertGeneralHolidays(item);
        }
        public IBaseEntityResponse<GeneralHolidays> UpdateGeneralHolidays(GeneralHolidays item)
        {
            return _generalHolidaysBA.UpdateGeneralHolidays(item);
        }
        public IBaseEntityResponse<GeneralHolidays> DeleteGeneralHolidays(GeneralHolidays item)
        {
            return _generalHolidaysBA.DeleteGeneralHolidays(item);
        }
        public IBaseEntityCollectionResponse<GeneralHolidays> GetBySearch(GeneralHolidaysSearchRequest searchRequest)
        {
            return _generalHolidaysBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralHolidays> SelectByID(GeneralHolidays item)
        {
            return _generalHolidaysBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralHolidays> GetHolidayAndWeeklyOffDayByEmployeeID(GeneralHolidaysSearchRequest searchRequest)
        {
            return _generalHolidaysBA.GetHolidayAndWeeklyOffDayByEmployeeID(searchRequest);
        }
        
    }
}
