

//this class contain methods related to Itemwise consumption report functionality

var InventoryDumpAndShrinkReport = {
    ActionName: null,
    SelectedLocationIDs: null,
    AllSelectedLocationIDs: null,
    //Class intialisation method
    Initialize: function () {
        InventoryDumpAndShrinkReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $("#DumpAndShrinkReport").hide();

        $('#btnDumpAndShrinkReportSubmit').on("click", function () {
            
            if ($("#AccountBalsheetMstID").val() != null && $("#AccountBalsheetMstID").val() > 0) {
                InventoryDumpAndShrinkReport.GetSelectedLocationListXML();
                $("#AccountBalsheetMstID").val($("#selectedBalsheetID").val());
                $("#IsPosted").val(true);
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectBalancesheet", "SuccessMessage", "#FFCC80");
            }
        });
        $('#FromDate').keypress(function (e) {
            return false;
        });
        $("#FromDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy'
        });

        $('#UptoDate').keypress(function (e) {
            return false;
        });
        $("#UptoDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy'
        });
    },

    //Genrate XML for item list.
    GetSelectedLocationListXML: function () {
        
        var xmlParamList = "<rows>"
        $('#e5_f input[type=checkbox]').each(function () {

            if ($(this).val() != "on") {
                if (this.checked == true) {
                    xmlParamList = xmlParamList + "<row><ID>0</ID>" + "<LocationID>" + $(this).val() + "</LocationID>" + "</row>";
                }
            }
        });
        if (xmlParamList.length > 6) {
            InventoryDumpAndShrinkReport.SelectedLocationIDs = xmlParamList + "</rows>";
            $("#LocationNameListXml").val(InventoryDumpAndShrinkReport.SelectedLocationIDs  );
        }
        else {
            $("#LocationNameListXml").val('');
        }
    },
};