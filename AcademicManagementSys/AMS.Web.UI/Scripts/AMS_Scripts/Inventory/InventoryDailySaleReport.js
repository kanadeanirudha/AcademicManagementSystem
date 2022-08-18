//this class contain methods related to nationality functionality
var InventoryDailySaleReport = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        InventoryDailySaleReport.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form
        $('#btnInventoryDailySaleReportSubmit').on("click", function () {
            $("#BalanceSheetID").val($("#selectedBalsheetID").val());
            $("#IsPosted").val(true);
        });

        $("#FromDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy',
        });

        $("#UptoDate").datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy',
        });

        $("#FromDate").on("keydown", function (e) {
            return false;
        });

        $("#UptoDate").on("keydown", function (e) {
            return false;
        });
    },

};