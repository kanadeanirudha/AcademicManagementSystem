using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IAccountExclusiveToCentreReportDataProvider
    {

        IBaseEntityCollectionResponse<AccountExclusiveToCentreReport> GetBySearch(AccountExclusiveToCentreReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountExclusiveToCentreReport> SelectByID(AccountExclusiveToCentreReport item);
    }
}
