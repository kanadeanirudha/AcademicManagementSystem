﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IAccountSessionMasterReportDataProvider
    {
      
        IBaseEntityCollectionResponse<AccountSessionMasterReport> GetAccountSessionMasterReportBySearch(AccountSessionMasterReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountSessionMasterReport> GetAccountSessionMasterReportByID(AccountSessionMasterReport item);
    }
}