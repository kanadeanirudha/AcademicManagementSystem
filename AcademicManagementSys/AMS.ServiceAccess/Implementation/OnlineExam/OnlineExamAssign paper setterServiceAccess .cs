using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamAssignpapersetterServiceAccess : IOnlineExamAssignpapersetterServiceAccess
    {
        IOnlineExamAssignpapersetterBA  _OnlineExamAssignpapersetterBA = null;
        public OnlineExamAssignpapersetterServiceAccess()
        {
            _OnlineExamAssignpapersetterBA = new OnlineExamAssignpapersetterBA();
        }
        public IBaseEntityResponse<OnlineExamAssignpapersetter> InsertOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            return _OnlineExamAssignpapersetterBA.InsertOnlineExamAssignpapersetter(item);
        }
        public IBaseEntityResponse<OnlineExamAssignpapersetter> UpdateOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            return _OnlineExamAssignpapersetterBA.UpdateOnlineExamAssignpapersetter(item);
        }
        public IBaseEntityResponse<OnlineExamAssignpapersetter> DeleteOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            return _OnlineExamAssignpapersetterBA.DeleteOnlineExamAssignpapersetter(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetBySearch(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            return _OnlineExamAssignpapersetterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            return _OnlineExamAssignpapersetterBA.GetOnlineExamAssignpapersetterSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamSupportStaffSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            return _OnlineExamAssignpapersetterBA.GetOnlineExamSupportStaffSearchList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamAssignpapersetter> SelectByID(OnlineExamAssignpapersetter item)
        {
            return _OnlineExamAssignpapersetterBA.SelectByID(item);
        }
        public IBaseEntityResponse<OnlineExamAssignpapersetter> OnlineExamSelectQuestionPaper(OnlineExamAssignpapersetter item)
        {
            return _OnlineExamAssignpapersetterBA.OnlineExamSelectQuestionPaper(item);
        }
    }
}
