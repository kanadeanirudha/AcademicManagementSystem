using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IFeeTypeAndSubTypeDataProvider
    {
        IBaseEntityResponse<FeeTypeAndSubType> InsertFeeTypeAndSubType(FeeTypeAndSubType item);
        IBaseEntityResponse<FeeTypeAndSubType> UpdateFeeTypeAndSubType(FeeTypeAndSubType item);
        IBaseEntityResponse<FeeTypeAndSubType> DeleteFeeTypeAndSubType(FeeTypeAndSubType item);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeTypeAndSubTypeBySearch(FeeTypeAndSubTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeList(FeeTypeAndSubTypeSearchRequest searchRequest);
        IBaseEntityResponse<FeeTypeAndSubType> GetFeeTypeAndSubTypeByID(FeeTypeAndSubType item);
        IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeSearchList(FeeTypeAndSubTypeSearchRequest searchRequest);
    }
}
