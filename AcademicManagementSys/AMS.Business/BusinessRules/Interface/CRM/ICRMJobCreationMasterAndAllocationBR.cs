using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMJobCreationMasterAndAllocationBR
    {
        IValidateBusinessRuleResponse InsertCRMJobCreationMasterAndAllocationValidate(CRMJobCreationMasterAndAllocation item);
        IValidateBusinessRuleResponse UpdateCRMJobCreationMasterAndAllocationValidate(CRMJobCreationMasterAndAllocation item);
        IValidateBusinessRuleResponse DeleteCRMJobCreationMasterAndAllocationValidate(CRMJobCreationMasterAndAllocation item);
    }
}
