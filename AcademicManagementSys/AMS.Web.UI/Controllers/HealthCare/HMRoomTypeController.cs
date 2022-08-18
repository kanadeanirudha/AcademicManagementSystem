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
    public class HMRoomTypeController : BaseController
    {
        IHMRoomTypeServiceAccess _HMRoomTypeServiceAcess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMRoomTypeController()
        {
            _HMRoomTypeServiceAcess = new HMRoomTypeServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/HealthCare/HMRoomType/Index.cshtml");

        }
        public ActionResult List(string actionMode)
        {
            try
            {
                HMRoomTypeViewModel model = new HMRoomTypeViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/HealthCare/HMRoomType/List.cshtml", model);
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
            HMRoomTypeViewModel model = new HMRoomTypeViewModel();
            
            //*****************Dropdown****************************
            List<SelectListItem> RoomType = new List<SelectListItem>();
            ViewBag.RoomType = new SelectList(RoomType, "Value", "Text");
            List<SelectListItem> RoomType_li = new List<SelectListItem>();
            RoomType_li.Add(new SelectListItem { Text = "Single Room", Value = "Single Room" });
            RoomType_li.Add(new SelectListItem { Text = "Semi Private Room", Value = "Semi Private Room" });
            RoomType_li.Add(new SelectListItem { Text = "Sharing Room", Value = "Sharing Room" });

            ViewData["RoomType"] = new SelectList(RoomType_li, "Value", "Text");
            return PartialView("/Views/HealthCare/HMRoomType/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMRoomTypeViewModel model)
        {
            try
            {
                if (model != null && model.HMRoomTypeDTO != null)
                {
                    model.HMRoomTypeDTO.ConnectionString = _connectioString;
                    model.HMRoomTypeDTO.RoomType = model.RoomType;
                    model.HMRoomTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMRoomType> response = _HMRoomTypeServiceAcess.InsertHMRoomType(model.HMRoomTypeDTO);
                    model.HMRoomTypeDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.HMRoomTypeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //    HMRoomTypeViewModel model = new HMRoomTypeViewModel();
        //    try
        //    {
        //        model.HMRoomTypeDTO = new HMRoomType();
        //        model.HMRoomTypeDTO.ID = id;
        //        model.HMRoomTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMRoomType> response = _HMRoomTypeServiceAcess.SelectByID(model.HMRoomTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMRoomTypeDTO.ID = response.Entity.ID;
        //            model.HMRoomTypeDTO.DeductionHeadName = response.Entity.DeductionHeadName;
        //            model.HMRoomTypeDTO.DeductionType = response.Entity.DeductionType;
                   
        //            model.HMRoomTypeDTO.CreatedBy = response.Entity.CreatedBy;
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
        //        return PartialView("/Views/Salary/HMRoomType/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(HMRoomTypeViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.HMRoomTypeDTO != null)
        //        {
        //            model.HMRoomTypeDTO.ConnectionString = _connectioString;
        //            model.HMRoomTypeDTO.ID = model.ID;
        //            model.HMRoomTypeDTO.DeductionHeadName = model.DeductionHeadName;
        //            model.HMRoomTypeDTO.DeductionType = model.DeductionType;
                   
        //            model.HMRoomTypeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMRoomType> response = _HMRoomTypeServiceAcess.UpdateHMRoomType(model.HMRoomTypeDTO);
        //            model.HMRoomTypeDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMRoomTypeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //        HMRoomTypeViewModel model = new HMRoomTypeViewModel();
        //        model.HMRoomTypeDTO = new HMRoomType();
        //        model.HMRoomTypeDTO.ID = Convert.ToInt16(ID);
        //        model.HMRoomTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMRoomType> response = _HMRoomTypeServiceAcess.SelectByID(model.HMRoomTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {

        //        }

        //        return PartialView("/Views/Salary/HMRoomType/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<HMRoomType> response = null;
                HMRoomType HMRoomTypeDTO = new HMRoomType();
                HMRoomTypeDTO.ConnectionString = _connectioString;
                HMRoomTypeDTO.ID = ID;
                HMRoomTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMRoomTypeServiceAcess.DeleteHMRoomType(HMRoomTypeDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMRoomTypeViewModel> GetHMRoomType(out int TotalRecords)
        {
            HMRoomTypeSearchRequest searchRequest = new HMRoomTypeSearchRequest();
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
            List<HMRoomTypeViewModel> listHMRoomTypeViewModel = new List<HMRoomTypeViewModel>();
            List<HMRoomType> listHMRoomType = new List<HMRoomType>();
            IBaseEntityCollectionResponse<HMRoomType> baseEntityCollectionResponse = _HMRoomTypeServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMRoomType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMRoomType item in listHMRoomType)
                    {
                        HMRoomTypeViewModel HMRoomTypeViewModel = new HMRoomTypeViewModel();
                        HMRoomTypeViewModel.HMRoomTypeDTO = item;
                        listHMRoomTypeViewModel.Add(HMRoomTypeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMRoomTypeViewModel;
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

                IEnumerable<HMRoomTypeViewModel> filteredUnitType;
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
                            _searchBy = "RoomType Like '%" + param.sSearch +  "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "RoomType ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "RoomType Like '%" + param.sSearch + "%'";
                        }
                        break;
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetHMRoomType(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.RoomType), Convert.ToString(c.ID) };

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