using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralPriceGroupServiceAccess : IGeneralPriceGroupServiceAccess
    {
        IGeneralPriceGroupBA _GeneralPriceGroupBA = null;
        public GeneralPriceGroupServiceAccess()
        {
            _GeneralPriceGroupBA = new GeneralPriceGroupBA();
        }
        public IBaseEntityResponse<GeneralPriceGroup> InsertGeneralPriceGroup(GeneralPriceGroup item)
        {
            return _GeneralPriceGroupBA.InsertGeneralPriceGroup(item);
        }
        public IBaseEntityResponse<GeneralPriceGroup> UpdateGeneralPriceGroup(GeneralPriceGroup item)
        {
            return _GeneralPriceGroupBA.UpdateGeneralPriceGroup(item);
        }
        public IBaseEntityResponse<GeneralPriceGroup> DeleteGeneralPriceGroup(GeneralPriceGroup item)
        {
            return _GeneralPriceGroupBA.DeleteGeneralPriceGroup(item);
        }
        public IBaseEntityCollectionResponse<GeneralPriceGroup> GetBySearch(GeneralPriceGroupSearchRequest searchRequest)
        {
            return _GeneralPriceGroupBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupSearchList(GeneralPriceGroupSearchRequest searchRequest)
        {
            return _GeneralPriceGroupBA.GetGeneralPriceGroupSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralPriceGroup> SelectByID(GeneralPriceGroup item)
        {
            return _GeneralPriceGroupBA.SelectByID(item);
        }
    }
}
