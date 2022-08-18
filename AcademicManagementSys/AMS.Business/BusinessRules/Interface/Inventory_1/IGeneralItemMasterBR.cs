using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralItemMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMasterValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse UpdateGeneralItemMasterValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemMasterValidate(GeneralItemMaster item);

        IValidateBusinessRuleResponse InsertGeneralItemBarcodesValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemBarcodesValidate(GeneralItemMaster item);

        IValidateBusinessRuleResponse InsertInventoryStoreSpecificInformationValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse InsertGeneralItemMasterExcelValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse InsertGeneralItemSupplierDataForVendorDetailsValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemMasterEComImagesValidate(GeneralItemMaster item);
    }
}
