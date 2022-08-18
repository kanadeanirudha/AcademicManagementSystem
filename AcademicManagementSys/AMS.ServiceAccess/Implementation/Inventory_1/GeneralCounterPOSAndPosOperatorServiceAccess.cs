using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralCounterPOSAndPosOperatorServiceAccess : IGeneralCounterPOSAndPosOperatorServiceAccess
    {
        IGeneralCounterPOSAndPosOperatorBA _GeneralCounterPOSAndPosOperatorBA = null;
        public GeneralCounterPOSAndPosOperatorServiceAccess()
        {
            _GeneralCounterPOSAndPosOperatorBA = new GeneralCounterPOSAndPosOperatorBA();
        }
        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetListCounterMaster(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            return _GeneralCounterPOSAndPosOperatorBA.GetListCounterMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetListPOSMaster(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            return _GeneralCounterPOSAndPosOperatorBA.GetListPOSMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetGeneralCounterPOSApplicableBySearch(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            return _GeneralCounterPOSAndPosOperatorBA.GetGeneralCounterPOSApplicableBySearch(searchRequest);
        }
        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> SelectByID(GeneralCounterPOSAndPosOperator item)
        {
            return _GeneralCounterPOSAndPosOperatorBA.SelectByID(item);
        }

        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> InsertGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item)
        {
            return _GeneralCounterPOSAndPosOperatorBA.InsertGeneralCounterPOSAndPosOperator(item);
        }
        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> UpdateGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item)
        {
            return _GeneralCounterPOSAndPosOperatorBA.UpdateGeneralCounterPOSAndPosOperator(item);
        }
        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> DeleteGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item)
        {
            return _GeneralCounterPOSAndPosOperatorBA.DeleteGeneralCounterPOSAndPosOperator(item);
        }
        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetGeneralCounterPOSAndPosOperatorSearchList(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            return _GeneralCounterPOSAndPosOperatorBA.GetGeneralCounterPOSAndPosOperatorSearchList(searchRequest);
        }
       

    }
}
