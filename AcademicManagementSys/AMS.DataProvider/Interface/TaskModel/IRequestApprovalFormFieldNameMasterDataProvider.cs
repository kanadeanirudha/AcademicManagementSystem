using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IRequestApprovalFormFieldNameMasterDataProvider
    {
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> InsertRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> UpdateRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> DeleteRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterBySearch(RequestApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterSearchList(RequestApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterByID(RequestApprovalFormFieldNameMaster item);
    }
}
