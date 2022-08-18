using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
     public interface IEntranceExamPaymentDetailsServiceAccess
    {
        // EntranceExamPaymentDetails Table Property.
         IBaseEntityResponse<EntranceExamPaymentDetails> InsertEntranceExamPaymentDetails(EntranceExamPaymentDetails item);
         IBaseEntityResponse<EntranceExamPaymentDetails> UpdateEntranceExamPaymentDetails(EntranceExamPaymentDetails item);
         IBaseEntityResponse<EntranceExamPaymentDetails> DeleteEntranceExamPaymentDetails(EntranceExamPaymentDetails item);
         IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsBySearch(EntranceExamPaymentDetailsSearchRequest searchRequest);
         IBaseEntityResponse<EntranceExamPaymentDetails> SelectEntranceExamPaymentDetailsByID(EntranceExamPaymentDetails item);

        //Search List.
         IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsSearchList(EntranceExamPaymentDetailsSearchRequest searchRequest);
    }
}
