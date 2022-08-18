using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamAssignPaperCheckerServiceAccess : IOnlineExamAssignPaperCheckerServiceAccess
    {
        IOnlineExamAssignPaperCheckerBA _OnlineExamAssignPaperCheckerBA = null;
        public OnlineExamAssignPaperCheckerServiceAccess()
        {
            _OnlineExamAssignPaperCheckerBA = new OnlineExamAssignPaperCheckerBA();
        }
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> InsertOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item)
        {
            return _OnlineExamAssignPaperCheckerBA.InsertOnlineExamAssignPaperChecker(item);
        }
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> UpdateOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item)
        {
            return _OnlineExamAssignPaperCheckerBA.UpdateOnlineExamAssignPaperChecker(item);
        }
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> DeleteOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item)
        {
            return _OnlineExamAssignPaperCheckerBA.DeleteOnlineExamAssignPaperChecker(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetBySearch(OnlineExamAssignPaperCheckerSearchRequest searchRequest)
        {
            return _OnlineExamAssignPaperCheckerBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetOnlineExamAssignPaperCheckerSearchList(OnlineExamAssignPaperCheckerSearchRequest searchRequest)
        {
            return _OnlineExamAssignPaperCheckerBA.GetOnlineExamAssignPaperCheckerSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetOnlineExamSupportStaffSearchList(OnlineExamAssignPaperCheckerSearchRequest searchRequest)
        {
            return _OnlineExamAssignPaperCheckerBA.GetOnlineExamSupportStaffSearchList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> SelectByID(OnlineExamAssignPaperChecker item)
        {
            return _OnlineExamAssignPaperCheckerBA.SelectByID(item);
        }
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> OnlineExamSelectQuestionPaper(OnlineExamAssignPaperChecker item)
        {
            return _OnlineExamAssignPaperCheckerBA.OnlineExamSelectQuestionPaper(item);
        }
    }
}
