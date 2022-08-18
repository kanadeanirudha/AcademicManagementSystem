using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
   public interface IGeneralCategoryMasterServiceAccess
    {
       IBaseEntityResponse<GeneralCategoryMaster> InsertGeneralCategoryMaster(GeneralCategoryMaster item);

       IBaseEntityResponse<GeneralCategoryMaster> UpdateGeneralCategoryMaster(GeneralCategoryMaster item);

       IBaseEntityResponse<GeneralCategoryMaster> DeleteGeneralCategoryMaster(GeneralCategoryMaster item);
       
        IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearch(GeneralCategoryMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearchList(GeneralCategoryMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralCategoryMaster> SelectByID(GeneralCategoryMaster item);
    }
}
