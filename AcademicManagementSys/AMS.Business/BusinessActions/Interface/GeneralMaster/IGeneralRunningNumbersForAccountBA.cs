﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralRunningNumbersForAccountBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> InsertGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// business action interface of update record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> UpdateGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// business action interface of dalete record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> DeleteGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// business action interface of select all record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetBySearch(GeneralRunningNumbersForAccountSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetGeneralRunningNumbersForAccountList(GeneralRunningNumbersForAccountSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> SelectByID(GeneralRunningNumbersForAccount item);

        IBaseEntityResponse<GeneralRunningNumbersForAccount> GetAutoGeneratedRequirementNumber(GeneralRunningNumbersForAccount item);
    }
}
