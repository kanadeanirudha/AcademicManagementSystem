﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IPurchaseRequisitionMasterBR
    {
        IValidateBusinessRuleResponse InsertPurchaseRequisitionMasterValidate(PurchaseRequisitionMaster item);
        IValidateBusinessRuleResponse UpdatePurchaseRequisitionMasterValidate(PurchaseRequisitionMaster item);
        IValidateBusinessRuleResponse DeletePurchaseRequisitionMasterValidate(PurchaseRequisitionMaster item);
    }
}
