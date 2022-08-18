using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralPackingTypeInfoServiceAccess : IGeneralPackingTypeInfoServiceAccess
    {
        IGeneralPackingTypeInfoBA _GeneralPackingTypeInfoBA = null;
        public GeneralPackingTypeInfoServiceAccess()
        {
            _GeneralPackingTypeInfoBA = new GeneralPackingTypeInfoBA();
        }
        public IBaseEntityResponse<GeneralPackingTypeInfo> InsertGeneralPackingTypeInfo(GeneralPackingTypeInfo item)
        {
            return _GeneralPackingTypeInfoBA.InsertGeneralPackingTypeInfo(item);
        }
        public IBaseEntityResponse<GeneralPackingTypeInfo> UpdateGeneralPackingTypeInfo(GeneralPackingTypeInfo item)
        {
            return _GeneralPackingTypeInfoBA.UpdateGeneralPackingTypeInfo(item);
        }
        public IBaseEntityResponse<GeneralPackingTypeInfo> DeleteGeneralPackingTypeInfo(GeneralPackingTypeInfo item)
        {
            return _GeneralPackingTypeInfoBA.DeleteGeneralPackingTypeInfo(item);
        }
        public IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetBySearch(GeneralPackingTypeInfoSearchRequest searchRequest)
        {
            return _GeneralPackingTypeInfoBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetGeneralPackingTypeInfoSearchList(GeneralPackingTypeInfoSearchRequest searchRequest)
        {
            return _GeneralPackingTypeInfoBA.GetGeneralPackingTypeInfoSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralPackingTypeInfo> SelectByID(GeneralPackingTypeInfo item)
        {
            return _GeneralPackingTypeInfoBA.SelectByID(item);
        }
    }
}
