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
    public class GeneralPolicyMasterController : BaseController
    {
        IGeneralPolicyMasterServiceAccess _GeneralPolicyMasterServiceAcess = null;
        IUserModuleMasterServiceAccess _userModuleMasterServiceAccess = null;


        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPolicyMasterController()
        {
            _GeneralPolicyMasterServiceAcess = new GeneralPolicyMasterServiceAccess();
            _userModuleMasterServiceAccess = new UserModuleMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
                return View("/Views/GeneralPolicyMaster/Index.cshtml"); 
       
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralPolicyMasterViewModel model = new GeneralPolicyMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralPolicyMaster/List.cshtml", model);
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
            GeneralPolicyMasterViewModel model = new GeneralPolicyMasterViewModel();
            //model.PolicyRelatedToModuleCodeList = GetUserModuleMaster();

            List<UserModuleMaster> PolicyRelatedToModuleCodeList = GetUserModuleMaster();
            List<SelectListItem> generalPolicyMaster = new List<SelectListItem>();
            foreach (UserModuleMaster item in PolicyRelatedToModuleCodeList)
            {
                generalPolicyMaster.Add(new SelectListItem { Text = item.ModuleName, Value = item.ModuleCode });
            }
            ViewBag.GeneralPolicyMaster = new SelectList(generalPolicyMaster, "Value", "Text");


            List<SelectListItem> li = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "General", Value = "General" });
            li.Add(new SelectListItem { Text = "Centerwise", Value = "Centerwise" });
            ViewData["PolicyApplicableStatus"] = li;


            List<SelectListItem> li1 = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "Logical", Value = "Logical" });
            li1.Add(new SelectListItem { Text = "Range", Value = "Range" });
            ViewData["PolicyAnsType"] = li1;


            List<SelectListItem> li2 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = ",", Value = "," });
            li2.Add(new SelectListItem { Text = "`", Value = "`" });
            li2.Add(new SelectListItem { Text = "-", Value = "-" });
            ViewData["RangeSeparateBy"] = li2;


            return PartialView("/Views/GeneralPolicyMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPolicyMasterViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.GeneralPolicyMasterDTO != null)
                    {
                        model.GeneralPolicyMasterDTO.ConnectionString = _connectioString;
                        model.GeneralPolicyMasterDTO.PolicyCode = model.PolicyCode;
                        model.GeneralPolicyMasterDTO.PolicyName = model.PolicyName;
                        model.GeneralPolicyMasterDTO.PolicyDescription = model.PolicyDescription;
                        model.GeneralPolicyMasterDTO.PolicyRelatedToModuleCode = model.PolicyRelatedToModuleCode;
                        model.GeneralPolicyMasterDTO.PolicyApplicableStatus = model.PolicyApplicableStatus;
                        model.GeneralPolicyMasterDTO.IsPolicyActive = model.IsPolicyActive;

                        //feilds From Table GeneralPolicyRule
                        model.GeneralPolicyMasterDTO.PolicyRange = model.PolicyRange;
                        model.GeneralPolicyMasterDTO.PolicyDefaultAnswer = model.PolicyDefaultAnswer;
                        model.GeneralPolicyMasterDTO.PolicyAnsType = model.PolicyAnsType;
                        model.GeneralPolicyMasterDTO.RangeSeparateBy = model.RangeSeparateBy;

                        model.GeneralPolicyMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPolicyMaster> response = _GeneralPolicyMasterServiceAcess.InsertGeneralPolicyMaster(model.GeneralPolicyMasterDTO);
                        model.GeneralPolicyMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.GeneralPolicyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                    
                    return Json("Please review your form");
                
               
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
            GeneralPolicyMasterViewModel model = new GeneralPolicyMasterViewModel();
          //  model.PolicyRelatedToModuleCodeList = GetUserModuleMaster();


            List<UserModuleMaster> PolicyRelatedToModuleCodeList = GetUserModuleMaster();
            List<SelectListItem> generalPolicyMaster = new List<SelectListItem>();
            foreach (UserModuleMaster item in PolicyRelatedToModuleCodeList)
            {
                generalPolicyMaster.Add(new SelectListItem { Text = item.ModuleName, Value = item.ModuleCode });
            }
            ViewBag.GeneralPolicyMaster = new SelectList(generalPolicyMaster, "Value", "Text");


            List<SelectListItem> li = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "General", Value = "General" });
            li.Add(new SelectListItem { Text = "Centerwise", Value = "Centerwise" });
            ViewData["PolicyApplicableStatus"] = li;

            List<SelectListItem> li1 = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = "Logical", Value = "Logical" });
            li1.Add(new SelectListItem { Text = "Range", Value = "Range" });
            ViewData["PolicyAnsType"] = li1;


            List<SelectListItem> li2 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = ",", Value = "," });
            li2.Add(new SelectListItem { Text = "`", Value = "`" });
            li2.Add(new SelectListItem { Text = "-", Value = "-" });
            ViewData["RangeSeparateBy"] = li2;
            try
            {                
                model.GeneralPolicyMasterDTO = new GeneralPolicyMaster();
                model.GeneralPolicyMasterDTO.ID = id;
                model.GeneralPolicyMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralPolicyMaster> response = _GeneralPolicyMasterServiceAcess.SelectByID(model.GeneralPolicyMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralPolicyMasterDTO.ID = response.Entity.ID;
                    model.GeneralPolicyMasterDTO.PolicyCode = response.Entity.PolicyCode;
                    model.GeneralPolicyMasterDTO.PolicyName = response.Entity.PolicyName;
                    model.GeneralPolicyMasterDTO.PolicyDescription = response.Entity.PolicyDescription;
                    model.GeneralPolicyMasterDTO.PolicyRelatedToModuleCode = response.Entity.PolicyRelatedToModuleCode;
                    model.GeneralPolicyMasterDTO.PolicyApplicableStatus = response.Entity.PolicyApplicableStatus;
                    model.GeneralPolicyMasterDTO.IsPolicyActive = response.Entity.IsPolicyActive;
                    //Feilds From Table GeneralPolicyRules
                    model.GeneralPolicyMasterDTO.PolicyRange = response.Entity.PolicyRange;
                    model.GeneralPolicyMasterDTO.PolicyDefaultAnswer = response.Entity.PolicyDefaultAnswer;
                    model.GeneralPolicyMasterDTO.PolicyAnsType = response.Entity.PolicyAnsType;
                    model.GeneralPolicyMasterDTO.RangeSeparateBy = response.Entity.RangeSeparateBy;
                    model.GeneralPolicyMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                ViewData["PolicyApplicableStatus"] = new SelectList(li, "Value", "Text", (model.PolicyApplicableStatus).ToString().Trim());
                ViewBag.GeneralPolicyMaster = new SelectList(generalPolicyMaster, "Value", "Text", model.GeneralPolicyMasterDTO.PolicyRelatedToModuleCode);

                return PartialView("/Views/GeneralPolicyMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralPolicyMasterViewModel model)
        {
            //if (ModelState.IsValid)
            //{
               if (model != null && model.GeneralPolicyMasterDTO != null)
                {
                    if (model != null && model.GeneralPolicyMasterDTO != null)
                    {
                        model.GeneralPolicyMasterDTO.ConnectionString = _connectioString;
                        model.GeneralPolicyMasterDTO.PolicyCode = model.PolicyCode;
                        model.GeneralPolicyMasterDTO.PolicyName = model.PolicyName;
                        model.GeneralPolicyMasterDTO.PolicyDescription = model.PolicyDescription;
                        model.GeneralPolicyMasterDTO.PolicyRelatedToModuleCode = model.PolicyRelatedToModuleCode;
                        model.GeneralPolicyMasterDTO.PolicyApplicableStatus = model.PolicyApplicableStatus;
                        model.GeneralPolicyMasterDTO.IsPolicyActive = model.IsPolicyActive;
                        
                        //Feilds from table GeneralPolicyRule
                        model.GeneralPolicyMasterDTO.PolicyRange = model.PolicyRange;
                        model.GeneralPolicyMasterDTO.PolicyDefaultAnswer = model.PolicyDefaultAnswer;
                        model.GeneralPolicyMasterDTO.PolicyAnsType = model.PolicyAnsType;
                        model.GeneralPolicyMasterDTO.RangeSeparateBy = model.RangeSeparateBy;

                        model.GeneralPolicyMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPolicyMaster> response = _GeneralPolicyMasterServiceAcess.UpdateGeneralPolicyMaster(model.GeneralPolicyMasterDTO);
                        model.GeneralPolicyMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.GeneralPolicyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                
            //}
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    GeneralPolicyMasterViewModel model = new GeneralPolicyMasterViewModel();
        //    model.GeneralPolicyMasterDTO = new GeneralPolicyMaster();
        //    model.GeneralPolicyMasterDTO.ID = ID;
        //    return PartialView("/Views/GeneralPolicyMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralPolicyMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralPolicyMaster GeneralPolicyMasterDTO = new GeneralPolicyMaster();
        //            GeneralPolicyMasterDTO.ConnectionString = _connectioString;
        //            GeneralPolicyMasterDTO.ID = model.ID;
        //            GeneralPolicyMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralPolicyMaster> response = _GeneralPolicyMasterServiceAcess.DeleteGeneralPolicyMaster(GeneralPolicyMasterDTO);
        //            model.GeneralPolicyMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.GeneralPolicyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        
        public ActionResult Delete(int ID)
        {
            GeneralPolicyMasterViewModel model = new GeneralPolicyMasterViewModel();
            //if (!ModelState.IsValid)
            //{
                if (ID > 0)
                {
                    GeneralPolicyMaster GeneralPolicyMasterDTO = new GeneralPolicyMaster();
                    GeneralPolicyMasterDTO.ConnectionString = _connectioString;
                    GeneralPolicyMasterDTO.ID = ID;
                    GeneralPolicyMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPolicyMaster> response = _GeneralPolicyMasterServiceAcess.DeleteGeneralPolicyMaster(GeneralPolicyMasterDTO);
                    model.GeneralPolicyMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.GeneralPolicyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }

        #endregion

        // Non-Action Method
        #region Methods

        protected List<UserModuleMaster> GetUserModuleMaster()
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<UserModuleMaster> listUserMasterModule = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterServiceAccess.GetUserModuleList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserMasterModule = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUserMasterModule;
        }

        public IEnumerable<GeneralPolicyMasterViewModel> GetGeneralPolicyMaster(out int TotalRecords)
        {
            GeneralPolicyMasterSearchRequest searchRequest = new GeneralPolicyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "A.PolicyCode like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "A.PolicyCode like '%'";
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
            List<GeneralPolicyMasterViewModel> listGeneralPolicyMasterViewModel = new List<GeneralPolicyMasterViewModel>();
            List<GeneralPolicyMaster> listGeneralPolicyMaster = new List<GeneralPolicyMaster>();
            IBaseEntityCollectionResponse<GeneralPolicyMaster> baseEntityCollectionResponse = _GeneralPolicyMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPolicyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPolicyMaster item in listGeneralPolicyMaster)
                    {
                        GeneralPolicyMasterViewModel GeneralPolicyMasterViewModel = new GeneralPolicyMasterViewModel();
                        GeneralPolicyMasterViewModel.GeneralPolicyMasterDTO = item;
                        listGeneralPolicyMasterViewModel.Add(GeneralPolicyMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPolicyMasterViewModel;
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

                IEnumerable<GeneralPolicyMasterViewModel> filteredGeneralPolicyMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.PolicyCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PolicyCode like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PolicyCode like '%" + param.sSearch + "%' or PolicyName Like '%" + param.sSearch + "%'or PolicyDescription Like '%" + param.sSearch + "%' or PolicyRelatedToModuleCode Like '%" + param.sSearch + "%' or PolicyApplicableStatus Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PolicyName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PolicyCode	Like '%" + param.sSearch + "%' or PolicyName Like '%" + param.sSearch + "%'or PolicyDescription Like '%" + param.sSearch + "%' or PolicyRelatedToModuleCode Like '%" + param.sSearch + "%' or PolicyApplicableStatus Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    
                    case 2:
                        _sortBy = "PolicyRelatedToModuleCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PolicyCode	Like '%" + param.sSearch + "%' or PolicyName Like '%" + param.sSearch + "%'or PolicyDescription Like '%" + param.sSearch + "%' or PolicyRelatedToModuleCode Like '%" + param.sSearch + "%' or PolicyApplicableStatus Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "PolicyApplicableStatus";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PolicyCode	Like '%" + param.sSearch + "%' or PolicyName Like '%" + param.sSearch + "%'or PolicyDescription Like '%" + param.sSearch + "%' or PolicyRelatedToModuleCode Like '%" + param.sSearch + "%' or PolicyApplicableStatus Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGeneralPolicyMaster = GetGeneralPolicyMaster(out TotalRecords);
                var records = filteredGeneralPolicyMaster.Skip(0).Take(param.iDisplayLength);
               // var result = from c in records select new[] { c.PolicyName.ToString(), c.PolicyCode.ToString(), c.PolicyDescription.ToString(), c.PolicyDefaultAnswer.ToString(), c.PolicyRelatedToModuleCode.ToString(), c.PolicyApplicableStatus.ToString(), c.IsPolicyActive.ToString(), Convert.ToString(c.ID) };
                var result = from c in records select new[] { Convert.ToString(c.PolicyName), Convert.ToString(c.PolicyCode), Convert.ToString(c.PolicyDescription), Convert.ToString(c.PolicyDefaultAnswer), Convert.ToString(c.PolicyRelatedToModuleCode), Convert.ToString(c.PolicyApplicableStatus), Convert.ToString(c.IsPolicyActive), Convert.ToString(c.ID) };
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