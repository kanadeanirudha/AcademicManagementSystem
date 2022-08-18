using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralAllocateSaleProcessUnitBA
    {
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> InsertGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item);
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> UpdateGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item);
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> DeleteGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item);
        IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetBySearch(GeneralAllocateSaleProcessUnitSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetGeneralAllocateSaleProcessUnitSearchList(GeneralAllocateSaleProcessUnitSearchRequest searchRequest);
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> SelectByID(GeneralAllocateSaleProcessUnit item);
    }
}

