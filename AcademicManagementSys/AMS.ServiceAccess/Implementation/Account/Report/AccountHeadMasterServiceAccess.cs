using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountHeadMasterReportServiceAccess: IAccountHeadMasterReportServiceAccess
    {
        IAccountHeadMasterReportBA _AccountHeadMasterReportBA = null;
        public AccountHeadMasterReportServiceAccess()
        {
            _AccountHeadMasterReportBA = new AccountHeadMasterReportBA();
        }

        /// <summary>
        /// Service access of create new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> InsertAccountHeadMasterReport(AccountHeadMasterReport item)
        {
            return _AccountHeadMasterReportBA.InsertAccountHeadMasterReport(item);
        }

        /// <summary>
        /// Service access of update a specific record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> UpdateAccountHeadMasterReport(AccountHeadMasterReport item)
        {
            return _AccountHeadMasterReportBA.UpdateAccountHeadMasterReport(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> DeleteAccountHeadMasterReport(AccountHeadMasterReport item)
        {
            return _AccountHeadMasterReportBA.DeleteAccountHeadMasterReport(item);
        }

        /// <summary>
        /// /// Service access of select all record from account head master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMasterReport> GetBySearch(AccountHeadMasterReportSearchRequest searchRequest)
        {
            return _AccountHeadMasterReportBA.GetAccountHeadMasterReportBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all head name list form account head master table.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMasterReport> GetHeadNameList(AccountHeadMasterReportSearchRequest searchRequest)
        {
            return _AccountHeadMasterReportBA.GetAccountHeadNameList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account head master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> SelectByID(AccountHeadMasterReport item)
        {
            return _AccountHeadMasterReportBA.GetAccountHeadMasterReportByID(item);
        }
    }
}
