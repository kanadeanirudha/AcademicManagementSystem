using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMSaleTargetDetailsBR
    {
        //CRMSaleTargetGroupWise
        IValidateBusinessRuleResponse InsertCRMSaleTargetGroupWiseValidate(CRMSaleTargetDetails item);

        IValidateBusinessRuleResponse UpdateCRMSaleTargetGroupWiseValidate(CRMSaleTargetDetails item);

        IValidateBusinessRuleResponse DeleteCRMSaleTargetGroupWiseValidate(CRMSaleTargetDetails item);

        //CRMSaleTargetException

        IValidateBusinessRuleResponse InsertCRMSaleTargetExceptionValidate(CRMSaleTargetDetails item);

        IValidateBusinessRuleResponse UpdateCRMSaleTargetExceptionValidate(CRMSaleTargetDetails item);

        IValidateBusinessRuleResponse DeleteCRMSaleTargetExceptionValidate(CRMSaleTargetDetails item);
    }
}
