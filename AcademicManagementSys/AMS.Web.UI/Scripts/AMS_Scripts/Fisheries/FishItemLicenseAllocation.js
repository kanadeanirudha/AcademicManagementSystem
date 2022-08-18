
//This class cantain methods for Fish License type funcationality.
var FishItemLicenseAllocation = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        FishItemLicenseAllocation.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
        });

        //Create New Record  
        $('#CreateFishItemLicenseAllocationRecord').on("click", function () {
            FishItemLicenseAllocation.ActionName = "Create";
            FishItemLicenseAllocation.AjaxCallFishItemLicenseAllocation();
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

        //// Validate Input fields in form
        //$('#FirstName').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});
    },

    //LoadList method is used to load List page
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "") {
            $.ajax({
                cache: false,
                type: "POST",
                datatype: "html",
                url: '/FishItemLicenseAllocation/List',
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
            url: '/FishItemLicenseAllocation/List',
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
    AjaxCallFishItemLicenseAllocation: function () {
        var FishItemLicenseAllocationData = null;
        if (FishItemLicenseAllocation.ActionName == "Create") {
            $("#FormCreateFishItemLicenseAllocation").validate();
            if ($("#FormCreateFishItemLicenseAllocation").valid()) {
                FishItemLicenseAllocationData = null;
                FishItemLicenseAllocationData = FishItemLicenseAllocation.GetFishItemLicenseAllocation();
                ajaxRequest.makeRequest("/FishItemLicenseAllocation/Create", "POST", FishItemLicenseAllocationData, FishItemLicenseAllocation.Success);
            }
        }
                
    },
    //Get properties data from the Create, Update and Delete page
    GetFishItemLicenseAllocation: function () {
        var Data = {
        };
        if (FishItemLicenseAllocation.ActionName == "Create" || FishItemLicenseAllocation.ActionName == "Edit") {
           
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
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        FishItemLicenseAllocation.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
    }
};