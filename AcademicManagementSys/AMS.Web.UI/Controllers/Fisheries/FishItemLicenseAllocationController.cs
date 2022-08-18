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

namespace AMS.Web.UI.Controllers.Fisheries
{
    public class FishItemLicenseAllocationController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IFishItemLicenseAllocationServiceAccess _fishItemLicenseAllocationServiceAccess;
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
        public FishItemLicenseAllocationController()
        {
            _fishItemLicenseAllocationServiceAccess = new FishItemLicenseAllocationServiceAccess();
        }

        #endregion


        #region ------------CONTROLLER ACTION METHODS------------
        
        public ActionResult Index()
        {
            if(Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/Fisheries/FishItemLicenseAllocation/Index.cshtml");
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
                FishItemLicenseAllocationViewModel model = new FishItemLicenseAllocationViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fisheries/FishItemLicenseAllocation/List.cshtml", model);
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        // AjaxHandler Method
        #region

        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FishItemLicenseAllocationViewModel> fishItemLicenseAllocationVM;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LocationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " LocationName Like '%" + param.sSearch + "%' or LicenseFeeAmount Like '%" + param.sSearch + "%'";
                    }
                    break;

                case 1:
                    _sortBy = "LicenseFeeAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " ReservoirName Like '%" + param.sSearch + "%' or LicenseFeeAmount Like '%" + param.sSearch + "%'";
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalanceSheet))
            {
                fishItemLicenseAllocationVM = GetFishItemLicenseAllocationDetails(SelectedBalanceSheet, out TotalRecords);
            }
            else
            {
                fishItemLicenseAllocationVM = new List<FishItemLicenseAllocationViewModel>();
                TotalRecords = 0;
            }
            var displayedPosts = fishItemLicenseAllocationVM.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.LocationName.ToString(), c.FromDate.ToString(), c.UptoDate.ToString(), c.LocationID.ToString(), c.Amount.ToString(), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //Non Action Method
        #region
        public IEnumerable<FishItemLicenseAllocationViewModel> GetFishItemLicenseAllocationDetails(string SelectedBalanceSheet, out int TotalRecords)
        {
            FishItemLicenseAllocationSearchRequest fishItemLicenseAllocationSR = new FishItemLicenseAllocationSearchRequest();
            fishItemLicenseAllocationSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            //fishItemLicenseAllocationSR.BalancesheetID = !string.IsNullOrEmpty(SelectedBalanceSheet) ? Convert.ToInt32(SelectedBalanceSheet) : 0;
            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert && Convert.ToInt32(SelectedBalanceSheet) > 0)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    fishItemLicenseAllocationSR.SortBy = "A.CreatedDate";
                    fishItemLicenseAllocationSR.StartRow = 0;
                    fishItemLicenseAllocationSR.EndRow = 10;
                    fishItemLicenseAllocationSR.SearchBy = string.Empty;
                    fishItemLicenseAllocationSR.SortDirection = "Desc";

                }
                
            }
            else
            {
                fishItemLicenseAllocationSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                fishItemLicenseAllocationSR.StartRow = _startRow;
                fishItemLicenseAllocationSR.EndRow = _startRow + _rowLength;
                fishItemLicenseAllocationSR.SearchBy = _searchBy;
                fishItemLicenseAllocationSR.SortDirection = _sortDirection;
            }
            List<FishItemLicenseAllocationViewModel> listFishItemLicenseAllocationVM = new List<FishItemLicenseAllocationViewModel>();
            List<FishItemLicenseAllocation> listFishItemLicenseAllocation = new List<FishItemLicenseAllocation>();
            IBaseEntityCollectionResponse<FishItemLicenseAllocation> baseEntityFishItemLicenseAllocation = _fishItemLicenseAllocationServiceAccess.GetBySearch(fishItemLicenseAllocationSR);
            if (baseEntityFishItemLicenseAllocation != null)
            {
                if (baseEntityFishItemLicenseAllocation.CollectionResponse != null && baseEntityFishItemLicenseAllocation.CollectionResponse.Count > 0)
                {
                    listFishItemLicenseAllocation = baseEntityFishItemLicenseAllocation.CollectionResponse.ToList();
                    foreach (FishItemLicenseAllocation fishLicenseAllocation in listFishItemLicenseAllocation)
                    {
                        FishItemLicenseAllocationViewModel licenseAllocationVM = new FishItemLicenseAllocationViewModel();
                        licenseAllocationVM.FishItemLicenseAllocationDTO = fishLicenseAllocation;
                        listFishItemLicenseAllocationVM.Add(licenseAllocationVM);
                    }
                }
            }
            TotalRecords = baseEntityFishItemLicenseAllocation.TotalRecords;
            return listFishItemLicenseAllocationVM;
        }

        #endregion


    }
}
