﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryEstimationMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item);
        IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationToLocation(InventoryEstimationMasterAndDetails item);
        IBaseEntityResponse<InventoryEstimationMasterAndDetails> UpdateInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item);
        IBaseEntityResponse<InventoryEstimationMasterAndDetails> DeleteInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item);
        IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetInventoryEstimationMasterAndDetailsBySearch(InventoryEstimationMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetailsSearchRequest searchRequest);

      
    }
}
