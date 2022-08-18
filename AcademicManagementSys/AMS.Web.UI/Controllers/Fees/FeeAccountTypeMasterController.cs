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
    public class FeeAccountTypeMasterController : BaseController
    {
        IFeeAccountTypeMasterServiceAccess _FeeAccountTypeMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeeAccountTypeMasterController()
        {
            _FeeAccountTypeMasterServiceAcess = new FeeAccountTypeMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Fees/FeeAccountTypeMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                FeeAccountTypeMasterViewModel model = new FeeAccountTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fees/FeeAccountTypeMaster/List.cshtml", model);
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
            FeeAccountTypeMasterViewModel model = new FeeAccountTypeMasterViewModel();

            List<SelectListItem> FeeAccountTypeCode = new List<SelectListItem>();
            ViewBag.FeeAccountTypeCode = new SelectList(FeeAccountTypeCode, "Value", "Text");
            List<SelectListItem> li_FeeAccountTypeCode = new List<SelectListItem>();
            li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Student", Value = "1" });
            li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Scholarship", Value = "2" });
            li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Discount", Value = "3" });
            li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Special Scholarship", Value = "4" });
            ViewData["FeeAccountTypeCode"] = li_FeeAccountTypeCode;


            return PartialView("/Views/Fees/FeeAccountTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(FeeAccountTypeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.FeeAccountTypeMasterDTO != null)
                {
                    model.FeeAccountTypeMasterDTO.ConnectionString = _connectioString;

                    model.FeeAccountTypeMasterDTO.FeeAccountTypeCode = model.FeeAccountTypeCode;
                    model.FeeAccountTypeMasterDTO.FeeAccountTypeDesc = model.FeeAccountTypeDesc;
                    model.FeeAccountTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeeAccountTypeMaster> response = _FeeAccountTypeMasterServiceAcess.InsertFeeAccountTypeMaster(model.FeeAccountTypeMasterDTO);

                    model.FeeAccountTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.FeeAccountTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    FeeAccountTypeMasterViewModel model = new FeeAccountTypeMasterViewModel();
        //    try
        //    {
        //        model.FeeAccountTypeMasterDTO = new FeeAccountTypeMaster();
        //        model.FeeAccountTypeMasterDTO.ID = id;
        //        model.FeeAccountTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<FeeAccountTypeMaster> response = _FeeAccountTypeMasterServiceAcess.SelectByID(model.FeeAccountTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.FeeAccountTypeMasterDTO.ID = response.Entity.ID;
        //            model.FeeAccountTypeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.FeeAccountTypeMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.FeeAccountTypeMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(FeeAccountTypeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.FeeAccountTypeMasterDTO != null)
                {
                    if (model != null && model.FeeAccountTypeMasterDTO != null)
                    {
                        model.FeeAccountTypeMasterDTO.ConnectionString = _connectioString;
                        //model.FeeAccountTypeMasterDTO.FeeAccountTypeMasterCode = model.FeeAccountTypeMasterCode;
                        //model.FeeAccountTypeMasterDTO.FeeAccountTypeMasterDescription = model.FeeAccountTypeMasterDescription;
                        //model.FeeAccountTypeMasterDTO.IsRelatedTo = model.IsRelatedTo;
                        model.FeeAccountTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<FeeAccountTypeMaster> response = _FeeAccountTypeMasterServiceAcess.UpdateFeeAccountTypeMaster(model.FeeAccountTypeMasterDTO);
                        model.FeeAccountTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.FeeAccountTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                FeeAccountTypeMasterViewModel model = new FeeAccountTypeMasterViewModel();
                model.FeeAccountTypeMasterDTO = new FeeAccountTypeMaster();
                model.FeeAccountTypeMasterDTO.ID = Convert.ToInt16(ID);
                model.FeeAccountTypeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<FeeAccountTypeMaster> response = _FeeAccountTypeMasterServiceAcess.SelectByID(model.FeeAccountTypeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.FeeAccountTypeMasterDTO.FeeAccountTypeDesc = response.Entity.FeeAccountTypeDesc;
                    model.FeeAccountTypeMasterDTO.FeeAccountTypeCode = response.Entity.FeeAccountTypeCode;
                }

                List<SelectListItem> FeeAccountTypeCode = new List<SelectListItem>();
                ViewBag.FeeAccountTypeCode = new SelectList(FeeAccountTypeCode, "Value", "Text");
                List<SelectListItem> li_FeeAccountTypeCode = new List<SelectListItem>();
                li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Student", Value = "1" });
                li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Scholarship", Value = "2" });
                li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Discount", Value = "3" });
                li_FeeAccountTypeCode.Add(new SelectListItem { Text = "Special Scholarship", Value = "4" });
                ViewData["FeeAccountTypeCode"] = new SelectList(li_FeeAccountTypeCode, "Value", "Text", model.FeeAccountTypeMasterDTO.FeeAccountTypeCode);


                return PartialView("/Views/Fees/FeeAccountTypeMaster/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<FeeAccountTypeMaster> response = null;
                FeeAccountTypeMaster FeeAccountTypeMasterDTO = new FeeAccountTypeMaster();
                FeeAccountTypeMasterDTO.ConnectionString = _connectioString;
                FeeAccountTypeMasterDTO.ID = Convert.ToInt16(ID);
                FeeAccountTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _FeeAccountTypeMasterServiceAcess.DeleteFeeAccountTypeMaster(FeeAccountTypeMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<FeeAccountTypeMasterViewModel> GetFeeAccountTypeMaster(out int TotalRecords)
        {
            FeeAccountTypeMasterSearchRequest searchRequest = new FeeAccountTypeMasterSearchRequest();
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
            List<FeeAccountTypeMasterViewModel> listFeeAccountTypeMasterViewModel = new List<FeeAccountTypeMasterViewModel>();
            List<FeeAccountTypeMaster> listFeeAccountTypeMaster = new List<FeeAccountTypeMaster>();
            IBaseEntityCollectionResponse<FeeAccountTypeMaster> baseEntityCollectionResponse = _FeeAccountTypeMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeAccountTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeAccountTypeMaster item in listFeeAccountTypeMaster)
                    {
                        FeeAccountTypeMasterViewModel FeeAccountTypeMasterViewModel = new FeeAccountTypeMasterViewModel();
                        FeeAccountTypeMasterViewModel.FeeAccountTypeMasterDTO = item;
                        listFeeAccountTypeMasterViewModel.Add(FeeAccountTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeAccountTypeMasterViewModel;
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

                IEnumerable<FeeAccountTypeMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.FeeAccountTypeDesc";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.FeeAccountTypeDesc Like '%" + param.sSearch + "%' or A.FeeAccountTypeCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.FeeAccountTypeCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.FeeAccountTypeDesc Like '%" + param.sSearch + "%' or A.FeeAccountTypeCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetFeeAccountTypeMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.FeeAccountTypeDesc), Convert.ToString(c.FeeAccountTypeCode), Convert.ToString(c.ID) };

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