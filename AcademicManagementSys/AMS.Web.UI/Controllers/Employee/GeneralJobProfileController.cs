using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel.Implementation.Employee;
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
    public class GeneralJobProfileController : BaseController
    {
        IGeneralJobProfileServiceAccess _GeneralJobProfileServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralJobProfileController()
        {
            _GeneralJobProfileServiceAcess = new GeneralJobProfileServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralJobProfileViewModel model = new GeneralJobProfileViewModel();
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
            GeneralJobProfileViewModel model = new GeneralJobProfileViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralJobProfileViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralJobProfileDTO != null)
                    {
                        model.GeneralJobProfileDTO.ConnectionString = _connectioString;
                        model.GeneralJobProfileDTO.JobProfileDescription = model.JobProfileDescription;                       
                        model.GeneralJobProfileDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralJobProfile> response = _GeneralJobProfileServiceAcess.InsertGeneralJobProfile(model.GeneralJobProfileDTO);
                        model.GeneralJobProfileDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.GeneralJobProfileDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralJobProfileViewModel model = new GeneralJobProfileViewModel();
            try
            {
                model.GeneralJobProfileDTO = new GeneralJobProfile();
                model.GeneralJobProfileDTO.ID = id;
                model.GeneralJobProfileDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralJobProfile> response = _GeneralJobProfileServiceAcess.SelectByID(model.GeneralJobProfileDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralJobProfileDTO.ID = response.Entity.ID;
                    model.GeneralJobProfileDTO.JobProfileDescription = response.Entity.JobProfileDescription;                  
                    model.GeneralJobProfileDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralJobProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralJobProfileDTO != null)
                {
                    if (model != null && model.GeneralJobProfileDTO != null)
                    {
                        model.GeneralJobProfileDTO.ConnectionString = _connectioString;
                        model.GeneralJobProfileDTO.JobProfileDescription = model.JobProfileDescription;                    
                        model.GeneralJobProfileDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralJobProfile> response = _GeneralJobProfileServiceAcess.UpdateGeneralJobProfile(model.GeneralJobProfileDTO);
                        model.GeneralJobProfileDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralJobProfileDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    GeneralJobProfileViewModel model = new GeneralJobProfileViewModel();
        //    model.GeneralJobProfileDTO = new GeneralJobProfile();
        //    model.GeneralJobProfileDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralJobProfileViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralJobProfile GeneralJobProfileDTO = new GeneralJobProfile();
        //            GeneralJobProfileDTO.ConnectionString = _connectioString;
        //            GeneralJobProfileDTO.ID = model.ID;
        //            GeneralJobProfileDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralJobProfile> response = _GeneralJobProfileServiceAcess.DeleteGeneralJobProfile(GeneralJobProfileDTO);
        //            model.GeneralJobProfileDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.GeneralJobProfileDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            GeneralJobProfileViewModel model = new GeneralJobProfileViewModel();
            if (ID > 0)
            {
                
                
                    GeneralJobProfile GeneralJobProfileDTO = new GeneralJobProfile();
                    GeneralJobProfileDTO.ConnectionString = _connectioString;
                    GeneralJobProfileDTO.ID = ID;
                    GeneralJobProfileDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralJobProfile> response = _GeneralJobProfileServiceAcess.DeleteGeneralJobProfile(GeneralJobProfileDTO);
                    model.GeneralJobProfileDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                
                return Json(model.GeneralJobProfileDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralJobProfileViewModel> GetGeneralJobProfile(out int TotalRecords)
        {
            GeneralJobProfileSearchRequest searchRequest = new GeneralJobProfileSearchRequest();
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
            List<GeneralJobProfileViewModel> listGeneralJobProfileViewModel = new List<GeneralJobProfileViewModel>();
            List<GeneralJobProfile> listGeneralJobProfile = new List<GeneralJobProfile>();
            IBaseEntityCollectionResponse<GeneralJobProfile> baseEntityCollectionResponse = _GeneralJobProfileServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralJobProfile = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralJobProfile item in listGeneralJobProfile)
                    {
                        GeneralJobProfileViewModel GeneralJobProfileViewModel = new GeneralJobProfileViewModel();
                        GeneralJobProfileViewModel.GeneralJobProfileDTO = item;
                        listGeneralJobProfileViewModel.Add(GeneralJobProfileViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralJobProfileViewModel;
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

                IEnumerable<GeneralJobProfileViewModel> filteredGeneralJobProfile;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "JobProfileDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "JobProfileDescription Like '%" + param.sSearch + "%' or JobProfileDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ContryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "JobProfileDescription Like '%" + param.sSearch + "%' or JobProfileDescription Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGeneralJobProfile = GetGeneralJobProfile(out TotalRecords);
                var records = filteredGeneralJobProfile.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.JobProfileDescription.ToString(), Convert.ToString(c.ID) };

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