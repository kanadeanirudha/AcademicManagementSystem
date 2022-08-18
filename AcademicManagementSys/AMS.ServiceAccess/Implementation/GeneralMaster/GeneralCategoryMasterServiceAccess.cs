using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;

namespace AMS.ServiceAccess 
{
    public class GeneralCategoryMasterServiceAccess : IGeneralCategoryMasterServiceAccess
    {
         IGeneralCategoryMasterBA _categoryMasterBA = null;

         public GeneralCategoryMasterServiceAccess()
        {
            _categoryMasterBA = new GeneralCategoryMasterBA();
        }

         public IBaseEntityResponse<GeneralCategoryMaster> InsertGeneralCategoryMaster(GeneralCategoryMaster item)
        {
            return _categoryMasterBA.InsertCategory(item);
        }

         public IBaseEntityResponse<GeneralCategoryMaster> UpdateGeneralCategoryMaster(GeneralCategoryMaster item)
        {
            return _categoryMasterBA.UpdateCategory(item);
        }

         public IBaseEntityResponse<GeneralCategoryMaster> DeleteGeneralCategoryMaster(GeneralCategoryMaster item)
        {
            return _categoryMasterBA.DeleteCategory(item);
        }

         public IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearch(GeneralCategoryMasterSearchRequest searchRequest)
        {
            return _categoryMasterBA.GetBySearch(searchRequest);
        }

         public IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearchList(GeneralCategoryMasterSearchRequest searchRequest)
        {
            return _categoryMasterBA.GetBySearchList(searchRequest);
        }


         public IBaseEntityResponse<GeneralCategoryMaster> SelectByID(GeneralCategoryMaster item)
        {
            return _categoryMasterBA.SelectByID(item);
        }
    }
}
