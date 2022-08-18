<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>AccountHeadReport</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvAccountHeadList);
            if (!IsPostBack)
            {
                List<AMS.DTO.AccountHeadMasterReport> accountHeadMasterReport = null;
                List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                AMS.Web.UI.Controllers.AccountHeadMasterReportController controller = new AMS.Web.UI.Controllers.AccountHeadMasterReportController();
                OrganisationStudyCentreMasterDetails = controller.GetReportHeader();
                accountHeadMasterReport = controller.GetListAccountHeadMaster();
                if (accountHeadMasterReport.Count == 0 || OrganisationStudyCentreMasterDetails.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;    
                    NoRecordDiv.Visible = false;
                    rvAccountHeadList.LocalReport.ReportPath = Server.MapPath("~/Report/AccountReports/AccountHeadListReport.rdlc");
                    rvAccountHeadList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "DataSetAccountHeadMasterReport";
                    rdc.Value = accountHeadMasterReport;
                    rvAccountHeadList.LocalReport.DataSources.Add(rdc);

                    ReportDataSource rdc2 = new ReportDataSource();
                    rdc2.Name = "StudyCentrePrintingFormat";
                    rdc2.Value = OrganisationStudyCentreMasterDetails;
                    rvAccountHeadList.LocalReport.DataSources.Add(rdc2);
                    
                    rvAccountHeadList.LocalReport.Refresh();
                    rvAccountHeadList.Visible = true;
                }
            }
        }
       

    </script>

</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <rsweb:ReportViewer ID="rvAccountHeadList" runat="server" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Width="67%" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.AccountHeadListReport.rdlc">

                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="AccountHeadList" />
                               <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />

                        </DataSources>

                    </LocalReport>
                </rsweb:ReportViewer>

                  <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AMSDataSetTableAdapters.OrgStudyCentrePrintingFormatTableAdapter"></asp:ObjectDataSource>
      
                <br />


            </div>
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align:center;" >
                
           <b>No Record Found</b> 
        
        </div>

    </form>
</body>
</html>
