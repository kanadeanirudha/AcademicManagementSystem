﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMSaleBillingTransactionBR
    {
        //CRMSaleTargetGroupWise
        IValidateBusinessRuleResponse InsertCRMSaleBillingTransactionValidate(CRMSaleBillingTransaction item);

        IValidateBusinessRuleResponse UpdateCRMSaleBillingTransactionValidate(CRMSaleBillingTransaction item);

        IValidateBusinessRuleResponse DeleteCRMSaleBillingTransactionValidate(CRMSaleBillingTransaction item);
    }
}
