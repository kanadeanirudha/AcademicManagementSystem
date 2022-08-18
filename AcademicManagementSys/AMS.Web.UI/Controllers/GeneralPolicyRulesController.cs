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
    public class GeneralPolicyRulesController : BaseController
    {
        IGeneralPolicyRulesServiceAccess _GeneralPolicyRulesServiceAcess = null;
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

        public GeneralPolicyRulesController()
        {
            _GeneralPolicyRulesServiceAcess = new GeneralPolicyRulesServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
                return View("/Views/GeneralPolicyRules/Index.cshtml"); 
       
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();

                //model.PolicyCode = Convert.ToString(PolicyCode);
                //model.PolicyName = PolicyName.Replace('~', ' ');
        
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralPolicyRules/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            
        }


        [HttpGet]
        public ActionResult Create(string PolicyMasterID)
        {
            GeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();
            model.GeneralPolicyRulesDTO = new GeneralPolicyRules();
            try
            {
                string[] PolicyStringArrays = PolicyMasterID.Split('~');
                model.GeneralPolicyRulesDTO.PolicyMasterID = Convert.ToInt32(PolicyStringArrays[0]);
                model.PolicyCode = PolicyStringArrays[1].Replace('$', ' ');

                

               // model.PolicyCode = Convert.ToString(PolicyCode);
                

                List<SelectListItem> li = new List<SelectListItem>();
                // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li.Add(new SelectListItem { Text = "Logical", Value = "Logical" });
                li.Add(new SelectListItem { Text = "Range", Value = "Range" });
                ViewData["PolicyAnsType"] = li;


                List<SelectListItem> li1 = new List<SelectListItem>();
                // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li1.Add(new SelectListItem { Text = ",", Value = "," });
                li1.Add(new SelectListItem { Text = "`", Value = "`" });
                li1.Add(new SelectListItem { Text = "-", Value = "-" });
                ViewData["RangeSeparateBy"] = li1;

            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;     
            }
            
            return PartialView("/Views/GeneralPolicyRules/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPolicyRulesViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.GeneralPolicyRulesDTO != null)
                    {
                        model.GeneralPolicyRulesDTO.ConnectionString = _connectioString;
                        model.GeneralPolicyRulesDTO.PolicyCode = model.PolicyCode;
                        model.GeneralPolicyRulesDTO.PolicyQuestionDescription = model.PolicyQuestionDescription;
                        model.GeneralPolicyRulesDTO.PolicyRange = model.PolicyRange;
                        model.GeneralPolicyRulesDTO.PolicyDefaultAnswer = model.PolicyDefaultAnswer;

                        model.GeneralPolicyRulesDTO.PolicyAnsType = model.PolicyAnsType;
                        model.GeneralPolicyRulesDTO.RangeSeparateBy = model.RangeSeparateBy;
                        model.GeneralPolicyRulesDTO.PolicyMasterID = model.PolicyMasterID;
                        model.GeneralPolicyRulesDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesServiceAcess.InsertGeneralPolicyRules(model.GeneralPolicyRulesDTO);
                        model.GeneralPolicyRulesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.GeneralPolicyRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            // li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "Logical", Value = "Logical" });
            li.Add(new SelectListItem { Text = "Range", Value = "Range" });
            ViewData["PolicyAnsType"] = li;


            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li1.Add(new SelectListItem { Text = ",", Value = "," });
            li1.Add(new SelectListItem { Text = "`", Value = "`" });
            li1.Add(new SelectListItem { Text = "-", Value = "-" });
            ViewData["RangeSeparateBy"] = li1;


            try
            {                
                model.GeneralPolicyRulesDTO = new GeneralPolicyRules();
                model.GeneralPolicyRulesDTO.ID = id;
                model.GeneralPolicyRulesDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesServiceAcess.SelectByID(model.GeneralPolicyRulesDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralPolicyRulesDTO.ID = response.Entity.ID;
                    model.GeneralPolicyRulesDTO.PolicyCode = response.Entity.PolicyCode;
                    model.GeneralPolicyRulesDTO.PolicyQuestionDescription = response.Entity.PolicyQuestionDescription;
                    model.GeneralPolicyRulesDTO.PolicyRange = response.Entity.PolicyRange;
                    model.GeneralPolicyRulesDTO.PolicyDefaultAnswer = response.Entity.PolicyDefaultAnswer;
                    model.GeneralPolicyRulesDTO.PolicyAnsType = response.Entity.PolicyAnsType;
                    model.GeneralPolicyRulesDTO.RangeSeparateBy = response.Entity.RangeSeparateBy;
                    model.GeneralPolicyRulesDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/GeneralPolicyRules/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralPolicyRulesViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralPolicyRulesDTO != null)
                {
                    if (model != null && model.GeneralPolicyRulesDTO != null)
                    {
                        model.GeneralPolicyRulesDTO.ConnectionString = _connectioString;
                        model.GeneralPolicyRulesDTO.PolicyCode = model.PolicyCode;
                        model.GeneralPolicyRulesDTO.PolicyQuestionDescription = model.PolicyQuestionDescription;
                        model.GeneralPolicyRulesDTO.PolicyRange = model.PolicyRange;
                        model.GeneralPolicyRulesDTO.PolicyDefaultAnswer = model.PolicyDefaultAnswer;
                        model.GeneralPolicyRulesDTO.PolicyAnsType = model.PolicyAnsType;
                        model.GeneralPolicyRulesDTO.RangeSeparateBy = model.RangeSeparateBy;
                        model.GeneralPolicyRulesDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesServiceAcess.UpdateGeneralPolicyRules(model.GeneralPolicyRulesDTO);
                        model.GeneralPolicyRulesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralPolicyRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            GeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();
            model.GeneralPolicyRulesDTO = new GeneralPolicyRules();
            model.GeneralPolicyRulesDTO.ID = ID;
            return PartialView("/Views/GeneralPolicyRules/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(GeneralPolicyRulesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    GeneralPolicyRules GeneralPolicyRulesDTO = new GeneralPolicyRules();
                    GeneralPolicyRulesDTO.ConnectionString = _connectioString;
                    GeneralPolicyRulesDTO.ID = model.ID;
                    GeneralPolicyRulesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesServiceAcess.DeleteGeneralPolicyRules(GeneralPolicyRulesDTO);
                    model.GeneralPolicyRulesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.GeneralPolicyRulesDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
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

        public IEnumerable<GeneralPolicyRulesViewModel> GetGeneralPolicyRules(out int TotalRecords)
        {
            GeneralPolicyRulesSearchRequest searchRequest = new GeneralPolicyRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate DESC,cte1.PolicyCode ASC";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "cte1.PolicyName like '%'";
                    searchRequest.SortDirection = " ";
                   
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "cte1.PolicyName like '%'";
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
            List<GeneralPolicyRulesViewModel> listGeneralPolicyRulesViewModel = new List<GeneralPolicyRulesViewModel>();
            List<GeneralPolicyRules> listGeneralPolicyRules = new List<GeneralPolicyRules>();
            IBaseEntityCollectionResponse<GeneralPolicyRules> baseEntityCollectionResponse = _GeneralPolicyRulesServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPolicyRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPolicyRules item in listGeneralPolicyRules)
                    {
                        GeneralPolicyRulesViewModel GeneralPolicyRulesViewModel = new GeneralPolicyRulesViewModel();
                        GeneralPolicyRulesViewModel.GeneralPolicyRulesDTO = item;
                        listGeneralPolicyRulesViewModel.Add(GeneralPolicyRulesViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPolicyRulesViewModel;
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

                IEnumerable<GeneralPolicyRulesViewModel> filteredGeneralPolicyRules;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "cte1.PolicyName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "cte1.PolicyName like '%'";
                        }
                        else
                        {
                            _searchBy = "cte1.PolicyName Like '%" + param.sSearch + "%' or PolicyQuestionDescription Like '%" + param.sSearch +"%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PolicyQuestionDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "cte1.PolicyName Like '%" + param.sSearch + "%' or PolicyQuestionDescription Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    
                    case 2:
                        _sortBy = "PolicyRange";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "cte1.PolicyName Like '%" + param.sSearch + "%' or PolicyQuestionDescription Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "PolicyDefaultAnswer";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "cte1.PolicyName Like '%" + param.sSearch + "%' or PolicyQuestionDescription Like '%" + param.sSearch + "%'or PolicyRange Like '%" + param.sSearch + "%'or PolicyDefaultAnswer Like '%" + param.sSearch + "%' or PolicyAnsType Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGeneralPolicyRules = GetGeneralPolicyRules(out TotalRecords);
                var records = filteredGeneralPolicyRules.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PolicyName),Convert.ToString(c.PolicyName) + " (" + Convert.ToString(c.PolicyCode) + ")", c.PolicyQuestionDescription.ToString(), c.PolicyRange.ToString(), c.PolicyDefaultAnswer.ToString(), c.PolicyAnsType.ToString(), Convert.ToString(c.ID), Convert.ToString(c.PolicyMasterID + "~" + c.PolicyCode) };

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