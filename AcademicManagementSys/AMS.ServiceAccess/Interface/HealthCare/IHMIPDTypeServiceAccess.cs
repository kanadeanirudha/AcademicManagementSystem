using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMIPDTypeServiceAccess
    {
        IBaseEntityResponse<HMIPDType> InsertHMIPDType(HMIPDType item);
        IBaseEntityResponse<HMIPDType> UpdateHMIPDType(HMIPDType item);
        IBaseEntityResponse<HMIPDType> DeleteHMIPDType(HMIPDType item);
        IBaseEntityCollectionResponse<HMIPDType> GetBySearch(HMIPDTypeSearchRequest searchRequest);
        IBaseEntityResponse<HMIPDType> SelectByID(HMIPDType item);
        IBaseEntityCollectionResponse<HMIPDType> GetHMIPDTypeSearchList(HMIPDTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMIPDType> GetIPDTypeList(HMIPDTypeSearchRequest searchRequest);
    }
}
