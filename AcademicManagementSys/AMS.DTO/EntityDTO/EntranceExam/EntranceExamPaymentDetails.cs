using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EntranceExamPaymentDetails : BaseDTO
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

        //Extra Property
        public string StudentName { get; set; }
        public int EntranceExamPaymenDetailsID { get; set; }        
        public string EntranceExamPaymentDetailsSearchWord { get; set; }
        //public string Paymentby { get; set; }
        public string PaymentModeValue { get; set; }
        

        //Common Property.
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
