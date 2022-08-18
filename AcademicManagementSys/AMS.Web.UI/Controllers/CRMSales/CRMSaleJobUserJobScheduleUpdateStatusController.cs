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
using System.IO;
using System.Net;
using System.Text;
using System.Data;

namespace AMS.Web.UI.Controllers
{
    public class CRMSaleJobUserJobScheduleUpdateStatusController : BaseController
    {
        ICRMSaleJobUserJobScheduleSheetServiceAccess _CRMSaleJobUserJobScheduleSheetServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleJobUserJobScheduleUpdateStatusController()
        {
            _CRMSaleJobUserJobScheduleSheetServiceAcess = new CRMSaleJobUserJobScheduleSheetServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Index.cshtml");
        }
        [HttpPost]
        public ActionResult List(string TransactionDate, string actionMode, Int16 MeetingStatus =0)
        {
            try
            {
                CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();

                ////~~~~~~~~~~~Caller Job status ~~~~~~~~~~~~~~~~~~~~~~~~         
                List<SelectListItem> UserMeetingStatus = new List<SelectListItem>();
                ViewBag.UserMeetingStatus = new SelectList(UserMeetingStatus, "Value", "Text");
                List<SelectListItem> UserMeetingStatus_li = new List<SelectListItem>();
                UserMeetingStatus_li.Add(new SelectListItem { Text = "All", Value = "0" });
                UserMeetingStatus_li.Add(new SelectListItem { Text = "Completed", Value = "1" });
                UserMeetingStatus_li.Add(new SelectListItem { Text = "Cancel", Value = "2" });
                UserMeetingStatus_li.Add(new SelectListItem { Text = "Pending", Value = "3" });
                UserMeetingStatus_li.Add(new SelectListItem { Text = "ReSchedule", Value = "4" });
                model.MeetingStatus = MeetingStatus;
                model.TransactionDate = TransactionDate;

                ViewData["MeetingStatus"] = new SelectList(UserMeetingStatus_li, "Value", "Text", model.MeetingStatus);

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                
                return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }



        public ActionResult Create()
        {
            CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();
            return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMSaleJobUserJobScheduleSheetViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (model != null && model.CRMSaleJobUserJobScheduleSheetDTO != null)
                {
                    model.CRMSaleJobUserJobScheduleSheetDTO.ConnectionString = _connectioString;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountMasterID = model.CRMSaleEnquiryAccountMasterID;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountContactPersonID = model.CRMSaleEnquiryAccountContactPersonID;

                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquiryMasterLatitude = model.EnquiryMasterLatitude;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquiryMasterLongitude = model.EnquiryMasterLongitude;

                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquiryAccountType = model.EnquiryAccountType;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquirySource = model.EnquirySource;

                    //model.CRMSaleJobUserJobScheduleSheetDTO.GenServiceRequiredID = model.GenServiceRequiredID;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.ExpectedBillingAmount = model.ExpectedBillingAmount;

                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquiryDesription = model.EnquiryDesription;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquiryMasterAddress = model.EnquiryMasterAddress;
                    //model.CRMSaleJobUserJobScheduleSheetDTO.EnquiryMasterCity = model.EnquiryMasterCity;

                    model.CRMSaleJobUserJobScheduleSheetDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.CRMSaleJobUserJobScheduleSheetDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                    IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = _CRMSaleJobUserJobScheduleSheetServiceAcess.UpdateCRMSaleJobUserJobScheduleSheetUpdate(model.CRMSaleJobUserJobScheduleSheetDTO);
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult CompleteMeeting(string StatusDetail)
        {

            CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();
            string[] StatusDetails = StatusDetail.Split('~');
            model.ID = Convert.ToInt64(StatusDetails[0]);
            model.ScheduleType = Convert.ToInt16(StatusDetails[1]);
            model.TransactionDate = StatusDetails[2];
            model.ScheduleDescription = StatusDetails[3];
            model.FromTime = StatusDetails[4].Replace('`', ':');
            model.UpToTime = StatusDetails[5].Replace('`', ':');
            model.JobCreationAllocationID = Convert.ToInt64(StatusDetails[7]);
            model.CRMSaleCallMasterID = Convert.ToInt64(StatusDetails[8]);
            model.CallEnquiryMasterID = Convert.ToInt64(StatusDetails[9]);
            //model.ActionName = StatusDetails[10];

            model.SubScheduleType = Convert.ToInt16(StatusDetails[6]);

            if (Convert.ToInt16(StatusDetails[1]) == 1)     //Meeting(schedule type)
            {
                if (Convert.ToInt16(StatusDetails[6]) != 4)     //Subschedule Type(! followUp)
                {
                  if(StatusDetails[10] == "Done")
                  {
                      // for Interestlevel
                      List<SelectListItem> Interestlevel = new List<SelectListItem>();
                      ViewBag.Interestlevel = new SelectList(Interestlevel, "Value", "Text");
                      List<SelectListItem> li_Interestlevel = new List<SelectListItem>();
                      li_Interestlevel.Add(new SelectListItem { Text = "--Select Interest Level--", Value = "0" });
                      li_Interestlevel.Add(new SelectListItem { Text = "Cold", Value = "1" });
                      li_Interestlevel.Add(new SelectListItem { Text = "Neutral", Value = "2" });
                      li_Interestlevel.Add(new SelectListItem { Text = "Warm", Value = "3" });
                      li_Interestlevel.Add(new SelectListItem { Text = "Not interested", Value = "4" });
                      ViewData["Interestlevel"] = li_Interestlevel;

                      //For Call Status
                      List<SelectListItem> CallStatus = new List<SelectListItem>();
                      ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
                      List<SelectListItem> li_CallStatus = new List<SelectListItem>();
                      li_CallStatus.Add(new SelectListItem { Text = "--Select Call Status--", Value = "0" });
                      li_CallStatus.Add(new SelectListItem { Text = "In Progress", Value = "2" });
                      li_CallStatus.Add(new SelectListItem { Text = "Failed", Value = "3" });

                      ViewData["CallStatus"] = li_CallStatus;

                      return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Done/MeetingWithDone.cshtml", model);
                  }
                  else if(StatusDetails[10] == "Reschedule")
                  {
                      return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/ReSchedule/MeetingWithReSchedule.cshtml", model);
                  }
                  else if (StatusDetails[10] == "Cancel")
                  {
                      return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Cancel/MeetingWithCancel.cshtml", model);
                  }              
                }
                else if (Convert.ToInt16(StatusDetails[6]) == 4)       //Follow Up
                {
                    if(StatusDetails[10] == "Done")
                    {
                        // for Follow Up
                        List<SelectListItem> FollowUpType = new List<SelectListItem>();
                        ViewBag.FollowUpType = new SelectList(FollowUpType, "Value", "Text");
                        List<SelectListItem> li_FollowUpType = new List<SelectListItem>();
                        li_FollowUpType.Add(new SelectListItem { Text = "--Select Follow Up Type--", Value = "" });
                        li_FollowUpType.Add(new SelectListItem { Text = "Email", Value = "Email" });
                        li_FollowUpType.Add(new SelectListItem { Text = "Call", Value = "Call" });
                        ViewData["FollowUpType"] = li_FollowUpType;

                        //For Call Status
                        List<SelectListItem> CallStatus = new List<SelectListItem>();
                        ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
                        List<SelectListItem> li_CallStatus = new List<SelectListItem>();
                        li_CallStatus.Add(new SelectListItem { Text = "--Select Status--", Value = "0" });
                        li_CallStatus.Add(new SelectListItem { Text = "In Progress", Value = "2" });
                        li_CallStatus.Add(new SelectListItem { Text = "Failed", Value = "3" });

                        ViewData["CallStatus"] = li_CallStatus;

                        // for Interestlevel
                        List<SelectListItem> Interestlevel = new List<SelectListItem>();
                        ViewBag.Interestlevel = new SelectList(Interestlevel, "Value", "Text");
                        List<SelectListItem> li_Interestlevel = new List<SelectListItem>();
                        li_Interestlevel.Add(new SelectListItem { Text = "--Select Interest Level--", Value = "0" });
                        li_Interestlevel.Add(new SelectListItem { Text = "Cold", Value = "1" });
                        li_Interestlevel.Add(new SelectListItem { Text = "Neutral", Value = "2" });
                        li_Interestlevel.Add(new SelectListItem { Text = "Warm", Value = "3" });
                        li_Interestlevel.Add(new SelectListItem { Text = "Not interested", Value = "4" });
                        ViewData["Interestlevel"] = li_Interestlevel;

                        return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Done/FollowUpWithDone.cshtml", model);
                    }
                    else if(StatusDetails[10] == "Reschedule")
                    {
                        return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/ReSchedule/FollowUpWithReSchedule.cshtml", model);
                    }
                    else if (StatusDetails[10] == "Cancel")
                    {
                        return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Cancel/FollowUpWithCancel.cshtml", model);
                    }
                }
            }
            else if (Convert.ToInt16(StatusDetails[1]) == 2)        //Servey
            {
                if (StatusDetails[10] == "Done")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Done/ServeyWithDone.cshtml", model);
                }
                else if (StatusDetails[10] == "Reschedule")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/ReSchedule/ServeyWithReSchedule.cshtml", model);
                }
                else if (StatusDetails[10] == "Cancel")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Cancel/ServeyWithCancel.cshtml", model);
                }
            }
            else if (Convert.ToInt16(StatusDetails[1]) == 3)         //Other
            {
                if (StatusDetails[10] == "Done")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Done/OtherWithDone.cshtml", model);
                }
                else if (StatusDetails[10] == "Reschedule")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/ReSchedule/OtherWithReSchedule.cshtml", model);
                }
                else if (StatusDetails[10] == "Cancel")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Cancel/OtherWithCancel.cshtml", model);
                }
            }
            else if (Convert.ToInt16(StatusDetails[1]) == 4)         //Call
            {
                if (StatusDetails[10] == "Done")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Done/CallWithDone.cshtml", model);
                }
                else if (StatusDetails[10] == "Reschedule")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/ReSchedule/CallWithReSchedule.cshtml", model);
                }
                else if (StatusDetails[10] == "Cancel")
                {
                    return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Cancel/CallWithCancel.cshtml", model);
                }
            }
                return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleUpdateStatus/Error.cshtml", model);           
        }

        [HttpPost]
        public ActionResult CompleteMeeting(CRMSaleJobUserJobScheduleSheetViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleJobUserJobScheduleSheetDTO != null)
                {
                    model.CRMSaleJobUserJobScheduleSheetDTO.ConnectionString = _connectioString;
                                        
                    model.CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID = model.JobCreationAllocationID;
                    model.CRMSaleJobUserJobScheduleSheetDTO.CallEnquiryMasterID = model.CallEnquiryMasterID;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ID = model.ID;
                    model.CRMSaleJobUserJobScheduleSheetDTO.CRMSaleCallMasterID = model.CRMSaleCallMasterID;

                    model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleStatus = model.ScheduleStatus;
                    model.CRMSaleJobUserJobScheduleSheetDTO.Remark = model.Remark ;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleType = model.ScheduleType;
                    model.CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType = model.SubScheduleType;

                    model.CRMSaleJobUserJobScheduleSheetDTO.ServeyDate = model.ServeyDate;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ServeyTime = model.ServeyTime;
                    model.CRMSaleJobUserJobScheduleSheetDTO.NextDate = model.NextDate;
                    model.CRMSaleJobUserJobScheduleSheetDTO.NextFromTime = model.NextFromTime;
                    model.CRMSaleJobUserJobScheduleSheetDTO.NextUpToTime = model.NextUpToTime;

                    model.CRMSaleJobUserJobScheduleSheetDTO.CallStatus = model.CallStatus;                  
                    model.CRMSaleJobUserJobScheduleSheetDTO.Interestlevel = model.Interestlevel;
                    model.CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus = model.CallerJobStatus;
                    model.CRMSaleJobUserJobScheduleSheetDTO.FromAddress = model.FromAddress;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ToAddress = model.ToAddress;

                    model.CRMSaleJobUserJobScheduleSheetDTO.VisitingCardName = model.VisitingCardName;
                    model.CRMSaleJobUserJobScheduleSheetDTO.TransactionDate = model.TransactionDate;
                    model.CRMSaleJobUserJobScheduleSheetDTO.FollowUpType = model.FollowUpType;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ContactPerson = model.ToMail;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ToSubject = model.ToSubject;

                    model.CRMSaleJobUserJobScheduleSheetDTO.Description = model.Description;


                    model.CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = _CRMSaleJobUserJobScheduleSheetServiceAcess.UpdateCRMSaleJobUserJobScheduleSheetUpdate(model.CRMSaleJobUserJobScheduleSheetDTO);
                    model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        //[HttpPost]
        //public ActionResult CompleteMeetingWithReschedule(CRMSaleJobUserJobScheduleSheetViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.CRMSaleJobUserJobScheduleSheetDTO != null)
        //        {
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ConnectionString = _connectioString;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID = model.JobCreationAllocationID;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallEnquiryMasterID = model.CallEnquiryMasterID;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ID = model.ID;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CRMSaleCallMasterID = model.CRMSaleCallMasterID;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleStatus = model.ScheduleStatus;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.Remark = model.Remark;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.VisitedLat = 0;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.VisitedLang = 0;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleType = model.ScheduleType;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType = model.SubScheduleType;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.NextDate = model.NextDate;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.NextFromTime = model.NextFromTime;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.NextUpToTime = model.NextUpToTime;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallStatus = model.CallStatus;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallJobStatus = 0;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.Interestlevel = model.Interestlevel;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus = model.CallerJobStatus;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.FromAddress = model.FromAddress;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ToAddress = model.ToAddress;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.VisitingCardName = model.VisitingCardName;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.TransactionDate = model.TransactionDate;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.FollowUpType = model.FollowUpType;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ContactPerson = string.Empty;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ToSubject = model.ToSubject;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.Description = model.Description;


        //            model.CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = _CRMSaleJobUserJobScheduleSheetServiceAcess.UpdateCRMSaleJobUserJobScheduleSheetUpdate(model.CRMSaleJobUserJobScheduleSheetDTO);
        //            model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}


        //[HttpPost]
        //public ActionResult CompleteMeetingWithCancel(CRMSaleJobUserJobScheduleSheetViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.CRMSaleJobUserJobScheduleSheetDTO != null)
        //        {
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ConnectionString = _connectioString;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID = model.JobCreationAllocationID;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallEnquiryMasterID = model.CallEnquiryMasterID;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ID = model.ID;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CRMSaleCallMasterID = model.CRMSaleCallMasterID;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleStatus = model.ScheduleStatus;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.Remark = model.Remark;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.VisitedLat = 0;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.VisitedLang = 0;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleType = model.ScheduleType;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType = model.SubScheduleType;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.NextDate = model.NextDate;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.NextFromTime = model.NextFromTime;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.NextUpToTime = model.NextUpToTime;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallStatus = model.CallStatus;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallJobStatus = 0;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.Interestlevel = model.Interestlevel;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus = model.CallerJobStatus;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.FromAddress = model.FromAddress;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ToAddress = model.ToAddress;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.VisitingCardName = model.VisitingCardName;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.TransactionDate = model.TransactionDate;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.FollowUpType = model.FollowUpType;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ContactPerson = string.Empty;
        //            model.CRMSaleJobUserJobScheduleSheetDTO.ToSubject = model.ToSubject;

        //            model.CRMSaleJobUserJobScheduleSheetDTO.Description = model.Description;


        //            model.CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = _CRMSaleJobUserJobScheduleSheetServiceAcess.UpdateCRMSaleJobUserJobScheduleSheetUpdate(model.CRMSaleJobUserJobScheduleSheetDTO);
        //            model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        public ActionResult Delete(string ID)
        {
            var errorMessage = string.Empty;
            CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();
            if (Convert.ToInt64(ID) > 0)
            {

                IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = null;
                CRMSaleJobUserJobScheduleSheet CRMSaleJobUserJobScheduleSheetDTO = new CRMSaleJobUserJobScheduleSheet();
                CRMSaleJobUserJobScheduleSheetDTO.ConnectionString = _connectioString;
                //CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryMasterID = Convert.ToInt64(ID);
                CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleJobUserJobScheduleSheetServiceAcess.DeleteCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheetDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods


        public IEnumerable<CRMSaleJobUserJobScheduleSheetViewModel> GetCRMSaleJobUserJobScheduleUpdateStatus(string TransactionDate, Int16 MeetingStatus, out int TotalRecords)
        {
            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.TransactionDate = TransactionDate;
                    searchRequest.MeetingStatus = MeetingStatus;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.TransactionDate = TransactionDate;
                    searchRequest.MeetingStatus = MeetingStatus;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.TransactionDate = TransactionDate;
                searchRequest.MeetingStatus = MeetingStatus;
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            }
            List<CRMSaleJobUserJobScheduleSheetViewModel> listCRMSaleJobUserJobScheduleUpdateStatusViewModel = new List<CRMSaleJobUserJobScheduleSheetViewModel>();
            List<CRMSaleJobUserJobScheduleSheet> listCRMSaleJobUserJobScheduleUpdateStatus = new List<CRMSaleJobUserJobScheduleSheet>();
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = _CRMSaleJobUserJobScheduleSheetServiceAcess.GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleJobUserJobScheduleUpdateStatus = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleJobUserJobScheduleSheet item in listCRMSaleJobUserJobScheduleUpdateStatus)
                    {
                        CRMSaleJobUserJobScheduleSheetViewModel CRMSaleJobUserJobScheduleUpdateStatusViewModel = new CRMSaleJobUserJobScheduleSheetViewModel();
                        CRMSaleJobUserJobScheduleUpdateStatusViewModel.CRMSaleJobUserJobScheduleSheetDTO = item;
                        listCRMSaleJobUserJobScheduleUpdateStatusViewModel.Add(CRMSaleJobUserJobScheduleUpdateStatusViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMSaleJobUserJobScheduleUpdateStatusViewModel;
        }


        //For Visitng Card.
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\CRMSale\\VisitingCard\\";
                    _imgname = "option_" + _imgname + _ext;

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    pic.SaveAs(_comPath + "\\" + Path.GetFileName(_imgname));

                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    MemoryStream ms = new MemoryStream();
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }



        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(string TransactionDate, Int16 MeetingStatus, JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleJobUserJobScheduleSheetViewModel> filteredCRMSaleJobUserJobScheduleUpdateStatus;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TransactionDate";
                        sortDirection = "Desc";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.CallerJobStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality SubScheduleType
                        }
                        break;                    
                    case 1:
                        _sortBy = "YEAR(A.TransactionDate) " + sortDirection + ",MONTH(A.TransactionDate) " + sortDirection + ",DAY(A.TransactionDate) " + sortDirection + ", A.ScheduleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.CallerJobStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality SubScheduleType
                        }
                        break;
                    case 2:
                        _sortBy = "A.FromTime";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.CallerJobStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality SubScheduleType
                        }
                        break;

                    case 3:
                        _sortBy = "A.ScheduleType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.CallerJobStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality SubScheduleType
                        }
                        break;

                    case 4:
                        _sortBy = "A.SubScheduleType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.CallerJobStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality SubScheduleType
                        }
                        break;
                    case 5:
                        _sortBy = "A.CallerJobStatus";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.CallerJobStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality SubScheduleType
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                filteredCRMSaleJobUserJobScheduleUpdateStatus = GetCRMSaleJobUserJobScheduleUpdateStatus(TransactionDate, Convert.ToInt16(MeetingStatus), out TotalRecords);

                var records = filteredCRMSaleJobUserJobScheduleUpdateStatus.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { 
                                                            Convert.ToString(c.TransactionDate), 
                                                            Convert.ToString(c.ScheduleDescription), 
                                                            Convert.ToString(String.Concat(c.FromTime, '-', c.UpToTime)), 
                                                            Convert.ToString(c.ScheduleType), 
                                                            Convert.ToString(c.CallerJobStatus), 
                                                            Convert.ToString(c.ID), 
                                                            Convert.ToString(c.FromTime), Convert.ToString(c.UpToTime), 
                                                            Convert.ToString(c.SubScheduleType),
                                                            Convert.ToString(c.JobCreationAllocationID),
                                                            Convert.ToString(c.CRMSaleCallMasterID),
                                                            Convert.ToString(c.CallEnquiryMasterID),
                                                            Convert.ToString(c.UpdateStatus),
                                                            Convert.ToString(c.IsInvitation) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}














