﻿
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineExamAssignpapersetterBR
    {
        IValidateBusinessRuleResponse InsertOnlineExamAssignpapersetterValidate(OnlineExamAssignpapersetter item);
        IValidateBusinessRuleResponse UpdateOnlineExamAssignpapersetterValidate(OnlineExamAssignpapersetter item);
        IValidateBusinessRuleResponse DeleteOnlineExamAssignpapersetterValidate(OnlineExamAssignpapersetter item);
    }
}
