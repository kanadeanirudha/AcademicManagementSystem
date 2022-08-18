
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
    public class GeneralQuestionLevelMasterController : BaseController
    {
        IGeneralQuestionLevelMasterServiceAccess _GeneralQuestionLevelMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralQuestionLevelMasterController()
        {
            _GeneralQuestionLevelMasterServiceAcess = new GeneralQuestionLevelMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/OnlineExam/GeneralQuestionLevelMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralQuestionLevelMasterViewModel model = new GeneralQuestionLevelMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/OnlineExam/GeneralQuestionLevelMaster/List.cshtml", model);
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
            GeneralQuestionLevelMasterViewModel model = new GeneralQuestionLevelMasterViewModel();

            return PartialView("/Views/OnlineExam/GeneralQuestionLevelMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralQuestionLevelMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralQuestionLevelMasterDTO != null)
                {
                    model.GeneralQuestionLevelMasterDTO.ConnectionString = _connectioString;
                    model.GeneralQuestionLevelMasterDTO.LevelDescription = model.LevelDescription;
                    model.GeneralQuestionLevelMasterDTO.LevelCode = model.LevelCode;
                   // model.GeneralQuestionLevelMasterDTO.IsActive = model.IsActive;
                    model.GeneralQuestionLevelMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralQuestionLevelMaster> response = _GeneralQuestionLevelMasterServiceAcess.InsertGeneralQuestionLevelMaster(model.GeneralQuestionLevelMasterDTO);

                    model.GeneralQuestionLevelMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralQuestionLevelMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    GeneralQuestionLevelMasterViewModel model = new GeneralQuestionLevelMasterViewModel();
        //    try
        //    {
        //        model.GeneralQuestionLevelMasterDTO = new GeneralQuestionLevelMaster();
        //        model.GeneralQuestionLevelMasterDTO.ID = id;
        //        model.GeneralQuestionLevelMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralQuestionLevelMaster> response = _GeneralQuestionLevelMasterServiceAcess.SelectByID(model.GeneralQuestionLevelMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralQuestionLevelMasterDTO.ID = response.Entity.ID;
        //            model.GeneralQuestionLevelMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralQuestionLevelMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralQuestionLevelMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(GeneralQuestionLevelMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.GeneralQuestionLevelMasterDTO != null)
        //        {
        //            if (model != null && model.GeneralQuestionLevelMasterDTO != null)
        //            {
        //                model.GeneralQuestionLevelMasterDTO.ConnectionString = _connectioString;
        //                model.GeneralQuestionLevelMasterDTO.MovementType = model.MovementType;
        //                model.GeneralQuestionLevelMasterDTO.MovementCode = model.MovementCode;
        //                model.GeneralQuestionLevelMasterDTO.IsActive = model.IsActive;
                      
        //                model.GeneralQuestionLevelMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<GeneralQuestionLevelMaster> response = _GeneralQuestionLevelMasterServiceAcess.UpdateGeneralQuestionLevelMaster(model.GeneralQuestionLevelMasterDTO);
        //                model.GeneralQuestionLevelMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.GeneralQuestionLevelMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralQuestionLevelMasterViewModel model = new GeneralQuestionLevelMasterViewModel();
        //        model.GeneralQuestionLevelMasterDTO = new GeneralQuestionLevelMaster();
        //        model.GeneralQuestionLevelMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralQuestionLevelMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralQuestionLevelMaster> response = _GeneralQuestionLevelMasterServiceAcess.SelectByID(model.GeneralQuestionLevelMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralQuestionLevelMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralQuestionLevelMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralQuestionLevelMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralQuestionLevelMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralQuestionLevelMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralQuestionLevelMaster> response = null;
                GeneralQuestionLevelMaster GeneralQuestionLevelMasterDTO = new GeneralQuestionLevelMaster();
                GeneralQuestionLevelMasterDTO.ConnectionString = _connectioString;
                GeneralQuestionLevelMasterDTO.ID = Convert.ToInt32(ID);
                GeneralQuestionLevelMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralQuestionLevelMasterServiceAcess.DeleteGeneralQuestionLevelMaster(GeneralQuestionLevelMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralQuestionLevelMasterViewModel> GetGeneralQuestionLevelMaster(out int TotalRecords)
        {
            GeneralQuestionLevelMasterSearchRequest searchRequest = new GeneralQuestionLevelMasterSearchRequest();
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
            List<GeneralQuestionLevelMasterViewModel> listGeneralQuestionLevelMasterViewModel = new List<GeneralQuestionLevelMasterViewModel>();
            List<GeneralQuestionLevelMaster> listGeneralQuestionLevelMaster = new List<GeneralQuestionLevelMaster>();
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> baseEntityCollectionResponse = _GeneralQuestionLevelMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralQuestionLevelMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralQuestionLevelMaster item in listGeneralQuestionLevelMaster)
                    {
                        GeneralQuestionLevelMasterViewModel GeneralQuestionLevelMasterViewModel = new GeneralQuestionLevelMasterViewModel();
                        GeneralQuestionLevelMasterViewModel.GeneralQuestionLevelMasterDTO = item;
                        listGeneralQuestionLevelMasterViewModel.Add(GeneralQuestionLevelMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralQuestionLevelMasterViewModel;
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

                IEnumerable<GeneralQuestionLevelMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.LevelDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.LevelCode Like '%" + param.sSearch + "%' or A.LevelDescription Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.LevelCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.LevelDescription Like '%" + param.sSearch + "%' or A.LevelCode Like '%" + param.sSearch + "%'"; //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralQuestionLevelMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.LevelDescription), Convert.ToString(c.LevelCode),Convert.ToString(c.ID) };

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