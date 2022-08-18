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

namespace AMS.Web.UI.Controllers.GeneralMaster
{
    public class GeneralMainTypeMasterController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IGeneralMainTypeMasterServiceAccess _generalMainTypeMasterServiceAccess;
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
        public GeneralMainTypeMasterController()
        {
            _generalMainTypeMasterServiceAccess = new GeneralMainTypeMasterServiceAccess();
        }

        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            return View("/Views/GeneralMaster/GeneralMainTypeMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            GeneralMainTypeMasterViewModel model = new GeneralMainTypeMasterViewModel();
            if (!string.IsNullOrEmpty(actionMode))
            {
                TempData["ActionMode"] = actionMode;
            }
            return PartialView("/Views/GeneralMaster/GeneralMainTypeMaster/List.cshtml", model);
        }

        public ActionResult Create()
        {
            GeneralMainTypeMasterViewModel model = new GeneralMainTypeMasterViewModel();

            // -----------------------------Get User Module List.----------------
            List<UserModuleMaster> userModuleMasterList = GetUserModuleMasterList();
            List<SelectListItem> listUserModuleMasterList = new List<SelectListItem>();
            foreach (UserModuleMaster item in userModuleMasterList)
            {
                listUserModuleMasterList.Add(new SelectListItem { Text = item.ModuleName, Value = item.ModuleCode });
            }
            ViewBag.GeneralUserModuleCodeMasterList = new SelectList(listUserModuleMasterList, "Value", "Text");

            //-----------------------------Get User Main Menu List---------------------           
            ViewBag.GeneralUserMenuCodeMasterList = new List<SelectListItem>();

            //----------------------------Get Transaction Type List--------------------
            List<AccountTransactionTypeMaster> accTransactionTypeMasterList = GetListOfAccountTransactionType();
            List<SelectListItem> listTransaction = new List<SelectListItem>();
            foreach (AccountTransactionTypeMaster item in accTransactionTypeMasterList)
            {
                listTransaction.Add(new SelectListItem { Text = item.TransactionTypeName, Value = Convert.ToString(item.TransactionTypeCode) });
            }
            ViewBag.GeneralAccTransactionTypeMasterList = new SelectList(listTransaction, "Value", "Text");

            //---------------------------
            ViewBag.GeneralRefTableEntityDisplayKeyList = new List<SelectListItem>();

            return PartialView("/Views/GeneralMaster/GeneralMainTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralMainTypeMasterViewModel model)
        {
            try
            {
                model.GeneralMainTypeMasterDTO.ConnectionString = _connectioString;
                model.GeneralMainTypeMasterDTO.TypeDesc = model.TypeDesc;
                model.GeneralMainTypeMasterDTO.TypeShortDesc = model.TypeShortDesc;
                model.GeneralMainTypeMasterDTO.ModuleCode = model.ModuleCode;
                model.GeneralMainTypeMasterDTO.MenuCode = model.MenuCode;
                model.GeneralMainTypeMasterDTO.IsFixed = model.IsFixed;
                model.GeneralMainTypeMasterDTO.SubTypeDesc = model.SubTypeDesc;
                model.GeneralMainTypeMasterDTO.SubShortDesc = model.SubShortDesc;
                model.GeneralMainTypeMasterDTO.TransactionType = model.TransactionType;
                model.GeneralMainTypeMasterDTO.KeyCode = model.KeyCode;
                model.GeneralMainTypeMasterDTO.RefTableEntityDisplayKey = model.RefTableEntityDisplayKey;
                model.GeneralMainTypeMasterDTO.RefTableEntity = model.RefTableEntity;
                model.GeneralMainTypeMasterDTO.RefTableEntityKey = model.RefTableEntityKey;
                model.GeneralMainTypeMasterDTO.RefTableEntityKeyValue = model.RefTableEntityKeyValue;
                model.GeneralMainTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                
                model.GeneralMainTypeMasterDTO.IsActive = model.IsActive;

                IBaseEntityResponse<GeneralMainTypeMaster> response = _generalMainTypeMasterServiceAccess.InsertGeneralMainTypeMaster(model.GeneralMainTypeMasterDTO);
                model.GeneralMainTypeMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.GeneralMainTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //public ActionResult Delete(int ID)
        //{
        //    GeneralMainTypeMasterViewModel model = new GeneralMainTypeMasterViewModel();
        //    model.GeneralMainTypeMasterDTO = new GeneralMainTypeMaster();
        //    model.GeneralMainTypeMasterDTO.ID = ID;
        //    return PartialView("/Views/GeneralMaster/GeneralMainTypeMaster/Delete.cshtml", model);
        //}


        //[HttpPost]
        //public ActionResult Delete(GeneralMainTypeMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralMainTypeMaster GeneralMainTypeMasterDTO = new GeneralMainTypeMaster();
        //            GeneralMainTypeMasterDTO.ConnectionString = _connectioString;
        //            GeneralMainTypeMasterDTO.ID = model.ID;
        //            GeneralMainTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralMainTypeMaster> response = _generalMainTypeMasterServiceAccess.DeleteGeneralMainTypeMaster(GeneralMainTypeMasterDTO);
        //            model.GeneralMainTypeMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            return Json(model.GeneralMainTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(Resources.DisplayMessage_PleaseReviewYourForm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            GeneralMainTypeMasterViewModel model = new GeneralMainTypeMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    GeneralMainTypeMaster GeneralMainTypeMasterDTO = new GeneralMainTypeMaster();
                    GeneralMainTypeMasterDTO.ConnectionString = _connectioString;
                    GeneralMainTypeMasterDTO.ID = ID;
                    GeneralMainTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralMainTypeMaster> response = _generalMainTypeMasterServiceAccess.DeleteGeneralMainTypeMaster(GeneralMainTypeMasterDTO);
                    model.GeneralMainTypeMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.GeneralMainTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        // Non-Action Method
        #region Methods

        public IEnumerable<GeneralMainTypeMasterViewModel> GetGeneralMainTypeMaster(out int TotalRecords)
        {
            GeneralMainTypeMasterSearchRequest searchRequest = new GeneralMainTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);

            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
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

            List<GeneralMainTypeMasterViewModel> listGeneralMainTypeMasterViewModel = new List<GeneralMainTypeMasterViewModel>();
            List<GeneralMainTypeMaster> listGeneralMainType = new List<GeneralMainTypeMaster>();
            IBaseEntityCollectionResponse<GeneralMainTypeMaster> baseEntityCollectionResponse = _generalMainTypeMasterServiceAccess.GetBySearch(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralMainType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralMainTypeMaster item in listGeneralMainType)
                    {
                        GeneralMainTypeMasterViewModel generalMainTypeMasterViewModel = new GeneralMainTypeMasterViewModel();
                        generalMainTypeMasterViewModel.GeneralMainTypeMasterDTO = item;
                        listGeneralMainTypeMasterViewModel.Add(generalMainTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralMainTypeMasterViewModel;
        }


        //Get Menu List From Module Code.
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUserMenuMasterList(string moduleCode)
        {
            try
            {
                var menuList = GetUserMainMenuMasterList(!string.IsNullOrEmpty(moduleCode) ? moduleCode : string.Empty);
                return Json(menuList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //Get Data from GeneralPreTableForMain to bind hidden fields.
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetGeneralPreTableforMainMaster(string moduleCode, string menuCode)
        {
            try
            {
                GeneralPreTablesForMainTypeMasterViewModel generalPreTableForMainMaster = new GeneralPreTablesForMainTypeMasterViewModel();
                generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                GeneralPreTablesForMainTypeMaster data = new GeneralPreTablesForMainTypeMaster();

                generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO.ModuleCode = moduleCode;
                generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO.MenuCode = menuCode;
                IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> response = _generalMainTypeMasterServiceAccess.GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO);
                if (response.Entity != null)
                {
                    generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO.RefTableEntity = response.Entity.RefTableEntity;
                    generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO.RefTableEntityKey = response.Entity.RefTableEntityKey;
                    generalPreTableForMainMaster.GeneralPreTablesForMainTypeMasterDTO.RefTableEntityDisplayKey = response.Entity.RefTableEntityDisplayKey;
                }
                return Json(generalPreTableForMainMaster, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        //Get Table field from table name.
        public ActionResult GetTableFielsList(string tableName)
        {
            try
            {
                var primaryKeyList = GetDatabaseTablePrimaryKeyList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var primaryKey = (from k in primaryKeyList
                                  select new
                                  {
                                      id = k.TaskApprovalParamPrimaryKey,
                                      name = k.TaskApprovalParamPrimaryKey
                                  }).ToList();
                var TableDisplayFeild = GetTableDisplayFieldList(!string.IsNullOrEmpty(tableName) ? tableName : string.Empty);
                var displayField = (from s in TableDisplayFeild
                                    select new
                                    {
                                        id = s.TaskApprovalTableDisplayField,
                                        name = s.TaskApprovalTableDisplayField
                                    }).ToList();
                var TableFeild = new { PrimaryKey = primaryKey, DisplayField = displayField };
                return Json(TableFeild, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //Get Refrence Table value
        public ActionResult GetRefrenceTableRecord(string refTableEntity, string refTableEntityKey, string refTableEntityKeyValue)
        {
            var RefrenceTableRecord = GetTaskApprovalKeyValueList(!string.IsNullOrEmpty(refTableEntity) ? refTableEntity : string.Empty, !string.IsNullOrEmpty(refTableEntityKey) ? refTableEntityKey : string.Empty, !string.IsNullOrEmpty(refTableEntityKeyValue) ? refTableEntityKeyValue : string.Empty);
            //var RefrenceKeyValue = (from item in RefrenceTableRecord
            //                        select new
            //                            {
            //                              id = item.DisplayField,
            //                              name = item.DisplayField
            //                            }).ToList();
            return Json(RefrenceTableRecord, JsonRequestBehavior.AllowGet);
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

                IEnumerable<GeneralMainTypeMasterViewModel> filteredGeneralMainTypeMasterVM;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TypeDesc";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TypeDesc Like '%" + param.sSearch + "%' or A.TypeShortDesc Like '%" + param.sSearch + "%' or C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;

                    case 1:
                        _sortBy = "A.TypeShortDesc";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TypeDesc Like '%" + param.sSearch + "%' or A.TypeShortDesc Like '%" + param.sSearch + "%' or C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;

                    case 2:
                        _sortBy = "C.ModuleName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TypeDesc Like '%" + param.sSearch + "%' or A.TypeShortDesc Like '%" + param.sSearch + "%' or C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;

                    case 3:
                        _sortBy = "B.MenuName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TypeDesc Like '%" + param.sSearch + "%' or A.TypeShortDesc Like '%" + param.sSearch + "%' or C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;

                    case 4:
                        _sortBy = "A.RefTableEntity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.TypeDesc Like '%" + param.sSearch + "%' or A.TypeShortDesc Like '%" + param.sSearch + "%' or C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                filteredGeneralMainTypeMasterVM = GetGeneralMainTypeMaster(out TotalRecords);
                var records = filteredGeneralMainTypeMasterVM.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.TypeDesc), Convert.ToString(c.TypeShortDesc), Convert.ToString(c.ModuleName), Convert.ToString(c.MenuName), Convert.ToString(c.RefTableEntity), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }


        }


        #endregion

    }
}
