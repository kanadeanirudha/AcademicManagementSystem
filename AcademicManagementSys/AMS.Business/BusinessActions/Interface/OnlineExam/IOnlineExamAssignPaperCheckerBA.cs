using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOnlineExamAssignPaperCheckerBA
    {
        IBaseEntityResponse<OnlineExamAssignPaperChecker> InsertOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item);
        IBaseEntityResponse<OnlineExamAssignPaperChecker> UpdateOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item);
        IBaseEntityResponse<OnlineExamAssignPaperChecker> DeleteOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item);
        IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetBySearch(OnlineExamAssignPaperCheckerSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetOnlineExamAssignPaperCheckerSearchList(OnlineExamAssignPaperCheckerSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetOnlineExamSupportStaffSearchList(OnlineExamAssignPaperCheckerSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAssignPaperChecker> SelectByID(OnlineExamAssignPaperChecker item);
        IBaseEntityResponse<OnlineExamAssignPaperChecker> OnlineExamSelectQuestionPaper(OnlineExamAssignPaperChecker item);
    }
}

