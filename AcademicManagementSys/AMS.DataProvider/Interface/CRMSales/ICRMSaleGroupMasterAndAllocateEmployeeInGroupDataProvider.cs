using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ICRMSaleGroupMasterAndAllocateEmployeeInGroupDataProvider
    {
        //CRMSaleGroupMaster
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> InsertCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CheckAuthorityToCreateGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> UpdateCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> DeleteCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetBySearchCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> SelectByCRMSaleGroupMasterID(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetCRMSaleGroupMasterSearchList(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest);

        //CRMSaleAllocateEmployeeInGroup
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> InsertCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> UpdateCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> DeleteCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetBySearchCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> SelectByCRMSaleAllocateEmployeeInGroupID(CRMSaleGroupMasterAndAllocateEmployeeInGroup item);
        IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetCRMSaleAllocateEmployeeInGroupSearchList(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest);
    }
}
