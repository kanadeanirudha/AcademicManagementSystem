using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IAccountCategoryMasterReportBA
    {

        /// <summary>
        /// business action interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetBySearch(AccountCategoryMasterReportSearchRequest searchRequest);

        /// <summary>
        /// business action interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetCategoryList(AccountCategoryMasterReportSearchRequest searchRequest);

        /// <summary>
        /// business action interface of dalete record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMasterReport> SelectByID(AccountCategoryMasterReport item);
    }
}
