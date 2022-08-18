using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralPriceGroupDataProvider
    {
        IBaseEntityResponse<GeneralPriceGroup> InsertGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> UpdateGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> DeleteGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupBySearch(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupSearchList(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceGroup> GetGeneralPriceGroupByID(GeneralPriceGroup item);
    }
}
