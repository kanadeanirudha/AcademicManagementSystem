using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;


namespace AMS.Web.UI.Controllers
{
    public class GeneralSupplierMasterController : Controller
    {
        //
        // GET: /GeneralSupplierMaster/
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IGeneralSupplierMasterServiceAccess _generalSupplierMasterServiceAccess = null;
        string _centreCode = string.Empty;
        string _sortOrder = string.Empty;
        string _soryBy = string.Empty;
        int _startRow;
        int _endRow;
        int _rowLength;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public GeneralSupplierMasterController()
        {
            _generalSupplierMasterServiceAccess = new GeneralSupplierMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            GeneralSupplierMasterViewModel model = new GeneralSupplierMasterViewModel();
            return PartialView("List", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GeneralSupplierMasterViewModel model = new GeneralSupplierMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralSupplierMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralSupplierMasterDTO != null)
                {
                    model.GeneralSupplierMasterDTO.ConnectionString = _connectioString;
                    model.GeneralSupplierMasterDTO.ID = model.ID;
                    model.GeneralSupplierMasterDTO.Vender = model.Vender;
                    model.GeneralSupplierMasterDTO.FirstName = model.FirstName;
                    model.GeneralSupplierMasterDTO.MiddleName = model.MiddleName;
                    model.GeneralSupplierMasterDTO.LastName = model.LastName;
                    model.GeneralSupplierMasterDTO.Sex = model.Sex;
                    model.GeneralSupplierMasterDTO.AddressFirst = model.AddressFirst;
                    model.GeneralSupplierMasterDTO.AddressSecond = model.AddressSecond;
                    model.GeneralSupplierMasterDTO.PlotNumber = model.PlotNumber;
                    model.GeneralSupplierMasterDTO.StreetNumber = model.StreetNumber;
                    model.GeneralSupplierMasterDTO.TahsilID = model.TahsilID;
                    model.GeneralSupplierMasterDTO.PinCode = model.PinCode;
                    model.GeneralSupplierMasterDTO.PhoneNumber = model.PhoneNumber;
                    model.GeneralSupplierMasterDTO.ResiPhoneNumber = model.ResiPhoneNumber;
                    model.GeneralSupplierMasterDTO.CellPhoneNumber = model.CellPhoneNumber;
                    model.GeneralSupplierMasterDTO.FaxNumber = model.FaxNumber;
                    model.GeneralSupplierMasterDTO.Email = model.Email;
                    model.GeneralSupplierMasterDTO.WebUrl = model.WebUrl;
                    model.GeneralSupplierMasterDTO.VenderDescription = model.VenderDescription;
                    model.GeneralSupplierMasterDTO.CategoryId = model.CategoryId;
                    model.GeneralSupplierMasterDTO.AccountId = model.AccountId;
                    model.GeneralSupplierMasterDTO.VAT = model.VAT;
                    model.GeneralSupplierMasterDTO.CST = model.CST;
                    model.GeneralSupplierMasterDTO.Excise = model.Excise;
                    model.GeneralSupplierMasterDTO.StablishmentNumber = model.StablishmentNumber;
                    model.GeneralSupplierMasterDTO.RefNumber = model.RefNumber;
                    model.GeneralSupplierMasterDTO.IsActive = true;
                    model.GeneralSupplierMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                    IBaseEntityResponse<GeneralSupplierMaster> response = _generalSupplierMasterServiceAccess.InsertGeneralSupplierMaster(model.GeneralSupplierMasterDTO);
                }
                return Json(Boolean.TrueString);
            }
            else
            {
                return Json(Boolean.FalseString);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralSupplierMasterViewModel model = new GeneralSupplierMasterViewModel();
            model.ID = id;
            model.GeneralSupplierMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralSupplierMaster> response = _generalSupplierMasterServiceAccess.SelectByID(model.GeneralSupplierMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralSupplierMasterDTO.ID = response.Entity.ID;
                model.GeneralSupplierMasterDTO.Vender = response.Entity.Vender;
                model.GeneralSupplierMasterDTO.FirstName = response.Entity.FirstName;
                model.GeneralSupplierMasterDTO.MiddleName = response.Entity.MiddleName;
                model.GeneralSupplierMasterDTO.LastName = response.Entity.LastName;
                model.GeneralSupplierMasterDTO.Sex = response.Entity.Sex;
                model.GeneralSupplierMasterDTO.AddressFirst = response.Entity.AddressFirst;
                model.GeneralSupplierMasterDTO.AddressSecond = response.Entity.AddressSecond;
                model.GeneralSupplierMasterDTO.PlotNumber = response.Entity.PlotNumber;
                model.GeneralSupplierMasterDTO.StreetNumber = response.Entity.StreetNumber;
                model.GeneralSupplierMasterDTO.TahsilID = response.Entity.TahsilID;
                model.GeneralSupplierMasterDTO.PinCode = response.Entity.PinCode;
                model.GeneralSupplierMasterDTO.PhoneNumber = response.Entity.PhoneNumber;
                model.GeneralSupplierMasterDTO.ResiPhoneNumber = response.Entity.ResiPhoneNumber;
                model.GeneralSupplierMasterDTO.CellPhoneNumber = response.Entity.CellPhoneNumber;
                model.GeneralSupplierMasterDTO.FaxNumber = response.Entity.FaxNumber;
                model.GeneralSupplierMasterDTO.Email = response.Entity.Email;
                model.GeneralSupplierMasterDTO.WebUrl = response.Entity.WebUrl;
                model.GeneralSupplierMasterDTO.VenderDescription = response.Entity.VenderDescription;
                model.GeneralSupplierMasterDTO.CategoryId = response.Entity.CategoryId;
                model.GeneralSupplierMasterDTO.AccountId = response.Entity.AccountId;
                model.GeneralSupplierMasterDTO.VAT = response.Entity.VAT;
                model.GeneralSupplierMasterDTO.CST = response.Entity.CST;
                model.GeneralSupplierMasterDTO.Excise = response.Entity.Excise;
                model.GeneralSupplierMasterDTO.StablishmentNumber = response.Entity.StablishmentNumber;
                model.GeneralSupplierMasterDTO.RefNumber = response.Entity.RefNumber;
                model.GeneralSupplierMasterDTO.IsActive = response.Entity.IsActive;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralSupplierMasterViewModel model)
        {
            var error = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralSupplierMasterDTO != null)
                {
                    model.GeneralSupplierMasterDTO.ConnectionString = _connectioString;
                    model.GeneralSupplierMasterDTO.ID = model.ID;
                    model.GeneralSupplierMasterDTO.Vender = model.Vender;
                    model.GeneralSupplierMasterDTO.FirstName = model.FirstName;
                    model.GeneralSupplierMasterDTO.MiddleName = model.MiddleName;
                    model.GeneralSupplierMasterDTO.LastName = model.LastName;
                    model.GeneralSupplierMasterDTO.Sex = model.Sex;
                    model.GeneralSupplierMasterDTO.AddressFirst = model.AddressFirst;
                    model.GeneralSupplierMasterDTO.AddressSecond = model.AddressSecond;
                    model.GeneralSupplierMasterDTO.PlotNumber = model.PlotNumber;
                    model.GeneralSupplierMasterDTO.StreetNumber = model.StreetNumber;
                    model.GeneralSupplierMasterDTO.TahsilID = model.TahsilID;
                    model.GeneralSupplierMasterDTO.PinCode = model.PinCode;
                    model.GeneralSupplierMasterDTO.PhoneNumber = model.PhoneNumber;
                    model.GeneralSupplierMasterDTO.ResiPhoneNumber = model.ResiPhoneNumber;
                    model.GeneralSupplierMasterDTO.CellPhoneNumber = model.CellPhoneNumber;
                    model.GeneralSupplierMasterDTO.FaxNumber = model.FaxNumber;
                    model.GeneralSupplierMasterDTO.Email = model.Email;
                    model.GeneralSupplierMasterDTO.WebUrl = model.WebUrl;
                    model.GeneralSupplierMasterDTO.VenderDescription = model.VenderDescription;
                    model.GeneralSupplierMasterDTO.CategoryId = model.CategoryId;
                    model.GeneralSupplierMasterDTO.AccountId = model.AccountId;
                    model.GeneralSupplierMasterDTO.VAT = model.VAT;
                    model.GeneralSupplierMasterDTO.CST = model.CST;
                    model.GeneralSupplierMasterDTO.Excise = model.Excise;
                    model.GeneralSupplierMasterDTO.StablishmentNumber = model.StablishmentNumber;
                    model.GeneralSupplierMasterDTO.RefNumber = model.RefNumber;
                    model.GeneralSupplierMasterDTO.ModifiedBy = 1;
                    model.GeneralSupplierMasterDTO.IsActive = model.IsActive;
                    IBaseEntityResponse<GeneralSupplierMaster> response = _generalSupplierMasterServiceAccess.UpdateGeneralSupplierMaster(model.GeneralSupplierMasterDTO);
                }

                return Json(Boolean.TrueString);
            }
            else
            {
                return Json(Boolean.FalseString);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            GeneralSupplierMasterViewModel model = new GeneralSupplierMasterViewModel();
            model.GeneralSupplierMasterDTO = new GeneralSupplierMaster();
            model.GeneralSupplierMasterDTO.ID = id;
            model.GeneralSupplierMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralSupplierMaster> response = _generalSupplierMasterServiceAccess.SelectByID(model.GeneralSupplierMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralSupplierMasterDTO.ID = response.Entity.ID;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(GeneralSupplierMasterViewModel model)
        {
            IBaseEntityResponse<GeneralSupplierMaster> response = null;
            if (model.ID > 0)
            {
                GeneralSupplierMaster GeneralSupplierMasterDTO = new GeneralSupplierMaster();
                GeneralSupplierMasterDTO.ConnectionString = _connectioString;
                GeneralSupplierMasterDTO.ID = model.ID;
                response = _generalSupplierMasterServiceAccess.DeleteGeneralSupplierMaster(GeneralSupplierMasterDTO);
            }
            if (response.Message.Count == 0)
            {
                return Json(Boolean.TrueString);
            }
            else
            {
                return Json(Boolean.FalseString);
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        [NonAction]
        public List<GeneralSupplierMaster> GetListGeneralSupplierMaster(out int _totalRecords)
        {
            List<GeneralSupplierMaster> listGeneralSupplierMaster = new List<GeneralSupplierMaster>();

            GeneralSupplierMasterSearchRequest searchRequest = new GeneralSupplierMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _soryBy;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            IBaseEntityCollectionResponse<GeneralSupplierMaster> baseEntityCollectionResponse = _generalSupplierMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralSupplierMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            _totalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralSupplierMaster;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<GeneralSupplierMaster> filteredGeneralSupplierMaster = null;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    {
                        _soryBy = "FullName";
                    }
                    break;
                case 1:
                    {
                        _soryBy = "VenderDescription";
                    }
                    break;
                case 2:
                    {
                        _soryBy = "PhoneNumber";
                    }
                    break;
                case 3:
                    {
                        _soryBy = "CST";
                    }
                    break;
                case 4:
                    {
                        _soryBy = "VAT";
                    }
                    break;
                case 5:
                    {
                        _soryBy = "RefNumber";
                    }
                    break;
            }
            _sortOrder = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var SupplierFullNameFilter = Convert.ToString(Request["sSearch_1"]);
                var VenderDescriptionFilter = Convert.ToString(Request["sSearch_2"]);
                var PhoneNumberFilter = Convert.ToString(Request["sSearch_3"]);
                var CSTFilter = Convert.ToString(Request["sSearch_4"]);
                var VATFilter = Convert.ToString(Request["sSearch_5"]);
                var RefNumberFilter = Convert.ToString(Request["sSearch_6"]);
                //Optionally check whether the columns are searchable at all 
                var isSupplierFullNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isVenderDescriptionSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isPhoneNumberSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
                var isCSTSearchable = Convert.ToBoolean(Request["bSearchable_4"]);
                var isVATSearchable = Convert.ToBoolean(Request["bSearchable_5"]);
                var isRefNumberSearchable = Convert.ToBoolean(Request["bSearchable_6"]);



                filteredGeneralSupplierMaster = GetListGeneralSupplierMaster(out TotalRecords)
                              .Where(c => isSupplierFullNameSearchable && c.FullName.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isVenderDescriptionSearchable && c.VenderDescription.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isPhoneNumberSearchable && c.PhoneNumber.ToString().Contains(param.sSearch.ToLower())
                               ||
                               isCSTSearchable && c.CST.ToString().Contains(param.sSearch.ToLower())
                               ||
                               isVATSearchable && c.VAT.ToString().Contains(param.sSearch.ToLower())
                               ||
                               isRefNumberSearchable && c.RefNumber.ToString().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredGeneralSupplierMaster = GetListGeneralSupplierMaster(out TotalRecords);
            }

            if (sortColumnIndex == 0)
            {
                if (sortDirection == "asc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderBy(x => x.FullName);
                }
                else if (sortDirection == "desc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderByDescending(x => x.FullName);
                }
            }
            else if (sortColumnIndex == 1)
            {
                if (sortDirection == "asc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderBy(x => x.VenderDescription);
                }
                else if (sortDirection == "desc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderByDescending(x => x.VenderDescription);
                }
            }
            else if (sortColumnIndex == 2)
            {
                if (sortDirection == "asc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderBy(x => x.PhoneNumber);
                }
                else if (sortDirection == "desc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderByDescending(x => x.PhoneNumber);
                }
            }
            else if (sortColumnIndex == 3)
            {
                if (sortDirection == "asc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderBy(x => x.CST);
                }
                else if (sortDirection == "desc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderByDescending(x => x.CST);
                }
            }
            else if (sortColumnIndex == 4)
            {
                if (sortDirection == "asc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderBy(x => x.VAT);
                }
                else if (sortDirection == "desc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderByDescending(x => x.VAT);
                }
            }
            else if (sortColumnIndex == 5)
            {
                if (sortDirection == "asc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderBy(x => x.RefNumber);
                }
                else if (sortDirection == "desc")
                {
                    filteredGeneralSupplierMaster = filteredGeneralSupplierMaster.OrderByDescending(x => x.RefNumber);
                }
            }

            var displayedCaste = filteredGeneralSupplierMaster.Skip(0).Take(param.iDisplayLength);

            var result = from c in displayedCaste
                         select new[]
            {
                Convert.ToString(c.FullName),
                Convert.ToString(c.VenderDescription),
                Convert.ToString(c.PhoneNumber),
                Convert.ToString(c.CST),
                Convert.ToString(c.VAT),
                Convert.ToString(c.RefNumber), 
                Convert.ToString(c.ID),
                Convert.ToString(c.ID)
            };

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
