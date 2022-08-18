using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOnlineExamAssignpapersetterDataProvider
    {
        IBaseEntityResponse<OnlineExamAssignpapersetter> InsertOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item);
        IBaseEntityResponse<OnlineExamAssignpapersetter> UpdateOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item);
        IBaseEntityResponse<OnlineExamAssignpapersetter> DeleteOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item);
        IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterBySearch(OnlineExamAssignpapersetterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamSupportStaffSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterByID(OnlineExamAssignpapersetter item);
        IBaseEntityResponse<OnlineExamAssignpapersetter> OnlineExamSelectQuestionPaper(OnlineExamAssignpapersetter item);
    }
}
