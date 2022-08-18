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
            scriptManager.RegisterPostBackControl(this.rvInventoryDumpAndShrinkReport);
            if (!Page.IsPostBack)
            {
                AMS.Web.UI.Controllers.InventoryDumpAndShrinkReportController controller = new AMS.Web.UI.Controllers.InventoryDumpAndShrinkReportController();
                List<AMS.DTO.InventoryReportMaster> InventoryDumpAndShrinkReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvInventoryDumpAndShrinkReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/InventoryDumpAndShrinkReport.rdlc");

                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    InventoryDumpAndShrinkReport = controller.GetDumpAndShrinkReportData();
                }

                if (InventoryDumpAndShrinkReport == null || InventoryDumpAndShrinkReport.Count == 0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryDumpAndShrinkReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "InventoryDumpAndShrinkReport";
                    rdc1.Value = InventoryDumpAndShrinkReport;
                    rvInventoryDumpAndShrinkReport.LocalReport.DataSources.Add(rdc1);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvInventoryDumpAndShrinkReport.LocalReport.DataSources.Add(rdc2);

                    rvInventoryDumpAndShrinkReport.LocalReport.Refresh();
                    rvInventoryDumpAndShrinkReport.Visible = true;

                    //ReportParameter[] param = new ReportParameter[2];
                    //param[0] = new ReportParameter("FromDate", InventoryDumpAndShrinkReport[0].FromDate, false);
                    //param[1] = new ReportParameter("UptoDate", InventoryDumpAndShrinkReport[0].UptoDate, false);
                    //rvInventoryDumpAndShrinkReport.LocalReport.SetParameters(param);
                    //rvInventoryDumpAndShrinkReport.LocalReport.Refresh();
                    //rvInventoryDumpAndShrinkReport.Visible = true;

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
                <rsweb:ReportViewer ID="rvInventoryDumpAndShrinkReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" PageCountMode="Actual" SizeToReportContent="True">
                
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="InventoryDumpAndShrinkReportDataSetTableAdapters.InventoryDumpAndShrinkReportTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="InventoryDumpAndShrinkTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
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
