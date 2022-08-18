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
            scriptManager.RegisterPostBackControl(this.rvInventoryBelowIndentLevelReport);
            if (!Page.IsPostBack)
            {
                AMS.Web.UI.Controllers.InventoryBelowIndentLevelController controller = new AMS.Web.UI.Controllers.InventoryBelowIndentLevelController();
                List<AMS.DTO.InventoryReportMaster> InventoryBelowIndentLevelReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;
                rvInventoryBelowIndentLevelReport.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory/InventoryBelowIndentLevelReport.rdlc");

                if (Request.RequestType == "POST")
                {
                    OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                    InventoryBelowIndentLevelReport = controller.GetBelowIndendLevelReportData();
                }

                if (InventoryBelowIndentLevelReport == null || InventoryBelowIndentLevelReport.Count == 0 || OrganisationStudyCentreMasterDetails == null || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvInventoryBelowIndentLevelReport.LocalReport.DataSources.Clear();

                    ReportDataSource rdc1 = new ReportDataSource();
                    rdc1.Name = "InventoryBelowIndentLevelReport";
                    rdc1.Value = InventoryBelowIndentLevelReport;
                    rvInventoryBelowIndentLevelReport.LocalReport.DataSources.Add(rdc1);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvInventoryBelowIndentLevelReport.LocalReport.DataSources.Add(rdc2);

                    rvInventoryBelowIndentLevelReport.LocalReport.Refresh();
                    rvInventoryBelowIndentLevelReport.Visible = true;                   

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
                <rsweb:ReportViewer ID="rvInventoryBelowIndentLevelReport" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="99%" PageCountMode="Actual" SizeToReportContent="True">
                
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="InventoryBelowIndentLevelReportDataSetTableAdapters.InventoryDumpAndShrinkReportTableAdapter"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="InventoryBelowIndentLevelTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
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
