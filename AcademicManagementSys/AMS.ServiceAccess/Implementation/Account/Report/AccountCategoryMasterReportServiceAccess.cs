using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountCategoryMasterReportServiceAccess: IAccountCategoryMasterReportServiceAccess
    {
        IAccountCategoryMasterReportBA _AccountCategoryMasterReportBA = null;
        public AccountCategoryMasterReportServiceAccess()
        {
            _AccountCategoryMasterReportBA = new AccountCategoryMasterReportBA();
        }


        /// <summary>
        /// /// Service access of select all record from account category master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetBySearch(AccountCategoryMasterReportSearchRequest searchRequest)
        {
            return _AccountCategoryMasterReportBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all category name list from account category master table.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetCategoryList(AccountCategoryMasterReportSearchRequest searchRequest)
        {
            return _AccountCategoryMasterReportBA.GetCategoryList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account category master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMasterReport> SelectByID(AccountCategoryMasterReport item)
        {
            return _AccountCategoryMasterReportBA.SelectByID(item);
        }
    }
}
