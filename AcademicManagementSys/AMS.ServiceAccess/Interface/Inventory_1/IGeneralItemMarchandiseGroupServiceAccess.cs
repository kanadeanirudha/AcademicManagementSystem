using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralItemMarchandiseGroupServiceAccess
    {
        IBaseEntityResponse<GeneralItemMarchandiseGroup> InsertGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item);
        IBaseEntityResponse<GeneralItemMarchandiseGroup> UpdateGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item);
        IBaseEntityResponse<GeneralItemMarchandiseGroup> DeleteGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetBySearch(GeneralItemMarchandiseGroupSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMarchandiseGroup> SelectByID(GeneralItemMarchandiseGroup item);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchList(GeneralItemMarchandiseGroupSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchListForCategory(GeneralItemMarchandiseGroupSearchRequest searchRequest);
    }
}
