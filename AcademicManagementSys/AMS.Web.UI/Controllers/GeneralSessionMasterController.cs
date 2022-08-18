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
    public class GeneralSessionMasterController : BaseController
    {
        IGeneralSessionMasterServiceAccess _generalSessionMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        


        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralSessionMasterController()
        {
            _generalSessionMasterServiceAcess = new GeneralSessionMasterServiceAccess();
        }

        #region Controller Methods

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0)
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
            GeneralSessionMasterViewModel model = new GeneralSessionMasterViewModel();
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
            GeneralSessionMasterViewModel model = new GeneralSessionMasterViewModel();
            var CurrentDate = DateTime.Now.ToString("yyyy");
            model.GeneralSessionMasterDTO.SessionFrom =Convert.ToInt32(CurrentDate);
            model.GeneralSessionMasterDTO.SessionUpto =Convert.ToInt32(CurrentDate)+1;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralSessionMasterViewModel model)
        {
          try
            { 
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralSessionMasterDTO != null)
                {
                    model.GeneralSessionMasterDTO.ConnectionString = _connectioString;
                    model.GeneralSessionMasterDTO.SessionName = model.SessionFrom +"-"+ model.SessionUpto;
                    //model.GeneralSessionMasterDTO.SessionOrder = model.SessionOrder;
                  //  model.GeneralSessionMasterDTO.CurrentFlag = model.CurrentFlag;
                    model.GeneralSessionMasterDTO.LockFlag = false;
                    model.GeneralSessionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);                   
                    IBaseEntityResponse<GeneralSessionMaster> response = _generalSessionMasterServiceAcess.InsertGeneralSessionMaster(model.GeneralSessionMasterDTO);
                    model.GeneralSessionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.GeneralSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralSessionMasterViewModel model = new GeneralSessionMasterViewModel();

            model.GeneralSessionMasterDTO = new GeneralSessionMaster();
            model.GeneralSessionMasterDTO.ID = id;
            model.GeneralSessionMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralSessionMaster> response = _generalSessionMasterServiceAcess.SelectByID(model.GeneralSessionMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralSessionMasterDTO.ID = response.Entity.ID;
                var result = response.Entity.SessionName.Split('-');
                model.GeneralSessionMasterDTO.SessionFrom = Convert.ToInt32( result[0]);
                model.GeneralSessionMasterDTO.SessionUpto = Convert.ToInt32(result[1]); 
                model.GeneralSessionMasterDTO.SessionName = response.Entity.SessionName;
             //   model.GeneralSessionMasterDTO.SessionOrder = response.Entity.SessionOrder;
              //  model.GeneralSessionMasterDTO.CurrentFlag = response.Entity.CurrentFlag;
              
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralSessionMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralSessionMasterDTO != null)
                {
                    if (model != null && model.GeneralSessionMasterDTO != null)
                    {
                        model.GeneralSessionMasterDTO.ConnectionString = _connectioString;
                        model.GeneralSessionMasterDTO.SessionName = model.SessionFrom +"-"+ model.SessionUpto;
                     // model.GeneralSessionMasterDTO.SessionOrder = model.SessionOrder;
                      //  model.GeneralSessionMasterDTO.CurrentFlag = model.CurrentFlag;
                        model.GeneralSessionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]); 
                        IBaseEntityResponse<GeneralSessionMaster> response = _generalSessionMasterServiceAcess.UpdateGeneralSessionMaster(model.GeneralSessionMasterDTO);
                        model.GeneralSessionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.GeneralSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(Boolean.FalseString);
                //return Content("Please review your form");
            }
        }
             catch (Exception ex)
          {
              _logException.Error(ex.Message);
              throw;
          }
        }

        // [HttpGet]
        //public ActionResult Delete(int ID)
        //{

        //    GeneralSessionMasterViewModel model = new GeneralSessionMasterViewModel();

        //    model.GeneralSessionMasterDTO = new GeneralSessionMaster();
        //    model.GeneralSessionMasterDTO.ID = ID;
        //    model.GeneralSessionMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<GeneralSessionMaster> response = _generalSessionMasterServiceAcess.SelectByID(model.GeneralSessionMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.GeneralSessionMasterDTO.ID = response.Entity.ID;
        //        model.GeneralSessionMasterDTO.SessionName = response.Entity.SessionName;
        //       // model.GeneralSessionMasterDTO.SessionOrder = response.Entity.SessionOrder;
        //      //  model.GeneralSessionMasterDTO.CurrentFlag = response.Entity.CurrentFlag;
        //    }

        //    return PartialView(model);
        //}



        //[HttpPost]
        //public ActionResult Delete(GeneralSessionMasterViewModel model)
        //{
        //    try
        //   { 
        //    if (model.ID > 0)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralSessionMaster generalSessionMasterDTO = new GeneralSessionMaster();
        //            generalSessionMasterDTO.ConnectionString = _connectioString;
        //            generalSessionMasterDTO.ID = model.ID;
        //            generalSessionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]); 
        //            IBaseEntityResponse<GeneralSessionMaster> response = _generalSessionMasterServiceAcess.DeleteGeneralSessionMaster(generalSessionMasterDTO);
        //            model.GeneralSessionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.GeneralSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        
        public ActionResult Delete(int ID)
        {
            GeneralSessionMasterViewModel model = new GeneralSessionMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        GeneralSessionMaster generalSessionMasterDTO = new GeneralSessionMaster();
                        generalSessionMasterDTO.ConnectionString = _connectioString;
                        generalSessionMasterDTO.ID = ID;
                        generalSessionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralSessionMaster> response = _generalSessionMasterServiceAcess.DeleteGeneralSessionMaster(generalSessionMasterDTO);
                        model.GeneralSessionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region Methods

        public IEnumerable<GeneralSessionMasterViewModel> GetGeneralSessionMaster(out int TotalRecords)
        {
            GeneralSessionMasterSearchRequest searchRequest = new GeneralSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode =Convert.ToString(TempData["ActionMode"]);   
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

            List<GeneralSessionMasterViewModel> listGeneralSessionMasterViewModel = new List<GeneralSessionMasterViewModel>();
            List<GeneralSessionMaster> listGeneralSessionMaster = new List<GeneralSessionMaster>();
            IBaseEntityCollectionResponse<GeneralSessionMaster> baseEntityCollectionResponse = _generalSessionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralSessionMaster item in listGeneralSessionMaster)
                    {
                        GeneralSessionMasterViewModel _generalSessionMasterViewModel = new GeneralSessionMasterViewModel();
                        _generalSessionMasterViewModel.GeneralSessionMasterDTO = item;
                        listGeneralSessionMasterViewModel.Add(_generalSessionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralSessionMasterViewModel;
        }

        #endregion
 
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralSessionMasterViewModel> filteredGeneralSessionMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SessionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SessionName Like '%" + param.sSearch + "%' or SessionOrder Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }  
                    break;
                case 1:
                    _sortBy = "SessionOrder";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SessionName Like '%" + param.sSearch + "%' or SessionOrder Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralSessionMaster = GetGeneralSessionMaster(out TotalRecords);
            var records = filteredGeneralSessionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SessionName.ToString(), c.SessionOrder.ToString(), Convert.ToString(c.ID) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

