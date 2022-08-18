using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class CRMJobCreationMasterAndAllocationServiceAccess : ICRMJobCreationMasterAndAllocationServiceAccess
    {
        ICRMJobCreationMasterAndAllocationBA _cRMJobCreationMasterAndAllocationBA = null;
        public CRMJobCreationMasterAndAllocationServiceAccess()
        {
            _cRMJobCreationMasterAndAllocationBA = new CRMJobCreationMasterAndAllocationBA();
        }
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> InsertCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            return _cRMJobCreationMasterAndAllocationBA.InsertCRMJobCreationMasterAndAllocation(item);
        }
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> UpdateCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            return _cRMJobCreationMasterAndAllocationBA.UpdateCRMJobCreationMasterAndAllocation(item);
        }
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> DeleteCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            return _cRMJobCreationMasterAndAllocationBA.DeleteCRMJobCreationMasterAndAllocation(item);
        }
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetBySearch(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            return _cRMJobCreationMasterAndAllocationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SelectByID(CRMJobCreationMasterAndAllocation item)
        {
            return _cRMJobCreationMasterAndAllocationBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetByCRMJobListByEmployeeID(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            return _cRMJobCreationMasterAndAllocationBA.GetByCRMJobListByEmployeeID(searchRequest);
        }
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SearchForDuplicateJobName(CRMJobCreationMasterAndAllocation item)
        {
            return _cRMJobCreationMasterAndAllocationBA.SearchForDuplicateJobName(item);
        }
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobAllocationList(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            return _cRMJobCreationMasterAndAllocationBA.CRMJobAllocationList(searchRequest);
        }
        
    }
}
