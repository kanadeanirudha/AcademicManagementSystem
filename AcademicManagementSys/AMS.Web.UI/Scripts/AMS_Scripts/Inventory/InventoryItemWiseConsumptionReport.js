
//this class contain methods related to Itemwise consumption report functionality

var InventoryItemWiseConsumptionReport = {
    ActionName: null,
    SelectedItemIDs: null,
    AllSelectedItemIDs: null,
    //Class intialisation method
    Initialize: function () {
        InventoryItemWiseConsumptionReport.constructor();
    },

    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $("#ItemConsumptionReport").hide();


        $('#btnItemWiseConsumptionReportSubmit').on("click", function () {
           
            if ($("#AccountBalsheetMstID").val() != null && $("#AccountBalsheetMstID").val() > 0) {
                InventoryItemWiseConsumptionReport.GetSelectedItemListXML();
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
    GetSelectedItemListXML: function () {
       
        var xmlParamList = "<rows>"
        $('#e5_f input[type=checkbox]').each(function () {

            if ($(this).val() != "on") {
                if (this.checked == true) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + $(this).val() + "</ID>" + "</row>";
                }
            }
        });
        if (xmlParamList.length > 6) {
            InventoryItemWiseConsumptionReport.SelectedItemIDs = xmlParamList + "</rows>";
            $("#ItemNameListXml").val(InventoryItemWiseConsumptionReport.SelectedItemIDs);
        }
        else {
            $("#ItemNameListXml").val('');
        }
    },
    

};