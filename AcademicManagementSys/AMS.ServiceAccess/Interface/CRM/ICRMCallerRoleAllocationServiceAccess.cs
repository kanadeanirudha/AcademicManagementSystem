using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMCallerRoleAllocationServiceAccess
    {
        IBaseEntityResponse<CRMCallerRoleAllocation> InsertCRMCallerRoleAllocation(CRMCallerRoleAllocation item);
        IBaseEntityResponse<CRMCallerRoleAllocation> UpdateCRMCallerRoleAllocation(CRMCallerRoleAllocation item);
        IBaseEntityResponse<CRMCallerRoleAllocation> DeleteCRMCallerRoleAllocation(CRMCallerRoleAllocation item);
        IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetBySearch(CRMCallerRoleAllocationSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallerRoleAllocation> SelectByID(CRMCallerRoleAllocation item);
        IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetCRMCallerRoleAllocationList(CRMCallerRoleAllocationSearchRequest searchRequest);
    }
}
