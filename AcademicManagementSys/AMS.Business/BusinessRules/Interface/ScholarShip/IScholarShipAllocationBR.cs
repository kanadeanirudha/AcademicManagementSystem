using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IScholarShipAllocationBR
    {
        IValidateBusinessRuleResponse InsertScholarShipAllocationValidate(ScholarShipAllocation item);
        IValidateBusinessRuleResponse UpdateScholarShipAllocationValidate(ScholarShipAllocation item);
        IValidateBusinessRuleResponse DeleteScholarShipAllocationValidate(ScholarShipAllocation item);
    }
}
