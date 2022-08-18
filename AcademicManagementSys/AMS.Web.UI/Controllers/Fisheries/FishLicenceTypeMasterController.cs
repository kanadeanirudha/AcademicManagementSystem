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
    public class FishLicenceTypeMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IFishLicenseTypeServiceAccess _fishLicenseTypeServiceAccess = null;
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
        public FishLicenceTypeMasterController()
        {
            _fishLicenseTypeServiceAccess = new FishLicenseTypeServiceAccess();
        }
        #endregion


        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            return View("/Views/Fisheries/FishLicenseType/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                FishLicenceTypeMasterViewModel model = new FishLicenceTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fisheries/FishLicenseType/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Create()
        {
            FishLicenceTypeMasterViewModel model = new FishLicenceTypeMasterViewModel();
            return PartialView("/Views/Fisheries/FishLicenseType/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(FishLicenceTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.FishLicenceTypeMasterDTO != null)
                    {
                        model.FishLicenceTypeMasterDTO.ConnectionString = _connectioString;
                        model.FishLicenceTypeMasterDTO.LicenseType = model.LicenseType;
                        model.FishLicenceTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<FishLicenseType> response = _fishLicenseTypeServiceAccess.InsertFishLicenseType(model.FishLicenceTypeMasterDTO);
                        model.FishLicenceTypeMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.FishLicenceTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Edit(int ID)
        {
            FishLicenceTypeMasterViewModel model = new FishLicenceTypeMasterViewModel();
            model.FishLicenceTypeMasterDTO = new FishLicenseType();
            model.FishLicenceTypeMasterDTO.ID = ID;
            model.FishLicenceTypeMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<FishLicenseType> response = _fishLicenseTypeServiceAccess.SelectByID(model.FishLicenceTypeMasterDTO);

            if (response.Entity != null)
            {
                model.FishLicenceTypeMasterDTO.ID = response.Entity.ID;
                model.FishLicenceTypeMasterDTO.LicenseType = response.Entity.LicenseType;

            }
            return PartialView("/Views/Fisheries/FishLicenseType/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(FishLicenceTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.FishLicenceTypeMasterDTO != null)
                    {
                        model.FishLicenceTypeMasterDTO.ConnectionString = _connectioString;
                        model.FishLicenceTypeMasterDTO.ID = model.ID;
                        model.FishLicenceTypeMasterDTO.LicenseType = model.LicenseType;
                        model.FishLicenceTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<FishLicenseType> response = _fishLicenseTypeServiceAccess.UpdateFishLicenseType(model.FishLicenceTypeMasterDTO);
                        model.FishLicenceTypeMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.FishLicenceTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(int ID)
        {
            FishLicenceTypeMasterViewModel model = new FishLicenceTypeMasterViewModel();
            model.FishLicenceTypeMasterDTO = new FishLicenseType();
            model.FishLicenceTypeMasterDTO.ID = ID;
            return PartialView("/Views/Fisheries/FishLicenseType/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(FishLicenceTypeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (model.ID > 0)
                {
                    FishLicenseType FishLicenseTypeDTO = new FishLicenseType();
                    FishLicenseTypeDTO.ConnectionString = _connectioString;
                    FishLicenseTypeDTO.ID = model.ID;
                    FishLicenseTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FishLicenseType> response = _fishLicenseTypeServiceAccess.DeleteFishLicenseType(FishLicenseTypeDTO);
                    model.FishLicenceTypeMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.FishLicenceTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
                //}

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion


        //Non Action Method
        #region
        public IEnumerable<FishLicenceTypeMasterViewModel> GetFishLicenseTypeMasterDetails(out int TotalRecords)
        {
            FishLicenseTypeSearchRequest fishLicenseTypeSR = new FishLicenseTypeSearchRequest();
            fishLicenseTypeSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    fishLicenseTypeSR.SortBy = "CreatedDate";
                    fishLicenseTypeSR.StartRow = 0;
                    fishLicenseTypeSR.EndRow = 10;
                    fishLicenseTypeSR.SearchBy = string.Empty;
                    fishLicenseTypeSR.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    fishLicenseTypeSR.SortBy = "ModifiedDate";
                    fishLicenseTypeSR.StartRow = 0;
                    fishLicenseTypeSR.EndRow = 10;
                    fishLicenseTypeSR.SearchBy = string.Empty;
                    fishLicenseTypeSR.SortDirection = "Desc";
                }
            }
            else
            {
                fishLicenseTypeSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                fishLicenseTypeSR.StartRow = _startRow;
                fishLicenseTypeSR.EndRow = _startRow + _rowLength;
                fishLicenseTypeSR.SearchBy = _searchBy;
                fishLicenseTypeSR.SortDirection = _sortDirection;
            }

            List<FishLicenceTypeMasterViewModel> listFishLicenseTypeMasterVM = new List<FishLicenceTypeMasterViewModel>();
            List<FishLicenseType> listFishLicenseType = new List<FishLicenseType>();
            IBaseEntityCollectionResponse<FishLicenseType> baseEntityFishLicenseType = _fishLicenseTypeServiceAccess.GetBySearch(fishLicenseTypeSR);
            if (baseEntityFishLicenseType != null)
            {
                if (baseEntityFishLicenseType.CollectionResponse != null && baseEntityFishLicenseType.CollectionResponse.Count > 0)
                {
                    listFishLicenseType = baseEntityFishLicenseType.CollectionResponse.ToList();
                    foreach (FishLicenseType licenseType in listFishLicenseType)
                    {
                        FishLicenceTypeMasterViewModel licenseTypeVM = new FishLicenceTypeMasterViewModel();
                        licenseTypeVM.FishLicenceTypeMasterDTO = licenseType;
                        listFishLicenseTypeMasterVM.Add(licenseTypeVM);
                    }
                }
            }
            TotalRecords = baseEntityFishLicenseType.TotalRecords;
            return listFishLicenseTypeMasterVM;
        }

        #endregion




        // AjaxHandler Method
        #region

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FishLicenceTypeMasterViewModel> fishLicenseTypeMasterVM;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LicenseType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " LicenseType Like '%" + param.sSearch + "%'";
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            fishLicenseTypeMasterVM = GetFishLicenseTypeMasterDetails(out TotalRecords);
            var displayedPosts = fishLicenseTypeMasterVM.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.LicenseType.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
