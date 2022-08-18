
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamExaminationMasterServiceAccess : IOnlineExamExaminationMasterServiceAccess
    {
        IOnlineExamExaminationMasterBA _OnlineExamExaminationMasterBA = null;
        public OnlineExamExaminationMasterServiceAccess()
        {
            _OnlineExamExaminationMasterBA = new OnlineExamExaminationMasterBA();
        }
        public IBaseEntityResponse<OnlineExamExaminationMaster> InsertOnlineExamExaminationMaster(OnlineExamExaminationMaster item)
        {
            return _OnlineExamExaminationMasterBA.InsertOnlineExamExaminationMaster(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationMaster> UpdateOnlineExamExaminationMaster(OnlineExamExaminationMaster item)
        {
            return _OnlineExamExaminationMasterBA.UpdateOnlineExamExaminationMaster(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationMaster> DeleteOnlineExamExaminationMaster(OnlineExamExaminationMaster item)
        {
            return _OnlineExamExaminationMasterBA.DeleteOnlineExamExaminationMaster(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetBySearch(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            return _OnlineExamExaminationMasterBA.GetBySearch(searchRequest);
        }
        //public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetSessionNameList(OnlineExamExaminationMasterSearchRequest searchRequest)
        //{
        //    return _OnlineExamExaminationMasterBA.GetBySearch(searchRequest);
        //}
        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterSearchList(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            return _OnlineExamExaminationMasterBA.GetOnlineExamExaminationMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamExaminationMaster> SelectByID(OnlineExamExaminationMaster item)
        {
            return _OnlineExamExaminationMasterBA.SelectByID(item);
        }
        //For Staff Allocation
        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster>GetExaminationNameList(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            return _OnlineExamExaminationMasterBA.GetExaminationNameList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamGetExaminationListCentreWise(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            return _OnlineExamExaminationMasterBA.OnlineExamGetExaminationListCentreWise(searchRequest);
        }
    }
}
