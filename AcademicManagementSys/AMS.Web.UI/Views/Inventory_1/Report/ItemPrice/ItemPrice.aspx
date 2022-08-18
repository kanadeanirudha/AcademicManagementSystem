﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Inventory Item Price Report</title>
    <script runat="server">
   
        AMS.Web.UI.Controllers.ItemPriceController controller = new AMS.Web.UI.Controllers.ItemPriceController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvItemPrice);
            if (!IsPostBack)
            {
                rvItemPrice.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.InventoryReport> InventoryReport = null;
                //List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;



                InventoryReport = controller.GetItemPriceList();


                if (InventoryReport == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvItemPrice.LocalReport.ReportPath = Server.MapPath("~/Report/Inventory_1/ItemPrice.rdlc");
                    rvItemPrice.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "InventoryItemPriceListDataSet1";//Data Set Name
                    rdc.Value = InventoryReport;                //DTO object
                    rvItemPrice.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[1];
                    param[0] = new ReportParameter("CentreName", InventoryReport.Count > 0 ? InventoryReport[0].CentreName : string.Empty, false);
                    rvItemPrice.LocalReport.SetParameters(param);

                    rvItemPrice.LocalReport.Refresh();
                    rvItemPrice.Visible = true;
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

                <rsweb:ReportViewer ID="rvItemPrice" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.ItemPrice.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="InventoryItemPriceListDataSet1" />
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="StudyCentrePrintingFormat" />
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="InventoryItemPriceListDataSet1TableAdapters.InventoryItemPriceListTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>

