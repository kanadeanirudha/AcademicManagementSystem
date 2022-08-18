using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralAllocateSaleProcessUnitDataProvider
    {
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> InsertGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item);
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> UpdateGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item);
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> DeleteGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item);
        IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetGeneralAllocateSaleProcessUnitBySearch(GeneralAllocateSaleProcessUnitSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetGeneralAllocateSaleProcessUnitSearchList(GeneralAllocateSaleProcessUnitSearchRequest searchRequest);
        IBaseEntityResponse<GeneralAllocateSaleProcessUnit> GetGeneralAllocateSaleProcessUnitByID(GeneralAllocateSaleProcessUnit item);
    }
}
