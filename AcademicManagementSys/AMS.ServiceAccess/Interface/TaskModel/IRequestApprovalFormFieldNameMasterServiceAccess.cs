using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IRequestApprovalFormFieldNameMasterServiceAccess
    {
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> InsertRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> UpdateRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> DeleteRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetBySearch(RequestApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> SelectByID(RequestApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterSearchList(RequestApprovalFormFieldNameMasterSearchRequest searchRequest);
    }
}
