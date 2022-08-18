
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
    public class GeneralPaperSetMasterController : BaseController
    {
        IGeneralPaperSetMasterServiceAccess _GeneralPaperSetMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPaperSetMasterController()
        {
            _GeneralPaperSetMasterServiceAcess = new GeneralPaperSetMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/OnlineExam/GeneralPaperSetMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralPaperSetMasterViewModel model = new GeneralPaperSetMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/OnlineExam/GeneralPaperSetMaster/List.cshtml", model);
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
            GeneralPaperSetMasterViewModel model = new GeneralPaperSetMasterViewModel();

            return PartialView("/Views/OnlineExam/GeneralPaperSetMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPaperSetMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralPaperSetMasterDTO != null)
                {
                    model.GeneralPaperSetMasterDTO.ConnectionString = _connectioString;
                    model.GeneralPaperSetMasterDTO.PaperSetCode = model.PaperSetCode;
                    //model.GeneralPaperSetMasterDTO.MovementCode = model.MovementCode;
                    //model.GeneralPaperSetMasterDTO.IsActive = model.IsActive;
                    model.GeneralPaperSetMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPaperSetMaster> response = _GeneralPaperSetMasterServiceAcess.InsertGeneralPaperSetMaster(model.GeneralPaperSetMasterDTO);

                    model.GeneralPaperSetMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralPaperSetMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    GeneralPaperSetMasterViewModel model = new GeneralPaperSetMasterViewModel();
        //    try
        //    {
        //        model.GeneralPaperSetMasterDTO = new GeneralPaperSetMaster();
        //        model.GeneralPaperSetMasterDTO.ID = id;
        //        model.GeneralPaperSetMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralPaperSetMaster> response = _GeneralPaperSetMasterServiceAcess.SelectByID(model.GeneralPaperSetMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralPaperSetMasterDTO.ID = response.Entity.ID;
        //            model.GeneralPaperSetMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralPaperSetMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralPaperSetMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(GeneralPaperSetMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralPaperSetMasterDTO != null)
                {
                    if (model != null && model.GeneralPaperSetMasterDTO != null)
                    {
                        model.GeneralPaperSetMasterDTO.ConnectionString = _connectioString;
                        model.GeneralPaperSetMasterDTO.PaperSetCode = model.PaperSetCode;
                        //model.GeneralPaperSetMasterDTO.MovementCode = model.MovementCode;
                        //model.GeneralPaperSetMasterDTO.IsActive = model.IsActive;
                      
                        model.GeneralPaperSetMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPaperSetMaster> response = _GeneralPaperSetMasterServiceAcess.UpdateGeneralPaperSetMaster(model.GeneralPaperSetMasterDTO);
                        model.GeneralPaperSetMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralPaperSetMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralPaperSetMasterViewModel model = new GeneralPaperSetMasterViewModel();
        //        model.GeneralPaperSetMasterDTO = new GeneralPaperSetMaster();
        //        model.GeneralPaperSetMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralPaperSetMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralPaperSetMaster> response = _GeneralPaperSetMasterServiceAcess.SelectByID(model.GeneralPaperSetMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralPaperSetMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralPaperSetMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralPaperSetMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralPaperSetMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralPaperSetMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralPaperSetMaster> response = null;
                GeneralPaperSetMaster GeneralPaperSetMasterDTO = new GeneralPaperSetMaster();
                GeneralPaperSetMasterDTO.ConnectionString = _connectioString;
                GeneralPaperSetMasterDTO.ID = Convert.ToByte(ID);
                GeneralPaperSetMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralPaperSetMasterServiceAcess.DeleteGeneralPaperSetMaster(GeneralPaperSetMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralPaperSetMasterViewModel> GetGeneralPaperSetMaster(out int TotalRecords)
        {
            GeneralPaperSetMasterSearchRequest searchRequest = new GeneralPaperSetMasterSearchRequest();
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
            List<GeneralPaperSetMasterViewModel> listGeneralPaperSetMasterViewModel = new List<GeneralPaperSetMasterViewModel>();
            List<GeneralPaperSetMaster> listGeneralPaperSetMaster = new List<GeneralPaperSetMaster>();
            IBaseEntityCollectionResponse<GeneralPaperSetMaster> baseEntityCollectionResponse = _GeneralPaperSetMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPaperSetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPaperSetMaster item in listGeneralPaperSetMaster)
                    {
                        GeneralPaperSetMasterViewModel GeneralPaperSetMasterViewModel = new GeneralPaperSetMasterViewModel();
                        GeneralPaperSetMasterViewModel.GeneralPaperSetMasterDTO = item;
                        listGeneralPaperSetMasterViewModel.Add(GeneralPaperSetMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPaperSetMasterViewModel;
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

                IEnumerable<GeneralPaperSetMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.PaperSetCode Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.PaperSetCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.PaperSetCode Like '%" + param.sSearch + "%' or A.ID Like '%" + param.sSearch + "%'"; //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralPaperSetMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PaperSetCode), Convert.ToString(c.ID) };

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