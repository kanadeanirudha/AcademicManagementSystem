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
    public class CRMCallEnquiryDetailsCallForwardController : BaseController
    {
        ICRMCallEnquiryDetailsServiceAccess _CRMCallEnquiryDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMCallEnquiryDetailsCallForwardController()
        {
            _CRMCallEnquiryDetailsServiceAcess = new CRMCallEnquiryDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string CallerJobStatus, string CallStatus, string actionMode)
        {
            
            CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
           // li.Add(new SelectListItem { Text = "--Select Job Status--", Value = " " });
          //  li.Add(new SelectListItem { Text = "Completed", Value = "1" });
            li.Add(new SelectListItem { Text = "Pending", Value = "3" });
            li.Add(new SelectListItem { Text = "In progress", Value = "2" });
            
            ViewData["CallerJobStatus"] = li;
            //ViewData["CallerJobStatus"] = new SelectList(li, model.CRMCallEnquiryDetailsDTO.CallerJobStatus);

           // List<SelectListItem> li1 = new List<SelectListItem>();
           //// li1.Add(new SelectListItem { Text = "--Select Call Status--", Value = " " });
           // li1.Add(new SelectListItem { Text = "CallBack", Value = "2" });
           // li1.Add(new SelectListItem { Text = "Failed", Value = "3" });
           // ViewData["CallStatus"] = li1;
           // ViewData["CallerJobStatus"] = new SelectList(li, model.CRMCallEnquiryDetailsDTO.CallStatus);

           
            model.CRMCallEnquiryDetailsDTO.CallerJobStatus = Convert.ToInt16(CallerJobStatus);
            model.CRMCallEnquiryDetailsDTO.CallStatus = Convert.ToInt16(CallStatus);
           
            if (model.CRMCallEnquiryDetailsDTO.CallerJobStatus > 0)
            {

                List<CRMCallEnquiryDetailsViewModel> listCRMCallEnquiryDetailsViewModel = new List<CRMCallEnquiryDetailsViewModel>();
                CRMCallEnquiryDetailsSearchRequest searchRequest = new CRMCallEnquiryDetailsSearchRequest();
                searchRequest.CallerJobStatus = Convert.ToInt16(CallerJobStatus);
                searchRequest.CallStatus = Convert.ToInt16(CallStatus);
                //CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                List<CRMCallEnquiryDetails> listCRMCallEnquiryDetails = new List<CRMCallEnquiryDetails>();
                IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollectionResponse = _CRMCallEnquiryDetailsServiceAcess.GetBySearchCallForward(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    listCRMCallEnquiryDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.CRMCallEnquiryDetailsList = listCRMCallEnquiryDetails;
                    foreach (CRMCallEnquiryDetails item in listCRMCallEnquiryDetails)
                    {
                        CRMCallEnquiryDetailsViewModel CRMCallEnquiryDetailsViewModel = new CRMCallEnquiryDetailsViewModel();
                        CRMCallEnquiryDetailsViewModel.CRMCallEnquiryDetailsDTO = item;
                        listCRMCallEnquiryDetailsViewModel.Add(CRMCallEnquiryDetailsViewModel);
                    }
                }
                model.CRMCallEnquiryDetailsList = listCRMCallEnquiryDetails;
            }
            if (!string.IsNullOrEmpty(actionMode))
            {
                TempData["ActionMode"] = actionMode;
            }   
            return View("/Views/CRM/CRMCallEnquiryDetailsCallForward/Index.cshtml",model);
        }

        [HttpGet]
        public ActionResult List(string CallerJobStatus, string CallStatus,string actionMode)
        {
            try
            {
                CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
                model.CRMCallEnquiryDetailsDTO.CallerJobStatus = Convert.ToInt16(CallerJobStatus);
                model.CRMCallEnquiryDetailsDTO.CallStatus = Convert.ToInt16(CallStatus);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                if (model.CRMCallEnquiryDetailsDTO.CallerJobStatus > 0)
                {

                    List<CRMCallEnquiryDetailsViewModel> listCRMCallEnquiryDetailsViewModel = new List<CRMCallEnquiryDetailsViewModel>();
                    CRMCallEnquiryDetailsSearchRequest searchRequest = new CRMCallEnquiryDetailsSearchRequest();
                    searchRequest.CallerJobStatus = Convert.ToInt16(CallerJobStatus);
                    searchRequest.CallStatus = Convert.ToInt16(CallStatus);
                    //CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
                    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                    List<CRMCallEnquiryDetails> listCRMCallEnquiryDetails = new List<CRMCallEnquiryDetails>();
                    IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollectionResponse = _CRMCallEnquiryDetailsServiceAcess.GetBySearchCallForward(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        listCRMCallEnquiryDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                        model.CRMCallEnquiryDetailsList = listCRMCallEnquiryDetails;
                        foreach (CRMCallEnquiryDetails item in listCRMCallEnquiryDetails)
                        {
                            CRMCallEnquiryDetailsViewModel CRMCallEnquiryDetailsViewModel = new CRMCallEnquiryDetailsViewModel();
                            CRMCallEnquiryDetailsViewModel.CRMCallEnquiryDetailsDTO = item;
                            listCRMCallEnquiryDetailsViewModel.Add(CRMCallEnquiryDetailsViewModel);
                        }
                    }
                    model.CRMCallEnquiryDetailsList = listCRMCallEnquiryDetails;
                }
                return PartialView("/Views/CRM/CRMCallEnquiryDetailsCallForward/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        [HttpPost]
        public ActionResult List(CRMCallEnquiryDetailsViewModel model)
        {
            try
            {
                if (model != null && model.CRMCallEnquiryDetailsDTO != null)
                {
                    model.CRMCallEnquiryDetailsDTO.ConnectionString = _connectioString;
                    model.CRMCallEnquiryDetailsDTO.CallStatus = model.CallStatus;
                    model.CRMCallEnquiryDetailsDTO.CallerJobStatus = model.CallerJobStatus;
                    model.CRMCallEnquiryDetailsDTO.XMLstring = model.XMLstring;
                    model.CRMCallEnquiryDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMCallEnquiryDetails> response = _CRMCallEnquiryDetailsServiceAcess.InsertCRMCallEnquiryDetailsCallForward(model.CRMCallEnquiryDetailsDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);                   
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
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

      

        // Non-Action Method
        #region Methods
        public IEnumerable<CRMCallEnquiryDetailsViewModel> GetCRMCallEnquiryDetails(out int TotalRecords)
        {
            CRMCallEnquiryDetailsSearchRequest searchRequest = new CRMCallEnquiryDetailsSearchRequest();
            CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<CRMCallEnquiryDetailsViewModel> listCRMCallEnquiryDetailsViewModel = new List<CRMCallEnquiryDetailsViewModel>();
            List<CRMCallEnquiryDetails> listCRMCallEnquiryDetails = new List<CRMCallEnquiryDetails>();
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollectionResponse = _CRMCallEnquiryDetailsServiceAcess.GetBySearchCallForward(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMCallEnquiryDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.CRMCallEnquiryDetailsList = listCRMCallEnquiryDetails;
                    foreach (CRMCallEnquiryDetails item in listCRMCallEnquiryDetails)
                    {
                        CRMCallEnquiryDetailsViewModel CRMCallEnquiryDetailsViewModel = new CRMCallEnquiryDetailsViewModel();
                        CRMCallEnquiryDetailsViewModel.CRMCallEnquiryDetailsDTO = item;
                        listCRMCallEnquiryDetailsViewModel.Add(CRMCallEnquiryDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            
            return listCRMCallEnquiryDetailsViewModel;

           
        }
        [HttpPost]
        public JsonResult GetEmployees(string term)
        {
            //var AdminRoleMasterID = Session["RoleID"].ToString();
            var data = GetEmployeeList(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName,
                              roleId = r.AdminRoleMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMCallEnquiryDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "CalleeFirstName Like '%" + param.sSearch + "%' or CalleeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "CalleeFirstName like '%'";
                        }
                        else
                        {
                            _searchBy = "CalleeFirstName Like '%" + param.sSearch + "%' or CalleeFirstName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetCRMCallEnquiryDetails(out TotalRecords);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<CRMCallEnquiryDetailsViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CallForwardTo), (c.CalleeFirstName.ToString() + " " + c.CalleeMiddelName.ToString() + " " + c.CalleeLastName.ToString()), Convert.ToString(c.Status), Convert.ToString(c.CalleeMobileNo), Convert.ToString(c.CalleeEmailID), Convert.ToString(c.ID) };

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