using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryConsumptionDetailDrillReportServiceAccess : IInventoryConsumptionDetailDrillReportServiceAccess
    {
        IInventoryConsumptionDetailDrillReportBA _InventoryConsumptionDetailDrillReportBA = null;
        public InventoryConsumptionDetailDrillReportServiceAccess()
        {
            _InventoryConsumptionDetailDrillReportBA = new InventoryConsumptionDetailDrillReportBA();
        }

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetGeneralUnitsDropdownForProccesingUnit(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetGeneralUnitsDropdownForProccesingUnit(searchRequest);
        }
        //------------------------------------------------Sale and Wastage----------------------------------
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventorySaleandWastageReportBySearch_GroupDescription(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_ItemDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            return _InventoryConsumptionDetailDrillReportBA.GetInventorySaleandWastageReportBySearch_ItemDescription(searchRequest);
        }
    }
}
