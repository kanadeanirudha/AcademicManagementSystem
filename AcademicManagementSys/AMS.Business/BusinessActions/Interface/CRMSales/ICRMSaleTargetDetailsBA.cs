using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ICRMSaleTargetDetailsBA
    {

        //CRMSaleTargetGroupWise
        IBaseEntityResponse<CRMSaleTargetDetails> InsertCRMSaleTargetGroupWise(CRMSaleTargetDetails item);
        IBaseEntityResponse<CRMSaleTargetDetails> UpdateCRMSaleTargetGroupWise(CRMSaleTargetDetails item);
        IBaseEntityResponse<CRMSaleTargetDetails> DeleteCRMSaleTargetGroupWise(CRMSaleTargetDetails item);
        IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetBySearchCRMSaleTargetGroupWise(CRMSaleTargetDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleTargetDetails> SelectByCRMSaleTargetGroupWiseID(CRMSaleTargetDetails item);
        IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetGroupWiseSearchList(CRMSaleTargetDetailsSearchRequest searchRequest);

        //CRMSaleTargetException
        IBaseEntityResponse<CRMSaleTargetDetails> InsertCRMSaleTargetException(CRMSaleTargetDetails item);
        IBaseEntityResponse<CRMSaleTargetDetails> UpdateCRMSaleTargetException(CRMSaleTargetDetails item);
        IBaseEntityResponse<CRMSaleTargetDetails> DeleteCRMSaleTargetException(CRMSaleTargetDetails item);
        IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetBySearchCRMSaleTargetException(CRMSaleTargetDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleTargetDetails> SelectByCRMSaleTargetExceptionID(CRMSaleTargetDetails item);
        IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetExceptionSearchList(CRMSaleTargetDetailsSearchRequest searchRequest);

        //CRMSaleTargetType
        IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetTypeSearchList(CRMSaleTargetDetailsSearchRequest searchRequest);
    }
}
