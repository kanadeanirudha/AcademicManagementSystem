using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEntranceExamPaymentDetailsViewModel
    {
        EntranceExamPaymentDetails EntranceExamPaymentDetailsDTO { get; set; }

        //----------------------------------Properties of EntranceExamPaymentDetails table--------------------------------

        int ID { get; set; }
        int EntranceExamValidationParameterApplicableID { get; set; }
        int StudentRegistrationID { get; set; }
        decimal PaymentAmount { get; set; }
        int PaymentMode { get; set; }
        int PaymentThrough { get; set; }
        string ChalanNo { get; set; }
        string ChalanDate { get; set; }
        string BankName { get; set; }
        string BankAddress { get; set; }
        byte[] AttachFile { get; set; }
        string PaymentID { get; set; }
        bool Status { get; set; }

        //Extra Property
        string StudentName { get; set; }
        string EntranceExamPaymentDetailsSearchWord { get; set; }

        //Common Property.
        bool? IsDeleted { get; set; }
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
           
    }
}
