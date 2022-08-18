using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;
namespace AMS.ViewModel
{
    public class EntranceExamViewModel : IEntranceExamViewModel
    {
       public EntranceExamViewModel()
        {
            EntranceExamDTO = new EntranceExam();
        }
       public EntranceExam EntranceExamDTO
       {
           get;
           set;
       }
       //----------------------------------Properties of EntranceExamIndStudentExamInfo  table--------------------------------
       public int ID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.ID > 0) ? EntranceExamDTO.ID : new int();
           }
           set
           {
               EntranceExamDTO.ID = value;
           }
       }
       public int StudentRegistrationID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.StudentRegistrationID > 0) ? EntranceExamDTO.StudentRegistrationID : new int();
           }
           set
           {
               EntranceExamDTO.StudentRegistrationID = value;
           }
       }
       public int EntranceExamApplicableExamToCourseID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.EntranceExamApplicableExamToCourseID > 0) ? EntranceExamDTO.EntranceExamApplicableExamToCourseID : new int();
           }
           set
           {
               EntranceExamDTO.EntranceExamApplicableExamToCourseID = value;
           }
       }
       public string CourseYearCode
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.CourseYearCode : string.Empty;
           }
           set
           {
               EntranceExamDTO.CourseYearCode = value;
           }
       }
       public Int16 AttendanceFlag
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.AttendanceFlag > 0) ? EntranceExamDTO.AttendanceFlag : new Int16();
           }
           set
           {
               EntranceExamDTO.AttendanceFlag = value;
           }
       }
       public string AttendLogInTime
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.AttendLogInTime : string.Empty;
           }
           set
           {
               EntranceExamDTO.AttendLogInTime = value;
           }
       }
       public string ExaminationDate
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.ExaminationDate : string.Empty;
           }
           set
           {
               EntranceExamDTO.ExaminationDate = value;
           }
       }
       public string ExaminationStartTime
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.ExaminationStartTime : string.Empty;
           }
           set
           {
               EntranceExamDTO.ExaminationStartTime = value;
           }
       }
       public string ExaminationEndTime
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.ExaminationEndTime : string.Empty;
           }
           set
           {
               EntranceExamDTO.ExaminationEndTime = value;
           }
       }
       public Boolean IsExaminationOver
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.IsExaminationOver : false;
           }
           set
           {
               EntranceExamDTO.IsExaminationOver = value;
           }
       }
       public string SessionName
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.SessionName : string.Empty;
           }
           set
           {
               EntranceExamDTO.SessionName = value;
           }
       }
       public Boolean LoginStatus
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.LoginStatus : false;
           }
           set
           {
               EntranceExamDTO.LoginStatus = value;
           }
       }
       public Boolean IsLock
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.IsLock : false;
           }
           set
           {
               EntranceExamDTO.IsLock = value;
           }
       }
       public int OnlineExaminationPaperID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.StudentRegistrationID > 0) ? EntranceExamDTO.OnlineExaminationPaperID : new int();
           }
           set
           {
               EntranceExamDTO.OnlineExaminationPaperID = value;
           }
       }
       public string IPAddress
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.IPAddress : string.Empty;
           }
           set
           {
               EntranceExamDTO.IPAddress = value;
           }
       }

       //----------------------------------Properties of EntranceExamIndQuestionPaper  table--------------------------------   
       public int EntranceExamIndQuestionPaperID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.EntranceExamIndQuestionPaperID > 0) ? EntranceExamDTO.EntranceExamIndQuestionPaperID : new int();
           }
           set
           {
               EntranceExamDTO.EntranceExamIndQuestionPaperID = value;
           }
       }
       public int OnlineExaminationMasterID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.OnlineExaminationMasterID > 0) ? EntranceExamDTO.OnlineExaminationMasterID : new int();
           }
           set
           {
               EntranceExamDTO.OnlineExaminationMasterID = value;
           }
       }
       public int SubjectID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.SubjectID > 0) ? EntranceExamDTO.SubjectID : new int();
           }
           set
           {
               EntranceExamDTO.SubjectID = value;
           }
       }
       public Int16 GenQuestionTypeID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.GenQuestionTypeID > 0) ? EntranceExamDTO.GenQuestionTypeID : new Int16();
           }
           set
           {
               EntranceExamDTO.GenQuestionTypeID = value;
           }
       }
       public int OnlineExamQuestionBankMasterID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.OnlineExamQuestionBankMasterID > 0) ? EntranceExamDTO.OnlineExamQuestionBankMasterID : new int();
           }
           set
           {
               EntranceExamDTO.OnlineExamQuestionBankMasterID = value;
           }
       }
       public string QuestionLableText
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.QuestionLableText : string.Empty;
           }
           set
           {
               EntranceExamDTO.QuestionLableText = value;
           }
       }
       public string ImageType
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.ImageType : string.Empty;
           }
           set
           {
               EntranceExamDTO.ImageType = value;
           }
       }
       public string ImageName
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.ImageName : string.Empty;
           }
           set
           {
               EntranceExamDTO.ImageName = value;
           }
       }
       public Boolean IsQuestionInImage
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.IsQuestionInImage : false;
           }
           set
           {
               EntranceExamDTO.IsQuestionInImage = value;
           }
       }
       public int AnswerOptionID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.AnswerOptionID > 0) ? EntranceExamDTO.AnswerOptionID : new int();
           }
           set
           {
               EntranceExamDTO.AnswerOptionID = value;
           }
       }
       public int CorrectOptionID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.CorrectOptionID > 0) ? EntranceExamDTO.CorrectOptionID : new int();
           }
           set
           {
               EntranceExamDTO.CorrectOptionID = value;
           }
       }
       public Boolean IsAnswerCorrect
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.IsAnswerCorrect : false;
           }
           set
           {
               EntranceExamDTO.IsAnswerCorrect = value;
           }
       }
       public decimal MarkObtained
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.AnswerOptionID > 0) ? EntranceExamDTO.MarkObtained : new decimal();
           }
           set
           {
               EntranceExamDTO.MarkObtained = value;
           }
       }
       public Int16 CurrentStatus
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.CurrentStatus > 0) ? EntranceExamDTO.CurrentStatus : new Int16();
           }
           set
           {
               EntranceExamDTO.CurrentStatus = value;
           }
       }

       //----------------------------------Properties of EntranceExamIndQuestionPaperDetails  table--------------------------------        
       public int EntranceExamIndQuestionPaperDetailsID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.EntranceExamIndQuestionPaperDetailsID > 0) ? EntranceExamDTO.EntranceExamIndQuestionPaperDetailsID : new int();
           }
           set
           {
               EntranceExamDTO.EntranceExamIndQuestionPaperDetailsID = value;
           }
       }
       public int OnlineExamQuestionBankDetailsID
       {
           get
           {
               return (EntranceExamDTO != null && EntranceExamDTO.OnlineExamQuestionBankDetailsID > 0) ? EntranceExamDTO.OnlineExamQuestionBankDetailsID : new int();
           }
           set
           {
               EntranceExamDTO.OnlineExamQuestionBankDetailsID = value;
           }
       }
       public string OptionText
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.OptionText : string.Empty;
           }
           set
           {
               EntranceExamDTO.OptionText = value;
           }
       }
       public string OptionImage
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.OptionImage : string.Empty;
           }
           set
           {
               EntranceExamDTO.OptionImage = value;
           }
       }
       public Boolean IsAnswer
       {
           get
           {
               return (EntranceExamDTO != null) ? EntranceExamDTO.IsAnswer : false;
           }
           set
           {
               EntranceExamDTO.IsAnswer = value;
           }
       }
    }
}
