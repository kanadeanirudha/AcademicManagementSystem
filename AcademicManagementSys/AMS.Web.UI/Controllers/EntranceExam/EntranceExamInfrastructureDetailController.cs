using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using AMS.Common;
using AMS.DataProvider;
using System.Configuration;

namespace AMS.Web.UI.Controllers
{
    public class EntranceExamInfrastructureDetailController : BaseController
    {

        #region------------CONTROLLER CLASS VARIABLE------------

        IEntranceExamInfrastructureDetailServiceAccess _entranceExamInfrastructureDetailServiceAccess;
        IGeneralLocationMasterServiceAccess _generalLocationMasterServiceAccess = null;
        private readonly ILogger _logException;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion


        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EntranceExamInfrastructureDetailController()
        {
            _entranceExamInfrastructureDetailServiceAccess = new EntranceExamInfrastructureDetailServiceAccess();
            _generalLocationMasterServiceAccess = new GeneralLocationMasterServiceAccess();
        }

        #endregion


        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            return View("/Views/EntranceExam/EntranceExamInfrastructureDetail/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                EntranceExamInfrastructureDetailViewModel model = new EntranceExamInfrastructureDetailViewModel();
                return PartialView("/Views/EntranceExam/EntranceExamInfrastructureDetail/List.cshtml", model);
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
            EntranceExamInfrastructureDetailViewModel model = new EntranceExamInfrastructureDetailViewModel();
            return PartialView("/Views/EntranceExam/EntranceExamInfrastructureDetail/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EntranceExamInfrastructureDetailViewModel model)
        {
            try
            {
                if (model != null && model.EntranceExamInfrastructureDetailDTO != null)
                {
                    model.EntranceExamInfrastructureDetailDTO.ConnectionString = _connectioString;
                    model.EntranceExamInfrastructureDetailDTO.CentreName = model.CentreName;
                    model.EntranceExamInfrastructureDetailDTO.LocationAddress = model.LocationAddress;
                    model.EntranceExamInfrastructureDetailDTO.GenLocationID = model.GenLocationID;
                    model.EntranceExamInfrastructureDetailDTO.Address = model.Address;
                    model.EntranceExamInfrastructureDetailDTO.ActiveFrom = model.ActiveFrom;
                    model.EntranceExamInfrastructureDetailDTO.ActiveUpto = model.ActiveUpto;

                    model.EntranceExamInfrastructureDetailDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EntranceExamInfrastructureDetail> response = _entranceExamInfrastructureDetailServiceAccess.InsertEntranceExamAvailableCentres(model.EntranceExamInfrastructureDetailDTO);
                    model.EntranceExamInfrastructureDetailDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EntranceExamInfrastructureDetailDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                return Json("Please review your form");


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        public ActionResult CreateInfrastructureDetail(string EntranceExamInfrastructureDetailString)
        {
            EntranceExamInfrastructureDetailViewModel model = new EntranceExamInfrastructureDetailViewModel();
            string[] TemplateStringArrays = EntranceExamInfrastructureDetailString.Split('~');
            model.EntranceExamInfrastructureDetailDTO.EntranceExamAvailableCentresID=Convert.ToInt32(TemplateStringArrays[0]);
            model.EntranceExamInfrastructureDetailDTO.CentreName = TemplateStringArrays[1].Replace('$', ' ');
           
            return PartialView("/Views/EntranceExam/EntranceExamInfrastructureDetail/CreateInfrastructureDetail.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateInfrastructureDetail(EntranceExamInfrastructureDetailViewModel model)
        {
            try
            {
                if (model != null && model.EntranceExamInfrastructureDetailDTO != null)
                {
                    model.EntranceExamInfrastructureDetailDTO.ConnectionString = _connectioString;
                    model.EntranceExamInfrastructureDetailDTO.EntranceExamAvailableCentresID = model.EntranceExamAvailableCentresID;
                    model.EntranceExamInfrastructureDetailDTO.RoomName = model.RoomName;
                    model.EntranceExamInfrastructureDetailDTO.RoomNumber = model.RoomNumber;
                    model.EntranceExamInfrastructureDetailDTO.ExtraDescription = model.ExtraDescription;
                    model.EntranceExamInfrastructureDetailDTO.RoomCapacity = model.RoomCapacity;
                   

                    model.EntranceExamInfrastructureDetailDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EntranceExamInfrastructureDetail> response = _entranceExamInfrastructureDetailServiceAccess.InsertEntranceExamInfrastructureDetail(model.EntranceExamInfrastructureDetailDTO);
                    model.EntranceExamInfrastructureDetailDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EntranceExamInfrastructureDetailDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id, string CentreName)
        {
            EntranceExamInfrastructureDetailViewModel model = new EntranceExamInfrastructureDetailViewModel();
            try
            {
                model.EntranceExamInfrastructureDetailDTO = new EntranceExamInfrastructureDetail();
                model.EntranceExamInfrastructureDetailDTO.EntranceExamInfrastructureDetailID = id;
                model.EntranceExamInfrastructureDetailDTO.CentreName = CentreName.Replace('~',' ');
                model.EntranceExamInfrastructureDetailDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EntranceExamInfrastructureDetail> response = _entranceExamInfrastructureDetailServiceAccess.SelectEntranceExamInfrastructureDetailByID(model.EntranceExamInfrastructureDetailDTO);
                if (response != null && response.Entity != null)
                {
                    model.EntranceExamInfrastructureDetailDTO.EntranceExamInfrastructureDetailID = response.Entity.EntranceExamInfrastructureDetailID;
                    //model.EntranceExamInfrastructureDetailDTO.CentreName = response.Entity.CentreName;
                    model.EntranceExamInfrastructureDetailDTO.EntranceExamAvailableCentresID = response.Entity.EntranceExamAvailableCentresID;
                    model.EntranceExamInfrastructureDetailDTO.RoomCapacity = response.Entity.RoomCapacity;
                    model.EntranceExamInfrastructureDetailDTO.RoomName = response.Entity.RoomName;
                    model.EntranceExamInfrastructureDetailDTO.RoomNumber = response.Entity.RoomNumber;
                    model.EntranceExamInfrastructureDetailDTO.ExtraDescription = response.Entity.ExtraDescription;


                    model.EntranceExamInfrastructureDetailDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/EntranceExam/EntranceExamInfrastructureDetail/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion


        //Non Action Method
        #region---------------Non Action Method----------------------

        public IEnumerable<EntranceExamInfrastructureDetailViewModel> GetEntranceExamInfrastructureDetails(out int TotalRecords)
        {
            EntranceExamInfrastructureDetailSearchRequest entranceExamInfrastructureDetailSR = new EntranceExamInfrastructureDetailSearchRequest();
            entranceExamInfrastructureDetailSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    entranceExamInfrastructureDetailSR.SortBy = "CreatedDate";
                    entranceExamInfrastructureDetailSR.StartRow = 0;
                    entranceExamInfrastructureDetailSR.EndRow = 10;
                    entranceExamInfrastructureDetailSR.SearchBy = "CentreName like '%'";
                    entranceExamInfrastructureDetailSR.SortDirection = "Desc";

                }
                else if (actionModeEnum == ActionModeEnum.Update)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    entranceExamInfrastructureDetailSR.SortBy = "ModifiedDate";
                    entranceExamInfrastructureDetailSR.StartRow = 0;
                    entranceExamInfrastructureDetailSR.EndRow = 10;
                    entranceExamInfrastructureDetailSR.SearchBy = "CentreName like '%'";
                    entranceExamInfrastructureDetailSR.SortDirection = "Desc";
                }
            }
            else
            {
                entranceExamInfrastructureDetailSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                entranceExamInfrastructureDetailSR.StartRow = _startRow;
                entranceExamInfrastructureDetailSR.EndRow = _startRow + _rowLength;
                entranceExamInfrastructureDetailSR.SearchBy = _searchBy;
                entranceExamInfrastructureDetailSR.SortDirection = _sortDirection;
            }

            List<EntranceExamInfrastructureDetailViewModel> listEntranceExamInfrastructureDetailVM = new List<EntranceExamInfrastructureDetailViewModel>();
            List<EntranceExamInfrastructureDetail> listEntranceExamInfrastructureDetail = new List<EntranceExamInfrastructureDetail>();
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> baseEntityEntranceExamInfrastructureDetail = _entranceExamInfrastructureDetailServiceAccess.GetEntranceExamAvailableCentresBySearch(entranceExamInfrastructureDetailSR);

            if (baseEntityEntranceExamInfrastructureDetail != null)
            {
                if (baseEntityEntranceExamInfrastructureDetail.CollectionResponse != null && baseEntityEntranceExamInfrastructureDetail.CollectionResponse.Count > 0)
                {
                    listEntranceExamInfrastructureDetail = baseEntityEntranceExamInfrastructureDetail.CollectionResponse.ToList();
                    foreach (EntranceExamInfrastructureDetail item in listEntranceExamInfrastructureDetail)
                    {
                        EntranceExamInfrastructureDetailViewModel entranceExamInfrastructureDetailVM = new EntranceExamInfrastructureDetailViewModel();
                        entranceExamInfrastructureDetailVM.EntranceExamInfrastructureDetailDTO = item;
                        listEntranceExamInfrastructureDetailVM.Add(entranceExamInfrastructureDetailVM);
                    }
                }
            }
            TotalRecords = baseEntityEntranceExamInfrastructureDetail.TotalRecords;
            return listEntranceExamInfrastructureDetailVM;
        }
        //searchlist of location
        public JsonResult GetLocationList(string term, string CityID, string RegionID)//, string courseYearID, string sectionDetailID, string SessionID)  
        {
            var data = GetLocationListbyCityIDAndRegionID(term, CityID, RegionID);
            var result = (from r in data select new { LocationAddress = r.LocationAddress, id = r.ID }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<GeneralLocationMaster> GetLocationListbyCityIDAndRegionID(string SearchKeyWord, string CityID, string RegionID)
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.MaxResults = 10;
            searchRequest.CityID = Convert.ToInt32(CityID);
            searchRequest.RegionID = Convert.ToInt32(RegionID);
            List<GeneralLocationMaster> listLocation = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterServiceAccess.GetByRegionIDAndCityID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocation;
        }
        //end of SearchList of Location
        #endregion


        // AjaxHandler Method
        #region AjaxHandler

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EntranceExamInfrastructureDetailViewModel> filteredEntranceExamInfrastructureDetail;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CentreName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "CentreName like '%'";
                    }
                    else
                    {
                        _searchBy = "CentreName Like '%" + param.sSearch + "%' or CentreName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "RoomName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "CentreName like '%'";
                    }
                    else
                    {
                        _searchBy = "CentreName Like '%" + param.sSearch + "%' or CentreName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
                    _sortDirection = sortDirection;
                    _rowLength = param.iDisplayLength;
                    _startRow = param.iDisplayStart;

                    filteredEntranceExamInfrastructureDetail = GetEntranceExamInfrastructureDetails(out TotalRecords);

                    var records = filteredEntranceExamInfrastructureDetail.Skip(0).Take(param.iDisplayLength);
                    var result = from c in records select new[] { Convert.ToString(c.CentreName), Convert.ToString(c.RoomName), Convert.ToString(c.RoomNumber), Convert.ToString(c.ExtraDescription), Convert.ToString(c.RoomCapacity), Convert.ToString(c.EntranceExamAvailableCentresID), Convert.ToString(c.EntranceExamInfrastructureDetailID), Convert.ToString(c.EntranceExamAvailableCentresID + "~" + c.CentreName) };
                    return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

            }        

        #endregion
    }
}
