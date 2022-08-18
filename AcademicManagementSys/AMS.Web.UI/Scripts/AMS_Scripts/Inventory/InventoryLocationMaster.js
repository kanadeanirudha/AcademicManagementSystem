//this class contain methods related to nationality functionality
var InventoryLocationMaster = {

    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryLocationMaster.constructor();
        //InventoryLocationMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#SelectedCentreCode').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
          
            if ($("#SelectedCentreCode").val() =="")
            {
                $("#divAddbtn").hide();
            }
            else {
                $("#divAddbtn").show();
            }
          
            
           

        });


        $('#LocationName').focus();
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LocationName').focus();
            return false;
        });

        $('#btnShowList').click(function () {
            
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            if (valuCentreCode != "") {
                InventoryLocationMaster.LoadList(valuCentreCode);
            }
            else if (valuCentreCode != "") {
                $('#SuccessMessage').html("Please select centre");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }

        });

        // Create new record
        $('#CreateInventoryLocationMasterRecord').on("click", function () {
            InventoryLocationMaster.ActionName = "Create";
            InventoryLocationMaster.AjaxCallInventoryLocationMaster();
        });

        $('#EditInventoryLocationMasterRecord').on("click", function () {

            InventoryLocationMaster.ActionName = "Edit";
            InventoryLocationMaster.AjaxCallInventoryLocationMaster();
        });

        $('#DeleteInventoryLocationMasterRecord').on("click", function () {

            InventoryLocationMaster.ActionName = "Delete";
            InventoryLocationMaster.AjaxCallInventoryLocationMaster();
        });


        $('#LocationName').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

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

        $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function (SelectedCentreCode) {
        $.ajax(

         {

             cache: false,
             type: "Get",
             data: { centerCode: SelectedCentreCode },
             dataType: "html",
             url: '/InventoryLocationMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);

                 if ($('#SelectedCentreCode :selected').val() == "") {
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
    ReloadList: function (message, colorCode, actionMode, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { centerCode: CentreCode, actionMode: actionMode },
            
            url: '/InventoryLocationMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                $("#divAddbtn").show();
            }
        });
    },
   

    //Fire ajax call to insert update and delete record
    AjaxCallInventoryLocationMaster: function () {
        var InventoryLocationMasterData = null;
        if (InventoryLocationMaster.ActionName == "Create") {
            $("#FormCreateInventoryLocationMaster").validate();
            if ($("#FormCreateInventoryLocationMaster").valid()) {
                InventoryLocationMasterData = null;
                InventoryLocationMasterData = InventoryLocationMaster.GetInventoryLocationMaster();
                ajaxRequest.makeRequest("/InventoryLocationMaster/Create", "POST", InventoryLocationMasterData, InventoryLocationMaster.Success);
            }
        }
        else if (InventoryLocationMaster.ActionName == "Edit") {
            $("#FormEditInventoryLocationMaster").validate();
            if ($("#FormEditInventoryLocationMaster").valid()) {
                InventoryLocationMasterData = null;
                InventoryLocationMasterData = InventoryLocationMaster.GetInventoryLocationMaster();
                ajaxRequest.makeRequest("/InventoryLocationMaster/Edit", "POST", InventoryLocationMasterData, InventoryLocationMaster.Success);
            }
        }
        else if (InventoryLocationMaster.ActionName == "Delete") {
            InventoryLocationMasterData = null;
            //$("#FormCreateInventoryLocationMaster").validate();
            InventoryLocationMasterData = InventoryLocationMaster.GetInventoryLocationMaster();
            ajaxRequest.makeRequest("/InventoryLocationMaster/Delete", "POST", InventoryLocationMasterData, InventoryLocationMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryLocationMaster: function () {
        var Data = {
        };
        if (InventoryLocationMaster.ActionName == "Create" || InventoryLocationMaster.ActionName == "Edit") {
         
            Data.ID = $("input[id=ID]").val();
            Data.LocationName = $('#LocationName').val();
            Data.SelectedCentreCode = $("#SelectedCentreCode :selected").val();
        }
        else if (InventoryLocationMaster.ActionName == "Delete") {
           
            Data.ID = $("input[id=ID]").val();
            Data.SelectedCentreCode = $("#SelectedCentreCode :selected").val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var CentreCode = data.SelectedCentreCode;

        var splitData = data.errorMessage.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            InventoryLocationMaster.ReloadList(splitData[0], splitData[1], splitData[2],CentreCode);
        } 

    },


};

