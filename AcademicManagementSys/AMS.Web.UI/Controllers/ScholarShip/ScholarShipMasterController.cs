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
    public class ScholarShipMasterController : BaseController
    {
        IScholarShipMasterServiceAccess _ScholarShipMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public ScholarShipMasterController()
        {
            _ScholarShipMasterServiceAccess = new ScholarShipMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/ScholarShip/ScholarShipMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                ScholarShipMasterViewModel model = new ScholarShipMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/ScholarShip/ScholarShipMaster/List.cshtml", model);
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
            ScholarShipMasterViewModel model = new ScholarShipMasterViewModel();

            List<SelectListItem> li1 = new List<SelectListItem>();
            li1.Add(new SelectListItem { Text = "Sponsor", Value = "1" });
            li1.Add(new SelectListItem { Text = "Discount", Value = "2" });
            ViewData["SchoalarShipTypeList"] = li1;

            List<SelectListItem> li2 = new List<SelectListItem>();
            li2.Add(new SelectListItem { Text = "Parameterised", Value = "1" });
            li2.Add(new SelectListItem { Text = "Special", Value = "2" });
            ViewData["ImplementationTypeList"] = li2;

            model.AccountMasterList = GetAccountList("L", string.Empty);

            model.AccountTypeList = GetFeeAccountType();

            return PartialView("/Views/ScholarShip/ScholarShipMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(ScholarShipMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.ScholarShipMasterDTO != null)
                    {
                        model.ScholarShipMasterDTO.ConnectionString = _connectioString;
                        model.ScholarShipMasterDTO.ScholarShipDescription       = model.ScholarShipDescription     ;
                        model.ScholarShipMasterDTO.ScholarShipType              = model.ScholarShipType      ;      
                        model.ScholarShipMasterDTO.ScholarShipImplementType     = model.ScholarShipImplementType   ;
                        model.ScholarShipMasterDTO.IsCalulatedAmountFix         = model.IsCalulatedAmountFix     ;  
                        model.ScholarShipMasterDTO.FixAmount                    = model.FixAmount           ;       
                        model.ScholarShipMasterDTO.Percentage                   = model.Percentage                ; 
                        model.ScholarShipMasterDTO.FeeAccountTypeMasterIDForStudentReceivable   =  model.FeeAccountTypeMasterIDForStudentReceivable ;
                        model.ScholarShipMasterDTO.FeeAccountSubTypeDescForStudentReceivable    =  model.FeeAccountSubTypeDescForStudentReceivable ; 
                        model.ScholarShipMasterDTO.FeeAccountSubTypeCodeForStudentReceivable    =  model.FeeAccountSubTypeCodeForStudentReceivable ; 
                        model.ScholarShipMasterDTO.AccountIDForStudentReceivable                =  model.AccountIDForStudentReceivable        ;      
                        model.ScholarShipMasterDTO.FeeAccountTypeMasterID       = model.FeeAccountTypeMasterID      ;
                        model.ScholarShipMasterDTO.FeeAccountSubTypeDesc        = model.FeeAccountSubTypeDesc     ;  
                        model.ScholarShipMasterDTO.FeeAccountSubTypeCode        = model.FeeAccountSubTypeCode     ;
                        model.ScholarShipMasterDTO.AccountID                    = model.AccountID;    
                        model.ScholarShipMasterDTO.CreatedBy                    = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<ScholarShipMaster> response = _ScholarShipMasterServiceAccess.InsertScholarShipMaster(model.ScholarShipMasterDTO);
                        model.ScholarShipMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.ScholarShipMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    ScholarShipMasterViewModel model = new ScholarShipMasterViewModel();
        //    try
        //    {
        //        model.ScholarShipMasterDTO = new ScholarShipMaster();
        //        model.ScholarShipMasterDTO.ID = id;
        //        model.ScholarShipMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<ScholarShipMaster> response = _ScholarShipMasterServiceAccess.SelectByID(model.ScholarShipMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.ScholarShipMasterDTO.ID = response.Entity.ID;
        //            model.ScholarShipMasterDTO.CountryName = response.Entity.CountryName;
        //            // model.ScholarShipMasterDTO.SeqNo = response.Entity.SeqNo;
        //            model.ScholarShipMasterDTO.ContryCode = response.Entity.ContryCode;
        //            model.ScholarShipMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
        //            model.ScholarShipMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
        //            model.ScholarShipMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(ScholarShipMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.ScholarShipMasterDTO != null)
        //        {
        //            if (model != null && model.ScholarShipMasterDTO != null)
        //            {
        //                model.ScholarShipMasterDTO.ConnectionString = _connectioString;
        //                model.ScholarShipMasterDTO.CountryName = model.CountryName;
        //                model.ScholarShipMasterDTO.SeqNo = model.SeqNo;
        //                model.ScholarShipMasterDTO.ContryCode = model.ContryCode;
        //                model.ScholarShipMasterDTO.DefaultFlag = model.DefaultFlag;
        //                model.ScholarShipMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<ScholarShipMaster> response = _ScholarShipMasterServiceAccess.UpdateScholarShipMaster(model.ScholarShipMasterDTO);
        //                model.ScholarShipMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.ScholarShipMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    ScholarShipMasterViewModel model = new ScholarShipMasterViewModel();
        //    model.ScholarShipMasterDTO = new ScholarShipMaster();
        //    model.ScholarShipMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(ScholarShipMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            ScholarShipMaster ScholarShipMasterDTO = new ScholarShipMaster();
        //            ScholarShipMasterDTO.ConnectionString = _connectioString;
        //            ScholarShipMasterDTO.ID = model.ID;
        //            ScholarShipMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<ScholarShipMaster> response = _ScholarShipMasterServiceAccess.DeleteScholarShipMaster(ScholarShipMasterDTO);
        //            model.ScholarShipMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.ScholarShipMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}
        #endregion

        // Non-Action Method
        #region Methods

        protected List<ScholarShipMaster> GetFeeAccountType()
        {
            ScholarShipMasterSearchRequest searchRequest = new ScholarShipMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<ScholarShipMaster> listFeeSubType = new List<ScholarShipMaster>();
            IBaseEntityCollectionResponse<ScholarShipMaster> baseEntityCollectionResponse = _ScholarShipMasterServiceAccess.GetAccountTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeSubType;
        }
        public IEnumerable<ScholarShipMasterViewModel> GetScholarShipMaster(out int TotalRecords)
        {
            ScholarShipMasterSearchRequest searchRequest = new ScholarShipMasterSearchRequest();
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
            List<ScholarShipMasterViewModel> listScholarShipMasterViewModel = new List<ScholarShipMasterViewModel>();
            List<ScholarShipMaster> listScholarShipMaster = new List<ScholarShipMaster>();
            IBaseEntityCollectionResponse<ScholarShipMaster> baseEntityCollectionResponse = _ScholarShipMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listScholarShipMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ScholarShipMaster item in listScholarShipMaster)
                    {
                        ScholarShipMasterViewModel ScholarShipMasterViewModel = new ScholarShipMasterViewModel();
                        ScholarShipMasterViewModel.ScholarShipMasterDTO = item;
                        listScholarShipMasterViewModel.Add(ScholarShipMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listScholarShipMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<ScholarShipMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ScholarShipDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ScholarShipDescription Like '%" + param.sSearch + "%' or ScholarShipType Like '%" + param.sSearch + "%'or ScholarShipImplementType Like '%" + param.sSearch + "%'  ";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ScholarShipType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ScholarShipDescription Like '%" + param.sSearch + "%' or ScholarShipType Like '%" + param.sSearch + "%'or ScholarShipImplementType Like '%" + param.sSearch + "%'  ";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "ScholarShipImplementType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ScholarShipDescription Like '%" + param.sSearch + "%' or ScholarShipType Like '%" + param.sSearch + "%'or ScholarShipImplementType Like '%" + param.sSearch + "%'  ";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetScholarShipMaster(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.ScholarShipDescription.ToString(), c.ScholarShipType.ToString(), Convert.ToString(c.ScholarShipImplementType), c.ID.ToString() };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}