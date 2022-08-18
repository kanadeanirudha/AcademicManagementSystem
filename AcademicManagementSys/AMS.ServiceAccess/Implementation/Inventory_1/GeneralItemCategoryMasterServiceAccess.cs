using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemCategoryMasterServiceAccess : IGeneralItemCategoryMasterServiceAccess
    {
        IGeneralItemCategoryMasterBA _GeneralItemCategoryMasterBA = null;
        public GeneralItemCategoryMasterServiceAccess()
        {
            _GeneralItemCategoryMasterBA = new GeneralItemCategoryMasterBA();
        }
        public IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            return _GeneralItemCategoryMasterBA.InsertGeneralItemCategoryMaster(item);
        }
        public IBaseEntityResponse<GeneralItemCategoryMaster> UpdateGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            return _GeneralItemCategoryMasterBA.UpdateGeneralItemCategoryMaster(item);
        }
        public IBaseEntityResponse<GeneralItemCategoryMaster> DeleteGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            return _GeneralItemCategoryMasterBA.DeleteGeneralItemCategoryMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetBySearch(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            return _GeneralItemCategoryMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterSearchList(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            return _GeneralItemCategoryMasterBA.GetGeneralItemCategoryMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemCategoryMaster> SelectByID(GeneralItemCategoryMaster item)
        {
            return _GeneralItemCategoryMasterBA.SelectByID(item);
        }
        public IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMasterExcel(GeneralItemCategoryMaster item)
        {
            return _GeneralItemCategoryMasterBA.InsertGeneralItemCategoryMasterExcel(item);
        }
    }
}
