using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemMarchandiseGroupServiceAccess : IGeneralItemMarchandiseGroupServiceAccess
    {
        IGeneralItemMarchandiseGroupBA _GeneralItemMarchandiseGroupBA = null;
        public GeneralItemMarchandiseGroupServiceAccess()
        {
            _GeneralItemMarchandiseGroupBA = new GeneralItemMarchandiseGroupBA();
        }
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> InsertGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item)
        {
            return _GeneralItemMarchandiseGroupBA.InsertGeneralItemMarchandiseGroup(item);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> UpdateGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item)
        {
            return _GeneralItemMarchandiseGroupBA.UpdateGeneralItemMarchandiseGroup(item);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> DeleteGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item)
        {
            return _GeneralItemMarchandiseGroupBA.DeleteGeneralItemMarchandiseGroup(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetBySearch(GeneralItemMarchandiseGroupSearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseGroupBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchList(GeneralItemMarchandiseGroupSearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseGroupBA.GetGeneralItemMarchandiseGroupSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> SelectByID(GeneralItemMarchandiseGroup item)
        {
            return _GeneralItemMarchandiseGroupBA.SelectByID(item);

        }
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchListForCategory(GeneralItemMarchandiseGroupSearchRequest searchRequest)
        {
            return _GeneralItemMarchandiseGroupBA.GetGeneralItemMarchandiseGroupSearchListForCategory(searchRequest);
        }
    }
}
