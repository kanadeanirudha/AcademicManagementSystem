﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface ILeaveLateMarkRulesDetailsBA
    {
        IBaseEntityResponse<LeaveLateMarkRulesDetails> InsertLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item);
        IBaseEntityResponse<LeaveLateMarkRulesDetails> UpdateLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item);
        IBaseEntityResponse<LeaveLateMarkRulesDetails> DeleteLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item);
        IBaseEntityCollectionResponse<LeaveLateMarkRulesDetails> GetBySearch(LeaveLateMarkRulesDetailsSearchRequest searchRequest);
        IBaseEntityResponse<LeaveLateMarkRulesDetails> SelectByID(LeaveLateMarkRulesDetails item);
    }
}
