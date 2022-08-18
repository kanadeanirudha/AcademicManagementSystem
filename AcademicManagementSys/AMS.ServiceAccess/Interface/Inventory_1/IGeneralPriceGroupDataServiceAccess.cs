using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPriceGroupServiceAccess
    {
        IBaseEntityResponse<GeneralPriceGroup> InsertGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> UpdateGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityResponse<GeneralPriceGroup> DeleteGeneralPriceGroup(GeneralPriceGroup item);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetBySearch(GeneralPriceGroupSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceGroup> SelectByID(GeneralPriceGroup item);
        IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupSearchList(GeneralPriceGroupSearchRequest searchRequest);
    }
}
