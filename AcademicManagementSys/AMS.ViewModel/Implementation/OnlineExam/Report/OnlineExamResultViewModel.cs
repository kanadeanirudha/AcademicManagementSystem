using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamResultViewModel
    {
        public OnlineExamResultViewModel()
        {
            OnlineExamResultDTO = new OnlineExamResult();
            ListOnlineExamResult = new List<OnlineExamResult>();
            ListAllVendor = new List<OnlineExamResult>();

        }


        public List<OnlineExamResult> ListOnlineExamResult { get; set; }
        public List<OnlineExamResult> ListAllVendor { get; set; }

        public OnlineExamResult OnlineExamResultDTO { get; set; }

        [Display(Name = "SelectedVendorID")]
        public string SelectedVendorID { get; set; }

        public IEnumerable<SelectListItem> VendorNameListItem
        {
            get
            {
                return new SelectList(ListAllVendor, "VendorID", "VendorName");
            }
        }



        public Int16 ID
        {
            get
            {
                return (OnlineExamResultDTO != null && OnlineExamResultDTO.ID > 0) ? OnlineExamResultDTO.ID : new Int16();
            }
            set
            {
                OnlineExamResultDTO.ID = value;
            }
        }


        public Int16 CorrectAnswer
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.CorrectAnswer : new Int16();
            }
            set
            {
                OnlineExamResultDTO.CorrectAnswer = value;
            }
        }


        public Int16 IncorrectAnswer
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.IncorrectAnswer : new Int16();
            }
            set
            {
                OnlineExamResultDTO.IncorrectAnswer = value;
            }
        }

        public int OnlineExamIndStudentExamInfoID
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.OnlineExamIndStudentExamInfoID : new int();
            }
            set
            {
                OnlineExamResultDTO.OnlineExamIndStudentExamInfoID = value;
            }
        }
        public Int16 NotAnswered
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.NotAnswered : new Int16();
            }
            set
            {
                OnlineExamResultDTO.NotAnswered = value;
            }
        }
        public string ExamName
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.ExamName : string.Empty;
            }
            set
            {
                OnlineExamResultDTO.ExamName = value;
            }
        }

        public string SubjectName
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.SubjectName : string.Empty;
            }
            set
            {
                OnlineExamResultDTO.SubjectName = value;
            }
        }
        public string ExamDate
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.ExamDate : string.Empty;
            }
            set
            {
                OnlineExamResultDTO.ExamDate = value;
            }
        }
        public byte TotalMarks
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.TotalMarks : new byte();
            }
            set
            {
                OnlineExamResultDTO.TotalMarks = value;
            }
        }
        public byte TotalQuestions
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.TotalQuestions : new byte();
            }
            set
            {
                OnlineExamResultDTO.TotalQuestions = value;
            }
        }
        public byte ExamDuration
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.ExamDuration : new byte();
            }
            set
            {
                OnlineExamResultDTO.ExamDuration = value;
            }
        }


        public decimal CorrectMarks
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.CorrectMarks : new decimal();
            }
            set
            {
                OnlineExamResultDTO.CorrectMarks = value;
            }
        }

        public decimal NegativeMarks
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.NegativeMarks : new decimal();
            }
            set
            {
                OnlineExamResultDTO.NegativeMarks = value;
            }
        }

        public decimal TotalMarksObtained
        {
            get
            {
                return (OnlineExamResultDTO != null) ? OnlineExamResultDTO.TotalMarksObtained : new decimal();
            }
            set
            {
                OnlineExamResultDTO.TotalMarksObtained = value;
            }
        }
    }

}

