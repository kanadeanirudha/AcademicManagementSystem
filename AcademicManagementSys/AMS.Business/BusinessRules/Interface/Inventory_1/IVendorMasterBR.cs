using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IVendorMasterBR
    {
        IValidateBusinessRuleResponse InsertVendorMasterValidate(VendorMaster item);
        IValidateBusinessRuleResponse UpdateVendorMasterValidate(VendorMaster item);
        IValidateBusinessRuleResponse DeleteVendorMasterValidate(VendorMaster item);
        IValidateBusinessRuleResponse InsertVendorMasterExcelValidate(VendorMaster item);

    }
}
