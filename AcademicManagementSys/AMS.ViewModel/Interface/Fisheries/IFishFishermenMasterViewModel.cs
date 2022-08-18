using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFishFishermenMasterViewModel
    {
        FishFishermenMaster FishFishermenMasterDTO { get; set; }

        int ID { get; set; }
        string FishermenCode { get; set; }
        int NameTitleID { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string PostalAddress { get; set; }
        string MobileNumber { get; set; }
        string EmailID { get; set; }
        bool IsLocalMember { get; set; }
        int LocalMemberId { get; set; }
        bool IsFederationMember { get; set; }
        int FederationMemberId { get; set; }
        string Gender { get; set; }
        string BirthDate { get; set; }
        int NationalityID { get; set; }
        string AdharCardNumber { get; set; }        
        string BankName { get; set; }
        string BankNumber { get; set; }
        string CentreCode { get; set; }
        //int DepartmentID { get; set; }
        string JoiningDate { get; set; }
        string DateOfLeaving { get; set; }
        int BioMatrixID { get; set; }
        //bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }
    }
}
