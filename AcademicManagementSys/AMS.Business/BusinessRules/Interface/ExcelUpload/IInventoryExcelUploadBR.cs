using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryExcelUploadBR
    {
        IValidateBusinessRuleResponse InsertVendorMasterMapCategoryExcelValidate(InventoryExcelUpload item);
        IValidateBusinessRuleResponse InsertItemMasterMapCategoryExcelValidate(InventoryExcelUpload item);
        IValidateBusinessRuleResponse InsertItemMasterStoreDataExcelValidate(InventoryExcelUpload item);
        IValidateBusinessRuleResponse InsertItemMasterPriceReportExcelValidate(InventoryExcelUpload item);
    }
}
