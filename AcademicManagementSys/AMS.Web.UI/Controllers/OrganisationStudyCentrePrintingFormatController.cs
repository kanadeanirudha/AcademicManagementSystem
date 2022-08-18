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
    public class OrganisationStudyCentrePrintingFormatController : BaseController
    {
        IOrganisationStudyCentrePrintingFormatServiceAccess _OrganisationStudyCentrePrintingFormatServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationStudyCentrePrintingFormatController()
        {
            _OrganisationStudyCentrePrintingFormatServiceAccess = new OrganisationStudyCentrePrintingFormatServiceAccess();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
               OrganisationStudyCentrePrintingFormatViewModel model = new OrganisationStudyCentrePrintingFormatViewModel();





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
        public ActionResult Create(string IDs)
        {
            string[] splitID = IDs.Split('~');
           

            
           OrganisationStudyCentrePrintingFormatViewModel model = new OrganisationStudyCentrePrintingFormatViewModel();
             model.OrganisationStudyCentrePrintingFormatDTO.ID = Convert.ToInt32(splitID[0]);
            model.OrganisationStudyCentrePrintingFormatDTO.CentreCode = splitID[1].ToString();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationStudyCentrePrintingFormatViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (model != null && model. OrganisationStudyCentrePrintingFormatDTO != null)
                    {
                        model. OrganisationStudyCentrePrintingFormatDTO.ConnectionString = _connectioString;
                        model. OrganisationStudyCentrePrintingFormatDTO.CentreCode = model.CentreCode;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine1 = model.PrintingLine1;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine2 = model.PrintingLine2;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine3 = model.PrintingLine3;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine4 = model.PrintingLine4;
                        model.OrganisationStudyCentrePrintingFormatDTO.Logo = model.Logo;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFilename = model.LogoFilename;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoType = model.LogoType;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFileSize = model.LogoFileSize;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFileWidth = model.LogoFileWidth;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFileHeight = model.LogoFileHeight;


                        model. OrganisationStudyCentrePrintingFormatDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse< OrganisationStudyCentrePrintingFormat> response = _OrganisationStudyCentrePrintingFormatServiceAccess.InsertOrganisationStudyCentrePrintingFormat(model. OrganisationStudyCentrePrintingFormatDTO);
                        model. OrganisationStudyCentrePrintingFormatDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    //}
                    return Json(model. OrganisationStudyCentrePrintingFormatDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(string IDs)
        {
            string[] splitID = IDs.Split('~');
           OrganisationStudyCentrePrintingFormatViewModel model = new OrganisationStudyCentrePrintingFormatViewModel();
           model.OrganisationStudyCentrePrintingFormatDTO.ID = Convert.ToInt32(splitID[0]);
           model.OrganisationStudyCentrePrintingFormatDTO.CentreCode = splitID[1].ToString();
         
          //  model. OrganisationStudyCentrePrintingFormatDTO = new OrganisationStudyCentrePrintingFormat();
            model. OrganisationStudyCentrePrintingFormatDTO.ConnectionString = _connectioString;

            IBaseEntityResponse< OrganisationStudyCentrePrintingFormat> response = _OrganisationStudyCentrePrintingFormatServiceAccess.SelectByID(model. OrganisationStudyCentrePrintingFormatDTO);

            if (response != null && response.Entity != null)
            {
                model. OrganisationStudyCentrePrintingFormatDTO.ID = response.Entity.ID;
                model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine1 = response.Entity.PrintingLine1;
                model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine2 = response.Entity.PrintingLine2;
                model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine3 = response.Entity.PrintingLine3;
                model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine4 = response.Entity.PrintingLine4;
                model.OrganisationStudyCentrePrintingFormatDTO.Logo = response.Entity.Logo;
                model.OrganisationStudyCentrePrintingFormatDTO.LogoType = response.Entity.LogoType;
                model.OrganisationStudyCentrePrintingFormatDTO.LogoFilename = response.Entity.LogoFilename;
                model.OrganisationStudyCentrePrintingFormatDTO.LogoFileWidth = response.Entity.LogoFileWidth;
                model.OrganisationStudyCentrePrintingFormatDTO.LogoFileHeight = response.Entity.LogoFileHeight;
                model.OrganisationStudyCentrePrintingFormatDTO.LogoFileSize = response.Entity.LogoFileSize;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(OrganisationStudyCentrePrintingFormatViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                   if (model != null && model. OrganisationStudyCentrePrintingFormatDTO != null)
                    {
                        if (model != null && model. OrganisationStudyCentrePrintingFormatDTO != null)
                        {
                        model. OrganisationStudyCentrePrintingFormatDTO.ConnectionString = _connectioString;
                        model. OrganisationStudyCentrePrintingFormatDTO.CentreCode = model.CentreCode;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine1 = model.PrintingLine1;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine2 = model.PrintingLine2;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine3 = model.PrintingLine3;
                        model. OrganisationStudyCentrePrintingFormatDTO.PrintingLine4 = model.PrintingLine4;
                        model.OrganisationStudyCentrePrintingFormatDTO.Logo = model.Logo;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFilename = model.LogoFilename;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoType = model.LogoType;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFileSize = model.LogoFileSize;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFileWidth = model.LogoFileWidth;
                        model.OrganisationStudyCentrePrintingFormatDTO.LogoFileHeight = model.LogoFileHeight;

                        model. OrganisationStudyCentrePrintingFormatDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse< OrganisationStudyCentrePrintingFormat> response = _OrganisationStudyCentrePrintingFormatServiceAccess.UpdateOrganisationStudyCentrePrintingFormat(model. OrganisationStudyCentrePrintingFormatDTO);
                        model. OrganisationStudyCentrePrintingFormatDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                  //  }
                    return Json(model. OrganisationStudyCentrePrintingFormatDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int ID)
        {
           OrganisationStudyCentrePrintingFormatViewModel model = new OrganisationStudyCentrePrintingFormatViewModel();
            model. OrganisationStudyCentrePrintingFormatDTO = new OrganisationStudyCentrePrintingFormat();
            model. OrganisationStudyCentrePrintingFormatDTO.ID = ID;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(OrganisationStudyCentrePrintingFormatViewModel model)
        {
            try
            {

                if (model.ID > 0)
                {
                    if (model != null && model. OrganisationStudyCentrePrintingFormatDTO != null)
                    {
                       OrganisationStudyCentrePrintingFormat OrganisationStudyCentrePrintingFormatDTO = new OrganisationStudyCentrePrintingFormat();
                       OrganisationStudyCentrePrintingFormatDTO.ConnectionString = _connectioString;
                       OrganisationStudyCentrePrintingFormatDTO.ID = model.ID;
                       OrganisationStudyCentrePrintingFormatDTO.DeletedBy = model.DeletedBy;
                       OrganisationStudyCentrePrintingFormatDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse< OrganisationStudyCentrePrintingFormat> response = _OrganisationStudyCentrePrintingFormatServiceAccess.DeleteOrganisationStudyCentrePrintingFormat( OrganisationStudyCentrePrintingFormatDTO);
                        model. OrganisationStudyCentrePrintingFormatDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model. OrganisationStudyCentrePrintingFormatDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        #endregion

        // Non-Action Methods
        #region Methods
        public IEnumerable<OrganisationStudyCentrePrintingFormatViewModel> GetOrganisationStudyCentrePrintingFormatDetails(out int TotalRecords)
        {
           OrganisationStudyCentrePrintingFormatSearchRequest searchRequest  = new OrganisationStudyCentrePrintingFormatSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationStudyCentrePrintingFormatViewModel> listOrganisationStudyCentrePrintingFormatViewModel = new List<OrganisationStudyCentrePrintingFormatViewModel>();
            List< OrganisationStudyCentrePrintingFormat> listOrganisationStudyCentrePrintingFormat = new List< OrganisationStudyCentrePrintingFormat>();
            IBaseEntityCollectionResponse< OrganisationStudyCentrePrintingFormat> baseEntityCollectionResponse = _OrganisationStudyCentrePrintingFormatServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentrePrintingFormat = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach ( OrganisationStudyCentrePrintingFormat item in listOrganisationStudyCentrePrintingFormat)
                    {
                       OrganisationStudyCentrePrintingFormatViewModel _OrganisationStudyCentrePrintingFormatViewModel = new OrganisationStudyCentrePrintingFormatViewModel();
                        _OrganisationStudyCentrePrintingFormatViewModel. OrganisationStudyCentrePrintingFormatDTO = item;
                        listOrganisationStudyCentrePrintingFormatViewModel.Add(_OrganisationStudyCentrePrintingFormatViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationStudyCentrePrintingFormatViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationStudyCentrePrintingFormatViewModel> filteredOrganisationStudyCentrePrintingFormat;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.CentreName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.CentreName Like '%" + param.sSearch + "%' or A.CentreCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "A.CentreCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.CentreName Like '%" + param.sSearch + "%' or A.CentreCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                //case 2:
                //    _sortBy = "PrintingLine1";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        _searchBy = "A.CentreName  Like '%" + param.sSearch + "%' or A.CentreCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                //    }
                //    break;

                //case 3:
                //    _sortBy = "PrintingLine2";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        _searchBy = "A.CentreName Like '%" + param.sSearch + "%' or A.CentreCode  Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                //    }
                //    break;

                //case 4:
                //    _sortBy = "PrintingLine3";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        _searchBy = "A.CentreName  Like '%" + param.sSearch + "%' or A.CentreCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                //    }
                //    break;

                //case 5:
                //    _sortBy = "PrintingLine4";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        _searchBy = "A.CentreName  Like '%" + param.sSearch + "%' or A.CentreCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                //    }
                    //break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationStudyCentrePrintingFormat = GetOrganisationStudyCentrePrintingFormatDetails(out TotalRecords);
            var records = filteredOrganisationStudyCentrePrintingFormat.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CentreName), Convert.ToString(c.CentreCode), Convert.ToString(c.PrintingLine1), Convert.ToString(c.PrintingLine2), Convert.ToString(c.PrintingLine3), Convert.ToString(c.PrintingLine4), Convert.ToString(c.StatusFlag), Convert.ToString(c.ID) + '~' + c.CentreCode};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


