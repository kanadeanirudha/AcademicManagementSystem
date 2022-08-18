using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IAccountGeneralLedgerReportBA
    {
       
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetBySearch(AccountGeneralLedgerReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetOtherLedgerBySearch(AccountGeneralLedgerReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountGeneralLedgerReport> SelectByID(AccountGeneralLedgerReport item);
        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(AccountGeneralLedgerReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetByIndividualBalanceReportSearch(AccountGeneralLedgerReportSearchRequest searchRequest);
    }
}
