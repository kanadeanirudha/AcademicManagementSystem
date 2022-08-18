using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMCallMasterAndDetails : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public Int64 CallMasterID
        {
            get;
            set;
        }
        public int JobID
        {
            get;
            set;
        }
        public string JobName
        {
            get;
            set;
        }
        public int CallerID
        {
            get;
            set;
        }
        public string MenuLink
        {
            get;
            set;
        }
        public Int16 CallerJobStatus
        {
            get;
            set;
        }
        public Int64 JobAllocationID
        {
            get;
            set;
        }

        public string CenterCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int BranchDetailID
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public int AdmissionPattern
        {
            get;
            set;
        }
        //Call Type New Admission
        #region
        public string CalleeTitle
        {
            get;
            set;
        }
        public string CalleeFullName
        {
            get;
            set;
        }
        public string CalleeFirstName
        {
            get;
            set;
        }
        public string CalleeMiddelName
        {
            get;
            set;
        }
        public string CalleeLastName
        {
            get;
            set;
        }
        public string CalleeMobileNo
        {
            get;
            set;
        }
        public string CalleeEmailID
        {
            get;
            set;
        }
        public string CalleeGender
        {
            get;
            set;
        }
        public int CalleeLocationID
        {
            get;
            set;
        }
        public string CalleeLocation
        {
            get;
            set;
        }
        public string CalleeQualification
        {
            get;
            set;
        }
        public int CalleeNationalityID
        {
            get;
            set;
        }
        public string CalleeNationality
        {
            get;
            set;
        }
        public string CalleeOccupation
        {
            get;
            set;
        }
        public string CalleeDesignation
        {
            get;
            set;
        }
        public string CalleeDepartment
        {
            get;
            set;
        }
        public string CalleeExperience
        {
            get;
            set;
        }
        
        public string EnglishFluency
        {
            get;
            set;
        }
        public string Source
        {
            get;
            set;
        }
        #endregion

        //Call Details
        #region
        public string CallerRemark
        {
            get;
            set;
        }
        public Int16 CallStatus
        {
            get;
            set;
        }
     
        public int CallEnquiryDetailID
        {
            get;
            set;
        }
        public string NextCallDate
        {
            get;
            set;
        }
        public string CallDate
        {
            get;
            set;
        }
        public string CalleeInterestedProgram
        {
            get;
            set;
        }
        public Int16 Interestlevel
        {
            get;
            set;
        }
        public Int16 ConcernArea
        {
            get;
            set;
        }
        public string OtherConcernArea
        {
            get;
            set;
        }
        public string CallAnswerXML
        {
            get;
            set;
        }
        public Int16 SelectedJobCallerStatus
        {
            get;
            set;
        }
        
        #endregion

        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public Int16 CallTimeID
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public string CallerFullName
        {
            get;
            set;
        }
        public int TotalCallCount
        {
            get;
            set;
        }
        public int PendingCount
        {
            get;
            set;
        }
        public int InprogressCount
        {
            get;
            set;
        }
        public int CompletedCount
        {
            get;
            set;
        }
        public int ConvertedCount
        {
            get;
            set;
        }
        public double ConvertedCallPercentage
        {
            get;
            set;
        }
        public string TimeSlot
        {
            get;
            set;
        }
         public int CountSource
        {
            get;
            set;
        }
         public string UniversityName
         {
             get;
             set;
         }
         public string BranchShortCode
         {
             get;
             set;
         }
         public string BranchDescription
         {
             get;
             set;
         }
    }
}

