using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralItemMarchandiseGroupBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMarchandiseGroupValidate(GeneralItemMarchandiseGroup item);
        IValidateBusinessRuleResponse UpdateGeneralItemMarchandiseGroupValidate(GeneralItemMarchandiseGroup item);
        IValidateBusinessRuleResponse DeleteGeneralItemMarchandiseGroupValidate(GeneralItemMarchandiseGroup item);
    }
}
