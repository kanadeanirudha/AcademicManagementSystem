using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentIdentityCardViewModel
    {
        StudentIdentityCard StudentIdentityCardDTO { get; set; }
        int ID
        {
            get;
            set;
        }
         int StudentId
        {
            get;
            set;
        }
         string StudentTitle
        {
            get;
            set;
        }
         string StudentFirstName
        {
            get;
            set;
        }
         string StudentMiddleName
        {
            get;
            set;
        }
         string StudentLastName
        {
            get;
            set;
        }
        string StudentFullName
        {
            get;
            set;
        }
        string StudentCode
        {
            get;
            set;
        }
        string StudentMobileNumber
        {
            get;
            set;
        }
        string ParentMobileNumber
        {
            get;
            set;
        }
        string RollNumber
        {
            get;
            set;
        }
        int BranchID
        {
            get;
            set;
        }
        int UniversityID
        {
            get;
            set;
        }
        int SectionDetailID
        {
            get;
            set;
        }
        string AcademicYear
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string UniqueIdentificatinNumber
        {
            get;
            set;
        }
        string AddressType
        {
            get;
            set;
        }
        string PermanentAddressLine1
        {
            get;
            set;
        }
        string PermanentAddressLine2
        {
            get;
            set;
        }
        string CorrespondenceAddressLine1
        {
            get;
            set;
        }
        string CorrespondenceAddressLine2
        {
            get;
            set;
        }
        
        string PlotNumber
        {
            get;
            set;
        }
        string Street
        {
            get;
            set;
        }
        string DateOfBirth
        {
            get;
            set;
        }
        string Bloodgroup
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
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }


        #region File Upload
        byte[] StudentPhoto
        {
            get;
            set;
        }

        string StudentPhotoType
        {
            get;
            set;
        }
        string StudentPhotoFilename
        {
            get;

            set;

        }

        string StudentPhotoFileWidth
        {
            get;

            set;
        }


        string StudentPhotoFileHeight
        {
            get;
            set;
        }


        string StudentPhotoFileSize
        {
            get;
            set;
        }

        // for Signature
        byte[] StudentSignature
        {
            get;
            set;
        }

        string StudentSignatureType
        {
            get;
            set;
        }
        string StudentSignatureFilename
        {
            get;

            set;

        }

        string StudentSignatureFileWidth
        {
            get;

            set;
        }


        string StudentSignatureFileHeight
        {
            get;
            set;
        }


        string StudentSignatureFileSize
        {
            get;
            set;
        }


        #endregion File Upload
    }
}

