using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
	public interface IAccountSessionMasterBA
	{
		IBaseEntityResponse<AccountSessionMaster> InsertAccountSessionMaster(AccountSessionMaster item);
		IBaseEntityResponse<AccountSessionMaster> UpdateAccountSessionMaster(AccountSessionMaster item);
		IBaseEntityResponse<AccountSessionMaster> DeleteAccountSessionMaster(AccountSessionMaster item);
		IBaseEntityCollectionResponse<AccountSessionMaster> GetBySearch(AccountSessionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionList(AccountSessionMasterSearchRequest searchRequest);
		IBaseEntityResponse<AccountSessionMaster> SelectByID(AccountSessionMaster item);
        IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession(AccountSessionMaster item);
        IBaseEntityResponse<AccountSessionMaster> InsertAccountYearEndJob(AccountSessionMaster item);
        IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession_AccountYearEnd(AccountSessionMaster item);
        IBaseEntityCollectionResponse<AccountSessionMaster> GetCentreWiseBalncesheetForYearEndJobList(AccountSessionMasterSearchRequest searchRequest);
    }
}
