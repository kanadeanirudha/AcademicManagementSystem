//this class contain methods related to nationality functionality
var FeeCriteriaMasterAndDetails = {
    //Member variables
    ActionName: null,
    SelectedCriteriaParamXMLstring: null,
    SelectedAccBalsheetMstIDs: null,
    //Class intialisation method
    Initialize: function () {
        FeeCriteriaMasterAndDetails.constructor();
    },
    //Attach all event of page
    constructor: function () {
        //Reset button click event function to reset all controls of form



        $('#CreateFeeCriteriaMasterAndDetailsRecord').on("click", function () {
            
            FeeCriteriaMasterAndDetails.ActionName = "Create";
            FeeCriteriaMasterAndDetails.GetCriteriaParam();
            if (FeeCriteriaMasterAndDetails.SelectedCriteriaParamXMLstring != null && FeeCriteriaMasterAndDetails.SelectedCriteriaParamXMLstring != "") {
                FeeCriteriaMasterAndDetails.AjaxCallFeeCriteriaMasterAndDetails();
            }
            else {
                $("#displayErrorMessage p").text("Criteria Parameter must be selected").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");

            }
           
        });
        $('#DeleteFeeCriteriaMasterAndDetailsRecord').on("click", function () {
           
            FeeCriteriaMasterAndDetails.ActionName = "Delete";
            FeeCriteriaMasterAndDetails.AjaxCallFeeCriteriaMasterAndDetails();
        });




        $('#reset').on("click", function () {
            debugger;
            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');
            $('#FeeCriteriaDescription').focus();
            $('#FeeCriteriaDescription').val("");
            //$('#ControlHeadlist').prop("disabled", true);
            $('#FeeCriteriaCode').val("");
            //$('#SubTypeIdentification').val("1");
            //$('#FeeSource').val("1");
            //$('#FeeTypeCode').val("STRUCT");
            $("#selectCriteriaParam").val('');
            $("select[name=selCriteriaParam]").val('').selectpicker('refresh');
            return false;
        });

        $('#FeeCriteriaDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#FeeCriteriaCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });
        InitAnimatedBorder();
        CloseAlert();


    },
    //LoadList method is used to load List page
    LoadList: function () {
        
        var Balancesheet = $("#selectedBalsheetID").val();        
        if (Balancesheet != null && Balancesheet != "") {
        $.ajax(
           {
               cache: false,
               type: "POST",
               dataType: "html",
               url: '/FeeCriteriaMasterAndDetails/List',
               success: function (data) {                  
                   
                   $('#ListViewModel').html(data);
               }
           });
        }
        else {
            notify("Please select balancesheet.", "danger");
            return false;
        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var Balancesheet = $("#selectedBalsheetID").val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            data: {  "actionMode": actionMode },
            dataType: "html",
            url: '/FeeCriteriaMasterAndDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                ////twitter type notification
                notify(message, colorCode);
            }
        });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallFeeCriteriaMasterAndDetails: function () {
        var FeeCriteriaMasterAndDetailsData = null;
        if (FeeCriteriaMasterAndDetails.ActionName == "Create") {
            
            $("#FormCreateFeeCriteriaMasterAndDetails").validate();
            if ($("#FormCreateFeeCriteriaMasterAndDetails").valid()) {
                FeeCriteriaMasterAndDetailsData = null;
                FeeCriteriaMasterAndDetailsData = FeeCriteriaMasterAndDetails.GetFeeCriteriaMasterAndDetails();
                ajaxRequest.makeRequest("/FeeCriteriaMasterAndDetails/CreateCriteriaMasterAndDetails", "POST", FeeCriteriaMasterAndDetailsData, FeeCriteriaMasterAndDetails.Success, "CreateFeeCriteriaMasterAndDetailsRecord");
            }
        }
        else if (FeeCriteriaMasterAndDetails.ActionName == "Delete") {
            $("#FormDeleteFeeCriteriaMasterAndDetails").validate();
            if ($("#FormDeleteFeeCriteriaMasterAndDetails").valid()) {
                FeeCriteriaMasterAndDetailsData = null;
                FeeCriteriaMasterAndDetailsData = FeeCriteriaMasterAndDetails.GetFeeCriteriaMasterAndDetails();
                ajaxRequest.makeRequest("/FeeCriteriaMasterAndDetails/DeleteCriteriaMasterAndDetails", "POST", FeeCriteriaMasterAndDetailsData, FeeCriteriaMasterAndDetails.Success, "DeleteFeeCriteriaMasterAndDetailsRecord");
            }
        }
    },
    //Method to create xml of Selected Criteria Param  
    GetCriteriaParam: function () {
        var selectedItem = $("#selectCriteriaParam").val();
        var xmlParamList = "<rows>";
       
        if (selectedItem != null) {
           
            for (var i = 0; i < selectedItem.length; i++) {
                xmlParamList = xmlParamList + "<row>" + "<FeeCriteriaParametersID>" + String(selectedItem).split(',')[i] + "</FeeCriteriaParametersID>" + "</row>";
            }         
        }
       
        if (xmlParamList.length > 6)
            FeeCriteriaMasterAndDetails.SelectedCriteriaParamXMLstring = xmlParamList + "</rows>";
        else
            FeeCriteriaMasterAndDetails.SelectedCriteriaParamXMLstring = "";
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeCriteriaMasterAndDetails: function () {
        var Data = {
        };
        if (FeeCriteriaMasterAndDetails.ActionName == "Create") {
            Data.AccBalanceSheetID = $('input[name=AccBalanceSheetID]').val();
            Data.FeeTypeID = $('#FeeTypeID').val();
            Data.FeeCriteriaDescription = $("input[name=FeeCriteriaDescription]").val();
            Data.FeeCriteriaCode = $("#FeeCriteriaCode").val();
            Data.FeeCriteriaParametersXML = FeeCriteriaMasterAndDetails.SelectedCriteriaParamXMLstring;
        }
        if (FeeCriteriaMasterAndDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeCriteriaMasterAndDetails.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },
};