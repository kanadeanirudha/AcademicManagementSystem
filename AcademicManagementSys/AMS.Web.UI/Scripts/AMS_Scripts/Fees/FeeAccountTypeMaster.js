//this class contain methods related to nationality functionality
var FeeAccountTypeMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        FeeAccountTypeMaster.constructor();
        //FeeAccountTypeMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#FeeAccountTypeMasterCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });



        // Create new record

        $('#CreateFeeAccountTypeMasterRecord').on("click", function () {
            debugger;
            FeeAccountTypeMaster.ActionName = "Create";
            FeeAccountTypeMaster.AjaxCallFeeAccountTypeMaster();
        });

        $('#EditFeeAccountTypeMasterRecord').on("click", function () {

            FeeAccountTypeMaster.ActionName = "Edit";
            FeeAccountTypeMaster.AjaxCallFeeAccountTypeMaster();
        });

        $('#DeleteFeeAccountTypeMasterRecord').on("click", function () {

            FeeAccountTypeMaster.ActionName = "Delete";
            FeeAccountTypeMaster.AjaxCallFeeAccountTypeMaster();
        });

        $('#FeeAccountTypeDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        

        InitAnimatedBorder();

        CloseAlert();

        //   $('#CountryName').on("keydown", function (e) {
        //AMSValidation.AllowCharacterOnly(e);
        // });
        //  $('#ContryCode').on("keydown", function (e) {
        //   AMSValidation.AllowCharacterOnly(e);
        //  if (e.keyCode == 32) {
        //       return false;
        // }
        // });
        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

        //$("#searchBtn").click(function () {
        //    $("#UserSearch").focus();
        //});


        //$("#showrecord").change(function () {
        //    var showRecord = $("#showrecord").val();
        //    $("select[name*='myDataTable_length']").val(showRecord);
        //    $("select[name*='myDataTable_length']").change();
        //});

        // $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/FeeAccountTypeMaster/List',
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
            url: '/FeeAccountTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallFeeAccountTypeMaster: function () {
        var FeeAccountTypeMasterData = null;

        if (FeeAccountTypeMaster.ActionName == "Create") {
            debugger;
            $("#FormCreateFeeAccountTypeMaster").validate();
            if ($("#FormCreateFeeAccountTypeMaster").valid()) {
                FeeAccountTypeMasterData = null;
                FeeAccountTypeMasterData = FeeAccountTypeMaster.GetFeeAccountTypeMaster();
                ajaxRequest.makeRequest("/FeeAccountTypeMaster/Create", "POST", FeeAccountTypeMasterData, FeeAccountTypeMaster.Success, "CreateFeeAccountTypeMasterRecord");
            }
        }
        else if (FeeAccountTypeMaster.ActionName == "Edit") {
            $("#FormEditFeeAccountTypeMaster").validate();
            if ($("#FormEditFeeAccountTypeMaster").valid()) {
                FeeAccountTypeMasterData = null;
                FeeAccountTypeMasterData = FeeAccountTypeMaster.GetFeeAccountTypeMaster();
                ajaxRequest.makeRequest("/FeeAccountTypeMaster/Edit", "POST", FeeAccountTypeMasterData, FeeAccountTypeMaster.Success);
            }
        }
        else if (FeeAccountTypeMaster.ActionName == "Delete") {

            FeeAccountTypeMasterData = null;
            //$("#FormCreateFeeAccountTypeMaster").validate();
            FeeAccountTypeMasterData = FeeAccountTypeMaster.GetFeeAccountTypeMaster();
            ajaxRequest.makeRequest("/FeeAccountTypeMaster/Delete", "POST", FeeAccountTypeMasterData, FeeAccountTypeMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeAccountTypeMaster: function () {
        var Data = {
        };

        if (FeeAccountTypeMaster.ActionName == "Create" || FeeAccountTypeMaster.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.FeeAccountTypeDesc = $('#FeeAccountTypeDesc').val();
            Data.FeeAccountTypeCode = $('#FeeAccountTypeCode').val();
        }
        else if (FeeAccountTypeMaster.ActionName == "Delete") {

            Data.ID = $('#ID').val();
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {


        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeAccountTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};

//this is used to for showing successfully record updation message and reload the list view
// editSuccess: function (data) {



// if (data == "True") {

//        parent.$.colorbox.close();
//    var actionMode = "1";
//       FeeAccountTypeMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//        //  alert("Record Created Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    }

//},
////this is used to for showing successfully record deletion message and reload the list view
//deleteSuccess: function (data) {


//    if (data == "True") {

//        parent.$.colorbox.close();
//        FeeAccountTypeMaster.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


