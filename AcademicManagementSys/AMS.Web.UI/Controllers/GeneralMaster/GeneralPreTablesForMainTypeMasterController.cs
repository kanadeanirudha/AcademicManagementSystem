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
    public class GeneralPreTablesForMainTypeMasterController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IGeneralPreTablesForMainTypeMasterServiceAccess _generalPreTablesForMainTypeMasterServiceAccess;
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
        public GeneralPreTablesForMainTypeMasterController()
        {
            _generalPreTablesForMainTypeMasterServiceAccess = new GeneralPreTablesForMainTypeMasterServiceAccess();
        }

        #endregion




        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            return View("/Views/GeneralMaster/GeneralPreTablesForMainTypeMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            GeneralPreTablesForMainTypeMasterViewModel _generalPreTablesForMainTypeMasterViewModel = new GeneralPreTablesForMainTypeMasterViewModel();
            if (!string.IsNullOrEmpty(actionMode))
            {
                TempData["ActionMode"] = actionMode;
            }
            return PartialView("/Views/GeneralMaster/GeneralPreTablesForMainTypeMaster/List.cshtml", _generalPreTablesForMainTypeMasterViewModel);
        }

        public ActionResult Create()
        {
            GeneralPreTablesForMainTypeMasterViewModel _generalPreTablesForMainTypeMasterViewModel = new GeneralPreTablesForMainTypeMasterViewModel();

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

            //---------------------------Get Database Table List--------------------------------
            List<GeneralTaskReportingDetails> userDatabaseTableNameList = GetAMSDatabaseTableNameList();
            List<SelectListItem> listDatabaseTableNameList = new List<SelectListItem>();
            foreach (GeneralTaskReportingDetails item in userDatabaseTableNameList)
            {
                listDatabaseTableNameList.Add(new SelectListItem { Text = item.TableName, Value = item.TableName });
            }

            //---------------------------Get Database Table Name and Display Feilds.--------------------------------
            ViewBag.GetAMSDatabseTableNameList = new SelectList(listDatabaseTableNameList, "Value", "Text");
            ViewBag.GetAMSDatabseTablePrimaryKey = new List<SelectListItem>();
            ViewBag.GetAMSDatabseTableFieldList = new List<SelectListItem>();

            return PartialView("/Views/GeneralMaster/GeneralPreTablesForMainTypeMaster/Create.cshtml", _generalPreTablesForMainTypeMasterViewModel);
        }

        [HttpPost]
        public ActionResult Create(GeneralPreTablesForMainTypeMasterViewModel model)
        {
            try
            {
                model.GeneralPreTablesForMainTypeMasterDTO.ConnectionString = _connectioString;
                model.GeneralPreTablesForMainTypeMasterDTO.RefTableEntity = model.RefTableEntity;
                model.GeneralPreTablesForMainTypeMasterDTO.RefTableEntityDisplayKey = model.RefTableEntityDisplayKey;
                model.GeneralPreTablesForMainTypeMasterDTO.RefTableEntityKey = model.RefTableEntityKey;
                model.GeneralPreTablesForMainTypeMasterDTO.ModuleCode = model.ModuleCode;
                model.GeneralPreTablesForMainTypeMasterDTO.MenuCode = model.MenuCode;
                model.GeneralPreTablesForMainTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> response = _generalPreTablesForMainTypeMasterServiceAccess.InsertGeneralPreTablesForMainTypeMaster(model.GeneralPreTablesForMainTypeMasterDTO);
                model.GeneralPreTablesForMainTypeMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.GeneralPreTablesForMainTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //public ActionResult Delete(int ID)
        //{
        //    GeneralPreTablesForMainTypeMasterViewModel model = new GeneralPreTablesForMainTypeMasterViewModel();
        //    model.GeneralPreTablesForMainTypeMasterDTO = new GeneralPreTablesForMainTypeMaster();
        //    model.GeneralPreTablesForMainTypeMasterDTO.ID = ID;
        //    return PartialView("/Views/GeneralMaster/GeneralPreTablesForMainTypeMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralPreTablesForMainTypeMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralPreTablesForMainTypeMaster GeneralPreTablesForMainTypeMasterDTO = new GeneralPreTablesForMainTypeMaster();
        //            GeneralPreTablesForMainTypeMasterDTO.ConnectionString = _connectioString;
        //            GeneralPreTablesForMainTypeMasterDTO.ID = model.ID;
        //            GeneralPreTablesForMainTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> response = _generalPreTablesForMainTypeMasterServiceAccess.DeleteGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMasterDTO);
        //            model.GeneralPreTablesForMainTypeMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            return Json(model.GeneralPreTablesForMainTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(int ID)
        {
            GeneralPreTablesForMainTypeMasterViewModel model = new GeneralPreTablesForMainTypeMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    GeneralPreTablesForMainTypeMaster GeneralPreTablesForMainTypeMasterDTO = new GeneralPreTablesForMainTypeMaster();
                    GeneralPreTablesForMainTypeMasterDTO.ConnectionString = _connectioString;
                    GeneralPreTablesForMainTypeMasterDTO.ID = ID;
                    GeneralPreTablesForMainTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> response = _generalPreTablesForMainTypeMasterServiceAccess.DeleteGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMasterDTO);
                    model.GeneralPreTablesForMainTypeMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.GeneralPreTablesForMainTypeMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<GeneralPreTablesForMainTypeMasterViewModel> GetGeneralPreTablesForMainTypeMaster(out int TotalRecords)
        {
            GeneralPreTablesForMainTypeMasterSearchRequest searchRequest = new GeneralPreTablesForMainTypeMasterSearchRequest();
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

            List<GeneralPreTablesForMainTypeMasterViewModel> listGeneralPreTablesForMainTypeMasterViewModel = new List<GeneralPreTablesForMainTypeMasterViewModel>();
            List<GeneralPreTablesForMainTypeMaster> listGeneralPreTables = new List<GeneralPreTablesForMainTypeMaster>();
            IBaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster> baseEntityCollectionResponse = _generalPreTablesForMainTypeMasterServiceAccess.GetBySearch(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPreTables = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPreTablesForMainTypeMaster item in listGeneralPreTables)
                    {
                        GeneralPreTablesForMainTypeMasterViewModel generalPreTablesForMainTypeMasterViewModel = new GeneralPreTablesForMainTypeMasterViewModel();
                        generalPreTablesForMainTypeMasterViewModel.GeneralPreTablesForMainTypeMasterDTO = item;
                        listGeneralPreTablesForMainTypeMasterViewModel.Add(generalPreTablesForMainTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPreTablesForMainTypeMasterViewModel;
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
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

                IEnumerable<GeneralPreTablesForMainTypeMasterViewModel> filteredGeneralPreTablesForMainVM;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "C.ModuleName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' or A.RefTableEntityKey Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;

                    case 1:
                        _sortBy = "B.MenuName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' or A.RefTableEntityKey Like '%" + param.sSearch + "%' ";       //this "if" block is added for search functionality
                        }
                        break;

                    case 2:
                        _sortBy = "A.RefTableEntity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' or A.RefTableEntityKey Like '%" + param.sSearch + "%' ";       //this "if" block is added for search functionality
                        }
                        break;

                    case 3:
                        _sortBy = "A.RefTableEntityKey";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "C.ModuleName Like '%" + param.sSearch + "%' or B.MenuName Like '%" + param.sSearch + "%' or A.RefTableEntity Like '%" + param.sSearch + "%' or A.RefTableEntityKey Like '%" + param.sSearch + "%' ";       //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                filteredGeneralPreTablesForMainVM = GetGeneralPreTablesForMainTypeMaster(out TotalRecords);
                var records = filteredGeneralPreTablesForMainVM.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ModuleName), Convert.ToString(c.MenuName), Convert.ToString(c.RefTableEntity), Convert.ToString(c.RefTableEntityKey), Convert.ToString(c.ID) };

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

