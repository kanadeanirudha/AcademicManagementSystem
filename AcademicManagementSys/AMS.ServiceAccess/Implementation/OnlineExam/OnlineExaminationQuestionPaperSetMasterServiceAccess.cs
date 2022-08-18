using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;
namespace AMS.ServiceAccess
{
	public class OnlineExaminationQuestionPaperSetMasterServiceAccess : IOnlineExaminationQuestionPaperSetMasterServiceAccess
	{
		IOnlineExaminationQuestionPaperSetMasterBA _OnlineExaminationQuestionPaperSetMasterBA = null;
		public OnlineExaminationQuestionPaperSetMasterServiceAccess()
		{
			_OnlineExaminationQuestionPaperSetMasterBA = new OnlineExaminationQuestionPaperSetMasterBA();
		}
		public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> InsertOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
		{
			return _OnlineExaminationQuestionPaperSetMasterBA.InsertOnlineExaminationQuestionPaperSetMaster(item);
		}
		public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> UpdateOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
		{
			return _OnlineExaminationQuestionPaperSetMasterBA.UpdateOnlineExaminationQuestionPaperSetMaster(item);
		}
		public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> DeleteOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
		{
			return _OnlineExaminationQuestionPaperSetMasterBA.DeleteOnlineExaminationQuestionPaperSetMaster(item);
		}
		public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetBySearch(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
		{
			return _OnlineExaminationQuestionPaperSetMasterBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterSearchList(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            return _OnlineExaminationQuestionPaperSetMasterBA.GetOnlineExaminationQuestionPaperSetMasterSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterBySpin(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            return _OnlineExaminationQuestionPaperSetMasterBA.GetOnlineExaminationQuestionPaperSetMasterBySpin(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> SelectByID(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
		{
            return _OnlineExaminationQuestionPaperSetMasterBA.SelectByID(searchRequest);
		}
	}
}
