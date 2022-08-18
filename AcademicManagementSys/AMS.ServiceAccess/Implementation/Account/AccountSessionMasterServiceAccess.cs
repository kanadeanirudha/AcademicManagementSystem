using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
	public class AccountSessionMasterServiceAccess : IAccountSessionMasterServiceAccess
	{
		IAccountSessionMasterBA _AccountSessionMasterBA = null;
		public AccountSessionMasterServiceAccess()
		{
			_AccountSessionMasterBA = new AccountSessionMasterBA();
		}
		public IBaseEntityResponse<AccountSessionMaster> InsertAccountSessionMaster(AccountSessionMaster item)
		{
			return _AccountSessionMasterBA.InsertAccountSessionMaster(item);
		}
		public IBaseEntityResponse<AccountSessionMaster> UpdateAccountSessionMaster(AccountSessionMaster item)
		{
			return _AccountSessionMasterBA.UpdateAccountSessionMaster(item);
		}
		public IBaseEntityResponse<AccountSessionMaster> DeleteAccountSessionMaster(AccountSessionMaster item)
		{
			return _AccountSessionMasterBA.DeleteAccountSessionMaster(item);
		}
		public IBaseEntityCollectionResponse<AccountSessionMaster> GetBySearch(AccountSessionMasterSearchRequest searchRequest)
		{
			return _AccountSessionMasterBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<AccountSessionMaster> GetAccountSessionList(AccountSessionMasterSearchRequest searchRequest)
		{
            return _AccountSessionMasterBA.GetAccountSessionList(searchRequest);
		}
		public IBaseEntityResponse<AccountSessionMaster> SelectByID(AccountSessionMaster item)
		{
			return _AccountSessionMasterBA.SelectByID(item);
		}
        public IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession(AccountSessionMaster item)
        {
            return _AccountSessionMasterBA.GetCurrentAccountSession(item);
        }
        public IBaseEntityResponse<AccountSessionMaster> InsertAccountYearEndJob(AccountSessionMaster item)
        {
            return _AccountSessionMasterBA.InsertAccountYearEndJob(item);
        }
        public IBaseEntityResponse<AccountSessionMaster> GetCurrentAccountSession_AccountYearEnd(AccountSessionMaster item)
        {
            return _AccountSessionMasterBA.GetCurrentAccountSession_AccountYearEnd(item);
        }
        public IBaseEntityCollectionResponse<AccountSessionMaster> GetCentreWiseBalncesheetForYearEndJobList(AccountSessionMasterSearchRequest searchRequest)
        {
            return _AccountSessionMasterBA.GetCentreWiseBalncesheetForYearEndJobList(searchRequest);
        }
    }
}
