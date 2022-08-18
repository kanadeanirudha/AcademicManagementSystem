using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ToolTemplateRegistration : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
      
        public int ParentID
        {
            get;
            set;
        }
        public int NumberOfColumn
        {
            get;
            set;
        }
        public int SequenceNo
        {
            get;
            set;
        }
        public bool IsActive
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

        public string Data1
        {
            get;
            set;
        }
        public string Data2
        {
            get;
            set;
        }
        public string Data3
        {
            get;
            set;
        }
        public string Data4
        {
            get;
            set;
        }
        public string Data5
        {
            get;
            set;
        }
        public string Data6
        {
            get;
            set;
        }
        public string Data7
        {
            get;
            set;
        }
        public string Data8
        {
            get;
            set;
        }
        public string Data9
        {
            get;
            set;
        }
        public string Data10
        {
            get;
            set;
        }
        public string TemplateName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
