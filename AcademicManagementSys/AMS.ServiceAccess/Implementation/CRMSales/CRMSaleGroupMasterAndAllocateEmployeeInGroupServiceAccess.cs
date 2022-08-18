using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess : ICRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess
    {
        ICRMSaleGroupMasterAndAllocateEmployeeInGroupBA _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA = null;

        public CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess()
        {
            _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA = new CRMSaleGroupMasterAndAllocateEmployeeInGroupBA();
        }

        //CRMSaleGroupMaster
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> InsertCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.InsertCRMSaleGroupMaster(item);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CheckAuthorityToCreateGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.CheckAuthorityToCreateGroup(item);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> UpdateCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.UpdateCRMSaleGroupMaster(item);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> DeleteCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.DeleteCRMSaleGroupMaster(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetBySearchCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.GetBySearchCRMSaleGroupMaster(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetCRMSaleGroupMasterSearchList(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.GetCRMSaleGroupMasterSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> SelectByCRMSaleGroupMasterID(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.SelectByCRMSaleGroupMasterID(item);
        }

        //CRMSaleAllocateEmployeeInGroup

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> InsertCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.InsertCRMSaleAllocateEmployeeInGroup(item);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> UpdateCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.UpdateCRMSaleAllocateEmployeeInGroup(item);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> DeleteCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.DeleteCRMSaleAllocateEmployeeInGroup(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetBySearchCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.GetBySearchCRMSaleAllocateEmployeeInGroup(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetCRMSaleAllocateEmployeeInGroupSearchList(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.GetCRMSaleAllocateEmployeeInGroupSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> SelectByCRMSaleAllocateEmployeeInGroupID(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            return _CRMSaleGroupMasterAndAllocateEmployeeInGroupBA.SelectByCRMSaleAllocateEmployeeInGroupID(item);
        }
    }
}

