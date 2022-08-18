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
    public class InventoryCounterMasterController : BaseController
    {
        IInventoryCounterMasterServiceAccess _InventoryCounterMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryCounterMasterController()
        {
            _InventoryCounterMasterServiceAcess = new InventoryCounterMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryCounterMaster/Index.cshtml");
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
                InventoryCounterMasterViewModel model = new InventoryCounterMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryCounterMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            
        }


        [HttpGet]
        public ActionResult Create()
        {
            InventoryCounterMasterViewModel model = new InventoryCounterMasterViewModel();
            return PartialView("/Views/Inventory/InventoryCounterMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryCounterMasterViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.InventoryCounterMasterDTO != null)
                    {
                        model.InventoryCounterMasterDTO.ConnectionString = _connectioString;
                        model.InventoryCounterMasterDTO.CounterName = model.CounterName;
                       // model.InventoryCounterMasterDTO.SeqNo = model.SeqNo; ;
                        model.InventoryCounterMasterDTO.CounterCode = model.CounterCode;
                        model.InventoryCounterMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryCounterMaster> response = _InventoryCounterMasterServiceAcess.InsertInventoryCounterMaster(model.InventoryCounterMasterDTO);
                        model.InventoryCounterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.InventoryCounterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                    
                    return Json("Please review your form");
                
               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;     
            }
          
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            InventoryCounterMasterViewModel model = new InventoryCounterMasterViewModel();
            try
            {                
                model.InventoryCounterMasterDTO = new InventoryCounterMaster();
                model.InventoryCounterMasterDTO.ID = id;
                model.InventoryCounterMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryCounterMaster> response = _InventoryCounterMasterServiceAcess.SelectByID(model.InventoryCounterMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryCounterMasterDTO.ID = response.Entity.ID;
                    model.InventoryCounterMasterDTO.CounterName = response.Entity.CounterName;
                   // model.InventoryCounterMasterDTO.SeqNo = response.Entity.SeqNo;
                    model.InventoryCounterMasterDTO.CounterCode = response.Entity.CounterCode;
                   // model.InventoryCounterMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.InventoryCounterMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/InventoryCounterMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryCounterMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryCounterMasterDTO != null)
                {
                    if (model != null && model.InventoryCounterMasterDTO != null)
                    {
                        model.InventoryCounterMasterDTO.ConnectionString = _connectioString;
                        model.InventoryCounterMasterDTO.CounterName = model.CounterName;
                       // model.InventoryCounterMasterDTO.SeqNo = model.SeqNo;
                        model.InventoryCounterMasterDTO.CounterCode = model.CounterCode;
                        model.InventoryCounterMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryCounterMaster> response = _InventoryCounterMasterServiceAcess.UpdateInventoryCounterMaster(model.InventoryCounterMasterDTO);
                        model.InventoryCounterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryCounterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    InventoryCounterMasterViewModel model = new InventoryCounterMasterViewModel();
        //    model.InventoryCounterMasterDTO = new InventoryCounterMaster();
        //    model.InventoryCounterMasterDTO.ID = ID;
        //    return PartialView("/Views/Inventory/InventoryCounterMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(InventoryCounterMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            InventoryCounterMaster InventoryCounterMasterDTO = new InventoryCounterMaster();
        //            InventoryCounterMasterDTO.ConnectionString = _connectioString;
        //            InventoryCounterMasterDTO.ID = model.ID;
        //            InventoryCounterMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<InventoryCounterMaster> response = _InventoryCounterMasterServiceAcess.DeleteInventoryCounterMaster(InventoryCounterMasterDTO);
        //            model.InventoryCounterMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.InventoryCounterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            InventoryCounterMasterViewModel model = new InventoryCounterMasterViewModel();
            if (ID > 0)
            {
                if (ID > 0)
                {
                    InventoryCounterMaster InventoryCounterMasterDTO = new InventoryCounterMaster();
                    InventoryCounterMasterDTO.ConnectionString = _connectioString;
                    InventoryCounterMasterDTO.ID = ID;
                    InventoryCounterMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryCounterMaster> response = _InventoryCounterMasterServiceAcess.DeleteInventoryCounterMaster(InventoryCounterMasterDTO);
                    model.InventoryCounterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.InventoryCounterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryCounterMasterViewModel> GetInventoryCounterMaster(out int TotalRecords)
        {
            InventoryCounterMasterSearchRequest searchRequest = new InventoryCounterMasterSearchRequest();
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
            List<InventoryCounterMasterViewModel> listInventoryCounterMasterViewModel = new List<InventoryCounterMasterViewModel>();
            List<InventoryCounterMaster> listInventoryCounterMaster = new List<InventoryCounterMaster>();
            IBaseEntityCollectionResponse<InventoryCounterMaster> baseEntityCollectionResponse = _InventoryCounterMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCounterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryCounterMaster item in listInventoryCounterMaster)
                    {
                        InventoryCounterMasterViewModel InventoryCounterMasterViewModel = new InventoryCounterMasterViewModel();
                        InventoryCounterMasterViewModel.InventoryCounterMasterDTO = item;
                        listInventoryCounterMasterViewModel.Add(InventoryCounterMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryCounterMasterViewModel;
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

                IEnumerable<InventoryCounterMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CounterName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CounterName Like '%" + param.sSearch + "%' or CounterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "CounterCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CounterCode Like '%" + param.sSearch + "%' or CounterCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetInventoryCounterMaster(out TotalRecords);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<InventoryCounterMasterViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.CounterName.ToString(), c.CounterCode.ToString(), Convert.ToString(c.ID) };

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