//this class contain methods related to nationality functionality
var InventoryCounterApplicableDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryCounterApplicableDetails.constructor();
        //InventoryCounterApplicableDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#SelectedCentreCode').on("change", function () {
            $('#DivCreateNew').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });




        $('#CounterName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MachineName').focus();
            $('#MachineCode').val("");
            return false;
        });

        $('#btnShowList').click(function () {
            
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            if (valuCentreCode != "") {
                InventoryCounterApplicableDetails.LoadList(valuCentreCode);
            }
            else if (valuCentreCode == "") {
                $('#SuccessMessage').html("Please select centre");
                $('#SuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }

        });

        // Create new record
        
        $('#CreateInventoryCounterApplicableDetailsRecord').on("click", function () {
           
            InventoryCounterApplicableDetails.ActionName = "Create";
            InventoryCounterApplicableDetails.AjaxCallInventoryCounterApplicableDetails();
        });

        $('#EditInventoryCounterApplicableDetailsRecord').on("click", function () {

           InventoryCounterApplicableDetails.ActionName = "Edit";
            InventoryCounterApplicableDetails.AjaxCallInventoryCounterApplicableDetails();
        });

        $('#DeleteInventoryCounterApplicableDetailsRecord').on("click", function () {

            InventoryCounterApplicableDetails.ActionName = "Delete";
            InventoryCounterApplicableDetails.AjaxCallInventoryCounterApplicableDetails();
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
        var selectedText = $('#SelectedCenterID').text();

        $.ajax(

         {
             cache: false,
             
             type: "GET",
             data: { centerCode: SelectedCentreCode },

             dataType: "html",
             url: '/InventoryCounterApplicableDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "GET",
            data: {  actionMode: actionMode, centerCode: CentreCode},
            dataType: "html",
          //  data: { "actionMode": actionMode },
            url: '/InventoryCounterApplicableDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallInventoryCounterApplicableDetails: function () {
     
        var InventoryCounterApplicableDetailsData = null;
        if (InventoryCounterApplicableDetails.ActionName == "Create") {
            
            $("#FormCreateInventoryCounterApplicableDetails").validate();
            if ($("#FormCreateInventoryCounterApplicableDetails").valid()) {
                InventoryCounterApplicableDetailsData = null;
                InventoryCounterApplicableDetailsData = InventoryCounterApplicableDetails.GetInventoryCounterApplicableDetails();
                ajaxRequest.makeRequest("/InventoryCounterApplicableDetails/Create", "POST", InventoryCounterApplicableDetailsData, InventoryCounterApplicableDetails.Success);
            }
        }
        else if (InventoryCounterApplicableDetails.ActionName == "Edit") {
            $("#FormEditInventoryCounterApplicableDetails").validate();
            if ($("#FormEditInventoryCounterApplicableDetails").valid()) {
                InventoryCounterApplicableDetailsData = null;
                InventoryCounterApplicableDetailsData = InventoryCounterApplicableDetails.GetInventoryCounterApplicableDetails();
                ajaxRequest.makeRequest("/InventoryCounterApplicableDetails/Edit", "POST", InventoryCounterApplicableDetailsData, InventoryCounterApplicableDetails.Success);
            }
        }
        else if (InventoryCounterApplicableDetails.ActionName == "Delete") {
            InventoryCounterApplicableDetailsData = null;
            //$("#FormCreateInventoryCounterApplicableDetails").validate();
            InventoryCounterApplicableDetailsData = InventoryCounterApplicableDetails.GetInventoryCounterApplicableDetails();
            ajaxRequest.makeRequest("/InventoryCounterApplicableDetails/Delete", "POST", InventoryCounterApplicableDetailsData, InventoryCounterApplicableDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryCounterApplicableDetails: function () {
        var Data = {
        };
        if (InventoryCounterApplicableDetails.ActionName == "Create" || InventoryCounterApplicableDetails.ActionName == "Edit") {
          //  Data.ID = $('#ID').val();
            Data.InvCounterMasterID = $("input[id=InvCounterMasterID]").val();
            Data.InvMachineMasterID = $('#MachineCode :selected').val();
            Data.MachineCode = $('#MachineCode :selected').text();
            Data.SelectedCentreCode = $("input[id=SelectedCentreCode]").val();
          
        }
        else if (InventoryCounterApplicableDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
            Data.SelectedCentreCode = $("#SelectedCentreCode :selected").val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        

        var CentreCode = data.SelectedCentreCode;//splitdata[1].split(":");
        //var splitData = data.errorMessage.split(',');


        var splitData = data.errorMessage.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            InventoryCounterApplicableDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        }

    },


};

