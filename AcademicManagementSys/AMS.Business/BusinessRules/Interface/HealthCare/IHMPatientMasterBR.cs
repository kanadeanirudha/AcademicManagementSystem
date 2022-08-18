using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IHMPatientMasterBR
    {
        IValidateBusinessRuleResponse InsertHMPatientMasterValidate(HMPatientMaster item);
        IValidateBusinessRuleResponse UpdateHMPatientMasterValidate(HMPatientMaster item);
        IValidateBusinessRuleResponse DeleteHMPatientMasterValidate(HMPatientMaster item);
    }
}
