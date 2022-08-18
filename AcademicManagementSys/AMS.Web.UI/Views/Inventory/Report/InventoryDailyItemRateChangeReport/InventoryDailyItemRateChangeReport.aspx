<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
    <script runat="server">
        static bool _pageLoad; static int _counter;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }

        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvInventoryDailyItemRateChangeReport);
            if (!Page.IsPostBack)
            {
                AMS.Web.UI.Controllers.InventoryDailyItemRateChangeReportController controller = new AMS.Web.UI.Controllers.InventoryDailyItemRateChangeReportController();
                List<AMS.DTO.InventoryReportMaster> InventoryDailyItemRateChangeReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvInventoryDailyItemRateChangeReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/InventoryDailyItemRateChangeReport.rdlc");

                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    InventoryDailyItemRateChangeReport = controller.GetInventoryDailyItemRateChange();
                }

                if (InventoryDailyItemRateChangeReport == null || InventoryDailyItemRateChangeReport.Count == 0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryDailyItemRateChangeReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "InventoryDailyItemRateChangeReport";
                    rdc1.Value = InventoryDailyItemRateChangeReport;
                    rvInventoryDailyItemRateChangeReport.LocalReport.DataSources.Add(rdc1);
                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvInventoryDailyItemRateChangeReport.LocalReport.DataSources.Add(rdc2);

                    rvInventoryDailyItemRateChangeReport.LocalReport.Refresh();
                    rvInventoryDailyItemRateChangeReport.Visible = true;
                    
                    
                }
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="dataDiv">
                <rsweb:ReportViewer ID="rvInventoryDailyItemRateChangeReport" runat="server" AsyncRendering="False" ConsumeContainerWhiteSpace="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" PageCountMode="Actual" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory.InventoryDailyItemRateChangeReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudyCentrePrintingFormat" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="InventoryDailyItemRateChangeReport" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="InventoryDailyItemRateChangeReportDataSetTableAdapters.InventoryDailyItemRateChangeReportTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="InventoryDailyItemRateChangeTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>
</html>

