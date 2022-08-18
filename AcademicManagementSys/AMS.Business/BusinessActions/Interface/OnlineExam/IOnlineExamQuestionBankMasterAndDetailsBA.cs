﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOnlineExamQuestionBankMasterAndDetailsBA
	{
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> UpdateOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> DeleteOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);
		IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetBySearch(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
		IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectByID(OnlineExamQuestionBankMasterAndDetails item);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectoneOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item);

        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetCourseYearDetailsByCentreCode(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamExaminationQuestionsList(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetSubjectDetailsByCourseAndSem(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item);
    }
}
