using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralAllocateSaleProcessUnitServiceAccess : IGeneralAllocateSaleProcessUnitServiceAccess
    {
        IGeneralAllocateSaleProcessUnitBA _GeneralAllocateSaleProcessUnitBA = null;
        public GeneralAllocateSaleProcessUnitServiceAccess()
        {
            _GeneralAllocateSaleProcessUnitBA = new GeneralAllocateSaleProcessUnitBA();
        }
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> InsertGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item)
        {
            return _GeneralAllocateSaleProcessUnitBA.InsertGeneralAllocateSaleProcessUnit(item);
        }
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> UpdateGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item)
        {
            return _GeneralAllocateSaleProcessUnitBA.UpdateGeneralAllocateSaleProcessUnit(item);
        }
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> DeleteGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item)
        {
            return _GeneralAllocateSaleProcessUnitBA.DeleteGeneralAllocateSaleProcessUnit(item);
        }
        public IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetBySearch(GeneralAllocateSaleProcessUnitSearchRequest searchRequest)
        {
            return _GeneralAllocateSaleProcessUnitBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetGeneralAllocateSaleProcessUnitSearchList(GeneralAllocateSaleProcessUnitSearchRequest searchRequest)
        {
            return _GeneralAllocateSaleProcessUnitBA.GetGeneralAllocateSaleProcessUnitSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> SelectByID(GeneralAllocateSaleProcessUnit item)
        {
            return _GeneralAllocateSaleProcessUnitBA.SelectByID(item);
        }
    }
}
