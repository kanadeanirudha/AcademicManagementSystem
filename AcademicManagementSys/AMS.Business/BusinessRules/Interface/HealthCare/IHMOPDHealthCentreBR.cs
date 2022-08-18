using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IHMOPDHealthCentreBR
    {
        IValidateBusinessRuleResponse InsertHMOPDHealthCentreValidate(HMOPDHealthCentre item);
        IValidateBusinessRuleResponse UpdateHMOPDHealthCentreValidate(HMOPDHealthCentre item);
        IValidateBusinessRuleResponse DeleteHMOPDHealthCentreValidate(HMOPDHealthCentre item);
    }
}
