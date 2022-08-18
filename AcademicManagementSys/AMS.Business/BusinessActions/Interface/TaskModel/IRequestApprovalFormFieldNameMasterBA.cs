using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IRequestApprovalFormFieldNameMasterBA
    {
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> InsertRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> UpdateRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> DeleteRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item);
        IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetBySearch(RequestApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterSearchList(RequestApprovalFormFieldNameMasterSearchRequest searchRequest);
        IBaseEntityResponse<RequestApprovalFormFieldNameMaster> SelectByID(RequestApprovalFormFieldNameMaster item);
    }
}

