using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IEntranceExamPaymentDetailsBA
    {
        // EntranceExamPaymentDetails Table Property.
        IBaseEntityResponse<EntranceExamPaymentDetails> InsertEntranceExamPaymentDetails(EntranceExamPaymentDetails item);
        IBaseEntityResponse<EntranceExamPaymentDetails> UpdateEntranceExamPaymentDetails(EntranceExamPaymentDetails item);
        IBaseEntityResponse<EntranceExamPaymentDetails> DeleteEntranceExamPaymentDetails(EntranceExamPaymentDetails item);
        IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsBySearch(EntranceExamPaymentDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamPaymentDetails> SelectEntranceExamPaymentDetailsByID(EntranceExamPaymentDetails item);

        //For Serach List Entrance Exam Payment Detail
        IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsSearchList(EntranceExamPaymentDetailsSearchRequest searchRequest);
    }
}
