//this class contain methods related to nationality functionality
var InventoryLocationMaster_1 = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryLocationMaster_1.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#InventoryLocationMasterID').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
           // $('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

            if ($("#InventoryLocationMasterID").val() == "") {
                $("#divAddbtn").hide();
            }
            else {
                $("#divAddbtn").show();
            }

          


        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            return false;
        });

        $("#btnShowList").on("click", function () {
           
            var valuCentreCode = $('#InventoryLocationMasterID :selected').val();
           
            if (valuCentreCode != "") {
                InventoryLocationMaster_1.LoadList(valuCentreCode);
                $("#divAddbtn").show();
            }
            else if (valuCentreCode == "") {
                notify("Please select Centre", 'warning');
                $('#divAddbtn').hide(true);
            }

        });
        
       
        // Create new record
        $('#CreateInventoryLocationMaster_1Record').on("click", function () {
          
            InventoryLocationMaster_1.ActionName = "Create";
            InventoryLocationMaster_1.AjaxCallInventoryLocationMaster_1();
        });


        $('#EditInventoryLocationMaster_1Record').on("click", function () {
            InventoryLocationMaster_1.ActionName = "Edit";
            InventoryLocationMaster_1.AjaxCallInventoryLocationMaster_1();
        });

        $('#DeleteInventoryLocationMaster_1Record').on("click", function () {

            InventoryLocationMaster_1.ActionName = "Delete";
            InventoryLocationMaster_1.AjaxCallInventoryLocationMaster_1();
        });


        $('#LocationName').on("keydown", function (e) {
            AMSValidation.AlphaNumericOnly(e);

        });


        InitAnimatedBorder();

        CloseAlert();

    },



    
    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode) {
        $.ajax(

         {

             cache: false,
             type: "Get",
             data: { centerCode: SelectedCentreCode },
             dataType: "html",
             url: '/InventoryLocationMaster_1/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

                 if ($('#InventoryLocationMasterID :selected').val() == "") {
                   
                     $("#divAddbtn").hide();
                 }
                 else {
                     $("#divAddbtn").show();
                 }

                 //$("#divAddbtn").show();
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { centerCode: $("#InventoryLocationMasterID").val(), actionMode: actionMode },
            url: '/InventoryLocationMaster_1/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                if ($('#InventoryLocationMasterID :selected').val() == "") {

                    $("#divAddbtn").hide();
                }
                else {
                    $("#divAddbtn").show();
                }
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryLocationMaster_1: function () {
        var InventoryLocationMaster_1Data = null;
        if (InventoryLocationMaster_1.ActionName == "Create") {
            $("#FormCreateInventoryLocationMaster_1").validate();
            if ($("#FormCreateInventoryLocationMaster_1").valid()) {
                InventoryLocationMaster_1Data = null;
                InventoryLocationMaster_1Data = InventoryLocationMaster_1.GetInventoryLocationMaster_1();

                ajaxRequest.makeRequest("/InventoryLocationMaster_1/Create", "POST", InventoryLocationMaster_1Data, InventoryLocationMaster_1.Success, "CreateInventoryLocationMaster_1Record");
            }


        }
        else if (InventoryLocationMaster_1.ActionName == "Edit") {
            $("#FormEditInventoryLocationMaster_1").validate();
            if ($("#FormEditInventoryLocationMaster_1").valid()) {
                InventoryLocationMaster_1Data = null;

                InventoryLocationMaster_1Data = InventoryLocationMaster_1.GetInventoryLocationMaster_1();

                ajaxRequest.makeRequest("/InventoryLocationMaster_1/Edit", "POST", InventoryLocationMaster_1Data, InventoryLocationMaster_1.Success);

            }
        }
        else if (InventoryLocationMaster_1.ActionName == "Delete") {
            InventoryLocationMaster_1Data = null;
            //$("#FormCreateInventoryLocationMaster_1").validate();
            InventoryLocationMaster_1Data = InventoryLocationMaster_1.GetInventoryLocationMaster_1();
            ajaxRequest.makeRequest("/InventoryLocationMaster_1/Delete", "POST", InventoryLocationMaster_1Data, InventoryLocationMaster_1.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryLocationMaster_1: function () {

        var Data = {
        };
        if (InventoryLocationMaster_1.ActionName == "Create" || InventoryLocationMaster_1.ActionName == "Edit") {

            Data.ID = $("input[id=ID]").val();
            Data.LocationName = $('#LocationName').val();
            Data.SelectedCentreCode = $("#InventoryLocationMasterID :selected").val();
        }
        else if (InventoryLocationMaster_1.ActionName == "Delete") {
            Data.InventoryLocationMaster_1ID = $('input[name=InventoryLocationMaster_1ID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
      
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            InventoryLocationMaster_1.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};
