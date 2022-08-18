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
    public class FishLicenseRuleMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IFishLicenseRuleMasterServiceAccess _fishLicenseRuleMasterServiceAccess = null;
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
        public FishLicenseRuleMasterController()
        {
            _fishLicenseRuleMasterServiceAccess = new FishLicenseRuleMasterServiceAccess();
        }
        #endregion




        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            {
                return View("/Views/Fisheries/FishLicenseRuleMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }


        public ActionResult List(string actionMode, int licenseTypeID)
        {
            try
            {
                FishLicenseRuleMasterViewModel _fishLicenseRuleMasterModel = new FishLicenseRuleMasterViewModel();
                _fishLicenseRuleMasterModel.LicenseTypeID = licenseTypeID;

                //--------------------------------------For License Type list---------------------------------//
                List<FishLicenseType> listFishLicenseType = GetListFishLicenseType();
                
                foreach (var item in listFishLicenseType)
                {   
                    _fishLicenseRuleMasterModel.ListGetFishLicenseType.Add(item);
                }

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fisheries/FishLicenseRuleMaster/List.cshtml", _fishLicenseRuleMasterModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //Create Call

        public ActionResult Create(int LicenseTypeID)
        {
            try
            {
                FishLicenseRuleMasterViewModel fishLicenseRuleMasterModel = new FishLicenseRuleMasterViewModel();
                fishLicenseRuleMasterModel.LicenseTypeID = LicenseTypeID;

                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> listOrgStudyApplicableCentreDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails centerList = null;
                foreach (var item in listOrgStudyApplicableCentreDetails)
                {
                    centerList = new AdminRoleApplicableDetails();
                    centerList.CentreCode = item.CentreCode;
                    centerList.CentreName = item.CentreName;
                    
                    fishLicenseRuleMasterModel.ListOrgStudyApplicableCentre.Add(centerList);
                }

                return PartialView("/Views/Fisheries/FishLicenseRuleMaster/Create.cshtml", fishLicenseRuleMasterModel);
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(FishLicenseRuleMasterViewModel model)
        {
            try
            {
                if (model.FishLicenseRuleMasterDTO != null)
                {
                    model.FishLicenseRuleMasterDTO.ConnectionString = _connectioString;

                    model.FishLicenseRuleMasterDTO.LicenseTypeID = model.LicenseTypeID;
                    model.FishLicenseRuleMasterDTO.RuleName = model.RuleName;
                    model.FishLicenseRuleMasterDTO.RuleCode = model.RuleCode;
                    model.FishLicenseRuleMasterDTO.ApplicableFromDate = model.ApplicableFromDate;
                    model.FishLicenseRuleMasterDTO.ApplicableUptoDate = model.ApplicableUptoDate;
                    model.FishLicenseRuleMasterDTO.Percentage = model.Percentage;
                    model.FishLicenseRuleMasterDTO.IncreaseDecreaseFlag = model.IncreaseDecreaseFlag;
                    model.FishLicenseRuleMasterDTO.IsAplicableToAllCentre = model.IsAplicableToAllCentre;
                    model.FishLicenseRuleMasterDTO.LicenseFeeAmount = model.LicenseFeeAmount;

                    model.FishLicenseRuleMasterDTO.SelectedCentreCodes = model.SelectedCentreCodes != null ? model.SelectedCentreCodes : "";
                    model.FishLicenseRuleMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<FishLicenseRuleMaster> response = _fishLicenseRuleMasterServiceAccess.InsertFishLicenseRuleMaster(model.FishLicenseRuleMasterDTO);
                    model.FishLicenseRuleMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.FishLicenseRuleMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        public ActionResult Delete(int ID, int LicenseTypeID, bool IsAplicableToAllCentre)
        {
            FishLicenseRuleMasterViewModel model = new FishLicenseRuleMasterViewModel();
            model.FishLicenseRuleMasterDTO = new FishLicenseRuleMaster();
            model.FishLicenseRuleMasterDTO.ID = ID;
            model.FishLicenseRuleMasterDTO.LicenseTypeID = LicenseTypeID;
            model.FishLicenseRuleMasterDTO.IsAplicableToAllCentre = IsAplicableToAllCentre;
            return PartialView("/Views/Fisheries/FishLicenseRuleMaster/Delete.cshtml", model);
        }


        [HttpPost]
        public ActionResult Delete(FishLicenseRuleMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    FishLicenseRuleMaster FishLicenseRuleMasterDTO = new FishLicenseRuleMaster();
                    FishLicenseRuleMasterDTO.ConnectionString = _connectioString;
                    FishLicenseRuleMasterDTO.ID = model.ID;
                    FishLicenseRuleMasterDTO.LicenseTypeID = model.LicenseTypeID;
                    FishLicenseRuleMasterDTO.IsAplicableToAllCentre = model.IsAplicableToAllCentre;
                    IBaseEntityResponse<FishLicenseRuleMaster> response = _fishLicenseRuleMasterServiceAccess.DeleteFishLicenseRuleMaster(FishLicenseRuleMasterDTO);
                    model.FishLicenseRuleMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.FishLicenseRuleMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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



        //Non Action Method
        #region---------------Non Action Method----------------------


        public IEnumerable<FishLicenseRuleMasterViewModel> GetFishLicenseRuleMasterDetails(out int TotalRecords,int LicenseTypeID)
        {
            FishLicenseRuleMasterSearchRequest fishLicenseRuleMasterSR = new FishLicenseRuleMasterSearchRequest();
            fishLicenseRuleMasterSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    fishLicenseRuleMasterSR.SortBy = "A.CreatedDate";
                    fishLicenseRuleMasterSR.StartRow = 0;
                    fishLicenseRuleMasterSR.EndRow = 10;
                    fishLicenseRuleMasterSR.SearchBy = string.Empty;
                    fishLicenseRuleMasterSR.SortDirection = "Desc";
                    fishLicenseRuleMasterSR.LicenseTypeID = LicenseTypeID;
                    //fishLicenseRuleMasterSR.LicenseType = LicenseType;

                }                
            }
            else
            {
                fishLicenseRuleMasterSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                fishLicenseRuleMasterSR.StartRow = _startRow;
                fishLicenseRuleMasterSR.EndRow = _startRow + _rowLength;
                fishLicenseRuleMasterSR.SearchBy = _searchBy;
                fishLicenseRuleMasterSR.SortDirection = _sortDirection;
                fishLicenseRuleMasterSR.LicenseTypeID = LicenseTypeID;
                //fishLicenseRuleMasterSR.LicenseType = LicenseType;
            }

            List<FishLicenseRuleMasterViewModel> listFishLicenseRuleMasterVM = new List<FishLicenseRuleMasterViewModel>();
            List<FishLicenseRuleMaster> listFishLicenseRuleMaster = new List<FishLicenseRuleMaster>();
            IBaseEntityCollectionResponse<FishLicenseRuleMaster> baseEntityFishLicenseRuleMaster = _fishLicenseRuleMasterServiceAccess.GetBySearch(fishLicenseRuleMasterSR);
            if (baseEntityFishLicenseRuleMaster != null)
            {
                if (baseEntityFishLicenseRuleMaster.CollectionResponse != null && baseEntityFishLicenseRuleMaster.CollectionResponse.Count > 0)
                {
                    listFishLicenseRuleMaster = baseEntityFishLicenseRuleMaster.CollectionResponse.ToList();
                    foreach (FishLicenseRuleMaster licenseRuleType in listFishLicenseRuleMaster)
                    {
                        FishLicenseRuleMasterViewModel fishLicenseRuleMasterVM = new FishLicenseRuleMasterViewModel();
                        fishLicenseRuleMasterVM.FishLicenseRuleMasterDTO = licenseRuleType;
                        listFishLicenseRuleMasterVM.Add(fishLicenseRuleMasterVM);
                    }
                }
            }
            TotalRecords = baseEntityFishLicenseRuleMaster.TotalRecords;
            return listFishLicenseRuleMasterVM;
        }


        #endregion



        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int LicenseTypeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FishLicenseRuleMasterViewModel> filteredFishLicenseRuleMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "RuleName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or Percentage Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "RuleCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or Percentage Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "Percentage";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or Percentage Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (LicenseTypeID > 0)
            {
                filteredFishLicenseRuleMaster = GetFishLicenseRuleMasterDetails(out TotalRecords,LicenseTypeID);
            }
            else
            {
                filteredFishLicenseRuleMaster = new List<FishLicenseRuleMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredFishLicenseRuleMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.RuleName) , Convert.ToString(c.RuleCode), Convert.ToString(c.Percentage),Convert.ToString(c.IncreaseDecreaseFlag), Convert.ToString(c.IsAplicableToAllCentre), Convert.ToString(c.ID), Convert.ToString(c.LicenseTypeID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        
    }
}
