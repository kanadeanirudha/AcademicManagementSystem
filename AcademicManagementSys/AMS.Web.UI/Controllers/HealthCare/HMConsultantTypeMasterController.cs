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
    public class HMConsultantTypeMasterController : BaseController
    {
        IHMConsultantTypeMasterServiceAccess _HMConsultantTypeMasterServiceAcess = null;
        IHMConsultantTypeMasterViewModel _HMConsultantTypeMasterViewModel = null;
        IOrganisationDepartmentMasterServiceAccess _OrganisationDepartmentMasterServiceAccess = null;
       
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMConsultantTypeMasterController()
        {
            _HMConsultantTypeMasterServiceAcess = new HMConsultantTypeMasterServiceAccess();
            _OrganisationDepartmentMasterServiceAccess = new OrganisationDepartmentMasterServiceAccess();
            _HMConsultantTypeMasterViewModel = new HMConsultantTypeMasterViewModel();
          
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
         [HttpGet]
        public ActionResult Index()
        {


            return View("/Views/HealthCare/HMConsultantTypeMaster/Index.cshtml");
        }
         public ActionResult List(string departmentID)
         {
             try
             {
                 HMConsultantTypeMasterViewModel model = new HMConsultantTypeMasterViewModel();
               
                 {
                     List<OrganisationDepartmentMaster> OrganisationDepartmentMaster = GetOrganisationDepartmentList();
                     List<SelectListItem> OrganisationDepartmentMasterList = new List<SelectListItem>();

                     foreach (OrganisationDepartmentMaster item in OrganisationDepartmentMaster)
                     {
                         OrganisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = Convert.ToString(item.ID) });
                     }
                     ViewBag.ListOrganisationDepartmentMaster = new SelectList(OrganisationDepartmentMasterList, "Value", "Text");

                     if (departmentID != null)
                     {
                         string[] ArrDept = departmentID.Split(':');
                         model.DepartmentID = Convert.ToInt32(ArrDept[0]);
                     }
                 }
                 return PartialView("/Views/HealthCare/HMConsultantTypeMaster/List.cshtml", model);
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }

         }


        [HttpGet]
        public ActionResult Create(string DepartmentID)
        {

              HMConsultantTypeMasterViewModel model = new HMConsultantTypeMasterViewModel();

              model.DepartmentID = Convert.ToInt32(DepartmentID);
            return PartialView("/Views/HealthCare/HMConsultantTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMConsultantTypeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.HMConsultantTypeMasterDTO != null)
                {
                    model.HMConsultantTypeMasterDTO.ConnectionString = _connectioString;
                   // model.HMConsultantTypeMasterDTO.CentreCode = model.CentreCode;
                    model.HMConsultantTypeMasterDTO.DepartmentID = model.DepartmentID;
                    model.HMConsultantTypeMasterDTO.Name = model.Name;
                    model.HMConsultantTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMConsultantTypeMaster> response = _HMConsultantTypeMasterServiceAcess.InsertHMConsultantTypeMaster(model.HMConsultantTypeMasterDTO);

                    model.HMConsultantTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.HMConsultantTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Edit(Int16 id)
        //{
        //    HMConsultantTypeMasterViewModel model = new HMConsultantTypeMasterViewModel();
        //    try
        //    {
        //        model.HMConsultantTypeMasterDTO = new HMConsultantTypeMaster();
        //        model.HMConsultantTypeMasterDTO.ID = id;
        //        model.HMConsultantTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMConsultantTypeMaster> response = _HMConsultantTypeMasterServiceAcess.SelectByID(model.HMConsultantTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMConsultantTypeMasterDTO.ID = response.Entity.ID;
        //            model.HMConsultantTypeMasterDTO.Name = response.Entity.Name;
        //           // model.HMConsultantTypeMasterDTO.DepartmentID = response.Entity.DepartmentID;
        //            model.HMConsultantTypeMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView("/Views/HealthCare/HMConsultantTypeMaster/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

      
        //[HttpPost]
        //public ActionResult Edit(HMConsultantTypeMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.HMConsultantTypeMasterDTO != null)
        //        {
        //            model.HMConsultantTypeMasterDTO.ConnectionString = _connectioString;
        //            model.HMConsultantTypeMasterDTO.ID = model.ID;
        //            model.HMConsultantTypeMasterDTO.Name = model.Name;
                   

        //            model.HMConsultantTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMConsultantTypeMaster> response = _HMConsultantTypeMasterServiceAcess.UpdateHMConsultantTypeMaster(model.HMConsultantTypeMasterDTO);
        //            model.HMConsultantTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMConsultantTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        HMConsultantTypeMasterViewModel model = new HMConsultantTypeMasterViewModel();
        //        model.HMConsultantTypeMasterDTO = new HMConsultantTypeMaster();
        //        model.HMConsultantTypeMasterDTO.ID = Convert.ToInt16(ID);
        //        model.HMConsultantTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMConsultantTypeMaster> response = _HMConsultantTypeMasterServiceAcess.SelectByID(model.HMConsultantTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMConsultantTypeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.HMConsultantTypeMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.HMConsultantTypeMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.HMConsultantTypeMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/HMConsultantTypeMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<HMConsultantTypeMaster> response = null;
                HMConsultantTypeMaster HMConsultantTypeMasterDTO = new HMConsultantTypeMaster();
                HMConsultantTypeMasterDTO.ConnectionString = _connectioString;
                HMConsultantTypeMasterDTO.ID = Convert.ToInt16(ID);
                HMConsultantTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMConsultantTypeMasterServiceAcess.DeleteHMConsultantTypeMaster(HMConsultantTypeMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMConsultantTypeMasterViewModel> GetHMConsultantTypeMaster(out int TotalRecords, string DepartmentID)
        {
            HMConsultantTypeMasterSearchRequest searchRequest = new HMConsultantTypeMasterSearchRequest();
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
                   // string[] Centre_code = CentreCode.Split(':');
                  //  searchRequest.CentreCode = Centre_code[0];
                 
                    searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null);
                  
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    //searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null);
                  
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
               // string[] Centre_code = CentreCode.Split(':');
               // searchRequest.CentreCode = Centre_code[0];
               
                 searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null);
              
            }
            List<HMConsultantTypeMasterViewModel> listHMConsultantTypeMasterViewModel = new List<HMConsultantTypeMasterViewModel>();
            List<HMConsultantTypeMaster> listHMConsultantTypeMaster = new List<HMConsultantTypeMaster>();
            IBaseEntityCollectionResponse<HMConsultantTypeMaster> baseEntityCollectionResponse = _HMConsultantTypeMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMConsultantTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMConsultantTypeMaster item in listHMConsultantTypeMaster)
                    {
                        HMConsultantTypeMasterViewModel HMConsultantTypeMasterViewModel = new HMConsultantTypeMasterViewModel();
                        HMConsultantTypeMasterViewModel.HMConsultantTypeMasterDTO = item;
                        listHMConsultantTypeMasterViewModel.Add(HMConsultantTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMConsultantTypeMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string DepartmentID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<HMConsultantTypeMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.Name";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.Name like '%'";
                            //_searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or A.AttributeName Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(DepartmentID))
                //if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                {
                    filteredGroupDescription = GetHMConsultantTypeMaster(out TotalRecords, DepartmentID);
                    // filteredCountryMaster = GetGeneralUnits(out TotalRecords, SelectedCentreCode, SelectedDepartmentID);
                }
                else
                {
                    filteredGroupDescription = new List<HMConsultantTypeMasterViewModel>();
                    TotalRecords = 0;
                }
                if ((filteredGroupDescription.Count()) == 0)
                {
                    filteredGroupDescription = new List<HMConsultantTypeMasterViewModel>();
                    TotalRecords = 0;
                }
               
                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.Name),Convert.ToString(c.ID) };

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