using System;
using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class InventoryExcelUploadServiceAccess : IInventoryExcelUploadServiceAccess
    {
        IInventoryExcelUploadBA _InventoryExcelUploadBA = null;
        public InventoryExcelUploadServiceAccess()
        {
            _InventoryExcelUploadBA = new InventoryExcelUploadBA();
        }

        public IBaseEntityResponse<InventoryExcelUpload> GetDataValidationListsForInventoryExcel(InventoryExcelUpload inventoryExcelUpload)
        {
            return _InventoryExcelUploadBA.GetDataValidationListsForInventoryExcel(inventoryExcelUpload);
        }
        public IBaseEntityResponse<InventoryExcelUpload> InsertVendorMasterMapCategoryExcel(InventoryExcelUpload item)
        {
            return _InventoryExcelUploadBA.InsertVendorMasterMapCategoryExcel(item);
        }
        public IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterMapCategoryExcel(InventoryExcelUpload item)
        {
            return _InventoryExcelUploadBA.InsertItemMasterMapCategoryExcel(item);
        }
        public IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterStoreDataExcel(InventoryExcelUpload item)
        {
            return _InventoryExcelUploadBA.InsertItemMasterStoreDataExcel(item);
        }

        public IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterPriceReportExcel(InventoryExcelUpload item)
        {
            return _InventoryExcelUploadBA.InsertItemMasterPriceReportExcel(item);
        }
    }
}
