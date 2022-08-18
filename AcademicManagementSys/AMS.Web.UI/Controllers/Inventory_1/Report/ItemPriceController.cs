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
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class ItemPriceController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryReportServiceAccess _InventoryReportServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ItemPriceController()
        {
            _InventoryReportServiceAccess = new InventoryReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            InventoryReportViewModel model = new InventoryReportViewModel();

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            return View("/Views/Inventory_1/Report/ItemPrice/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(InventoryReportViewModel model)
        {

            model.ListGetAdminRoleApplicableCentre = GetCentreListByRoleAuthorization();

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;

                model.IsPosted = false;
            }
            else
            {
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
            }

            return View("/Views/Inventory_1/Report/ItemPrice/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            InventoryReportViewModel model = new InventoryReportViewModel();
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }
            return model.ListGetAdminRoleApplicableCentre;
        }

        public List<InventoryReport> GetItemPriceList()
        {
            try
            {
                List<InventoryReport> listInventoryReport = new List<InventoryReport>();
                InventoryReportSearchRequest searchRequest = new InventoryReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                searchRequest.CentreName = _centreName;

                IBaseEntityCollectionResponse<InventoryReport> baseEntityCollectionResponse = _InventoryReportServiceAccess.GetInventoryReportBySearch_ItemList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listInventoryReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion



    }
}
