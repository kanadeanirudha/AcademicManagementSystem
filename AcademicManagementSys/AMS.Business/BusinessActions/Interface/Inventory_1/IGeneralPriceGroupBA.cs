using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralPriceGroupBA
    {
        IBaseEntityResponse<GeneralPriceGroup> InsertGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> UpdateGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> DeleteGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetBySearch(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupSearchList(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceGroup> SelectByID(GeneralPriceGroup item);
    }
}

