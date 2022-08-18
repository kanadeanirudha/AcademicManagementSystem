

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class CRMCallEnquiryDetailsMannualModeController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        ICRMCallEnquiryDetailsServiceAccess _CRMCallEnquiryDetailsServiceAccess = null;
        IAccountSessionMasterServiceAccess _accountSessionMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CRMCallEnquiryDetailsMannualModeController()
        {
            _CRMCallEnquiryDetailsServiceAccess = new CRMCallEnquiryDetailsServiceAccess();
           
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
           
                List<SelectListItem> source = new List<SelectListItem>();
                ViewBag.source = new SelectList(source, "Value", "Text");
                List<SelectListItem> li_source = new List<SelectListItem>();
                li_source.Add(new SelectListItem { Text = "----Select Source------", Value = "" });
                li_source.Add(new SelectListItem { Text = "Laimoon", Value = "Laimoon" });
                li_source.Add(new SelectListItem { Text = "Social Media", Value = "Social Media" });
                li_source.Add(new SelectListItem { Text = "Website", Value = "Website" });
                li_source.Add(new SelectListItem { Text = "Event", Value = "Event" });
                    ViewData["source"] = li_source;

                    List<CRMCallType> CallTypeList = GetListCallType();
                    List<SelectListItem> callTypelist = new List<SelectListItem>();
                    foreach (CRMCallType item in CallTypeList)
                    {
                        callTypelist.Add(new SelectListItem { Text = item.CallTypeDescription, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.CallTypeDescription = new SelectList(callTypelist, "Value", "Text");

                    return View("/Views/CRM/CRMCallEnquiryDetailsMannualMode/Index.cshtml");
            }

          
        

        public ActionResult List(string selectedBalsheet, string actionMode)
        {
            try
            {
                CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();

                   

                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/CRM/CRMCallEnquiryDetailsMannualMode/List.cshtml", model);
               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
    

        public ActionResult Create(CRMCallEnquiryDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.CRMCallEnquiryDetailsDTO != null)
                {
                    model.CRMCallEnquiryDetailsDTO.ConnectionString = _connectioString;
                    model.CRMCallEnquiryDetailsDTO.XMLstring = model.XMLstring;
                    model.CRMCallEnquiryDetailsDTO.CallTypeID = model.CallTypeID;
                    model.CRMCallEnquiryDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMCallEnquiryDetails> response = _CRMCallEnquiryDetailsServiceAccess.InsertCRMCallEnquiryDetails(model.CRMCallEnquiryDetailsDTO);
                    model.CRMCallEnquiryDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    model.CRMCallEnquiryDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMCallEnquiryDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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
        [HttpGet]
        public ActionResult View(int id, int balancesheetId)
        {
            try
            {
                CRMCallEnquiryDetailsViewModel model = new CRMCallEnquiryDetailsViewModel();



                return PartialView("/Views/CRM/CRMCallEnquiryDetailsMannualMode/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
      
       


     
     
        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<CRMCallEnquiryDetails> GetListCRMCallEnquiryDetails(string SelectedBalanceSheet, out int TotalRecords)
        {
            List<CRMCallEnquiryDetails> listCRMCallEnquiryDetails = new List<CRMCallEnquiryDetails>();
            CRMCallEnquiryDetailsSearchRequest searchRequest = new CRMCallEnquiryDetailsSearchRequest();
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
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollectionResponse = _CRMCallEnquiryDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMCallEnquiryDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMCallEnquiryDetails;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<CRMCallEnquiryDetails> filteredCRMCallEnquiryDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "B.CalleeFirstName like '%'";
                    }
                    else
                    {
                        _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CalleeMobileNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "B.CalleeFirstName like '%'";
                    }
                    else
                    {
                        _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "CalleeEmailID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "B.CalleeFirstName like '%'";
                    }
                    else
                    {
                        _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "Source";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "B.CalleeFirstName like '%'";
                    }
                    else
                    {
                        _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 5:
                    _sortBy = "SourceContactPerson";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "B.CalleeFirstName like '%'";
                    }
                    else
                    {
                        _searchBy = "B.CalleeFirstName Like '%" + param.sSearch + "%' or B.CalleeEmailID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalanceSheet) )
            {
                filteredCRMCallEnquiryDetails = GetListCRMCallEnquiryDetails(SelectedBalanceSheet, out TotalRecords);
            }
            else
            {
                filteredCRMCallEnquiryDetails = new List<CRMCallEnquiryDetails>();
                TotalRecords = 0;
            }
            var records = filteredCRMCallEnquiryDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CalleeEntityType), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

