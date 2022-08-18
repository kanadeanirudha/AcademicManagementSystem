using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class CRMSalesCustomerInformationReportViewModel
    {
        public CRMSalesCustomerInformationReportViewModel()
        {
            CRMSalesCustomerInformationReportDTO = new CRMSalesCustomerInformationReport();
            ListCRMSalesCustomerInformationReport = new List<CRMSalesCustomerInformationReport>();
        }


        public List<CRMSalesCustomerInformationReport> ListCRMSalesCustomerInformationReport { get; set; }

        public CRMSalesCustomerInformationReport CRMSalesCustomerInformationReportDTO { get; set; }
    }
}
