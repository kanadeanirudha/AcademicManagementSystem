
//This class cantain methods for Entrance Exam Payment Details funcationality.
var EntranceExamPaymentDetails = {

    //Member variables
    ActionName: null,
    Initialize: function () {
        EntranceExamPaymentDetails.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#PaymentMode').val('');
        });

        $('#onlinePayment').hide();
        $('#offlinePayment').hide();

        $("#ChalanDate").datepicker({
            dateFormat: 'd M yy',
            numberOfMonths: 1,
            minDate: 0
        });

        $("input[name='PaymentMode']").change(function () {
            var selectedRadio = $("input[name='PaymentMode']:checked").val();
           
            if (selectedRadio == 'Online') {
                $("#PaymentModeValue").val(selectedRadio);
                $("#offlinePayment").hide();
                $("#onlinePayment").show();

            }
            if (selectedRadio == 'Offline') {                
                $("#PaymentModeValue").val(selectedRadio);
                $("#onlinePayment").hide();
                $("#offlinePayment").show();
            }
            
        });

        // Validate Input fields in form
        $('#ChalanNo').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#BankName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#BankAddress').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

    },

};