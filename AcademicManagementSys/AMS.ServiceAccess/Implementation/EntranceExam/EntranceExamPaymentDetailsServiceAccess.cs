using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class EntranceExamPaymentDetailsServiceAccess :IEntranceExamPaymentDetailsServiceAccess
    {
        IEntranceExamPaymentDetailsBA _entranceExamPaymentDetailsBA = null;

        public EntranceExamPaymentDetailsServiceAccess()
        {
            _entranceExamPaymentDetailsBA = new EntranceExamPaymentDetailsBA();
        }

        // EntranceExamPaymentDetails Table Property.
        public IBaseEntityResponse<EntranceExamPaymentDetails> InsertEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            return _entranceExamPaymentDetailsBA.InsertEntranceExamPaymentDetails(item);
        }
        public IBaseEntityResponse<EntranceExamPaymentDetails> UpdateEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            return _entranceExamPaymentDetailsBA.UpdateEntranceExamPaymentDetails(item);
        }
        public IBaseEntityResponse<EntranceExamPaymentDetails> DeleteEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            return _entranceExamPaymentDetailsBA.DeleteEntranceExamPaymentDetails(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsBySearch(EntranceExamPaymentDetailsSearchRequest searchRequest)
        {
            return _entranceExamPaymentDetailsBA.GetEntranceExamPaymentDetailsBySearch(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamPaymentDetails> SelectEntranceExamPaymentDetailsByID(EntranceExamPaymentDetails item)
        {
            return _entranceExamPaymentDetailsBA.SelectEntranceExamPaymentDetailsByID(item);
        }


        //Service Access for Item Name Search List
        public IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsSearchList(EntranceExamPaymentDetailsSearchRequest searchRequest)
        {
            return _entranceExamPaymentDetailsBA.GetEntranceExamPaymentDetailsSearchList(searchRequest);
        }

    }
}
