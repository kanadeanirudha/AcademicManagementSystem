using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using AMS.Common;
using AMS.DataProvider;
using System.Configuration;

namespace AMS.Web.UI.Controllers
{
    public class EntranceExamPaymentDetailsController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IEntranceExamPaymentDetailsServiceAccess _entranceExamPaymentDetailsServiceAccess;
        private readonly ILogger _logException;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EntranceExamPaymentDetailsController()
        {
            _entranceExamPaymentDetailsServiceAccess = new EntranceExamPaymentDetailsServiceAccess();
        }

        #endregion


        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            EntranceExamPaymentDetailsViewModel model = new EntranceExamPaymentDetailsViewModel();

            model.EntranceExamPaymentDetailsDTO = new EntranceExamPaymentDetails();            
            model.EntranceExamPaymentDetailsDTO.StudentRegistrationID = Convert.ToInt32(Session["UserID"]);
            model.EntranceExamPaymentDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EntranceExamPaymentDetails> response = _entranceExamPaymentDetailsServiceAccess.SelectEntranceExamPaymentDetailsByID(model.EntranceExamPaymentDetailsDTO);
            if (response.Entity != null)
            {
                model.EntranceExamPaymentDetailsDTO.ID = response.Entity.ID;
                model.EntranceExamPaymentDetailsDTO.StudentName = response.Entity.StudentName;
                model.EntranceExamPaymentDetailsDTO.PaymentAmount = response.Entity.PaymentAmount;
                model.EntranceExamPaymentDetailsDTO.Status = response.Entity.Status;
                model.EntranceExamPaymentDetailsDTO.EntranceExamValidationParameterApplicableID = response.Entity.EntranceExamValidationParameterApplicableID;
                model.EntranceExamPaymentDetailsDTO.EntranceExamPaymenDetailsID = response.Entity.EntranceExamPaymenDetailsID;
                model.EntranceExamPaymentDetailsDTO.StudentRegistrationID = response.Entity.StudentRegistrationID;
            }

            return View("/Views/EntranceExam/EntranceExamPaymentDetails/Index.cshtml", model);
        }


        public ActionResult SavePaymentDetails(EntranceExamPaymentDetailsViewModel model)
        {
            try
            {
                if(model.EntranceExamPaymentDetailsDTO != null)
                {
                    model.EntranceExamPaymentDetailsDTO.ConnectionString = _connectioString;

                    model.EntranceExamPaymentDetailsDTO.StudentRegistrationID = model.StudentRegistrationID;
                    model.EntranceExamPaymentDetailsDTO.EntranceExamValidationParameterApplicableID = model.EntranceExamValidationParameterApplicableID;
                    model.EntranceExamPaymentDetailsDTO.PaymentAmount = model.PaymentAmount;

                    int data = model.PaymentModeValue == "Online" ? 0 : 1;
                    if (data > 0)
                    {
                        model.EntranceExamPaymentDetailsDTO.ChalanNo = model.ChalanNo;
                        model.EntranceExamPaymentDetailsDTO.ChalanDate = model.ChalanDate;
                        model.EntranceExamPaymentDetailsDTO.BankName = model.BankName;
                        model.EntranceExamPaymentDetailsDTO.BankAddress = model.BankAddress;
                        model.EntranceExamPaymentDetailsDTO.PaymentMode = model.PaymentModeValue == "Online" ? 0 : 1;
                        model.EntranceExamPaymentDetailsDTO.PaymentThrough = 4;
                        model.EntranceExamPaymentDetailsDTO.PaymentID = null;

                        if (model.AttachPaymentDetailFile.FileName != null)
                        {                            
                            HttpPostedFileBase file =model.AttachPaymentDetailFile;
                            model.EntranceExamPaymentDetailsDTO.AttachFile = ConvertToBytes(file); 
                        }                        
                    }
                    else
                    {
                        model.EntranceExamPaymentDetailsDTO.PaymentID = null;
                        model.EntranceExamPaymentDetailsDTO.PaymentMode = model.PaymentModeValue == "Online" ? 0 :1 ;
                        model.EntranceExamPaymentDetailsDTO.PaymentThrough = model.PaymentThrough;
                    }
                    model.EntranceExamPaymentDetailsDTO.Status = model.Status;
                    model.EntranceExamPaymentDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<EntranceExamPaymentDetails> response = _entranceExamPaymentDetailsServiceAccess.InsertEntranceExamPaymentDetails(model.EntranceExamPaymentDetailsDTO);
                    model.EntranceExamPaymentDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    
                    return RedirectToAction("Index", "EntranceExamPaymentDetails");
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion       
    }
}
