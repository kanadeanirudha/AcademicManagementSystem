using System;
using System.Collections.Generic;
using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IHMIPDTypeBA
    {
        IBaseEntityResponse<HMIPDType> InsertHMIPDType(HMIPDType item);
        IBaseEntityResponse<HMIPDType> UpdateHMIPDType(HMIPDType item);
        IBaseEntityResponse<HMIPDType> DeleteHMIPDType(HMIPDType item);
        IBaseEntityCollectionResponse<HMIPDType> GetBySearch(HMIPDTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMIPDType> GetHMIPDTypeSearchList(HMIPDTypeSearchRequest searchRequest);
        IBaseEntityResponse<HMIPDType> SelectByID(HMIPDType item);
        IBaseEntityCollectionResponse<HMIPDType> GetIPDTypeList(HMIPDTypeSearchRequest searchRequest);
    }
}

