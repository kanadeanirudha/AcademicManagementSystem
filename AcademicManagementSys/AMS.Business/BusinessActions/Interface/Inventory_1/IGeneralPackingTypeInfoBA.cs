using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralPackingTypeInfoBA
    {
        IBaseEntityResponse<GeneralPackingTypeInfo> InsertGeneralPackingTypeInfo(GeneralPackingTypeInfo item);
        IBaseEntityResponse<GeneralPackingTypeInfo> UpdateGeneralPackingTypeInfo(GeneralPackingTypeInfo item);
        IBaseEntityResponse<GeneralPackingTypeInfo> DeleteGeneralPackingTypeInfo(GeneralPackingTypeInfo item);
        IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetBySearch(GeneralPackingTypeInfoSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetGeneralPackingTypeInfoSearchList(GeneralPackingTypeInfoSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPackingTypeInfo> SelectByID(GeneralPackingTypeInfo item);
    }
}

