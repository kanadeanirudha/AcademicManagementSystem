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
    public class OrganisationStreamMasterController : BaseController
    {
        IOrganisationStreamMasterServiceAccess _orgStreamMasterServiceAcess = null;
        OrganisationStreamMasterBaseViewModel _orgStreamMasterBaseViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
 
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationStreamMasterController()
        {
            _orgStreamMasterServiceAcess = new OrganisationStreamMasterServiceAccess();
            _orgStreamMasterBaseViewModel = new OrganisationStreamMasterBaseViewModel();
            
        }
        
        #region Controller Methods

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
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
                OrganisationStreamMasterViewModel model = new OrganisationStreamMasterViewModel();
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
        public ActionResult Create(string Division)
        {
            OrganisationStreamMasterViewModel model = new OrganisationStreamMasterViewModel();
            try
            {
                List<OrganisationDivisionMaster> orgDivisionMasterList = GetListOrganisationDivisionMaster();
                List<SelectListItem> orgDivisionMaster = new List<SelectListItem>();
                foreach (OrganisationDivisionMaster item in orgDivisionMasterList)
                {
                    orgDivisionMaster.Add(new SelectListItem { Text = item.DivisionDescription, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationDivisionMaster = new SelectList(orgDivisionMaster, "Value", "Text");

            }
            catch (Exception)
            {
                
                throw;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationStreamMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationStreamMasterDTO != null)
                {
                    model.OrganisationStreamMasterDTO.ConnectionString = _connectioString;
                   
                    model.OrganisationStreamMasterDTO.StreamDescription = model.StreamDescription;
                    model.OrganisationStreamMasterDTO.DivisionID = Convert.ToInt32(model.SelectedDivisionID); ;
                    model.OrganisationStreamMasterDTO.StreamShortCode = model.StreamShortCode;
                    model.OrganisationStreamMasterDTO.PrintShortCode = model.PrintShortCode;
                    model.OrganisationStreamMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); //model.CreatedBy;
                    IBaseEntityResponse<OrganisationStreamMaster> response = _orgStreamMasterServiceAcess.InsertOrganisationStreamMaster(model.OrganisationStreamMasterDTO);
                    model.OrganisationStreamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationStreamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

            }
          catch (Exception)
          {

              throw;
          }

        }
         [HttpGet]
        public ActionResult Edit(int id)
        {
          
            OrganisationStreamMasterViewModel model = new OrganisationStreamMasterViewModel();
            try
            {
                List<OrganisationDivisionMaster> orgDivisionMasterList = GetListOrganisationDivisionMaster();
                List<SelectListItem> orgDivisionMaster = new List<SelectListItem>();
                foreach (OrganisationDivisionMaster item in orgDivisionMasterList)
                {
                    orgDivisionMaster.Add(new SelectListItem { Text = item.DivisionDescription, Value = item.ID.ToString() });
                }
                model.OrganisationStreamMasterDTO = new OrganisationStreamMaster();
                model.OrganisationStreamMasterDTO.ID = id;
                model.OrganisationStreamMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationStreamMaster> response = _orgStreamMasterServiceAcess.SelectByID(model.OrganisationStreamMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationStreamMasterDTO.ID = response.Entity.ID;
                    model.OrganisationStreamMasterDTO.StreamDescription = response.Entity.StreamDescription;
                    model.OrganisationStreamMasterDTO.StreamShortCode = response.Entity.StreamShortCode;
                    model.OrganisationStreamMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
                    model.OrganisationStreamMasterDTO.IsUserDefined = response.Entity.IsUserDefined;   
                    ViewBag.OrganisationDivisionMaster = new SelectList(orgDivisionMaster, "Value", "Text", response.Entity.DivisionID.ToString());  
                 
                }
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }
           
        }



        [HttpPost]
        public ActionResult Edit(OrganisationStreamMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationStreamMasterDTO != null)
                {
                    if (model != null && model.OrganisationStreamMasterDTO != null)
                    {
                        model.OrganisationStreamMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationStreamMasterDTO.StreamDescription = model.StreamDescription;
                        model.OrganisationStreamMasterDTO.DivisionID =Convert.ToInt32(model.SelectedDivisionID);
                        model.OrganisationStreamMasterDTO.StreamShortCode = model.StreamShortCode;
                        model.OrganisationStreamMasterDTO.PrintShortCode = model.PrintShortCode;
                        model.OrganisationStreamMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);//model.ModifiedBy;
                        IBaseEntityResponse<OrganisationStreamMaster> response = _orgStreamMasterServiceAcess.UpdateOrganisationStreamMaster(model.OrganisationStreamMasterDTO);
                        model.OrganisationStreamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.OrganisationStreamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

            }
         catch (Exception)
          {

              throw;
          }

        }

        // [HttpGet]
        //public ActionResult Delete(int ID)
        //{

        //    OrganisationStreamMasterViewModel model = new OrganisationStreamMasterViewModel();

        //    model.OrganisationStreamMasterDTO = new OrganisationStreamMaster();
        //    model.OrganisationStreamMasterDTO.ID = ID;
        //    model.OrganisationStreamMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<OrganisationStreamMaster> response = _orgStreamMasterServiceAcess.SelectByID(model.OrganisationStreamMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.OrganisationStreamMasterDTO.ID = response.Entity.ID;
        //        model.OrganisationStreamMasterDTO.StreamDescription = response.Entity.StreamDescription;
        //        model.OrganisationStreamMasterDTO.StreamShortCode = response.Entity.StreamShortCode;
        //        model.OrganisationStreamMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
        //    }

        //    return PartialView(model);
        //}



        //[HttpPost]
        //public ActionResult Delete(OrganisationStreamMasterViewModel model)
        //{
        //  try
        //    {
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationStreamMaster orgStreamMasterDTO = new OrganisationStreamMaster();
        //            orgStreamMasterDTO.ConnectionString = _connectioString;
        //            orgStreamMasterDTO.ID = model.ID;
        //            orgStreamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);//model.DeletedBy;
        //            IBaseEntityResponse<OrganisationStreamMaster> response = _orgStreamMasterServiceAcess.DeleteOrganisationStreamMaster(orgStreamMasterDTO);
        //            model.OrganisationStreamMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.OrganisationStreamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        // catch (Exception)
        //  {

        //      throw;
        //  }

        //}

        
        public ActionResult Delete(int ID)
        {
            OrganisationStreamMasterViewModel model = new OrganisationStreamMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        OrganisationStreamMaster orgStreamMasterDTO = new OrganisationStreamMaster();
                        orgStreamMasterDTO.ConnectionString = _connectioString;
                        orgStreamMasterDTO.ID = ID;
                        orgStreamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);//model.DeletedBy;
                        IBaseEntityResponse<OrganisationStreamMaster> response = _orgStreamMasterServiceAcess.DeleteOrganisationStreamMaster(orgStreamMasterDTO);
                        model.OrganisationStreamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.OrganisationStreamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Methods

        public IEnumerable<OrganisationStreamMasterViewModel> GetOrganisationStreamMaster(out int TotalRecords)
        {
            OrganisationStreamMasterSearchRequest searchRequest = new OrganisationStreamMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.sortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.sortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.sortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationStreamMasterViewModel> listOrganisationStreamMasterViewModel = new List<OrganisationStreamMasterViewModel>();
            List<OrganisationStreamMaster> listOrganisationStreamMaster = new List<OrganisationStreamMaster>();
            IBaseEntityCollectionResponse<OrganisationStreamMaster> baseEntityCollectionResponse = _orgStreamMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStreamMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationStreamMaster item in listOrganisationStreamMaster)
                    {
                        OrganisationStreamMasterViewModel orgStreamMasterViewModel = new OrganisationStreamMasterViewModel();
                        orgStreamMasterViewModel.OrganisationStreamMasterDTO = item;
                        listOrganisationStreamMasterViewModel.Add(orgStreamMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationStreamMasterViewModel;
        }

        #endregion

        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc      
            IEnumerable<OrganisationStreamMasterViewModel> filteredOrganisationStreamMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "StreamDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(StreamDescription Like '%" + param.sSearch + "%' or StreamShortCode Like '%" + param.sSearch + "%' or PrintShortCode Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "StreamShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(StreamDescription Like '%" + param.sSearch + "%' or StreamShortCode Like '%" + param.sSearch + "%' or PrintShortCode Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "PrintShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(StreamDescription Like '%" + param.sSearch + "%' or StreamShortCode Like '%" + param.sSearch + "%' or PrintShortCode Like '%" + param.sSearch + "%')";    //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationStreamMaster = GetOrganisationStreamMaster(out TotalRecords);
            var records = filteredOrganisationStreamMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.StreamDescription.ToString(), c.StreamShortCode.ToString(), c.PrintShortCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };
            return Json(new {sEcho = param.sEcho,  iTotalRecords = TotalRecords,  iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}