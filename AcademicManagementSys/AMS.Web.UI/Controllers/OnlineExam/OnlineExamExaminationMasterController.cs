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
    public class OnlineExamExaminationMasterController : BaseController
    {
        IOnlineExamExaminationMasterServiceAccess _OnlineExamExaminationMasterServiceAcess = null;

        IGeneralSessionMasterServiceAccess _GeneralSessionMasterServiceAccess=null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OnlineExamExaminationMasterController()
        {
            _OnlineExamExaminationMasterServiceAcess = new OnlineExamExaminationMasterServiceAccess();

            _GeneralSessionMasterServiceAccess = new GeneralSessionMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/OnlineExam/OnlineExamExaminationMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OnlineExamExaminationMasterViewModel model = new OnlineExamExaminationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/OnlineExam/OnlineExamExaminationMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(String actionMode)
        {
            OnlineExamExaminationMasterViewModel model = new OnlineExamExaminationMasterViewModel();
            //*************Static DropDownList For ExaminationFor**********************************
                      List<SelectListItem> ExaminationFor = new List<SelectListItem>();
                      ViewBag.ExaminationFor = new SelectList(ExaminationFor, "Value", "Text");
                      List<SelectListItem> li_ExaminationFor = new List<SelectListItem>();
                      li_ExaminationFor.Add(new SelectListItem { Text = "Academic", Value = "Academic" });
                      li_ExaminationFor.Add(new SelectListItem { Text = "Entrance", Value = "Entrance" });
                      li_ExaminationFor.Add(new SelectListItem { Text = "Other", Value = "Other" });

                     ViewBag.ExaminationFor = li_ExaminationFor;
                     if (!string.IsNullOrEmpty(actionMode))
                    {
                       TempData["ActionMode"] = actionMode;
                    }
            

           //************************** Dynamic Drop Down For Academic Session id **********************

                     List<GeneralSessionMaster> GeneralSessionMaster = GetListGeneralSessionMaster();
                     List<SelectListItem> GeneralSessionMasterList = new List<SelectListItem>();

                     foreach (GeneralSessionMaster item in GeneralSessionMaster)
                     {
                         GeneralSessionMasterList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
                     }
                     ViewBag.GeneralSessionMasterListt = new SelectList(GeneralSessionMasterList, "Value", "Text");


            return PartialView("/Views/OnlineExam/OnlineExamExaminationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExamExaminationMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.OnlineExamExaminationMasterDTO != null)
                {
                    model.OnlineExamExaminationMasterDTO.ConnectionString = _connectioString;
                    model.OnlineExamExaminationMasterDTO.ExaminationName = model.ExaminationName;
                    model.OnlineExamExaminationMasterDTO.Purpose= model.Purpose;
                    model.OnlineExamExaminationMasterDTO.AcadSessionId = model.AcadSessionId;
                    model.OnlineExamExaminationMasterDTO.ExaminationFor = model.ExaminationFor;
                    model.OnlineExamExaminationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OnlineExamExaminationMaster> response = _OnlineExamExaminationMasterServiceAcess.InsertOnlineExamExaminationMaster(model.OnlineExamExaminationMasterDTO);

                    model.OnlineExamExaminationMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OnlineExamExaminationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    OnlineExamExaminationMasterViewModel model = new OnlineExamExaminationMasterViewModel();
        //    try
        //    {
        //        model.OnlineExamExaminationMasterDTO = new OnlineExamExaminationMaster();
        //        model.OnlineExamExaminationMasterDTO.ID = id;
        //        model.OnlineExamExaminationMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<OnlineExamExaminationMaster> response = _OnlineExamExaminationMasterServiceAcess.SelectByID(model.OnlineExamExaminationMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.OnlineExamExaminationMasterDTO.ID = response.Entity.ID;
        //            model.OnlineExamExaminationMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.OnlineExamExaminationMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.OnlineExamExaminationMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(OnlineExamExaminationMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.OnlineExamExaminationMasterDTO != null)
        //        {
        //            if (model != null && model.OnlineExamExaminationMasterDTO != null)
        //            {
        //                model.OnlineExamExaminationMasterDTO.ConnectionString = _connectioString;
        //                model.OnlineExamExaminationMasterDTO.MovementType = model.MovementType;
        //                model.OnlineExamExaminationMasterDTO.MovementCode = model.MovementCode;
        //                model.OnlineExamExaminationMasterDTO.IsActive = model.IsActive;
                      
        //                model.OnlineExamExaminationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<OnlineExamExaminationMaster> response = _OnlineExamExaminationMasterServiceAcess.UpdateOnlineExamExaminationMaster(model.OnlineExamExaminationMasterDTO);
        //                model.OnlineExamExaminationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.OnlineExamExaminationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        OnlineExamExaminationMasterViewModel model = new OnlineExamExaminationMasterViewModel();
        //        model.OnlineExamExaminationMasterDTO = new OnlineExamExaminationMaster();
        //        model.OnlineExamExaminationMasterDTO.ID = Convert.ToInt16(ID);
        //        model.OnlineExamExaminationMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<OnlineExamExaminationMaster> response = _OnlineExamExaminationMasterServiceAcess.SelectByID(model.OnlineExamExaminationMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.OnlineExamExaminationMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.OnlineExamExaminationMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.OnlineExamExaminationMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.OnlineExamExaminationMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/OnlineExamExaminationMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<OnlineExamExaminationMaster> response = null;
                OnlineExamExaminationMaster OnlineExamExaminationMasterDTO = new OnlineExamExaminationMaster();
                OnlineExamExaminationMasterDTO.ConnectionString = _connectioString;
                OnlineExamExaminationMasterDTO.ID = Convert.ToInt32(ID);
                OnlineExamExaminationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _OnlineExamExaminationMasterServiceAcess.DeleteOnlineExamExaminationMaster(OnlineExamExaminationMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        //Dropdown For Session
        protected List<GeneralSessionMaster> GetListGeneralSessionMaster()
        {
            GeneralSessionMasterSearchRequest searchRequest = new GeneralSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralSessionMaster> listGeneralSessionMaster = new List<GeneralSessionMaster>();
            IBaseEntityCollectionResponse<GeneralSessionMaster> baseEntityCollectionResponse = _GeneralSessionMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralSessionMaster;
        }



        public IEnumerable<OnlineExamExaminationMasterViewModel> GetOnlineExamExaminationMaster(out int TotalRecords)
        {
            OnlineExamExaminationMasterSearchRequest searchRequest = new OnlineExamExaminationMasterSearchRequest();
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
            List<OnlineExamExaminationMasterViewModel> listOnlineExamExaminationMasterViewModel = new List<OnlineExamExaminationMasterViewModel>();
            List<OnlineExamExaminationMaster> listOnlineExamExaminationMaster = new List<OnlineExamExaminationMaster>();
            IBaseEntityCollectionResponse<OnlineExamExaminationMaster> baseEntityCollectionResponse = _OnlineExamExaminationMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamExaminationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamExaminationMaster item in listOnlineExamExaminationMaster)
                    {
                        OnlineExamExaminationMasterViewModel OnlineExamExaminationMasterViewModel = new OnlineExamExaminationMasterViewModel();
                        OnlineExamExaminationMasterViewModel.OnlineExamExaminationMasterDTO = item;
                        listOnlineExamExaminationMasterViewModel.Add(OnlineExamExaminationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamExaminationMasterViewModel;
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

                IEnumerable<OnlineExamExaminationMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ExaminationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%"+param.sSearch+"%' or A.ExaminationFor Like'%"+param.sSearch+"%'";  //this if block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.Purpose";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%" + param.sSearch + "%' or A.ExaminationFor Like'%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.AcadSessionId";
                        if(string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%" + param.sSearch + "%' or A.ExaminationFor Like'%" + param.sSearch + "%'"; //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "A.ExaminationFor";
                        if(string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%" + param.sSearch + "%' or A.ExaminationFor Like'%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetOnlineExamExaminationMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ExaminationName), Convert.ToString(c.Purpose),Convert.ToString(c.AcadSessionId),Convert.ToString(c.SessionName),Convert.ToString(c.ExaminationFor),Convert.ToString(c.ID)};

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