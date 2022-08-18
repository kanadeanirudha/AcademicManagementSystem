
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
    public class InventoryMachineMasterController : BaseController
    {
        IInventoryMachineMasterServiceAccess _InventoryMachineMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryMachineMasterController()
        {
            _InventoryMachineMasterServiceAcess = new InventoryMachineMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryMachineMaster/Index.cshtml");
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
                InventoryMachineMasterViewModel model = new InventoryMachineMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryMachineMaster/List.cshtml", model);
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
            InventoryMachineMasterViewModel model = new InventoryMachineMasterViewModel();
            return PartialView("/Views/Inventory/InventoryMachineMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryMachineMasterViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.InventoryMachineMasterDTO != null)
                    {
                        model.InventoryMachineMasterDTO.ConnectionString = _connectioString;
                        model.InventoryMachineMasterDTO.MachineName = model.MachineName;
                       // model.InventoryMachineMasterDTO.SeqNo = model.SeqNo; ;
                        model.InventoryMachineMasterDTO.MachineCode = model.MachineCode;
                        model.InventoryMachineMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryMachineMaster> response = _InventoryMachineMasterServiceAcess.InsertInventoryMachineMaster(model.InventoryMachineMasterDTO);
                        model.InventoryMachineMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.InventoryMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            InventoryMachineMasterViewModel model = new InventoryMachineMasterViewModel();
            try
            {                
                model.InventoryMachineMasterDTO = new InventoryMachineMaster();
                model.InventoryMachineMasterDTO.ID = id;
                model.InventoryMachineMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryMachineMaster> response = _InventoryMachineMasterServiceAcess.SelectByID(model.InventoryMachineMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryMachineMasterDTO.ID = response.Entity.ID;
                    model.InventoryMachineMasterDTO.MachineName = response.Entity.MachineName;
                   // model.InventoryMachineMasterDTO.SeqNo = response.Entity.SeqNo;
                    model.InventoryMachineMasterDTO.MachineCode = response.Entity.MachineCode;
                   // model.InventoryMachineMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.InventoryMachineMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/InventoryMachineMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryMachineMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryMachineMasterDTO != null)
                {
                    if (model != null && model.InventoryMachineMasterDTO != null)
                    {
                        model.InventoryMachineMasterDTO.ConnectionString = _connectioString;
                        model.InventoryMachineMasterDTO.MachineName = model.MachineName;
                       // model.InventoryMachineMasterDTO.SeqNo = model.SeqNo;
                        model.InventoryMachineMasterDTO.MachineCode = model.MachineCode;
                        model.InventoryMachineMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryMachineMaster> response = _InventoryMachineMasterServiceAcess.UpdateInventoryMachineMaster(model.InventoryMachineMasterDTO);
                        model.InventoryMachineMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    InventoryMachineMasterViewModel model = new InventoryMachineMasterViewModel();
        //    model.InventoryMachineMasterDTO = new InventoryMachineMaster();
        //    model.InventoryMachineMasterDTO.ID = ID;
        //    return PartialView("/Views/Inventory/InventoryMachineMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(InventoryMachineMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            InventoryMachineMaster InventoryMachineMasterDTO = new InventoryMachineMaster();
        //            InventoryMachineMasterDTO.ConnectionString = _connectioString;
        //            InventoryMachineMasterDTO.ID = model.ID;
        //            InventoryMachineMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<InventoryMachineMaster> response = _InventoryMachineMasterServiceAcess.DeleteInventoryMachineMaster(InventoryMachineMasterDTO);
        //            model.InventoryMachineMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.InventoryMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            InventoryMachineMasterViewModel model = new InventoryMachineMasterViewModel();
            if (ID > 0)
            {
                if (ID > 0)
                {
                    InventoryMachineMaster InventoryMachineMasterDTO = new InventoryMachineMaster();
                    InventoryMachineMasterDTO.ConnectionString = _connectioString;
                    InventoryMachineMasterDTO.ID = ID;
                    InventoryMachineMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryMachineMaster> response = _InventoryMachineMasterServiceAcess.DeleteInventoryMachineMaster(InventoryMachineMasterDTO);
                    model.InventoryMachineMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.InventoryMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryMachineMasterViewModel> GetInventoryMachineMaster(out int TotalRecords)
        {
            InventoryMachineMasterSearchRequest searchRequest = new InventoryMachineMasterSearchRequest();
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
            List<InventoryMachineMasterViewModel> listInventoryMachineMasterViewModel = new List<InventoryMachineMasterViewModel>();
            List<InventoryMachineMaster> listInventoryMachineMaster = new List<InventoryMachineMaster>();
            IBaseEntityCollectionResponse<InventoryMachineMaster> baseEntityCollectionResponse = _InventoryMachineMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryMachineMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryMachineMaster item in listInventoryMachineMaster)
                    {
                        InventoryMachineMasterViewModel InventoryMachineMasterViewModel = new InventoryMachineMasterViewModel();
                        InventoryMachineMasterViewModel.InventoryMachineMasterDTO = item;
                        listInventoryMachineMasterViewModel.Add(InventoryMachineMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryMachineMasterViewModel;
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

                IEnumerable<InventoryMachineMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "MachineName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "MachineName Like '%" + param.sSearch + "%' or MachineCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "MachineCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "MachineName Like '%" + param.sSearch + "%' or MachineCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetInventoryMachineMaster(out TotalRecords);
                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<InventoryMachineMasterViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.MachineName.ToString(), c.MachineCode.ToString(), Convert.ToString(c.ID) };

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