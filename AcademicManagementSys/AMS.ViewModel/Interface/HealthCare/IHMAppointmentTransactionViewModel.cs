using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IHMAppointmentTransactionViewModel
    {
        HMAppointmentTransaction HMAppointmentTransactionDTO
        {
            get;
            set;
        }

       Int64 ID
        {
            get;
            set;
        }
       string TransactionDate
        {
            get;
            set;
        }
       Int64 GeneralPatientMasterId
       {
           get;
           set;
       }
       bool IsNewPatient
       { get; 
         set;
       }
       string Symtomp
       { 
           get; 
           set;
       }
       string PatientName
       {
           get;
           set;
       }
       string CaseHistoryNumber

       {   get;
           set;
       }
        Int32 ConsultantID
        { get;
          set;
        }
        string NextAppointmentDate
        { get;
          set;
        }
        byte Status
        { get; 
          set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string CentreName
        {
            get;
            set;
        }
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        string EntityLevel
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
      
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }

        List<HMOPDHealthCentre> ListOfOPDNameMaster { get; set; }
        string SelectedCentreCode { get; set; }
        string SelectedHMOPDHealthCentreID { get; set; }
        Int16 HMOPDHealthCentreID
       {
           get;
           set;
       }
    }
}
