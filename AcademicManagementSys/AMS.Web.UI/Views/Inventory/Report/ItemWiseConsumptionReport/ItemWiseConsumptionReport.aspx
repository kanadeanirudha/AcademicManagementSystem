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
            scriptManager.RegisterPostBackControl(this.rvInventoryItemwiseConsumptionReport);
            if (!Page.IsPostBack)
            {
                AMS.Web.UI.Controllers.InventoryItemwiseConsumptionReportController controller = new AMS.Web.UI.Controllers.InventoryItemwiseConsumptionReportController();
                List<AMS.DTO.InventoryReportMaster> InventoryItemwiseConsumptionReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvInventoryItemwiseConsumptionReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/InventoryItemwiseConsumptionReport.rdlc");

                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    InventoryItemwiseConsumptionReport = controller.GetItemwiseConsumptionData();
                }

                if (InventoryItemwiseConsumptionReport == null || InventoryItemwiseConsumptionReport.Count == 0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryItemwiseConsumptionReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "InventoryItemwiseConsumptionReport";
                    rdc1.Value = InventoryItemwiseConsumptionReport;
                    rvInventoryItemwiseConsumptionReport.LocalReport.DataSources.Add(rdc1);
                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvInventoryItemwiseConsumptionReport.LocalReport.DataSources.Add(rdc2);

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("FromDate", InventoryItemwiseConsumptionReport[0].FromDate, false);
                    param[1] = new ReportParameter("UptoDate", InventoryItemwiseConsumptionReport[0].UptoDate, false);
                    rvInventoryItemwiseConsumptionReport.LocalReport.SetParameters(param);
                    rvInventoryItemwiseConsumptionReport.LocalReport.Refresh();
                    rvInventoryItemwiseConsumptionReport.Visible = true;
                    
                    
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
                <rsweb:ReportViewer ID="rvInventoryItemwiseConsumptionReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" PageCountMode="Actual" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory.InventoryItemwiseConsumptionReport.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudyCentrePrintingFormat" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="InventoryItemwiseConsumptionReport" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="InventoryItemwiseConsumptionReportDataSetTableAdapters.InventoryItemwiseConsumptionReportTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="InventoryItemWiseConsumptionTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
    <div>
        <br />
        <br />
        <br />
    </div>
</body>
</html>

