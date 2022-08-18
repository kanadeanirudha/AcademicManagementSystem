using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IHMComfirtTypeBR
    {
        IValidateBusinessRuleResponse InsertHMComfirtTypeValidate(HMComfirtType item);
        IValidateBusinessRuleResponse UpdateHMComfirtTypeValidate(HMComfirtType item);
        IValidateBusinessRuleResponse DeleteHMComfirtTypeValidate(HMComfirtType item);
    }
}
