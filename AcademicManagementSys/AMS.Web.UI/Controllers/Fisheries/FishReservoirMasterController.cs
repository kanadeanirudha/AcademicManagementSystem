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

namespace AMS.Web.UI.Controllers.FishReservoir
{
    public class FishReservoirMasterController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IFishReservoirMasterServiceAccess _fishReservoirMasterServiceAccess;
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
         public FishReservoirMasterController()
        {
            _fishReservoirMasterServiceAccess = new FishReservoirMasterServiceAccess();
        }

        #endregion


         #region ------------CONTROLLER ACTION METHODS------------
         public ActionResult Index()
        {
            return View("/Views/Fisheries/FishReservoir/Index.cshtml");
        }

         public ActionResult List(string actionMode)
         {
             try
             {
                 FishReservoirMasterViewModel model = new FishReservoirMasterViewModel();
                 if (!string.IsNullOrEmpty(actionMode))
                 {
                     TempData["ActionMode"] = actionMode;
                 }
                 return PartialView("/Views/Fisheries/FishReservoir/List.cshtml", model);
             }
             catch(Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
         }

        public ActionResult Create()
         {
             FishReservoirMasterViewModel model = new FishReservoirMasterViewModel();
             return PartialView("/Views/Fisheries/FishReservoir/Create.cshtml", model);
         }

        [HttpPost]
        public ActionResult Create(FishReservoirMasterViewModel model)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    if(model.FishReservoirMasterDTO != null)
                    {
                        model.FishReservoirMasterDTO.ConnectionString = _connectioString;
                        model.FishReservoirMasterDTO.ReservoirName = model.ReservoirName;
                        model.FishReservoirMasterDTO.ReservoirCode = model.ReservoirCode;
                        model.FishReservoirMasterDTO.Address = model.Address;
                        model.FishReservoirMasterDTO.Area = model.Area;
                        model.FishReservoirMasterDTO.Latitude = model.Latitude;
                        model.FishReservoirMasterDTO.Logitude = model.Logitude;
                        model.FishReservoirMasterDTO.Capacity = model.Capacity;
                        model.FishReservoirMasterDTO.MinProductCapacity = model.MinProductCapacity;
                        model.FishReservoirMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.FishReservoirMasterDTO.BalancesheetID = model.BalancesheetID;
                        IBaseEntityResponse<FishReservoirMaster> response = _fishReservoirMasterServiceAccess.InsertFishReservoirMaster(model.FishReservoirMasterDTO);
                        model.FishReservoirMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, actionModeEnum);
                    }
                    return Json(model.FishReservoirMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Edit(int ID)
        {
            FishReservoirMasterViewModel model = new FishReservoirMasterViewModel();
            model.FishReservoirMasterDTO = new FishReservoirMaster();
            model.FishReservoirMasterDTO.ID = ID;
            model.FishReservoirMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<FishReservoirMaster> response = _fishReservoirMasterServiceAccess.SelectByID(model.FishReservoirMasterDTO);

            if(response.Entity != null)
            {
                model.FishReservoirMasterDTO.ID = response.Entity.ID;
                model.FishReservoirMasterDTO.ReservoirName = response.Entity.ReservoirName;
                model.FishReservoirMasterDTO.ReservoirCode = response.Entity.ReservoirCode;
                model.FishReservoirMasterDTO.Address = response.Entity.Address;
                model.FishReservoirMasterDTO.Latitude = response.Entity.Latitude;
                model.FishReservoirMasterDTO.Logitude = response.Entity.Logitude;
                model.FishReservoirMasterDTO.Area = response.Entity.Area;
                model.FishReservoirMasterDTO.Capacity = response.Entity.Capacity;
                model.FishReservoirMasterDTO.MinProductCapacity = response.Entity.MinProductCapacity;
                model.FishReservoirMasterDTO.LocationId = response.Entity.LocationId;

            }
            return PartialView("/Views/Fisheries/FishReservoir/Edit.cshtml", model);
        }


        [HttpPost]
        public ActionResult Edit(FishReservoirMasterViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(model.FishReservoirMasterDTO != null)
                    {
                        model.FishReservoirMasterDTO.ConnectionString = _connectioString;
                        model.FishReservoirMasterDTO.ID = model.ID;
                        model.FishReservoirMasterDTO.ReservoirName = model.ReservoirName;
                        model.FishReservoirMasterDTO.Address = model.Address;
                        model.FishReservoirMasterDTO.BalancesheetID = model.BalancesheetID;
                        model.FishReservoirMasterDTO.LocationId = model.LocationId;
                        model.FishReservoirMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                        //model.FishReservoirMasterDTO.ReservoirCode = model.ReservoirCode;                       
                        //model.FishReservoirMasterDTO.Latitude = model.Latitude;
                        //model.FishReservoirMasterDTO.Logitude = model.Logitude;
                        //model.FishReservoirMasterDTO.Area = model.Area;
                        //model.FishReservoirMasterDTO.Capacity = model.Capacity;
                        //model.FishReservoirMasterDTO.MinProductCapacity = model.MinProductCapacity;
                        IBaseEntityResponse<FishReservoirMaster> response = _fishReservoirMasterServiceAccess.UpdateFishReservoirMaster(model.FishReservoirMasterDTO);
                        model.FishReservoirMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.FishReservoirMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(int ID)
        {
            FishReservoirMasterViewModel model = new FishReservoirMasterViewModel();
            model.FishReservoirMasterDTO = new FishReservoirMaster();
            model.FishReservoirMasterDTO.ID = model.ID;
            return PartialView("/Views/Fisheries/FishReservoir/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(FishReservoirMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    FishReservoirMaster FishReservoirMasterDTO = new FishReservoirMaster();
                    FishReservoirMasterDTO.ConnectionString = _connectioString;
                    FishReservoirMasterDTO.ID = model.ID;
                    FishReservoirMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FishReservoirMaster> response = _fishReservoirMasterServiceAccess.DeleteFishReservoirMaster(FishReservoirMasterDTO);
                    model.FishReservoirMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.FishReservoirMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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


        // AjaxHandler Method
        #region

         public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet)
         {
             int TotalRecords;
             var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
             string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

             IEnumerable<FishReservoirMasterViewModel> fishReservoirMasterVM;
             switch (Convert.ToInt32(sortColumnIndex))
             {
                 case 0:
                     _sortBy = "ReservoirName";
                      if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " ReservoirName Like '%" + param.sSearch + "%' or ReservoirCode Like '%" + param.sSearch + "%' or Address Like '%" + param.sSearch + "%' or Area Like '%" + param.sSearch + "%' or Capacity Like '%" + param.sSearch + "%'";
                    }
                    break;

                 case 1:
                    _sortBy = "ReservoirCode";
                      if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " ReservoirName Like '%" + param.sSearch + "%' or ReservoirCode Like '%" + param.sSearch + "%' or Address Like '%" + param.sSearch + "%' or Area Like '%" + param.sSearch + "%' or Capacity Like '%" + param.sSearch + "%'";
                    }
                    break;

                 case 2:
                    _sortBy = "Address";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " ReservoirName Like '%" + param.sSearch + "%' or ReservoirCode Like '%" + param.sSearch + "%' or Address Like '%" + param.sSearch + "%' or Area Like '%" + param.sSearch + "%' or Capacity Like '%" + param.sSearch + "%'";
                    }
                    break;

                 case 3:
                    _sortBy = "Area";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " ReservoirName Like '%" + param.sSearch + "%' or ReservoirCode Like '%" + param.sSearch + "%' or Address Like '%" + param.sSearch + "%' or Area Like '%" + param.sSearch + "%' or Capacity Like '%" + param.sSearch + "%'";
                    }
                    break;

                 case 4:
                    _sortBy = "Capacity";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = " ReservoirName Like '%" + param.sSearch + "%' or ReservoirCode Like '%" + param.sSearch + "%' or Address Like '%" + param.sSearch + "%' or Area Like '%" + param.sSearch + "%' or Capacity Like '%" + param.sSearch + "%'";
                    }
                    break;
             }
             _sortDirection = sortDirection;
             _rowLength = param.iDisplayLength;
             _startRow = param.iDisplayStart;
             if (!string.IsNullOrEmpty(SelectedBalanceSheet))
             {
                 fishReservoirMasterVM = GetFishReservoirMasterDetails( SelectedBalanceSheet , out TotalRecords);
             }
             else
             {
                 fishReservoirMasterVM = new List<FishReservoirMasterViewModel>();
                 TotalRecords = 0;
             }
             var displayedPosts = fishReservoirMasterVM.Skip(0).Take(param.iDisplayLength);
             var result = from c in displayedPosts select new[] { c.ReservoirName.ToString(), c.ReservoirCode.ToString(), c.Address.ToString(), c.Area.ToString(), c.Capacity.ToString(), Convert.ToString(c.ID) };
             return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
         }
        #endregion

        //Non Action Method
        #region
         public IEnumerable<FishReservoirMasterViewModel> GetFishReservoirMasterDetails(string SelectedBalanceSheet, out int TotalRecords)
         {
             FishReservoirMasterSearchRequest fishReservoirMasterSR = new FishReservoirMasterSearchRequest();
             fishReservoirMasterSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
             _actionMode = Convert.ToString(TempData["ActionMode"]);
             fishReservoirMasterSR.BalancesheetID = !string.IsNullOrEmpty(SelectedBalanceSheet) ? Convert.ToInt32(SelectedBalanceSheet) : 0;
             // checks actionMode i.e. Insert or Update //
             if (Enum.TryParse(_actionMode, out actionModeEnum))
             {
                 if (actionModeEnum == ActionModeEnum.Insert)
                 {
                     // parameters for SelectAll procedures under Insert or Update mode condition
                     fishReservoirMasterSR.SortBy = "A.CreatedDate";
                     fishReservoirMasterSR.StartRow = 0;
                     fishReservoirMasterSR.EndRow = 10;
                     fishReservoirMasterSR.SearchBy = string.Empty;
                     fishReservoirMasterSR.SortDirection = "Desc";

                 }
                 if (actionModeEnum == ActionModeEnum.Update)
                 {
                     fishReservoirMasterSR.SortBy = "A.ModifiedDate";
                     fishReservoirMasterSR.StartRow = 0;
                     fishReservoirMasterSR.EndRow = 10;
                     fishReservoirMasterSR.SearchBy = string.Empty;
                     fishReservoirMasterSR.SortDirection = "Desc";
                 }             
             }
             else
             {
                 fishReservoirMasterSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                 fishReservoirMasterSR.StartRow = _startRow;
                 fishReservoirMasterSR.EndRow = _startRow + _rowLength;
                 fishReservoirMasterSR.SearchBy = _searchBy;
                 fishReservoirMasterSR.SortDirection = _sortDirection;
             }
             List<FishReservoirMasterViewModel> listFishReserviorMasterVM = new List<FishReservoirMasterViewModel>();
             List<FishReservoirMaster> listFishReserviorMaster = new List<FishReservoirMaster>();
             IBaseEntityCollectionResponse<FishReservoirMaster> baseEntityFishReserviorMaster = _fishReservoirMasterServiceAccess.GetBySearch(fishReservoirMasterSR);
             if (baseEntityFishReserviorMaster != null)
             {
                 if (baseEntityFishReserviorMaster.CollectionResponse != null && baseEntityFishReserviorMaster.CollectionResponse.Count > 0)
                 {
                     listFishReserviorMaster = baseEntityFishReserviorMaster.CollectionResponse.ToList();
                     foreach (FishReservoirMaster fishReservior in listFishReserviorMaster)
                     {
                         FishReservoirMasterViewModel reservoirMasterVM = new FishReservoirMasterViewModel();
                         reservoirMasterVM.FishReservoirMasterDTO = fishReservior;
                         listFishReserviorMasterVM.Add(reservoirMasterVM);
                     }
                 }
             }
             TotalRecords = baseEntityFishReserviorMaster.TotalRecords;
             return listFishReserviorMasterVM;
         }

        #endregion
    }
}
