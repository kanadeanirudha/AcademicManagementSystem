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
    public class FishItemLicenseRateController : BaseController
    {

        #region------------CONTROLLER CLASS VARIABLE------------

        IFishItemLicenseRateServiceAccess _fishItemLicenseRateServiceAccess;
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
        public FishItemLicenseRateController()
        {
            _fishItemLicenseRateServiceAccess = new FishItemLicenseRateServiceAccess();
        }

        #endregion



        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/Fisheries/FishItemLicenseRate/Index.cshtml");
            }
            else
            {
               return RedirectToAction("UnauthorizedAccess", "Home");              
            }            
        }

        public ActionResult List(string actionMode, string centerCode, int licenseTypeID)
        {
            try
            {
                FishItemLicenseRateViewModel model = new FishItemLicenseRateViewModel();
                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> listOrgStudyApplicableCentreDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails centerList = null;
                foreach (var item in listOrgStudyApplicableCentreDetails)
                {
                    centerList = new AdminRoleApplicableDetails();
                    centerList.CentreCode = item.CentreCode;
                    centerList.CentreName = item.CentreName;
                    
                    model.ListApplicableCentre.Add(centerList);
                }               

                //--------------------------------------For License Type list---------------------------------//
                List<FishLicenseType> listFishLicenseType = GetListFishLicenseType();

                foreach (var item in listFishLicenseType)
                {
                    model.ListGetFishLicenseType.Add(item);
                }


                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.FishItemLicenseRateDTO.CentreCode = centerCode;
                model.FishItemLicenseRateDTO.LicenseTypeID = licenseTypeID;
                return PartialView("/Views/Fisheries/FishItemLicenseRate/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Create(string centreCode, string licenseTypeID)
        {
            FishItemLicenseRateViewModel model = new FishItemLicenseRateViewModel();
            model.CentreCode = centreCode;
            model.LicenseTypeID = Convert.ToInt32(licenseTypeID);
            return PartialView("/Views/Fisheries/FishItemLicenseRate/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(FishItemLicenseRateViewModel model)
        {
            try
            {
                if (model != null && model.FishItemLicenseRateDTO != null)
                {
                    model.FishItemLicenseRateDTO.ConnectionString = _connectioString;
                    model.FishItemLicenseRateDTO.CentreCode = model.CentreCode;
                    model.FishItemLicenseRateDTO.LicenseTypeID = model.LicenseTypeID;
                    model.FishItemLicenseRateDTO.ItemID = model.ItemID;
                    model.FishItemLicenseRateDTO.Rate = model.Rate;
                    model.FishItemLicenseRateDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<FishItemLicenseRate> response = _fishItemLicenseRateServiceAccess.InsertFishItemLicenseRate(model.FishItemLicenseRateDTO);
                    model.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Edit(int ID)
        {
            FishItemLicenseRateViewModel model = new FishItemLicenseRateViewModel();
            model.FishItemLicenseRateDTO = new FishItemLicenseRate();
            model.FishItemLicenseRateDTO.ConnectionString = _connectioString;
            model.FishItemLicenseRateDTO.ID = ID;

            IBaseEntityResponse<FishItemLicenseRate> response = _fishItemLicenseRateServiceAccess.SelectByID(model.FishItemLicenseRateDTO);
            if(response.Entity != null)
            {
                model.FishItemLicenseRateDTO.ID = response.Entity.ID;
                model.FishItemLicenseRateDTO.ItemID = response.Entity.ItemID;
                model.FishItemLicenseRateDTO.ItemName = response.Entity.ItemName;
                model.FishItemLicenseRateDTO.LicenseTypeID = response.Entity.LicenseTypeID;
                model.FishItemLicenseRateDTO.CentreCode = response.Entity.CentreCode;
                model.FishItemLicenseRateDTO.Rate = response.Entity.Rate;
                model.FishItemLicenseRateDTO.CreatedBy = response.Entity.CreatedBy;
            }
            return PartialView("/Views/Fisheries/FishItemLicenseRate/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(FishItemLicenseRateViewModel model)
        {
            try
            {
                if(model.FishItemLicenseRateDTO != null)
                {
                    model.FishItemLicenseRateDTO.ConnectionString = _connectioString;
                    model.FishItemLicenseRateDTO.ID = model.ID;
                    model.FishItemLicenseRateDTO.Rate = model.Rate;
                    model.FishItemLicenseRateDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    
                    IBaseEntityResponse<FishItemLicenseRate> response = _fishItemLicenseRateServiceAccess.UpdateFishItemLicenseRate(model.FishItemLicenseRateDTO);
                    model.FishItemLicenseRateDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion

              


        //Non Action Method
        #region---------------Non Action Method----------------------

        public IEnumerable<FishItemLicenseRateViewModel> GetFishItemLicenseRateDetails(out int TotalRecords, string centreCode, int licenseTypeID)
        {
            FishItemLicenseRateSearchRequest fishItemLicenseRateSR = new FishItemLicenseRateSearchRequest();
            fishItemLicenseRateSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    fishItemLicenseRateSR.SortBy = "A.CreatedDate";
                    fishItemLicenseRateSR.StartRow = 0;
                    fishItemLicenseRateSR.EndRow = 10;
                    fishItemLicenseRateSR.SearchBy = string.Empty;
                    fishItemLicenseRateSR.SortDirection = "Desc";
                    fishItemLicenseRateSR.LicenseTypeID = licenseTypeID;
                    fishItemLicenseRateSR.CentreCode = centreCode;
                }
                else if (actionModeEnum == ActionModeEnum.Update)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    fishItemLicenseRateSR.SortBy = "A.ModifiedDate";
                    fishItemLicenseRateSR.StartRow = 0;
                    fishItemLicenseRateSR.EndRow = 10;
                    fishItemLicenseRateSR.SearchBy = string.Empty;
                    fishItemLicenseRateSR.SortDirection = "Desc";
                    fishItemLicenseRateSR.LicenseTypeID = licenseTypeID;
                    fishItemLicenseRateSR.CentreCode = centreCode;
                }      
            }
            else
            {
                fishItemLicenseRateSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                fishItemLicenseRateSR.StartRow = _startRow;
                fishItemLicenseRateSR.EndRow = _startRow + _rowLength;
                fishItemLicenseRateSR.SearchBy = _searchBy;
                fishItemLicenseRateSR.SortDirection = _sortDirection;
                fishItemLicenseRateSR.LicenseTypeID = licenseTypeID;
                fishItemLicenseRateSR.CentreCode = centreCode;
            }

            List<FishItemLicenseRateViewModel> listFishItemLicenseRateVM = new List<FishItemLicenseRateViewModel>();
            List<FishItemLicenseRate> listFishItemLicenseRate = new List<FishItemLicenseRate>();
            IBaseEntityCollectionResponse<FishItemLicenseRate> baseEntityFishItemLicenseRate = _fishItemLicenseRateServiceAccess.GetBySearch(fishItemLicenseRateSR);

            if(baseEntityFishItemLicenseRate != null)
            {
                if (baseEntityFishItemLicenseRate.CollectionResponse != null && baseEntityFishItemLicenseRate.CollectionResponse.Count > 0)
                {
                    listFishItemLicenseRate = baseEntityFishItemLicenseRate.CollectionResponse.ToList();
                    foreach (FishItemLicenseRate fishItemsType in listFishItemLicenseRate)
                    {
                        FishItemLicenseRateViewModel fishLicenseRuleMasterVM = new FishItemLicenseRateViewModel();
                        fishLicenseRuleMasterVM.FishItemLicenseRateDTO = fishItemsType;
                        listFishItemLicenseRateVM.Add(fishLicenseRuleMasterVM);
                    }
                }
            }
            TotalRecords = baseEntityFishItemLicenseRate.TotalRecords;
            return listFishItemLicenseRateVM;
        }


        //Method to Get ItemName List for Search text.

        [HttpPost]
        public JsonResult GetItemNameSearch(string term)
        {
            var data = GetItemNameSearchList(term);
            var result = (from item in data
                          select new
                          {
                              itemId = item.ItemID,
                              itemName = item.ItemName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<FishItemLicenseRate> GetItemNameSearchList(string SearchKeyWord)
        {
            FishItemLicenseRateSearchRequest searchRequest = new FishItemLicenseRateSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;            

            List<FishItemLicenseRate> listItemNames = new List<FishItemLicenseRate>();
            IBaseEntityCollectionResponse<FishItemLicenseRate> baseEntityCollectionResponse = _fishItemLicenseRateServiceAccess.GetItemNameCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listItemNames = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listItemNames;
        }



        #endregion


        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string centerCode, int licenseTypeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FishItemLicenseRateViewModel> filteredFishItemLicenseRate;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.ItemName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ItemName Like '%" + param.sSearch + "%' or Rate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.Rate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ItemName Like '%" + param.sSearch + "%' or Rate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (centerCode != "" && licenseTypeID > 0)
            {
                filteredFishItemLicenseRate = GetFishItemLicenseRateDetails(out TotalRecords, centerCode, licenseTypeID);
            }
            else
            {
                filteredFishItemLicenseRate = new List<FishItemLicenseRateViewModel>();
                TotalRecords = 0;
            }
            var records = filteredFishItemLicenseRate.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ItemName), Convert.ToString(c.Rate), Convert.ToString(c.ItemID), Convert.ToString(c.ID), Convert.ToString(c.CentreCode), Convert.ToString(c.LicenseTypeID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
