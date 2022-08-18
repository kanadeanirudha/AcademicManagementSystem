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
    public class GeneralPolicyDetailsController : BaseController
    {
        IGeneralPolicyDetailsServiceAccess _GeneralPolicyDetailsServiceAcess = null;
        IGeneralPolicyRulesServiceAccess _GeneralPolicyRulesServiceAccess = null;
        IGeneralPolicyDetailsViewModel _GeneralPolicyDetailsViewModel = null;
        IGeneralPolicyRulesViewModel _GeneralPolicyRulesViewModel = null;


        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPolicyDetailsController()
        {
            _GeneralPolicyDetailsServiceAcess = new GeneralPolicyDetailsServiceAccess();
            _GeneralPolicyRulesServiceAccess = new GeneralPolicyRulesServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/GeneralPolicyDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }


        }

        public ActionResult List(string actionMode, string centreCode, string centreName)
        {
            try
            {
                GeneralPolicyDetailsViewModel model = new GeneralPolicyDetailsViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        if (item.IsSuperUser == 1 || item.IsAcadMgr == 1)
                        {
                            a = new AdminRoleApplicableDetails();
                            a.CentreCode = item.CentreCode;
                            a.CentreName = item.CentreName;
                            model.ListGetAdminRoleApplicableCentre.Add(a);
                        }
                    }
                }
                model.SelectedCentreCode = centreCode;
                model.CentreName = centreName;

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
        public ActionResult Create(int ID, string CentreDetails, string PolicyCode, string PolicyQuestionDescription, string PolicyDefaultAnswer, int GeneralPolicyRulesID)
        {
            GeneralPolicyDetailsViewModel model = new GeneralPolicyDetailsViewModel();


            string[] CentreCodeArrays = CentreDetails.Split('~');
            //model.GeneralPolicyDetailsDTO.CentreCode = CentreDetails.Replace('~', ' ');
            model.GeneralPolicyDetailsDTO.PolicyCode = PolicyCode.Replace('~', ' ');
            model.GeneralPolicyDetailsDTO.PolicyQuestionDescription = PolicyQuestionDescription.Replace('~', ' ');
            model.GeneralPolicyDetailsDTO.CentreName = CentreCodeArrays[0].Replace('`', ' ');
            model.GeneralPolicyDetailsDTO.CentreCode = CentreCodeArrays[1].Replace('$', ' ');
            model.GeneralPolicyDetailsDTO.PolicyDefaultAnswer = PolicyDefaultAnswer.Replace('~', ' ');
            model.GeneralPolicyDetailsDTO.GeneralPolicyRulesID = GeneralPolicyRulesID;
            model.GeneralPolicyDetailsDTO.ID = ID;

            List<GeneralPolicyRules> GeneralPolicyRulesList = GetListGeneralPolicyRules(GeneralPolicyRulesID);
            string a = GeneralPolicyRulesList[0].RangeSeparateBy;
            string[] stringArray = GeneralPolicyRulesList[0].PolicyRange.Split(Convert.ToChar(a));
          
            List<SelectListItem> GeneralPolicyRules = new List<SelectListItem>();
            for (int i = 0; i < stringArray.Count(); i++) 
            {
                GeneralPolicyRules.Add(new SelectListItem { Text = stringArray[i], Value = stringArray[i] });
            }
                //foreach (GeneralPolicyRules item in GeneralPolicyRulesList)
                //{
                //    GeneralPolicyRules.Add(new SelectListItem { Text = item.PolicyRange, Value = item.ID.ToString() });
                //}
                ViewBag.GeneralPolicyRules = new SelectList(GeneralPolicyRules, "Value", "Text");




            return PartialView("/Views/GeneralPolicyDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPolicyDetailsViewModel model)
        {
            try
            {


                if (model != null && model.GeneralPolicyDetailsDTO != null)
                {
                    model.GeneralPolicyDetailsDTO.ConnectionString = _connectioString;
                    model.GeneralPolicyDetailsDTO.GeneralPolicyRulesID = model.GeneralPolicyRulesID;
                    model.GeneralPolicyDetailsDTO.CentreCode = model.CentreCode;
                   // model.GeneralPolicyDetailsDTO.PolicyDefaultAnswer = model.PolicyDefaultAnswer;

                    model.GeneralPolicyDetailsDTO.PolicyAnswered = model.PolicyAnswered;
                    model.GeneralPolicyDetailsDTO.ApplicableFromDate = model.ApplicableFromDate;
                   // model.GeneralPolicyDetailsDTO.ApplicableUptoDate = model.ApplicableUptoDate;
                    if (string.IsNullOrEmpty(model.ApplicableUptoDate))
                    {
                        model.GeneralPolicyDetailsDTO.ApplicableUptoDate = null;
                    }
                    else
                    {
                        model.GeneralPolicyDetailsDTO.ApplicableUptoDate = model.ApplicableUptoDate;
                    }



                    model.GeneralPolicyDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPolicyDetails> response = _GeneralPolicyDetailsServiceAcess.InsertGeneralPolicyDetails(model.GeneralPolicyDetailsDTO);
                    model.GeneralPolicyDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralPolicyDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID, string CentreDetails, string PolicyCode, string PolicyQuestionDescription, string PolicyDefaultAnswer, int GeneralPolicyRulesID)
        {
            GeneralPolicyDetailsViewModel model = new GeneralPolicyDetailsViewModel();
            try
            {
                model.GeneralPolicyDetailsDTO = new GeneralPolicyDetails();
                string[] CentreCodeArrays = CentreDetails.Split('~');
                //model.GeneralPolicyDetailsDTO.CentreCode = CentreDetails.Replace('~', ' ');
                model.GeneralPolicyDetailsDTO.PolicyCode = PolicyCode.Replace('~', ' ');
                model.GeneralPolicyDetailsDTO.PolicyQuestionDescription = PolicyQuestionDescription.Replace('~', ' ');
                model.GeneralPolicyDetailsDTO.CentreName = CentreCodeArrays[0].Replace('`', ' ');
                model.GeneralPolicyDetailsDTO.CentreCode = CentreCodeArrays[1].Replace('$', ' ');
                model.GeneralPolicyDetailsDTO.PolicyDefaultAnswer = PolicyDefaultAnswer.Replace('~', ' ');
                model.GeneralPolicyDetailsDTO.GeneralPolicyRulesID = GeneralPolicyRulesID;
                model.GeneralPolicyDetailsDTO.ID = ID;

                //List<GeneralPolicyRules> GeneralPolicyRulesList = GetListGeneralPolicyRules(GeneralPolicyRulesID);
                //string a = GeneralPolicyRulesList[0].RangeSeparateBy;
                //string[] stringArray = GeneralPolicyRulesList[0].PolicyRange.Split(Convert.ToChar(a));

                //List<SelectListItem> GeneralPolicyRules = new List<SelectListItem>();
                //for (int i = 0; i < stringArray.Count(); i++)
                //{
                //    GeneralPolicyRules.Add(new SelectListItem { Text = stringArray[i], Value = stringArray[i] });
                //}
                //ViewBag.GeneralPolicyRules = new SelectList(GeneralPolicyRules, "Value", "Text");

                model.GeneralPolicyDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralPolicyDetails> response = _GeneralPolicyDetailsServiceAcess.SelectByID(model.GeneralPolicyDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralPolicyDetailsDTO.ID = response.Entity.ID;
                    model.GeneralPolicyDetailsDTO.PolicyAnswered = response.Entity.PolicyAnswered;
                    model.GeneralPolicyDetailsDTO.ApplicableFromDate = response.Entity.ApplicableFromDate;
                    model.GeneralPolicyDetailsDTO.ApplicableUptoDate = response.Entity.ApplicableUptoDate;
                    model.GeneralPolicyDetailsDTO.CentreCode = response.Entity.CentreCode;
                    //model.GeneralPolicyDetailsDTO.PolicyApplicableStatus = response.Entity.PolicyApplicableStatus;
                    //model.GeneralPolicyDetailsDTO.IsPolicyActive = response.Entity.IsPolicyActive;
                    model.GeneralPolicyDetailsDTO.CreatedBy = response.Entity.CreatedBy;
                }

                return PartialView("/Views/GeneralPolicyDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralPolicyDetailsViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                if (model != null && model.GeneralPolicyDetailsDTO != null)
                {
                    if (model != null && model.GeneralPolicyDetailsDTO != null)
                    {
                        model.GeneralPolicyDetailsDTO.ConnectionString = _connectioString;
                        model.GeneralPolicyDetailsDTO.GeneralPolicyRulesID = model.GeneralPolicyRulesID;
                        model.GeneralPolicyDetailsDTO.CentreCode = model.CentreCode;
                        model.GeneralPolicyDetailsDTO.PolicyAnswered = model.PolicyAnswered;
                        model.GeneralPolicyDetailsDTO.ApplicableFromDate = model.ApplicableFromDate;
                        model.GeneralPolicyDetailsDTO.ApplicableUptoDate = model.ApplicableUptoDate;
                        model.GeneralPolicyDetailsDTO.ApplicableUptoDate = model.ApplicableUptoDate;
                        model.GeneralPolicyDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<GeneralPolicyDetails> response = _GeneralPolicyDetailsServiceAcess.UpdateGeneralPolicyDetails(model.GeneralPolicyDetailsDTO);
                        model.GeneralPolicyDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.GeneralPolicyDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
               
            //}
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            GeneralPolicyDetailsViewModel model = new GeneralPolicyDetailsViewModel();
            model.GeneralPolicyDetailsDTO = new GeneralPolicyDetails();
            model.GeneralPolicyDetailsDTO.ID = ID;
            return PartialView("/Views/GeneralPolicyDetails/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(GeneralPolicyDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    GeneralPolicyDetails GeneralPolicyDetailsDTO = new GeneralPolicyDetails();
                    GeneralPolicyDetailsDTO.ConnectionString = _connectioString;
                    GeneralPolicyDetailsDTO.ID = model.ID;
                    GeneralPolicyDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPolicyDetails> response = _GeneralPolicyDetailsServiceAcess.DeleteGeneralPolicyDetails(GeneralPolicyDetailsDTO);
                    model.GeneralPolicyDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.GeneralPolicyDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods

        //protected List<UserModuleMaster> GetUserModuleMaster()
        //{
        //    UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<UserModuleMaster> listUserMasterModule = new List<UserModuleMaster>();
        //    IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterServiceAccess.GetUserModuleList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listUserMasterModule = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listUserMasterModule;
        //}

        public IEnumerable<GeneralPolicyDetailsViewModel> GetGeneralPolicyDetails(string centreCode, out int TotalRecords)
        {
            GeneralPolicyDetailsSearchRequest searchRequest = new GeneralPolicyDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "cte1.PolicyCode like '%'";
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "cte1.PolicyCode like '%'";
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centreCode;
                searchRequest.PolicyApplicableStatus = "Centerwise";
            }
            List<GeneralPolicyDetailsViewModel> listGeneralPolicyDetailsViewModel = new List<GeneralPolicyDetailsViewModel>();
            List<GeneralPolicyDetails> listGeneralPolicyDetails = new List<GeneralPolicyDetails>();
            IBaseEntityCollectionResponse<GeneralPolicyDetails> baseEntityCollectionResponse = _GeneralPolicyDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPolicyDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPolicyDetails item in listGeneralPolicyDetails)
                    {
                        GeneralPolicyDetailsViewModel GeneralPolicyDetailsViewModel = new GeneralPolicyDetailsViewModel();
                        GeneralPolicyDetailsViewModel.GeneralPolicyDetailsDTO = item;
                        listGeneralPolicyDetailsViewModel.Add(GeneralPolicyDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPolicyDetailsViewModel;
        } 

        //PolicyRangeDropDownList

        protected List<GeneralPolicyRules> GetListGeneralPolicyRules(int GeneralPolicyRulesID)
        {
            GeneralPolicyRulesSearchRequest searchRequest = new GeneralPolicyRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = Convert.ToInt32(GeneralPolicyRulesID);
            List<GeneralPolicyRules> listGeneralPolicyRules = new List<GeneralPolicyRules>();
            IBaseEntityCollectionResponse<GeneralPolicyRules> baseEntityCollectionResponse = _GeneralPolicyRulesServiceAccess.GetGeneralPolicyRulesForPolicyRange(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPolicyRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralPolicyRules;
        }






        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralPolicyDetailsViewModel> filteredGeneralPolicyDetails;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "cte1.PolicyCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "cte1.PolicyCode like '%'"; 
                        }
                        else
                        {
                          //  _searchBy = "cte1.PolicyCode like '%'Like '%" + param.sSearch + "%' or PolicyAnswered Like '%" + param.sSearch + "%'or ApplicableFromDate Like '%" + param.sSearch + "%' or ApplicableUptoDate Like '%" + param.sSearch + "%' or PolicyDefaultAnswer Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                            _searchBy = "cte1.PolicyCode Like '%" + param.sSearch + "%' or PolicyAnswered Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        
                        
                        }
                        break;
                    case 1:
                        _sortBy = "PolicyAnswered";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                           // _searchBy = "cte1.PolicyCode like '%'Like '%" + param.sSearch + "%' or PolicyAnswered Like '%" + param.sSearch + "%'or ApplicableFromDate Like '%" + param.sSearch + "%' or ApplicableUptoDate Like '%" + param.sSearch + "%' or PolicyDefaultAnswer Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                            _searchBy = "cte1.PolicyCode Like '%" + param.sSearch + "%' or PolicyAnswered Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;

                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
               // filteredGeneralPolicyDetails = GetGeneralPolicyDetails(out TotalRecords);

                if (!string.IsNullOrEmpty(SelectedCentreCode))
                {
                    filteredGeneralPolicyDetails = GetGeneralPolicyDetails(SelectedCentreCode, out TotalRecords);
                }
                else
                {
                    filteredGeneralPolicyDetails = new List<GeneralPolicyDetailsViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredGeneralPolicyDetails.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.PolicyCode.ToString(), Convert.ToString(c.PolicyQuestionDescription), Convert.ToString(c.PolicyDefaultAnswer), c.PolicyAnswered.ToString(), c.ApplicableFromDate.ToString(), c.ApplicableUptoDate.ToString(),Convert.ToString(c.GeneralPolicyRulesID), Convert.ToString(c.ID) };

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