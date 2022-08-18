using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentIdentityCard : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int StudentId
        {
            get;
            set;
        }
        public string StudentTitle
        {
            get;
            set;
        }
        public string StudentFirstName
        {
            get;
            set;
        }
        public string StudentMiddleName
        {
            get;
            set;
        }
        public string StudentLastName
        {
            get;
            set;
        }
        public string StudentFullName
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public string StudentMobileNumber
        {
            get;
            set;
        }
        public string ParentMobileNumber
        {
            get;
            set;
        }
        public string StudentIdentificationMark
        {
            get;
            set;
        }
        
        public string RollNumber
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public string AcademicYear
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string UniqueIdentificatinNumber
        {
            get;
            set;
        }
        public string AddressType
        {
            get;
            set;
        }
        public string PermanentAddressLine1
        {
            get;
            set;
        }
        public string PermanentAddressLine2
        {
            get;
            set;
        }
        public string CorrespondenceAddressLine1
        {
            get;
            set;
        }
        public string CorrespondenceAddressLine2
        {
            get;
            set;
        }
        public string PlotNumber
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string Bloodgroup
        {
            get;
            set;
        }
       
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
        public string errorMessage
        {
            get;
            set;
        }



        #region File Upload
        public byte[] StudentPhoto
        {
            get;
            set;
        }

        public string StudentPhotoType
        {
            get;
            set;
        }
        public string StudentPhotoFilename
        {
            get;

            set;

        }

        public string StudentPhotoFileWidth
        {
            get;

            set;
        }


        public string StudentPhotoFileHeight
        {
            get;
            set;
        }


        public string StudentPhotoFileSize
        {
            get;
            set;
        }

        // for Signature
        public byte[] StudentSignature
        {
            get;
            set;
        }

        public string StudentSignatureType
        {
            get;
            set;
        }
        public string StudentSignatureFilename
        {
            get;

            set;

        }

        public string StudentSignatureFileWidth
        {
            get;

            set;
        }


        public string StudentSignatureFileHeight
        {
            get;
            set;
        }


        public string StudentSignatureFileSize
        {
            get;
            set;
        }


        #endregion File Upload


        #region Address
     
        # endregion Address
    }
}
