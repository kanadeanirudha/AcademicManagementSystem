<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>CRMSales Customer Information Report</title>
    <script runat="server">
   
        AMS.Web.UI.Controllers.CRMSalesCustomerInformationReportController controller = new AMS.Web.UI.Controllers.CRMSalesCustomerInformationReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvCRMSalesCustomerInformation);
            if (!IsPostBack)
            {
                rvCRMSalesCustomerInformation.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.CRMSalesCustomerInformationReport> CRMSalesCustomerInformationReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

         
                  
                    CRMSalesCustomerInformationReport = controller.GetCRMSalesCustomerInformationReport();
                

                if ( CRMSalesCustomerInformationReport == null  )
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvCRMSalesCustomerInformation.LocalReport.ReportPath = Server.MapPath("~/Report/CRMSales/CRMSalesCustomerInformationReport.rdlc");
                    rvCRMSalesCustomerInformation.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "CRMSalesCustomerInfoDataSet";
                    rdc.Value = CRMSalesCustomerInformationReport;
                    rvCRMSalesCustomerInformation.LocalReport.DataSources.Add(rdc);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    //rvCRMSalesCustomerInformation.LocalReport.DataSources.Add(rdc2);

                    rvCRMSalesCustomerInformation.LocalReport.Refresh();
                    rvCRMSalesCustomerInformation.Visible = true;
                }
            }
        
        }
        
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <rsweb:ReportViewer ID="rvCRMSalesCustomerInformation" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.CRMSales.CRMSalesCustomerInformationReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="CRMSalesCustomerInfoDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="CRMSalesCustomerInfoDataSetTableAdapters.CRMSalesCustomerInformationTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


