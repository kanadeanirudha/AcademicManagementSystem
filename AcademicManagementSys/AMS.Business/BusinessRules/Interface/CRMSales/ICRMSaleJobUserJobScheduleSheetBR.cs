using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMSaleJobUserJobScheduleSheetBR
    {
        //CRMSaleAccountProgressTypeRule
        IValidateBusinessRuleResponse InsertCRMSaleJobUserJobScheduleSheetValidate(CRMSaleJobUserJobScheduleSheet item);
        IValidateBusinessRuleResponse UpdateCRMSaleJobUserJobScheduleSheetValidate(CRMSaleJobUserJobScheduleSheet item);
        IValidateBusinessRuleResponse DeleteCRMSaleJobUserJobScheduleSheetValidate(CRMSaleJobUserJobScheduleSheet item);

        IValidateBusinessRuleResponse UpdateCRMSaleJobUserJobScheduleSheetUpdateValidate(CRMSaleJobUserJobScheduleSheet item);

    }
}
