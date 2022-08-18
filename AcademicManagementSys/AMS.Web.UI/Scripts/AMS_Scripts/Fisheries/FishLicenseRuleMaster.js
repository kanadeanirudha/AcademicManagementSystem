
//This class cantain methods for Fish License Rule funcationality.

var FishLicenseRuleMaster = {
    //Member variables
    ActionName: null,
    SelectedCentreCodes: null,
    AllSelectedCentreCodes: null,
    //Class intialisation method
    Initialize: function () {
        FishLicenseRuleMaster.constructor();
    },

    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
        });

        //Create New Record  
        $('#CreateFishLicenseRuleMasterRecord').on("click", function () {            
            FishLicenseRuleMaster.ActionName = "Create";
            FishLicenseRuleMaster.GetSelectedApplicableCenter();

            if (FishLicenseRuleMaster.SelectedCentreCodes != "" && FishLicenseRuleMaster.SelectedCentreCodes != null || FishLicenseRuleMaster.AllSelectedCentreCodes == true) {
                FishLicenseRuleMaster.AjaxCallFishLicenseRuleMaster();
            }
            else
            {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLicenseRule", "msgDiv", "#FFCC80");                
            }               
        });

        //Delete Record
        $('#DeleteFishLicenseRuleMasterRecord').on("click", function () {            
            FishLicenseRuleMaster.ActionName = "Delete";
            FishLicenseRuleMaster.AjaxCallFishLicenseRuleMaster();
        });

        ////Edit Existing Record
        //$('#EditFishLicenseRuleMasterRecord').on("click", function () {            
        //    FishLicenseRuleMaster.ActionName = "Edit";
        //    FishLicenseRuleMaster.GetSelectedApplicableCenter();
        //    FishLicenseRuleMaster.AjaxCallFishLicenseRuleMaster();
        //});

       

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        $("#ApplicableFromDate").datepicker({
            dateFormat: 'd M yy',
            numberOfMonths: 1,
        });

        $("#ApplicableUptoDate").datepicker({
            dateFormat: 'd M yy',
            numberOfMonths: 1,
        });

        
        $('input[name=IsAplicableToAllCentre]').on("change", function () {                    
            if ($('#IsAplicableToAllCentre').is(":checked")) {                
                $("#checkboxlist").hide();
                $("label[for=FishLicenseApplicableID]").hide();
                // 
                $("#aplicableCentreCheckBoxList").multipleSelect("uncheckAll");
            }            
            else
            {
                $("#checkboxlist").show();
                $("label[for=FishLicenseApplicableID]").show();
                
            }
        });

        $(".ajax").colorbox();

        // Validate Input fields in form
        $('#RuleName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#RuleCode').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#ApplicableFromDate').on("keydown", function (e) {
            AMSValidation.isDate(e);
        });

        $('#ApplicableUptoDate').on("keydown", function (e) {
            AMSValidation.isDate(e);
        });

        $('#Percentage').on("keydown", function (e) {
            AMSValidation.allowNumbersWithDecimalOnly(e);
        });

        $('#LicenseFeeAmount').on("keydown", function (e) {
            AMSVValidation.allowNumbersWithDecimalOnly(e);
        });
        
        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('#Createbutton').hide();
        });

        $("#ShowList").click(function () {           
            var SelectedLicenseTypeID = $('#LicenseTypeList').val();
            if (SelectedLicenseTypeID != "") {
                $.ajax({
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, licenseTypeID: SelectedLicenseTypeID },
                    dataType: "html",
                    url: '/FishLicenseRuleMaster/List',
                    success: function (result) {
                        //Rebind Grid Data                
                        $('#ListViewModel').html(result);
                        $('#Createbutton').show();
                    }
                });
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLicenseRule", "SuccessMessage", "#FFCC80");
                $('#Createbutton').hide();                             
            }
        });
    },

    //LoadList method is used to load List page
    LoadList: function () {
        
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/FishLicenseRuleMaster/List',
            data: { "actionMode": null, "licenseTypeID": 0 },
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);               
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, licenseTypeID, actionMode) {        
        var ID = $('input[name=ID]').val();
        var LicenseTypeID = $('#LicenseTypeID').val();

        $.ajax(        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "licenseTypeID": LicenseTypeID },
            url: '/FishLicenseRuleMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification

                $('#Createbutton').show();
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
            }
        });
    },

    //Method to Create xml of Selected Applicable Center.

    GetSelectedApplicableCenter: function () {        
        var xmlParamList = "<rows>"
        $('#e5_f input[type=checkbox]').each(function () {

            if ($(this).val() != "on") {
                if (this.checked == true) {
                    xmlParamList = xmlParamList + "<row>" + "<CentreCode>" + $(this).val() + "</CentreCode>" + "</row>";
                }
            }
        });
        if (xmlParamList.length > 6)
            FishLicenseRuleMaster.SelectedCentreCodes = xmlParamList + "</rows>";
        else
            FishLicenseRuleMaster.SelectedCentreCodes = "";
    },
    //Fire ajax call to insert update and delete record
    AjaxCallFishLicenseRuleMaster: function () {       
        var FishLicenseRuleMasterData = null;
        if (FishLicenseRuleMaster.ActionName == "Create") {
            
            $("#FormCreateFishLicenseRuleMaster").validate();
            if ($("#FormCreateFishLicenseRuleMaster").valid()) {                
                FishLicenseRuleMasterData = null;
                FishLicenseRuleMasterData = FishLicenseRuleMaster.GetFishLicenseRuleMaster();
                ajaxRequest.makeRequest("/FishLicenseRuleMaster/Create", "POST", FishLicenseRuleMasterData, FishLicenseRuleMaster.Success);
            }
        }
        else if (FishLicenseRuleMaster.ActionName == "Delete") {
            FishLicenseRuleMasterData = null;
            FishLicenseRuleMasterData = FishLicenseRuleMaster.GetFishLicenseRuleMaster();
            ajaxRequest.makeRequest("/FishLicenseRuleMaster/Delete", "POST", FishLicenseRuleMasterData, FishLicenseRuleMaster.Success);
        }

        //else if (FishLicenseRuleMaster.ActionName == "Edit") {
        //    $("#FormEditFishLicenseRuleMaster").validate();
        //    if ($("#FormEditFishLicenseRuleMaster").valid()) {
        //        FishLicenseRuleMasterData = null;
        //        FishLicenseRuleMasterData = FishLicenseRuleMaster.GetFishLicenseRuleMaster();
        //        ajaxRequest.makeRequest("/FishLicenseRuleMaster/Edit", "POST", FishLicenseRuleMasterData, FishLicenseRuleMaster.Success);
        //    }
        //}
        
    },

    //Get properties data from the Create, Update and Delete page
    GetFishLicenseRuleMaster: function () {
        var Data = {
        };
        if (FishLicenseRuleMaster.ActionName == "Create") {
            
            Data.ID = $('input[name=ID]').val();
            Data.LicenseTypeID = $('input[name=LicenseTypeID]').val();
            Data.RuleName = $('input[name=RuleName]').val();
            Data.RuleCode = $('input[name=RuleCode]').val();
            Data.ApplicableFromDate = $('input[name=ApplicableFromDate]').val();
            Data.ApplicableUptoDate = $('input[name=ApplicableUptoDate]').val();
            Data.Percentage = $('input[name=Percentage]').val();
            var flag = $('input[name=IncreaseDecreaseFlag]:checked').val();
            if (flag == "Increase")
            {
                Data.IncreaseDecreaseFlag = "I";
            }
            else
            {
                Data.IncreaseDecreaseFlag = "D";
             }
            Data.IsAplicableToAllCentre = FishLicenseRuleMaster.AllSelectedCentreCodes;
            if (FishLicenseRuleMaster.AllSelectedCentreCodes == false)
            {
                Data.SelectedCentreCodes = FishLicenseRuleMaster.SelectedCentreCodes;
            }
            else {
                Data.SelectedCentreCodes = "";
            }
            Data.LicenseFeeAmount = $('#LicenseFeeAmount').val();
        }
        else if (FishLicenseRuleMaster.ActionName == "Delete") {            
            Data.ID = $('#ID').val();
            Data.LicenseTypeID = $('input[name=LicenseTypeID]').val();
            Data.IsAplicableToAllCentre = $('#IsAplicableToAllCentre').val();
            
        }
        return Data;
    },

    //This method is call on successfully record crated
    Success: function (data) {       
        var splitData = data.split(',');
        parent.$.colorbox.close();
        FishLicenseRuleMaster.AllSelectedCentreCodes = false;
        FishLicenseRuleMaster.SelectedCentreCodes = "";
        FishLicenseRuleMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    }

};