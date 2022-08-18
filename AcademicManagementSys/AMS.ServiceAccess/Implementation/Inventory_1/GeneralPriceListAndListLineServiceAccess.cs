using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralPriceListAndListLineServiceAccess : IGeneralPriceListAndListLineServiceAccess
    {
        IGeneralPriceListAndListLineBA _GeneralPriceListAndListLineBA = null;
        public GeneralPriceListAndListLineServiceAccess()
        {
            _GeneralPriceListAndListLineBA = new GeneralPriceListAndListLineBA();
        }
        public IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceListAndListLine(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.InsertGeneralPriceListAndListLine(item);
        }
        public IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceListAndListLine(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.UpdateGeneralPriceListAndListLine(item);
        }
        public IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceListAndListLine(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.DeleteGeneralPriceListAndListLine(item);
        }
        public IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetBySearch(GeneralPriceListAndListLineSearchRequest searchRequest)
        {
            return _GeneralPriceListAndListLineBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineSearchList(GeneralPriceListAndListLineSearchRequest searchRequest)
        {
            return _GeneralPriceListAndListLineBA.GetGeneralPriceListAndListLineSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralPriceListAndListLine> SelectByID(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.SelectByID(item);
        }
        //***************************************************************************************//
        public IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceList(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.InsertGeneralPriceList(item);
        }
        public IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceList(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.UpdateGeneralPriceList(item);
        }
        public IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceList(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.DeleteGeneralPriceList(item);
        }

        public IBaseEntityCollectionResponse<GeneralPriceListAndListLine> SelectByGeneralPriceListID(GeneralPriceListAndListLineSearchRequest searchRequest)
        {
            return _GeneralPriceListAndListLineBA.SelectByGeneralPriceListID(searchRequest);
        }

        public IBaseEntityResponse<GeneralPriceListAndListLine> GetIsRootCount(GeneralPriceListAndListLine item)
        {
            return _GeneralPriceListAndListLineBA.GetIsRootCount(item);
        }
    }
}
