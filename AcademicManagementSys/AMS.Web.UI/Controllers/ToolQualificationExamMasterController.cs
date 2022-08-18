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
namespace AMS.Web.UI.Controllers
{
    public class ToolQualificationExamMasterController : BaseController
    {
        IToolQualificationExamMasterServiceAccess _ToolQualificationExamMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public ToolQualificationExamMasterController()
        {
            _ToolQualificationExamMasterServiceAcess = new ToolQualificationExamMasterServiceAccess();

        }

        #region Controller Methods

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                ToolQualificationExamMasterViewModel model = new ToolQualificationExamMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("List", model);
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
            ToolQualificationExamMasterViewModel model = new ToolQualificationExamMasterViewModel();
            //For EducationType
            List<SelectListItem> ToolQualificationExamMaster_EducationType = new List<SelectListItem>();
            ViewBag.ToolQualificationExamMaster_EducationType = new SelectList(ToolQualificationExamMaster_EducationType, "Value", "Text");
            List<SelectListItem> li = new List<SelectListItem>();
        //    li.Add(new SelectListItem { Text = "-- Select Type --", Value = "" });
            li.Add(new SelectListItem { Text = "General", Value = "G" });
            li.Add(new SelectListItem { Text = "HSC", Value = "H" });
            li.Add(new SelectListItem { Text = "SSC", Value = "S" });            
            ViewData["EducationType"] = li;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolQualificationExamMasterViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (model != null && model.ToolQualificationExamMasterDTO != null)
                    {
                        model.ToolQualificationExamMasterDTO.ConnectionString = _connectioString;
                        model.ToolQualificationExamMasterDTO.QualificationName = model.QualificationName;
                        model.ToolQualificationExamMasterDTO.EducationType = model.EducationType;
                        model.ToolQualificationExamMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);  //model.CreatedBy;
                        IBaseEntityResponse<ToolQualificationExamMaster> response = _ToolQualificationExamMasterServiceAcess.InsertToolQualificationExamMaster(model.ToolQualificationExamMasterDTO);
                        model.ToolQualificationExamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    // return Content(Boolean.TrueString);
                    return Json(model.ToolQualificationExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        public ActionResult Edit(int id)
        {

            ToolQualificationExamMasterViewModel model = new ToolQualificationExamMasterViewModel();
            try
            {
                model.ToolQualificationExamMasterDTO = new ToolQualificationExamMaster();
                model.ToolQualificationExamMasterDTO.ID = id;
                model.ToolQualificationExamMasterDTO.ConnectionString = _connectioString;

                //For EducationType
                List<SelectListItem> ToolQualificationExamMaster_EducationType = new List<SelectListItem>();
                ViewBag.ToolQualificationExamMaster_EducationType = new SelectList(ToolQualificationExamMaster_EducationType, "Value", "Text");
                List<SelectListItem> li = new List<SelectListItem>();
                //    li.Add(new SelectListItem { Text = "-- Select Type --", Value = "" });
                li.Add(new SelectListItem { Text = "General", Value = "G" });
                li.Add(new SelectListItem { Text = "HSC", Value = "H" });
                li.Add(new SelectListItem { Text = "SSC", Value = "S" });                
               
                IBaseEntityResponse<ToolQualificationExamMaster> response = _ToolQualificationExamMasterServiceAcess.SelectByID(model.ToolQualificationExamMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.ToolQualificationExamMasterDTO.ID = response.Entity.ID;
                    model.ToolQualificationExamMasterDTO.QualificationName = response.Entity.QualificationName;
                    model.ToolQualificationExamMasterDTO.EducationType = response.Entity.EducationType;
                    ViewData["EducationType"] = new SelectList(li, "Value", "Text", response.Entity.EducationType.ToString());
                }
              
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(ToolQualificationExamMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.ToolQualificationExamMasterDTO != null)
                    {
                        model.ToolQualificationExamMasterDTO.ConnectionString = _connectioString;
                        model.ToolQualificationExamMasterDTO.QualificationName = model.QualificationName;
                        model.ToolQualificationExamMasterDTO.EducationType = model.EducationType;
                        model.ToolQualificationExamMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                        IBaseEntityResponse<ToolQualificationExamMaster> response = _ToolQualificationExamMasterServiceAcess.UpdateToolQualificationExamMaster(model.ToolQualificationExamMasterDTO);
                        model.ToolQualificationExamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    // return Content(Boolean.TrueString);
                    return Json(model.ToolQualificationExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //    [HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    ToolQualificationExamMasterViewModel model = new ToolQualificationExamMasterViewModel();
        //    model.ToolQualificationExamMasterDTO = new ToolQualificationExamMaster();
        //    model.ToolQualificationExamMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //    public ActionResult Delete(ToolQualificationExamMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            ToolQualificationExamMaster ToolQualificationExamMasterDTO = new ToolQualificationExamMaster();
        //            ToolQualificationExamMasterDTO.ConnectionString = _connectioString;
        //            ToolQualificationExamMasterDTO.ConnectionString = _connectioString;
        //            ToolQualificationExamMasterDTO.ID = model.ID;
        //            ToolQualificationExamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<ToolQualificationExamMaster> response = _ToolQualificationExamMasterServiceAcess.DeleteToolQualificationExamMaster(ToolQualificationExamMasterDTO);
        //            model.ToolQualificationExamMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.ToolQualificationExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            ToolQualificationExamMasterViewModel model = new ToolQualificationExamMasterViewModel();
            //if (!ModelState.IsValid)
            //{
                if (ID > 0)
                {
                    ToolQualificationExamMaster ToolQualificationExamMasterDTO = new ToolQualificationExamMaster();
                    ToolQualificationExamMasterDTO.ConnectionString = _connectioString;
                    ToolQualificationExamMasterDTO.ConnectionString = _connectioString;
                    ToolQualificationExamMasterDTO.ID = ID;
                    ToolQualificationExamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<ToolQualificationExamMaster> response = _ToolQualificationExamMasterServiceAcess.DeleteToolQualificationExamMaster(ToolQualificationExamMasterDTO);
                    model.ToolQualificationExamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.ToolQualificationExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        

        #endregion

        #region Methods

        public IEnumerable<ToolQualificationExamMasterViewModel> GetToolQualificationExamMaster(out int TotalRecords)
        {
            ToolQualificationExamMasterSearchRequest searchRequest = new ToolQualificationExamMasterSearchRequest();
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
            List<ToolQualificationExamMasterViewModel> listToolQualificationExamMasterViewModel = new List<ToolQualificationExamMasterViewModel>();
            List<ToolQualificationExamMaster> listToolQualificationExamMaster = new List<ToolQualificationExamMaster>();
            IBaseEntityCollectionResponse<ToolQualificationExamMaster> baseEntityCollectionResponse = _ToolQualificationExamMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolQualificationExamMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolQualificationExamMaster item in listToolQualificationExamMaster)
                    {
                        ToolQualificationExamMasterViewModel ToolQualificationExamMasterViewModel = new ToolQualificationExamMasterViewModel();
                        ToolQualificationExamMasterViewModel.ToolQualificationExamMasterDTO = item;
                        listToolQualificationExamMasterViewModel.Add(ToolQualificationExamMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listToolQualificationExamMasterViewModel;
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<ToolQualificationExamMasterViewModel> filteredRegionMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "QualificationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QualificationName Like '%" + param.sSearch + "%'" ;      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;




            filteredRegionMaster = GetToolQualificationExamMaster(out TotalRecords);
                   
            var displayedPosts = filteredRegionMaster.Skip(0).Take(param.iDisplayLength);


            var result = from c in displayedPosts select new[] { c.QualificationName.ToString(), Convert.ToString(c.ID) };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
           JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}