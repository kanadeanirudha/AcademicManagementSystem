
using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class OnlineExaminationHallTicketController : BaseController
    {
        IOnlineExaminationHallTicketServiceAccess _OnlineExaminationHallTicketServiceAcess = null;
        
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
       

        protected static string StudentFullName= string.Empty;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OnlineExaminationHallTicketController()
        {
            _OnlineExaminationHallTicketServiceAcess = new OnlineExaminationHallTicketServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
           
            OnlineExaminationHallTicketViewModel model = new OnlineExaminationHallTicketViewModel();
            try
            {
                model.OnlineExaminationHallTicketDTO = new OnlineExaminationHallTicket();
              //  model.OnlineExaminationHallTicketDTO.StudentRegistrationID = id;
                model.OnlineExaminationHallTicketDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OnlineExaminationHallTicket> response = _OnlineExaminationHallTicketServiceAcess.SelectByID(model.OnlineExaminationHallTicketDTO);
                if (response != null && response.Entity != null)
                {
                    model.OnlineExaminationHallTicketDTO.RollNumber = response.Entity.RollNumber;
                    model.OnlineExaminationHallTicketDTO.StudentFullName = response.Entity.StudentFullName;
                    model.OnlineExaminationHallTicketDTO.Gender = response.Entity.Gender;
                    model.OnlineExaminationHallTicketDTO.RegistrationNumber = response.Entity.RegistrationNumber;
                    model.OnlineExaminationHallTicketDTO.ExamTime = response.Entity.ExamTime;
                    model.OnlineExaminationHallTicketDTO.ExamDate = response.Entity.ExamDate;
                    model.OnlineExaminationHallTicketDTO.Venue = response.Entity.Venue;
                    model.OnlineExaminationHallTicketDTO.Venue1 = response.Entity.Venue1;
                    model.OnlineExaminationHallTicketDTO.StudentPhoto = response.Entity.StudentPhoto;
                    model.OnlineExaminationHallTicketDTO.StudentPhotoFileSize = response.Entity.StudentPhotoFileSize;
                    model.OnlineExaminationHallTicketDTO.StudentSignature = response.Entity.StudentSignature;
                    model.OnlineExaminationHallTicketDTO.StudentSignatureFileSize = response.Entity.StudentSignatureFileSize;
                    model.OnlineExaminationHallTicketDTO.ExaminationName = response.Entity.ExaminationName;

                    model.OnlineExaminationHallTicketDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return View("/Views/OnlineExam/OnlineExaminationHallTicket/Index.cshtml",model);
            }
            catch (Exception)
            {
                throw;
            }







        }

        #endregion
    }
}
