using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMCallTypeServiceAccess
    {
        IBaseEntityResponse<CRMCallType> InsertCRMCallType(CRMCallType item);
        IBaseEntityResponse<CRMCallType> UpdateCRMCallType(CRMCallType item);
        IBaseEntityResponse<CRMCallType> DeleteCRMCallType(CRMCallType item);
        IBaseEntityCollectionResponse<CRMCallType> GetBySearch(CRMCallTypeSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallType> SelectByID(CRMCallType item);
        IBaseEntityCollectionResponse<CRMCallType> GetCRMCallTypeList(CRMCallTypeSearchRequest searchRequest);
    }
}
