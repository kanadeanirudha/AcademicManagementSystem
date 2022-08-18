using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ICRMJobCreationMasterAndAllocationServiceAccess
    {
        IBaseEntityResponse<CRMJobCreationMasterAndAllocation> InsertCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item);
        IBaseEntityResponse<CRMJobCreationMasterAndAllocation> UpdateCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item);
        IBaseEntityResponse<CRMJobCreationMasterAndAllocation> DeleteCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item);
        IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetBySearch(CRMJobCreationMasterAndAllocationSearchRequest searchRequest);
        IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SelectByID(CRMJobCreationMasterAndAllocation item);
        IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetByCRMJobListByEmployeeID(CRMJobCreationMasterAndAllocationSearchRequest searchRequest);
        IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SearchForDuplicateJobName(CRMJobCreationMasterAndAllocation item);
        IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobAllocationList(CRMJobCreationMasterAndAllocationSearchRequest searchRequest);
    }
}
