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
    public class HMIPDTypeController : BaseController
    {
        IHMIPDTypeServiceAccess _HMIPDTypeServiceAcess = null;
        

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMIPDTypeController()
        {
            _HMIPDTypeServiceAcess = new HMIPDTypeServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/HealthCare/HMIPDType/Index.cshtml");

        }
        public ActionResult List(string actionMode)
        {
            try
            {
                HMIPDTypeViewModel model = new HMIPDTypeViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/HealthCare/HMIPDType/List.cshtml", model);
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
            HMIPDTypeViewModel model = new HMIPDTypeViewModel();
            
            //*****************Dropdown****************************
           List<SelectListItem> IPDType = new List<SelectListItem>();
            ViewBag.IPDType =  new SelectList(IPDType,"Value","Text");
            List<SelectListItem>IPDType_li = new List<SelectListItem>();
            IPDType_li.Add(new SelectListItem{Text = "ICU", Value = "ICU" });
            IPDType_li.Add(new SelectListItem{Text="General", Value="General"});
            IPDType_li.Add(new SelectListItem{Text="Gynic" ,Value="Gynic"});
            IPDType_li.Add(new SelectListItem{Text="Isolated", Value="Isolated"});
            IPDType_li.Add(new SelectListItem{Text="Burn" ,Value="Burn"});

            ViewData["IPDType"] = new SelectList(IPDType_li, "Value", "Text");
            return PartialView("/Views/HealthCare/HMIPDType/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMIPDTypeViewModel model)
        {
            try
            {
                if (model != null && model.HMIPDTypeDTO != null)
                {
                    model.HMIPDTypeDTO.ConnectionString = _connectioString;
                    model.HMIPDTypeDTO.Name = model.Name;
                    model.HMIPDTypeDTO.Type = model.Type;
                    model.HMIPDTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMIPDType> response = _HMIPDTypeServiceAcess.InsertHMIPDType(model.HMIPDTypeDTO);
                    model.HMIPDTypeDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.HMIPDTypeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //    HMIPDTypeViewModel model = new HMIPDTypeViewModel();
        //    try
        //    {
        //        model.HMIPDTypeDTO = new HMIPDType();
        //        model.HMIPDTypeDTO.ID = id;
        //        model.HMIPDTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMIPDType> response = _HMIPDTypeServiceAcess.SelectByID(model.HMIPDTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMIPDTypeDTO.ID = response.Entity.ID;
        //            model.HMIPDTypeDTO.DeductionHeadName = response.Entity.DeductionHeadName;
        //            model.HMIPDTypeDTO.DeductionType = response.Entity.DeductionType;
                   
        //            model.HMIPDTypeDTO.CreatedBy = response.Entity.CreatedBy;
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
        //        return PartialView("/Views/Salary/HMIPDType/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(HMIPDTypeViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.HMIPDTypeDTO != null)
        //        {
        //            model.HMIPDTypeDTO.ConnectionString = _connectioString;
        //            model.HMIPDTypeDTO.ID = model.ID;
        //            model.HMIPDTypeDTO.DeductionHeadName = model.DeductionHeadName;
        //            model.HMIPDTypeDTO.DeductionType = model.DeductionType;
                   
        //            model.HMIPDTypeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMIPDType> response = _HMIPDTypeServiceAcess.UpdateHMIPDType(model.HMIPDTypeDTO);
        //            model.HMIPDTypeDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMIPDTypeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //        HMIPDTypeViewModel model = new HMIPDTypeViewModel();
        //        model.HMIPDTypeDTO = new HMIPDType();
        //        model.HMIPDTypeDTO.ID = Convert.ToInt16(ID);
        //        model.HMIPDTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMIPDType> response = _HMIPDTypeServiceAcess.SelectByID(model.HMIPDTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {

        //        }

        //        return PartialView("/Views/Salary/HMIPDType/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<HMIPDType> response = null;
                HMIPDType HMIPDTypeDTO = new HMIPDType();
                HMIPDTypeDTO.ConnectionString = _connectioString;
                HMIPDTypeDTO.ID = ID;
                HMIPDTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMIPDTypeServiceAcess.DeleteHMIPDType(HMIPDTypeDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMIPDTypeViewModel> GetHMIPDType(out int TotalRecords)
        {
            HMIPDTypeSearchRequest searchRequest = new HMIPDTypeSearchRequest();
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
            List<HMIPDTypeViewModel> listHMIPDTypeViewModel = new List<HMIPDTypeViewModel>();
            List<HMIPDType> listHMIPDType = new List<HMIPDType>();
            IBaseEntityCollectionResponse<HMIPDType> baseEntityCollectionResponse = _HMIPDTypeServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMIPDType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMIPDType item in listHMIPDType)
                    {
                        HMIPDTypeViewModel HMIPDTypeViewModel = new HMIPDTypeViewModel();
                        HMIPDTypeViewModel.HMIPDTypeDTO = item;
                        listHMIPDTypeViewModel.Add(HMIPDTypeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMIPDTypeViewModel;
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

                IEnumerable<HMIPDTypeViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "Name";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Name Like '%" + param.sSearch + "%'or Type Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "Type";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "Name Like '%" + param.sSearch + "%' or Type Like '%" + param.sSearch + "%'";
                        }
                        break;
                  
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetHMIPDType(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.Name),Convert.ToString(c.Type),Convert.ToString(c.ID) };

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