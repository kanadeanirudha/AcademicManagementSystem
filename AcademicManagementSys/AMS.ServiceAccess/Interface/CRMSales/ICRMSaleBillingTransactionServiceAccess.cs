﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMSaleBillingTransactionServiceAccess
    {
        //CRMSaleBillingTransaction
        IBaseEntityResponse<CRMSaleBillingTransaction> InsertCRMSaleBillingTransaction(CRMSaleBillingTransaction item);
        IBaseEntityResponse<CRMSaleBillingTransaction> UpdateCRMSaleBillingTransaction(CRMSaleBillingTransaction item);
        IBaseEntityResponse<CRMSaleBillingTransaction> DeleteCRMSaleBillingTransaction(CRMSaleBillingTransaction item);
        IBaseEntityCollectionResponse<CRMSaleBillingTransaction> GetCRMSaleBillingTransactionSelectAll(CRMSaleBillingTransactionSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleBillingTransaction> SelectByCRMSaleBillingTransactionID(CRMSaleBillingTransaction item);
    }
}
