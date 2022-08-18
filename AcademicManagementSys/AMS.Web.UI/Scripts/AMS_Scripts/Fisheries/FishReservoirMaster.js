//this class contain methods related to nationality functionality
var FishReservoirMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        FishReservoirMaster.constructor();        
    },
    //Attach all event of page
    constructor: function () {

        $("reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
        });

        //Create New Record  
        $('#CreateFishReservoirMasterRecord').on("click", function () {
            FishReservoirMaster.ActionName = "Create";
            FishReservoirMaster.AjaxCallFishReserviorMaster();
        });

        //Edit Existing Record
        $('#EditFishReservoirMasterRecord').on("click", function () {
            FishReservoirMaster.ActionName = "Edit";
            FishReservoirMaster.AjaxCallFishReserviorMaster();
        });

        //Delete Record
        $('#DeleteFishReservoirMasterRecord').on("click", function () {
            FishReservoirMaster.ActionName = "Delete";
            FishReservoirMaster.AjaxCallFishReserviorMaster();
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

        // Validate Input fields in form
        $('#ReservoirName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#ReservoirCode').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#Address').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Latitude').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#Logitude').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#Area').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#Capacity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });

        $('#MinProductCapacity').on("keydown", function (e) {
            AMSValidation.AllowNumbersWithDecimalOnly(e);
        });       
    },

    //LoadList method is used to load List page
    LoadList: function () {        
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "") {
            $.ajax({
                cache: false,
                type: "POST",
                datatype: "html",
                url: '/FishReservoirMaster/List',
                data: { "actionMode": null },
                success: function (data) {
                    //Rebind Grid Data.
                    $('#ListViewModel').html(data);
                }
            });
        }
        else {
            ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectBalancesheet", "SuccessMessage", "#FFCC80");            
        }
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax({
            cache: false,
            type: "POST",
            datatype: "html",
            data: { actionMode: actionMode },
            url: '/FishReservoirMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallFishReserviorMaster: function () {
        var FishReservoirMasterData = null;        
        if (FishReservoirMaster.ActionName == "Create") {
            $("#FormCreateFishReservoirMaster").validate();
            if ($("#FormCreateFishReservoirMaster").valid()) {                
                FishReservoirMasterData = null;
                FishReservoirMasterData = FishReservoirMaster.GetFishReservoirMaster();
                ajaxRequest.makeRequest("/FishReservoirMaster/Create", "POST", FishReservoirMasterData, FishReservoirMaster.Success);
            }
        }
        else if (FishReservoirMaster.ActionName == "Edit") {
            $("#FormEditFishReservoirMaster").validate();
            if ($("#FormEditFishReservoirMaster").valid()) {
                FishReservoirMasterData = null;
                FishReservoirMasterData = FishReservoirMaster.GetFishReservoirMaster();
                ajaxRequest.makeRequest("/FishReservoirMaster/Edit", "POST", FishReservoirMasterData, FishReservoirMaster.Success);
            }
        }
        else if (FishReservoirMaster.ActionName == "Delete") {
            FishReservoirMasterData = null;
            FishReservoirMasterData = FishReservoirMaster.GetFishReservoirMaster();
            ajaxRequest.makeRequest("/FishReservoirMaster/Delete", "POST", FishReservoirMasterData, FishReservoirMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFishReservoirMaster: function () {
        var Data = {
        };
        if (FishReservoirMaster.ActionName == "Create" || FishReservoirMaster.ActionName == "Edit") {
            
            Data.ID = $('input[name=ID]').val();
            Data.ReservoirName = $('input[name=ReservoirName]').val();
            Data.ReservoirCode = $('input[name=ReservoirCode]').val();
            Data.Address = $('input[name=Address]').val();
            Data.Latitude = $('input[name=Latitude]').val();
            Data.Logitude = $('input[name=Logitude]').val();
            Data.Area = $('input[name=Area]').val();
            Data.Capacity = $('input[name=Capacity]').val();
            Data.MinProductCapacity = $('input[name=MinProductCapacity]').val();
            Data.BalancesheetID = $("#selectedBalsheetID").val();
            Data.LocationId = $('input[name=LocationId]').val();
           
        }
        else if (FishReservoirMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        FishReservoirMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3], splitData[4], splitData[5], splitData[6], splitData[7]);
    }

};