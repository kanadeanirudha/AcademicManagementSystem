using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IEmpDesignationMasterBR
    {
        IValidateBusinessRuleResponse InsertEmpDesignationMasterValidate(EmpDesignationMaster item);

        IValidateBusinessRuleResponse UpdateEmpDesignationMasterValidate(EmpDesignationMaster item);

        IValidateBusinessRuleResponse DeleteEmpDesignationMasterValidate(EmpDesignationMaster item);
    }
}
