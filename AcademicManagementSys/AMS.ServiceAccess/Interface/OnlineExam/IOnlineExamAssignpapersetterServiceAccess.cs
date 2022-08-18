
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamAssignpapersetterServiceAccess
    {
        IBaseEntityResponse<OnlineExamAssignpapersetter> InsertOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item);
        IBaseEntityResponse<OnlineExamAssignpapersetter> UpdateOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item);
        IBaseEntityResponse<OnlineExamAssignpapersetter> DeleteOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item);
        IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetBySearch(OnlineExamAssignpapersetterSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAssignpapersetter> SelectByID(OnlineExamAssignpapersetter item);
        IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamSupportStaffSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAssignpapersetter> OnlineExamSelectQuestionPaper(OnlineExamAssignpapersetter item);
    }
}
