using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RequestApprovalFormFieldNameMasterServiceAccess: IRequestApprovalFormFieldNameMasterServiceAccess
    {
        IRequestApprovalFormFieldNameMasterBA _RequestApprovalFormFieldNameMasterBA = null;
        public RequestApprovalFormFieldNameMasterServiceAccess()
        {
            _RequestApprovalFormFieldNameMasterBA = new RequestApprovalFormFieldNameMasterBA();
        }
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> InsertRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item)
        {
            return _RequestApprovalFormFieldNameMasterBA.InsertRequestApprovalFormFieldNameMaster(item);
        }
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> UpdateRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item)
        {
            return _RequestApprovalFormFieldNameMasterBA.UpdateRequestApprovalFormFieldNameMaster(item);
        }
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> DeleteRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item)
        {
            return _RequestApprovalFormFieldNameMasterBA.DeleteRequestApprovalFormFieldNameMaster(item);
        }
        public IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetBySearch(RequestApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            return _RequestApprovalFormFieldNameMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterSearchList(RequestApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            return _RequestApprovalFormFieldNameMasterBA.GetRequestApprovalFormFieldNameMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> SelectByID(RequestApprovalFormFieldNameMaster item)
        {
            return _RequestApprovalFormFieldNameMasterBA.SelectByID(item);
        }
    }
}
