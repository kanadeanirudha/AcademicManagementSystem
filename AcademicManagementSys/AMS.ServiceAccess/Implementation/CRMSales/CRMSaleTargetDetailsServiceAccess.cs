using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleTargetDetailsServiceAccess : ICRMSaleTargetDetailsServiceAccess
    {
        ICRMSaleTargetDetailsBA _CRMSaleTargetDetailsBA = null;

        public CRMSaleTargetDetailsServiceAccess()
        {
            _CRMSaleTargetDetailsBA = new CRMSaleTargetDetailsBA();
        }

        //CRMSaleTargetGroupWise
        public IBaseEntityResponse<CRMSaleTargetDetails> InsertCRMSaleTargetGroupWise(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.InsertCRMSaleTargetGroupWise(item);
        }

        public IBaseEntityResponse<CRMSaleTargetDetails> UpdateCRMSaleTargetGroupWise(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.UpdateCRMSaleTargetGroupWise(item);
        }

        public IBaseEntityResponse<CRMSaleTargetDetails> DeleteCRMSaleTargetGroupWise(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.DeleteCRMSaleTargetGroupWise(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetBySearchCRMSaleTargetGroupWise(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            return _CRMSaleTargetDetailsBA.GetBySearchCRMSaleTargetGroupWise(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetGroupWiseSearchList(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            return _CRMSaleTargetDetailsBA.GetCRMSaleTargetGroupWiseSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleTargetDetails> SelectByCRMSaleTargetGroupWiseID(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.SelectByCRMSaleTargetGroupWiseID(item);
        }

        //CRMSaleTargetException

        public IBaseEntityResponse<CRMSaleTargetDetails> InsertCRMSaleTargetException(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.InsertCRMSaleTargetException(item);
        }

        public IBaseEntityResponse<CRMSaleTargetDetails> UpdateCRMSaleTargetException(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.UpdateCRMSaleTargetException(item);
        }

        public IBaseEntityResponse<CRMSaleTargetDetails> DeleteCRMSaleTargetException(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.DeleteCRMSaleTargetException(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetBySearchCRMSaleTargetException(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            return _CRMSaleTargetDetailsBA.GetBySearchCRMSaleTargetException(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetExceptionSearchList(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            return _CRMSaleTargetDetailsBA.GetCRMSaleTargetExceptionSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleTargetDetails> SelectByCRMSaleTargetExceptionID(CRMSaleTargetDetails item)
        {
            return _CRMSaleTargetDetailsBA.SelectByCRMSaleTargetExceptionID(item);
        }
        //CRMSaleTargetType
        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetTypeSearchList(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            return _CRMSaleTargetDetailsBA.GetCRMSaleTargetTypeSearchList(searchRequest);
        }
    }
}

