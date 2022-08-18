<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Daily Sale Report</title>
    <script runat="server">
   
        AMS.Web.UI.Controllers.InventoryDailySaleReportController controller = new AMS.Web.UI.Controllers.InventoryDailySaleReportController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvInventoryDailySaleReport);
            if (!IsPostBack)
            {
                rvInventoryDailySaleReport.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.InventoryDailySaleReport> InventoryDailySaleReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    InventoryDailySaleReport = controller.GetInventoryDailySaleReport();
                }

                if ( InventoryDailySaleReport == null || OrganisationStudyCentreMasterDetails == null )
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryDailySaleReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/InventoryDailySaleReport.rdlc");
                    rvInventoryDailySaleReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "InventoryDailySaleReportDataSet";
                    rdc.Value = InventoryDailySaleReport;
                    rvInventoryDailySaleReport.LocalReport.DataSources.Add(rdc);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvInventoryDailySaleReport.LocalReport.DataSources.Add(rdc2);

                    rvInventoryDailySaleReport.LocalReport.Refresh();
                    rvInventoryDailySaleReport.Visible = true;
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

                <rsweb:ReportViewer ID="rvInventoryDailySaleReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory.InventoryDailySaleReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventoryDailySaleReportDataSet" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AMSDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DataSetTableAdapters.InventoryDailySaleReportTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>

<script type="text/javascript">
    $(document).ready(function () {
        InventoryDailySaleReport.Initialize();
    });
</script>
