﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISyncBR
    {
        /// <summary>
        /// business rule interface of insert new record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSyncValidate(Sync item);

        /// <summary>
        /// business rule interface of update record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSyncValidate(Sync item);

        /// <summary>
        /// business rule interface of dalete record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSyncValidate(Sync item);
    }
}
