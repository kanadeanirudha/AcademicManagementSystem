﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IAccountTrialBalanceReportDataProvider
    {

        IBaseEntityCollectionResponse<AccountTrialBalanceReport> GetAccountTrialBalanceReportBySearch(AccountTrialBalanceReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountTrialBalanceReport> GetAccountTrialBalanceReportByID(AccountTrialBalanceReport item);
    }
}
