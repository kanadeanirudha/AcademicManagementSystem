using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IHMIPDTypeDataProvider
    {
        IBaseEntityResponse<HMIPDType> InsertHMIPDType(HMIPDType item);
        IBaseEntityResponse<HMIPDType> UpdateHMIPDType(HMIPDType item);
        IBaseEntityResponse<HMIPDType> DeleteHMIPDType(HMIPDType item);
        IBaseEntityCollectionResponse<HMIPDType> GetHMIPDTypeBySearch(HMIPDTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMIPDType> GetHMIPDTypeSearchList(HMIPDTypeSearchRequest searchRequest);
        IBaseEntityResponse<HMIPDType> GetHMIPDTypeByID(HMIPDType item);
        IBaseEntityCollectionResponse<HMIPDType> GetIPDTypeList(HMIPDTypeSearchRequest searchRequest);
    }
}
