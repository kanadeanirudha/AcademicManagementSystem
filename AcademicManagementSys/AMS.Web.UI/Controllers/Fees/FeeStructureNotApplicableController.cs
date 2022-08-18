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
    public class FeeStructureNotApplicableController : BaseController
    {
        IFeeStructureApplicableServiceAccess _feeStructureApplicableServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeeStructureNotApplicableController()
        {
            _feeStructureApplicableServiceAcess = new FeeStructureApplicableServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
              if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
              {
                  return View("/Views/Fees/FeeStructureNotApplicable/Index.cshtml");
              }
              else
              {
                  return RedirectToAction("UnauthorizedAccess", "Home");
              }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                FeeStructureApplicableViewModel model = new FeeStructureApplicableViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fees/FeeStructureNotApplicable/List.cshtml", model);
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
        public IEnumerable<FeeStructureApplicableViewModel> GetFeeStructureNotApplicable(out int TotalRecords)
        {
            FeeStructureApplicableSearchRequest searchRequest = new FeeStructureApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "FeeCriteriaParametersDescription Like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "FeeCriteriaParametersDescription Like '%'";
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
            List<FeeStructureApplicableViewModel> listFeeStructureNotApplicableViewModel = new List<FeeStructureApplicableViewModel>();
            List<FeeStructureApplicable> listFeeStructureNotApplicable = new List<FeeStructureApplicable>();
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollectionResponse = _feeStructureApplicableServiceAcess.GetFeeStructureNotApplicableStudentList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeStructureNotApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeStructureApplicable item in listFeeStructureNotApplicable)
                    {
                        FeeStructureApplicableViewModel FeeStructureNotApplicableViewModel = new FeeStructureApplicableViewModel();
                        FeeStructureNotApplicableViewModel.FeeStructureApplicableDTO = item;
                        listFeeStructureNotApplicableViewModel.Add(FeeStructureNotApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeStructureNotApplicableViewModel;
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

                IEnumerable<FeeStructureApplicableViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.StudentCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.StudentCode like '%'"; 
                        }
                        else
                        {
                            _searchBy = "A.StudentCode Like '%" + param.sSearch + "%' or A.StudentCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.StudentCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.StudentCode Like '%'";
                        }
                        else
                        {
                            _searchBy = "A.StudentCode  Like '%" + param.sSearch + "%' or A.StudentCode  Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetFeeStructureNotApplicable(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.StudentName),Convert.ToString(c.AdmitAcademicYear),Convert.ToString(c.AddmissionYear),Convert.ToString(c.CourseYearDesc),Convert.ToString(c.StandardDescription),Convert.ToString(c.ID) };

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