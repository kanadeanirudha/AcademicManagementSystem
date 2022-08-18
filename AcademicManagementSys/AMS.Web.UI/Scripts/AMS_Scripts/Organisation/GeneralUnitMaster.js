//this class contain methods related to nationality functionality
var GeneralUnitMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralUnitMaster.constructor();
        //GeneralUnitMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#UnitDescription').focus();
            $('#UnitDescription').val('');
        });

        // Create new record
        $('#CreateGeneralUnitMasterRecord').on("click", function () {
            
            GeneralUnitMaster.ActionName = "Create";
            GeneralUnitMaster.AjaxCallGeneralUnitMaster();
        });

        $('#EditGeneralUnitMasterRecord').on("click", function () {
            
            GeneralUnitMaster.ActionName = "Edit";
            GeneralUnitMaster.AjaxCallGeneralUnitMaster();
        });

        $('#DeleteGeneralUnitMasterRecord').on("click", function () {

            GeneralUnitMaster.ActionName = "Delete";
            GeneralUnitMaster.AjaxCallGeneralUnitMaster();
        });
        $('#WeekDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $("#UserSearch").keyup(function () {
            oTable = $("#myDataTable").dataTable();
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
             url: '/GeneralUnitMaster/List',
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
            data: { actionMode: actionMode },
            url: '/GeneralUnitMaster/List',
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
    AjaxCallGeneralUnitMaster: function () {
        var GeneralUnitMasterData = null;
        if (GeneralUnitMaster.ActionName == "Create") {
            $("#FormCreateGeneralUnitMaster").validate();
            if ($("#FormCreateGeneralUnitMaster").valid()) {
                GeneralUnitMasterData = null;
                GeneralUnitMasterData = GeneralUnitMaster.GetGeneralUnitMaster();
                ajaxRequest.makeRequest("/GeneralUnitMaster/Create", "POST", GeneralUnitMasterData, GeneralUnitMaster.Success);
            }
        }
        else if (GeneralUnitMaster.ActionName == "Edit") {
            $("#FormEditGeneralUnitMaster").validate();
            if ($("#FormEditGeneralUnitMaster").valid()) {
                GeneralUnitMasterData = null;
                GeneralUnitMasterData = GeneralUnitMaster.GetGeneralUnitMaster();
                ajaxRequest.makeRequest("/GeneralUnitMaster/Edit", "POST", GeneralUnitMasterData, GeneralUnitMaster.Success);
            }
        }
        else if (GeneralUnitMaster.ActionName == "Delete") {
            GeneralUnitMasterData = null;
            $("#FormDeleteGeneralUnitMaster").validate();
            GeneralUnitMasterData = GeneralUnitMaster.GetGeneralUnitMaster();
            ajaxRequest.makeRequest("/GeneralUnitMaster/Delete", "POST", GeneralUnitMasterData, GeneralUnitMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralUnitMaster: function () {
        var Data = {
        };
        if (GeneralUnitMaster.ActionName == "Create" || GeneralUnitMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.UnitDescription = $('#UnitDescription').val();
            Data.ShortCode = $('#ShortCode').val();

        }
        else if (GeneralUnitMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            GeneralUnitMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            GeneralUnitMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralUnitMaster.ReloadList("Record Updated Sucessfully.", actionMode);
    //        //  alert("Record Created Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
    //    }

    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {

    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        GeneralUnitMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

