

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
    public class GeneralQuestionTypeMasterController : BaseController
    {
        IGeneralQuestionTypeMasterServiceAccess _GeneralQuestionTypeMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralQuestionTypeMasterController()
        {
            _GeneralQuestionTypeMasterServiceAcess = new GeneralQuestionTypeMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/GeneralMaster/GeneralQuestionTypeMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralQuestionTypeMasterViewModel model = new GeneralQuestionTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralQuestionTypeMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(String actionMode)
        {   

            GeneralQuestionTypeMasterViewModel model = new GeneralQuestionTypeMasterViewModel();
            List<SelectListItem> RelatedWith = new List<SelectListItem>();
            ViewBag.RelatedWith = new SelectList(RelatedWith, "Value", "Text");
            List<SelectListItem> li_RelatedWith = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });s
            li_RelatedWith.Add(new SelectListItem { Text = "General Aptitude", Value = "General Aptitude" });
            li_RelatedWith.Add(new SelectListItem { Text = "Subject Specific", Value = "Subject Specific" });
            //li_RelatedWith.Add(new SelectListItem { Text = "Fixed Asset", Value = "3" });

            ViewBag.RelatedWith = li_RelatedWith;
            if (!string.IsNullOrEmpty(actionMode))
            {
                TempData["ActionMode"] = actionMode;
            }



            return PartialView("/Views/GeneralMaster/GeneralQuestionTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralQuestionTypeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralQuestionTypeMasterDTO != null)
                {
                    model.GeneralQuestionTypeMasterDTO.ConnectionString = _connectioString;
                    model.GeneralQuestionTypeMasterDTO.QuestionType = model.QuestionType;
                    model.GeneralQuestionTypeMasterDTO.RelatedWith = model.RelatedWith;
                    //model.GeneralQuestionTypeMasterDTO.IsActive = model.IsActive;
                    model.GeneralQuestionTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralQuestionTypeMaster> response = _GeneralQuestionTypeMasterServiceAcess.InsertGeneralQuestionTypeMaster(model.GeneralQuestionTypeMasterDTO);

                    model.GeneralQuestionTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralQuestionTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    GeneralQuestionTypeMasterViewModel model = new GeneralQuestionTypeMasterViewModel();
        //    try
        //    {
        //        model.GeneralQuestionTypeMasterDTO = new GeneralQuestionTypeMaster();
        //        model.GeneralQuestionTypeMasterDTO.ID = id;
        //        model.GeneralQuestionTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralQuestionTypeMaster> response = _GeneralQuestionTypeMasterServiceAcess.SelectByID(model.GeneralQuestionTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralQuestionTypeMasterDTO.ID = response.Entity.ID;
        //            model.GeneralQuestionTypeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralQuestionTypeMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralQuestionTypeMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(GeneralQuestionTypeMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.GeneralQuestionTypeMasterDTO != null)
        //        {
        //            if (model != null && model.GeneralQuestionTypeMasterDTO != null)
        //            {
        //                model.GeneralQuestionTypeMasterDTO.ConnectionString = _connectioString;
        //                model.GeneralQuestionTypeMasterDTO.PaperSetCode = model.PaperSetCode;
        //                //model.GeneralQuestionTypeMasterDTO.MovementCode = model.MovementCode;
        //                //model.GeneralQuestionTypeMasterDTO.IsActive = model.IsActive;
                      
        //                model.GeneralQuestionTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<GeneralQuestionTypeMaster> response = _GeneralQuestionTypeMasterServiceAcess.UpdateGeneralQuestionTypeMaster(model.GeneralQuestionTypeMasterDTO);
        //                model.GeneralQuestionTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.GeneralQuestionTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralQuestionTypeMasterViewModel model = new GeneralQuestionTypeMasterViewModel();
        //        model.GeneralQuestionTypeMasterDTO = new GeneralQuestionTypeMaster();
        //        model.GeneralQuestionTypeMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralQuestionTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralQuestionTypeMaster> response = _GeneralQuestionTypeMasterServiceAcess.SelectByID(model.GeneralQuestionTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralQuestionTypeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralQuestionTypeMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralQuestionTypeMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralQuestionTypeMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralQuestionTypeMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralQuestionTypeMaster> response = null;
                GeneralQuestionTypeMaster GeneralQuestionTypeMasterDTO = new GeneralQuestionTypeMaster();
                GeneralQuestionTypeMasterDTO.ConnectionString = _connectioString;
                GeneralQuestionTypeMasterDTO.GeneralQuestionTypeMasterID= Convert.ToByte(ID);
                GeneralQuestionTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralQuestionTypeMasterServiceAcess.DeleteGeneralQuestionTypeMaster(GeneralQuestionTypeMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralQuestionTypeMasterViewModel> GetGeneralQuestionTypeMaster(out int TotalRecords)
        {
            GeneralQuestionTypeMasterSearchRequest searchRequest = new GeneralQuestionTypeMasterSearchRequest();
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
            List<GeneralQuestionTypeMasterViewModel> listGeneralQuestionTypeMasterViewModel = new List<GeneralQuestionTypeMasterViewModel>();
            List<GeneralQuestionTypeMaster> listGeneralQuestionTypeMaster = new List<GeneralQuestionTypeMaster>();
            IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> baseEntityCollectionResponse = _GeneralQuestionTypeMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralQuestionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralQuestionTypeMaster item in listGeneralQuestionTypeMaster)
                    {
                        GeneralQuestionTypeMasterViewModel GeneralQuestionTypeMasterViewModel = new GeneralQuestionTypeMasterViewModel();
                        GeneralQuestionTypeMasterViewModel.GeneralQuestionTypeMasterDTO = item;
                        listGeneralQuestionTypeMasterViewModel.Add(GeneralQuestionTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralQuestionTypeMasterViewModel;
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

                IEnumerable<GeneralQuestionTypeMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.QuestionType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.RelatedWith Like '%" + param.sSearch + "%' or A.QuestionType Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.RelatedWith";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.QuestionType Like '%" + param.sSearch + "%' or A.RelatedWith Like '%" + param.sSearch + "%'"; //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription =  GetGeneralQuestionTypeMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.QuestionType), Convert.ToString(c.RelatedWith), Convert.ToString(c.GeneralQuestionTypeMasterID) };

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