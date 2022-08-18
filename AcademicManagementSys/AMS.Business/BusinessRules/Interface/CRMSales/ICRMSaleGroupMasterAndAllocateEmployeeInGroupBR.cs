using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMSaleGroupMasterAndAllocateEmployeeInGroupBR
    {
        //CRMSaleGroupMaster
        IValidateBusinessRuleResponse InsertCRMSaleGroupMasterValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);

        IValidateBusinessRuleResponse UpdateCRMSaleGroupMasterValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);

        IValidateBusinessRuleResponse DeleteCRMSaleGroupMasterValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);

        //CRMSaleAllocateEmployeeInGroup

        IValidateBusinessRuleResponse InsertCRMSaleAllocateEmployeeInGroupValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);

        IValidateBusinessRuleResponse UpdateCRMSaleAllocateEmployeeInGroupValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);

        IValidateBusinessRuleResponse DeleteCRMSaleAllocateEmployeeInGroupValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
    }
}
