using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IScholarShipMasterBR
    {
        IValidateBusinessRuleResponse InsertScholarShipMasterValidate(ScholarShipMaster item);
        IValidateBusinessRuleResponse UpdateScholarShipMasterValidate(ScholarShipMaster item);
        IValidateBusinessRuleResponse DeleteScholarShipMasterValidate(ScholarShipMaster item);
    }
}
