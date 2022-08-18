
//This class cantain methods for Fish Item License Rate funcationality.
var FishItemLicenseRate = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        FishItemLicenseRate.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ItemName').focus();
        });

        //Create New Record  
        $('#CreateFishItemLicenseRateRecord').on("click", function () {
            FishItemLicenseRate.ActionName = "Create";
            FishItemLicenseRate.AjaxCallFishItemLicenseRate();
        });

        //Edit Existing Record
        $('#EditFishItemLicenseRateRecord').on("click", function () {
            FishItemLicenseRate.ActionName = "Edit";
            FishItemLicenseRate.AjaxCallFishItemLicenseRate();
        });
                

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

        //FOLLOWING FUNCTION IS SEARCHLIST OF EMPLOYEE NAMES 
        $("#ItemName").autocomplete({
            source: function (request, response) {
               
                $.ajax({
                    url: "/FishItemLicenseRate/GetItemNameSearch",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        
                        response($.map(data, function (item) {
                            
                            return { label: item.itemName, value: item.itemName, id:item.itemId };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                $("#ItemID").val(ui.item.id);               
            }
        });

        $(".ajax").colorbox();

        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            $('#Createbutton').hide();
        });

        // Validate Input fields in form
        $('#Rate').on("keydown", function (e) {
            AMSValidation.allowNumbersWithDecimalOnly(e);
        });
    

        $("#btnShowList").click(function () {            
         var centreCodeID = $("#CenterCodeList").val();
         var licenseTypeID = $("#LicenseTypeList").val();
         if (centreCodeID != null && centreCodeID != "")
        {            
            if (licenseTypeID != null && licenseTypeID != "")
            {    
                $.ajax({
                    cache: false,
                    type: "POST",
                    data: { actionMode: null, centerCode: centreCodeID, licenseTypeID: licenseTypeID },
                    dataType: "html",
                    url: '/FishItemLicenseRate/List',
                    success: function (result) {
                        //Rebind Grid Data                
                        $('#ListViewModel').html(result);
                        $('#Createbutton').show();
                    }
                });
            }
            else
            {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectLicenseType", "SuccessMessage", "#FFCC80");
                $('#Createbutton').hide();                             
            }
        }
        else 
         {            
             ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
            $('#Createbutton').hide();                             
        } 
    })
},

//LoadList method is used to load List page
LoadList: function () {    
    $.ajax({
        cache: false,
        type: "POST",
        dataType: "html",
        url: '/FishItemLicenseRate/List',
        data: { "actionMode": null, "CenterCode": "" ,"LicenseTypeID": 0 },
        success: function (data) {
            //Rebind Grid Data
            $('#ListViewModel').html(data);               
        }
    });
},

//ReloadList method is used to load List page
ReloadList: function (message, colorCode, actionMode) {    
    var CenterCode = $("#CenterCodeList").val();
    var LicenseTypeID = $("#LicenseTypeList").val();
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",            
            data: { actionMode: actionMode, centerCode: CenterCode, licenseTypeID: LicenseTypeID },
            url: '/FishItemLicenseRate/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                $('#Createbutton').show();
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFishItemLicenseRate: function () {
        var FishItemLicenseRateData = null;
        if (FishItemLicenseRate.ActionName == "Create") {

            $("#FormCreateFishItemLicenseRate").validate();
            if ($("#FormCreateFishItemLicenseRate").valid()) {
                FishItemLicenseRateData = null;
                FishItemLicenseRateData = FishItemLicenseRate.GetFishItemLicenseRate();
                ajaxRequest.makeRequest("/FishItemLicenseRate/Create", "POST", FishItemLicenseRateData, FishItemLicenseRate.Success);
            }
        }
        else if (FishItemLicenseRate.ActionName == "Edit") {
            $("#FormEditFishItemLicenseRate").validate();
            if ($("#FormEditFishItemLicenseRate").valid()) {
                FishItemLicenseRateData = null;
                FishItemLicenseRateData = FishItemLicenseRate.GetFishItemLicenseRate();
                ajaxRequest.makeRequest("/FishItemLicenseRate/Edit", "POST", FishItemLicenseRateData, FishItemLicenseRate.Success);
            }
        }        
    },

    //Get properties data from the Create, Update and Delete page
    GetFishItemLicenseRate: function () {
        var Data = {
        };
        if (FishItemLicenseRate.ActionName == "Create" || FishItemLicenseRate.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.ItemID = $("#ItemID").val();
            Data.CentreCode = $('#CentreCode').val();
            Data.LicenseTypeID = $('#LicenseTypeID').val();
            Data.Rate = $('#Rate').val();
            
        }        
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {       
        var splitData = data.ErrorMessage.split(',');
        parent.$.colorbox.close();
        FishItemLicenseRate.ReloadList(splitData[0], splitData[1], splitData[2]);
    }

};