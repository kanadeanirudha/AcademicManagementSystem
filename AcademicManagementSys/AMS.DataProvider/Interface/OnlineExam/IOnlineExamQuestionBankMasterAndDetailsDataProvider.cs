using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOnlineExamQuestionBankMasterAndDetailsDataProvider
	{
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> UpdateOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> DeleteOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectoneOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetOnlineExamQuestionBankMasterBySearch(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> GetOnlineExamQuestionBankMasterByID(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamExaminationQuestionsList(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetCourseYearDetailsByCentreCode(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetSubjectDetailsByCourseAndSem(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
    }
}
