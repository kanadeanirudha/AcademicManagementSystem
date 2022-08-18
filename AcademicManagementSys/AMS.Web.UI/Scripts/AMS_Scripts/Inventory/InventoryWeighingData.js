//this class contain methods related to nationality functionality
var InventoryWeighingData = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryWeighingData.constructor();
        //InventoryWeighingData.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MachineCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            return false;
        });


        // Create new record
        $('#CreateInventoryWeighingDataRecord').on("click", function () {
           
            InventoryWeighingData.ActionName = "Create";
            InventoryWeighingData.AjaxCallInventoryWeighingData();
        });

        $('#EditInventoryWeighingDataRecord').on("click", function () {

            InventoryWeighingData.ActionName = "Edit";
            InventoryWeighingData.AjaxCallInventoryWeighingData();
        });

        $('#DeleteInventoryWeighingDataRecord').on("click", function () {

            InventoryWeighingData.ActionName = "Delete";
            InventoryWeighingData.AjaxCallInventoryWeighingData();
        });


        $('#MachineCode').on("keydown", function (e) {
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
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/InventoryWeighingData/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
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
            data: { "actionMode": actionMode },
            url: '/InventoryWeighingData/List',
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
    AjaxCallInventoryWeighingData: function () {

        var InventoryWeighingDataData = null;
        if (InventoryWeighingData.ActionName == "Create") {
            $("#FormCreateInventoryWeighingData").validate();
            if ($("#FormCreateInventoryWeighingData").valid()) {
                InventoryWeighingDataData = null;
                InventoryWeighingDataData = InventoryWeighingData.GetInventoryWeighingData();
                ajaxRequest.makeRequest("/InventoryWeighingData/Create", "POST", InventoryWeighingDataData, InventoryWeighingData.Success);
            }
        }
        else if (InventoryWeighingData.ActionName == "Edit") {
            $("#FormEditInventoryWeighingData").validate();
            if ($("#FormEditInventoryWeighingData").valid()) {
                InventoryWeighingDataData = null;
                InventoryWeighingDataData = InventoryWeighingData.GetInventoryWeighingData();
                ajaxRequest.makeRequest("/InventoryWeighingData/Edit", "POST", InventoryWeighingDataData, InventoryWeighingData.Success);
            }
        }
        else if (InventoryWeighingData.ActionName == "Delete") {
            InventoryWeighingDataData = null;
            //$("#FormCreateInventoryWeighingData").validate();
            InventoryWeighingDataData = InventoryWeighingData.GetInventoryWeighingData();
            ajaxRequest.makeRequest("/InventoryWeighingData/Delete", "POST", InventoryWeighingDataData, InventoryWeighingData.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryWeighingData: function () {

        var Data = {
        };
        if (InventoryWeighingData.ActionName == "Create" || InventoryWeighingData.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.MachineCode = $('#MachineCode').val();
        }
        else if (InventoryWeighingData.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            InventoryWeighingData.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            InventoryWeighingData.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

