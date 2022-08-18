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
    public class InventoryDatewiseItemTransactionController : BaseController
    {
        IInventoryDatewiseItemTransactionServiceAccess _InventoryDatewiseItemTransactionServiceAcess = null;
        IGeneralUnitMasterServiceAccess _generalUnitMasterServiceAcess = null;
        IInventoryItemCategoryMasterServiceAccess _InventoryItemCategoryMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryDatewiseItemTransactionController()
        {
            _InventoryDatewiseItemTransactionServiceAcess = new InventoryDatewiseItemTransactionServiceAccess();
            _generalUnitMasterServiceAcess = new GeneralUnitMasterServiceAccess();
            _InventoryItemCategoryMasterServiceAccess = new InventoryItemCategoryMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryDatewiseItemTransaction/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            
        }

        public ActionResult List(string actionMode, string categoryCode)
        {
            try
            {
                InventoryDatewiseItemTransactionViewModel model = new InventoryDatewiseItemTransactionViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.ListGetCategoryCode = GetListGetCategoryCode();
                model.CategoryCode = categoryCode;
                return PartialView("/Views/Inventory/InventoryDatewiseItemTransaction/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            
        }

         [HttpPost]
        public ActionResult List(InventoryDatewiseItemTransactionViewModel model)
        {
            try
            {
                if (model != null && model.InventoryDatewiseItemTransactionDTO != null)
                {
                    model.InventoryDatewiseItemTransactionDTO.ConnectionString = _connectioString;
                    model.InventoryDatewiseItemTransactionDTO.SelectedXml = model.SelectedXml;
                    model.InventoryDatewiseItemTransactionDTO.TransactionDate = Convert.ToDateTime(DateTime.Now) ;
                    model.InventoryDatewiseItemTransactionDTO.CategoryCode = model.CategoryCode;
                    model.InventoryDatewiseItemTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    
                    IBaseEntityResponse<InventoryDatewiseItemTransaction> response = _InventoryDatewiseItemTransactionServiceAcess.InsertInventoryDatewiseItemTransaction(model.InventoryDatewiseItemTransactionDTO);
                    model.InventoryDatewiseItemTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryDatewiseItemTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryDatewiseItemTransactionViewModel> GetInventoryDatewiseItemTransaction(out int TotalRecords,string CategoryCode)
        {
            InventoryDatewiseItemTransactionSearchRequest searchRequest = new InventoryDatewiseItemTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.ItemName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "asc";
                    searchRequest.CategoryCode = CategoryCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ItemName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "asc";
                    searchRequest.CategoryCode = CategoryCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CategoryCode = CategoryCode;


            }
            List<InventoryDatewiseItemTransactionViewModel> listInventoryDatewiseItemTransactionViewModel = new List<InventoryDatewiseItemTransactionViewModel>();
            List<InventoryDatewiseItemTransaction> listInventoryDatewiseItemTransaction = new List<InventoryDatewiseItemTransaction>();
            IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> baseEntityCollectionResponse = _InventoryDatewiseItemTransactionServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryDatewiseItemTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryDatewiseItemTransaction item in listInventoryDatewiseItemTransaction)
                    {
                        InventoryDatewiseItemTransactionViewModel InventoryDatewiseItemTransactionViewModel = new InventoryDatewiseItemTransactionViewModel();
                        InventoryDatewiseItemTransactionViewModel.InventoryDatewiseItemTransactionDTO = item;
                        listInventoryDatewiseItemTransactionViewModel.Add(InventoryDatewiseItemTransactionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryDatewiseItemTransactionViewModel;
        }

        protected List<InventoryItemCategoryMaster> GetListGetCategoryCode()
        {

            InventoryItemCategoryMasterSearchRequest searchRequest = new InventoryItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryItemCategoryMaster> listCategoryCodeMaster = new List<InventoryItemCategoryMaster>();
            IBaseEntityCollectionResponse<InventoryItemCategoryMaster> baseEntityCollectionResponse = _InventoryItemCategoryMasterServiceAccess.GetInventoryItemCategoryMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCategoryCodeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listCategoryCodeMaster;
        }


        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,string CategoryCode)
        {
            
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<InventoryDatewiseItemTransactionViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ItemName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ItemName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

             if (!string.IsNullOrEmpty(CategoryCode))
            {
                filteredCountryMaster = GetInventoryDatewiseItemTransaction(out TotalRecords,CategoryCode);
            }
            else
            {
                filteredCountryMaster = new List<InventoryDatewiseItemTransactionViewModel>();
                TotalRecords = 0;
            }
             if ((filteredCountryMaster.Count()) == 0)
             {
                 filteredCountryMaster = new List<InventoryDatewiseItemTransactionViewModel>();
                 TotalRecords = 0;
             }

           // var a= filteredCountryMaster.Count();
            

                //filteredCountryMaster = GetInventoryDatewiseItemTransaction(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.ItemName.ToString(),Convert.ToString( c.RetailRate), Convert.ToString(c.Quantity), Convert.ToString(c.ItemID), Convert.ToString(c.ID), };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}