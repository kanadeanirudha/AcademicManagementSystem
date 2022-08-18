using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IScholarShipAllocationViewModel
    {
        ScholarShipAllocation ScholarShipAllocationDTO { get; set; }
        //-------------------Properties of table ScholarShipAllocation -----------------------------------
        int ID
        {
            get;
            set;
        }
        int StudentID
        {
            get;
            set;
        }
        int ScholarShipMasterID
        {
            get;
            set;
        }
        string TransDate
        {
            get;
            set;
        }
        string ScholarSheepDocumentNumber
        {
            get;
            set;
        }
        bool IsApproved
        {
            get;
            set;
        }
        int ApporvedBy
        {
            get;
            set;
        }
        string ApproveStatus
        {
            get;
            set;
        }
        int LastSectionDetailID
        {
            get;
            set;
        }
        bool IsActive
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
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }

        //-------------------Properties of table ScholarShipTransactionDetails  -----------------------------------
        int StudentAmissionDetailID
        {
            get;
            set;
        }
        int ScholarShipAllocationID
        {
            get;
            set;
        }
        int SectionDetailId
        {
            get;
            set;
        }
        decimal Amount
        {
            get;
            set;
        }
        int AcadCenterwiseSessionId
        {
            get;
            set;
        }
        string StandarNumber
        {
            get;
            set;
        }

        //--------------------------------------Extra properties-------------------------------------------------------
        string StudentName
        {
            get;
            set;
        }
        string SectionDetailDescription
        {
            get;
            set;
        }
        string errorMessage { get; set; }
        string SelectedBalanceSheet { get; set; }
        int SelectedBalanceSheetID { get; set; }
        int TaskNotificationDetailsID { get; set; }
        int TaskNotificationMasterID { get; set; }
        int GeneralTaskReportingDetailsID { get; set; }
        string TaskCode { get; set; }
        int StageSequenceNumber { get; set; }
        bool IsLastRecord { get; set; }
        string CentreName { get; set; }
        string CentreCode { get; set; }
        string XMLstring { get; set; }

    }
}
