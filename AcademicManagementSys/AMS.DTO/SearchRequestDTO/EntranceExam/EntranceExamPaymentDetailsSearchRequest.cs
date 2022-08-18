using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class EntranceExamPaymentDetailsSearchRequest : Request
    {
        //----------------------------------Properties of EntranceExamPaymentDetails table--------------------------------

        public int ID { get; set; }
        public int EntranceExamValidationParameterApplicableID { get; set; }
        public int StudentRegistrationID { get; set; }
        public decimal PaymentAmount { get; set; }
        public int PaymentMode { get; set; }
        public int PaymentThrough { get; set; }
        public string ChalanNo { get; set; }
        public string ChalanDate { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public byte[] AttachFile { get; set; }
        public string PaymentID { get; set; }
        public bool Status { get; set; }

        //Common Property.
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }

        //Extra Property.
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string EntranceExamPaymentDetailsSearchWord { get; set; }

    }
}
