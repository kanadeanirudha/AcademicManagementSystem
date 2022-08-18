using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamQuestionBankMasterAndDetailsServiceAccess : IOnlineExamQuestionBankMasterAndDetailsServiceAccess
	{
        IOnlineExamQuestionBankMasterAndDetailsBA _onlineExamQuestionBankMasterAndDetailsBA = null;
		public OnlineExamQuestionBankMasterAndDetailsServiceAccess()
		{
            _onlineExamQuestionBankMasterAndDetailsBA = new OnlineExamQuestionBankMasterAndDetailsBA();
		}
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
		{
			return _onlineExamQuestionBankMasterAndDetailsBA.InsertOnlineExamQuestionBankMasterAndDetails(item);
		}
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> UpdateOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
		{
			return _onlineExamQuestionBankMasterAndDetailsBA.UpdateOnlineExamQuestionBankMasterAndDetails(item);
		}
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> DeleteOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
		{
			return _onlineExamQuestionBankMasterAndDetailsBA.DeleteOnlineExamQuestionBankMasterAndDetails(item);
		}
		public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetBySearch(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
		{
			return _onlineExamQuestionBankMasterAndDetailsBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectByID(OnlineExamQuestionBankMasterAndDetails item)
		{
			return _onlineExamQuestionBankMasterAndDetailsBA.SelectByID(item);
		}
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectoneOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
        {
            return _onlineExamQuestionBankMasterAndDetailsBA.SelectoneOnlineExamQuestionBankMasterAndDetails(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetCourseYearDetailsByCentreCode(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
		{
            return _onlineExamQuestionBankMasterAndDetailsBA.GetCourseYearDetailsByCentreCode(searchRequest);
		}
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetSubjectDetailsByCourseAndSem(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            return _onlineExamQuestionBankMasterAndDetailsBA.GetSubjectDetailsByCourseAndSem(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            return _onlineExamQuestionBankMasterAndDetailsBA.GetListQuestionBankMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamExaminationQuestionsList(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            return _onlineExamQuestionBankMasterAndDetailsBA.OnlineExamExaminationQuestionsList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item)
        {
            return _onlineExamQuestionBankMasterAndDetailsBA.InsertOnlineExamQuestionBankMaster(item);
        }
	}
}

