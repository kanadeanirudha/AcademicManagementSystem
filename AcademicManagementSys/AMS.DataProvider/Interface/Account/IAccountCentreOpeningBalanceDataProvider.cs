using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
   public interface IAccountCentreOpeningBalanceDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account centre opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetAccountCentreOpeningBalanceBySearch(AccountCentreOpeningBalanceSearchRequest searchRequest);
       
        /// <summary>
        /// data provider interface of select all record of account centre opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearchIndividualAccount(AccountCentreOpeningBalanceSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account centre opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentreOpeningBalance> GetAccountCentreOpeningBalanceByID(AccountCentreOpeningBalance item);

        /// <summary>
        /// data provider interface of insert new record of account centre opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentreOpeningBalance> InsertAccountCentreOpeningBalance(AccountCentreOpeningBalance item);

        /// <summary>
        /// data provider interface of update record of account centre opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentreOpeningBalance> UpdateAccountCentreOpeningBalance(AccountCentreOpeningBalance item);

        /// <summary>
        /// data provider interface of dalete record of account centre opening balance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCentreOpeningBalance> DeleteAccountCentreOpeningBalance(AccountCentreOpeningBalance item);
    }
}
