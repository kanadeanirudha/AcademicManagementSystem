﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryEstimationMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertInventoryEstimationMasterAndDetailsValidate(InventoryEstimationMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateInventoryEstimationMasterAndDetailsValidate(InventoryEstimationMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteInventoryEstimationMasterAndDetailsValidate(InventoryEstimationMasterAndDetails item);
    }
}
