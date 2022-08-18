using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IFeeTypeAndSubTypeBA
    {
        IBaseEntityResponse<FeeTypeAndSubType> InsertFeeTypeAndSubType(FeeTypeAndSubType item);
        IBaseEntityResponse<FeeTypeAndSubType> UpdateFeeTypeAndSubType(FeeTypeAndSubType item);
        IBaseEntityResponse<FeeTypeAndSubType> DeleteFeeTypeAndSubType(FeeTypeAndSubType item);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetBySearch(FeeTypeAndSubTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeList(FeeTypeAndSubTypeSearchRequest searchRequest);
        IBaseEntityResponse<FeeTypeAndSubType> SelectByID(FeeTypeAndSubType item);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeSearchList(FeeTypeAndSubTypeSearchRequest searchRequest);
    }
}
