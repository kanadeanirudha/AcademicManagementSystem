﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IOnlineExamQuestionBankMasterAndDetailsServiceAccess
	{
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> UpdateOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> DeleteOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
		IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetBySearch(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectByID(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectoneOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);

        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetCourseYearDetailsByCentreCode(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamExaminationQuestionsList(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchReq);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetSubjectDetailsByCourseAndSem(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchReq);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchReq);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item);
    }
}
