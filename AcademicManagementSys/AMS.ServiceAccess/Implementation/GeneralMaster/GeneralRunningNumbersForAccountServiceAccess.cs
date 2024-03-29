﻿using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class GeneralRunningNumbersForAccountServiceAccess : IGeneralRunningNumbersForAccountServiceAccess
    {
        IGeneralRunningNumbersForAccountBA  _GeneralRunningNumbersForAccountBA = null;

        public GeneralRunningNumbersForAccountServiceAccess()
        {
            _GeneralRunningNumbersForAccountBA = new GeneralRunningNumbersForAccountBA();
        }
        /// <summary>
        /// Service access of create new record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> InsertGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item)
        {
            return _GeneralRunningNumbersForAccountBA.InsertGeneralRunningNumbersForAccount(item);
        }

        /// <summary>
        /// Service access of update a specific record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> UpdateGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item)
        {
            return _GeneralRunningNumbersForAccountBA.UpdateGeneralRunningNumbersForAccount(item);
        }

        /// <summary>
        /// Service access of delete a selected record from GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> DeleteGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item)
        {
            return _GeneralRunningNumbersForAccountBA.DeleteGeneralRunningNumbersForAccount(item);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralRunningNumbersForAccount table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetBySearch(GeneralRunningNumbersForAccountSearchRequest searchRequest)
        {
            return _GeneralRunningNumbersForAccountBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from GeneralRunningNumbersForAccount table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetGeneralRunningNumbersForAccountList(GeneralRunningNumbersForAccountSearchRequest searchRequest)
        {
            return _GeneralRunningNumbersForAccountBA.GetGeneralRunningNumbersForAccountList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from GeneralRunningNumbersForAccount table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> SelectByID(GeneralRunningNumbersForAccount item)
        {
            return _GeneralRunningNumbersForAccountBA.SelectByID(item);
        }
        //Get Auto generated Purchase Requirement Number
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> GetAutoGeneratedRequirementNumber(GeneralRunningNumbersForAccount item)
        {
            return _GeneralRunningNumbersForAccountBA.GetAutoGeneratedRequirementNumber(item);
        }
    }
}

