//this class contain methods related to nationality functionality
var GeneralPriceGroup = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPriceGroup.constructor();
        //GeneralPriceGroup.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#GeneralPriceGroupCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#GroupDescription').focus();
            return false;
        });



        // Create new record

        $('#CreateGeneralPriceGroupRecord').on("click", function () {
            debugger;
            GeneralPriceGroup.ActionName = "Create";
            GeneralPriceGroup.AjaxCallGeneralPriceGroup();
        });

        $('#EditGeneralPriceGroupRecord').on("click", function () {

            GeneralPriceGroup.ActionName = "Edit";
            GeneralPriceGroup.AjaxCallGeneralPriceGroup();
        });

        $('#DeleteGeneralPriceGroupRecord').on("click", function () {

            GeneralPriceGroup.ActionName = "Delete";
            GeneralPriceGroup.AjaxCallGeneralPriceGroup();
        });

        $('#GeneralPriceGroupDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MarchandiseGroupCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

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
             url: '/GeneralPriceGroup/List',
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
            url: '/GeneralPriceGroup/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record

    AjaxCallGeneralPriceGroup: function () {
        var GeneralPriceGroupData = null;

        if (GeneralPriceGroup.ActionName == "Create") {
            debugger;
            $("#FormCreateGeneralPriceGroup").validate();
            if ($("#FormCreateGeneralPriceGroup").valid()) {
                GeneralPriceGroupData = null;
                GeneralPriceGroupData = GeneralPriceGroup.GetGeneralPriceGroup();
                ajaxRequest.makeRequest("/GeneralPriceGroup/Create", "POST", GeneralPriceGroupData, GeneralPriceGroup.Success, "CreateGeneralPriceGroupRecord");
            }
        }
        else if (GeneralPriceGroup.ActionName == "Edit") {
            $("#FormEditGeneralPriceGroup").validate();
            if ($("#FormEditGeneralPriceGroup").valid()) {
                GeneralPriceGroupData = null;
                GeneralPriceGroupData = GeneralPriceGroup.GetGeneralPriceGroup();
                ajaxRequest.makeRequest("/GeneralPriceGroup/Edit", "POST", GeneralPriceGroupData, GeneralPriceGroup.Success);
            }
        }
        else if (GeneralPriceGroup.ActionName == "Delete") {

            GeneralPriceGroupData = null;
            //$("#FormCreateGeneralPriceGroup").validate();
            GeneralPriceGroupData = GeneralPriceGroup.GetGeneralPriceGroup();
            ajaxRequest.makeRequest("/GeneralPriceGroup/Delete", "POST", GeneralPriceGroupData, GeneralPriceGroup.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPriceGroup: function () {
        var Data = {
        };

        if (GeneralPriceGroup.ActionName == "Create" || GeneralPriceGroup.ActionName == "Edit") {
            debugger
            Data.ID = $('#ID').val();
            Data.GeneralPriceGroupCode = $('#GeneralPriceGroupCode').val();
            Data.GeneralPriceGroupDescription = $('#GeneralPriceGroupDescription').val();
            Data.IsRelatedTo = $('#IsRelatedTo').val();

        }
        else if (GeneralPriceGroup.ActionName == "Delete") {

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
            GeneralPriceGroup.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
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
//       GeneralPriceGroup.ReloadList("Record Updated Sucessfully.", actionMode);
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
//        GeneralPriceGroup.ReloadList("Record Deleted Sucessfully.");
//      //  alert("Record Deleted Sucessfully.");

//    } else {
//        parent.$.colorbox.close();
//       // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    }


//},


