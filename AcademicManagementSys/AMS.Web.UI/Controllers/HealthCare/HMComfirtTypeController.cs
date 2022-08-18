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
    public class HMComfirtTypeController : BaseController
    {
        IHMComfirtTypeServiceAccess _HMComfirtTypeServiceAcess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMComfirtTypeController()
        {
            _HMComfirtTypeServiceAcess = new HMComfirtTypeServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/HealthCare/HMComfirtType/Index.cshtml");

        }
        public ActionResult List(string actionMode)
        {
            try
            {
                HMComfirtTypeViewModel model = new HMComfirtTypeViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/HealthCare/HMComfirtType/List.cshtml", model);
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
            HMComfirtTypeViewModel model = new HMComfirtTypeViewModel();
            
            //*****************Dropdown****************************
            List<SelectListItem> ComfirtType = new List<SelectListItem>();
            ViewBag.ComfirtType = new SelectList(ComfirtType, "Value", "Text");
            List<SelectListItem> ComfirtType_li = new List<SelectListItem>();
            ComfirtType_li.Add(new SelectListItem { Text = "Private", Value = "Private" });
            ComfirtType_li.Add(new SelectListItem { Text = "Delux", Value = "Delux" });
            ComfirtType_li.Add(new SelectListItem { Text = "Suit", Value = "Suit" });
            ComfirtType_li.Add(new SelectListItem { Text = "General", Value = "General" });

            ViewData["ComfirtType"] = new SelectList(ComfirtType_li, "Value", "Text");
            return PartialView("/Views/HealthCare/HMComfirtType/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMComfirtTypeViewModel model)
        {
            try
            {
                if (model != null && model.HMComfirtTypeDTO != null)
                {
                    model.HMComfirtTypeDTO.ConnectionString = _connectioString;
                    model.HMComfirtTypeDTO.ComfirtType = model.ComfirtType;
                    model.HMComfirtTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMComfirtType> response = _HMComfirtTypeServiceAcess.InsertHMComfirtType(model.HMComfirtTypeDTO);
                    model.HMComfirtTypeDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.HMComfirtTypeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
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
        //    HMComfirtTypeViewModel model = new HMComfirtTypeViewModel();
        //    try
        //    {
        //        model.HMComfirtTypeDTO = new HMComfirtType();
        //        model.HMComfirtTypeDTO.ID = id;
        //        model.HMComfirtTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMComfirtType> response = _HMComfirtTypeServiceAcess.SelectByID(model.HMComfirtTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMComfirtTypeDTO.ID = response.Entity.ID;
        //            model.HMComfirtTypeDTO.DeductionHeadName = response.Entity.DeductionHeadName;
        //            model.HMComfirtTypeDTO.DeductionType = response.Entity.DeductionType;
                   
        //            model.HMComfirtTypeDTO.CreatedBy = response.Entity.CreatedBy;
        //            List<SelectListItem> DeductionType = new List<SelectListItem>();
        //            ViewBag.DeductionType = new SelectList(DeductionType, "Value", "Text");
        //            List<SelectListItem> DeductionType_li = new List<SelectListItem>();
        //            DeductionType_li.Add(new SelectListItem { Text = "PF", Value = "PF" });
        //            DeductionType_li.Add(new SelectListItem { Text = "ESI", Value = "ESI" });
        //            DeductionType_li.Add(new SelectListItem { Text = "PT", Value = "PT" });
        //            DeductionType_li.Add(new SelectListItem { Text = "LIC", Value = "LIC" });
        //            DeductionType_li.Add(new SelectListItem { Text = "LOAN", Value = "LOAN" });
        //            DeductionType_li.Add(new SelectListItem { Text = "TDS", Value = "TDS" });

        //            ViewData["DeductionType"] = new SelectList(DeductionType_li, "Value", "Text");
        //        }
        //        return PartialView("/Views/Salary/HMComfirtType/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(HMComfirtTypeViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.HMComfirtTypeDTO != null)
        //        {
        //            model.HMComfirtTypeDTO.ConnectionString = _connectioString;
        //            model.HMComfirtTypeDTO.ID = model.ID;
        //            model.HMComfirtTypeDTO.DeductionHeadName = model.DeductionHeadName;
        //            model.HMComfirtTypeDTO.DeductionType = model.DeductionType;
                   
        //            model.HMComfirtTypeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMComfirtType> response = _HMComfirtTypeServiceAcess.UpdateHMComfirtType(model.HMComfirtTypeDTO);
        //            model.HMComfirtTypeDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMComfirtTypeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        HMComfirtTypeViewModel model = new HMComfirtTypeViewModel();
        //        model.HMComfirtTypeDTO = new HMComfirtType();
        //        model.HMComfirtTypeDTO.ID = Convert.ToInt16(ID);
        //        model.HMComfirtTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMComfirtType> response = _HMComfirtTypeServiceAcess.SelectByID(model.HMComfirtTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {

        //        }

        //        return PartialView("/Views/Salary/HMComfirtType/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<HMComfirtType> response = null;
                HMComfirtType HMComfirtTypeDTO = new HMComfirtType();
                HMComfirtTypeDTO.ConnectionString = _connectioString;
                HMComfirtTypeDTO.ID = ID;
                HMComfirtTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMComfirtTypeServiceAcess.DeleteHMComfirtType(HMComfirtTypeDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMComfirtTypeViewModel> GetHMComfirtType(out int TotalRecords)
        {
            HMComfirtTypeSearchRequest searchRequest = new HMComfirtTypeSearchRequest();
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
            List<HMComfirtTypeViewModel> listHMComfirtTypeViewModel = new List<HMComfirtTypeViewModel>();
            List<HMComfirtType> listHMComfirtType = new List<HMComfirtType>();
            IBaseEntityCollectionResponse<HMComfirtType> baseEntityCollectionResponse = _HMComfirtTypeServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMComfirtType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMComfirtType item in listHMComfirtType)
                    {
                        HMComfirtTypeViewModel HMComfirtTypeViewModel = new HMComfirtTypeViewModel();
                        HMComfirtTypeViewModel.HMComfirtTypeDTO = item;
                        listHMComfirtTypeViewModel.Add(HMComfirtTypeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMComfirtTypeViewModel;
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

                IEnumerable<HMComfirtTypeViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ComfirtType Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ComfirtType ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ComfirtType Like '%" + param.sSearch + "%'";
                        }
                        break;
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetHMComfirtType(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ComfirtType), Convert.ToString(c.ID) };

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