using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryExcelUploadServiceAccess
    {
        IBaseEntityResponse<InventoryExcelUpload> GetDataValidationListsForInventoryExcel(InventoryExcelUpload inventoryExcelUpload);
        IBaseEntityResponse<InventoryExcelUpload> InsertVendorMasterMapCategoryExcel(InventoryExcelUpload item);
        IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterMapCategoryExcel(InventoryExcelUpload item);
        IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterStoreDataExcel(InventoryExcelUpload item);
        IBaseEntityResponse<InventoryExcelUpload> InsertItemMasterPriceReportExcel(InventoryExcelUpload item);

    }
}
