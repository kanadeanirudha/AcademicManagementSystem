////this class contain methods related to nationality functionality
//var GeneralCasteMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralCasteMaster.constructor();
//        //GeneralCasteMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#SelectedCategoryID').val('');
//            $('#SelectedCategoryID').focus();
//            return false;
//        });

//        // Create new record
//        $('#CreateGeneralCasteMasterRecord').on("click", function () {
//            GeneralCasteMaster.ActionName = "Create";
//            GeneralCasteMaster.AjaxCallGeneralCasteMaster();
//        });

//        $('#EditGeneralCasteMasterRecord').on("click", function () {
            
//            GeneralCasteMaster.ActionName = "Edit";
//            GeneralCasteMaster.AjaxCallGeneralCasteMaster();
//        });

//        $('#DeleteGeneralCasteMasterRecord').on("click", function () {

//            GeneralCasteMaster.ActionName = "Delete";
//            GeneralCasteMaster.AjaxCallGeneralCasteMaster();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $('#CastName').on("keydown", function (e) {
//            AMSValidation.AllowAlphaNumericOnly(e);
//        });
//    },
//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/GeneralCasteMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message ,colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode },
//            url: '/GeneralCasteMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralCasteMaster: function () {
//        var GeneralCasteMasterData = null;
//        if (GeneralCasteMaster.ActionName == "Create") {
//            $("#FormCreateGeneralCasteMaster").validate();
//            if ($("#FormCreateGeneralCasteMaster").valid()) {
//                GeneralCasteMasterData = null;
//                GeneralCasteMasterData = GeneralCasteMaster.GetGeneralCasteMaster();
//                ajaxRequest.makeRequest("/GeneralCasteMaster/Create", "POST", GeneralCasteMasterData, GeneralCasteMaster.Success);
//            }
//        }
//        else if (GeneralCasteMaster.ActionName == "Edit") {
//            $("#FormEditGeneralCasteMaster").validate();
//            if ($("#FormEditGeneralCasteMaster").valid()) {
//                GeneralCasteMasterData = null;
//                GeneralCasteMasterData = GeneralCasteMaster.GetGeneralCasteMaster();
//                ajaxRequest.makeRequest("/GeneralCasteMaster/Edit", "POST", GeneralCasteMasterData, GeneralCasteMaster.Success);
//            }
//        }
//        else if (GeneralCasteMaster.ActionName == "Delete") {
//            GeneralCasteMasterData = null;
//            //$("#FormCreateGeneralCasteMaster").validate();
//            GeneralCasteMasterData = GeneralCasteMaster.GetGeneralCasteMaster();
            
//            ajaxRequest.makeRequest("/GeneralCasteMaster/Delete", "POST", GeneralCasteMasterData, GeneralCasteMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralCasteMaster: function () {
//        var Data = {
//        };
//        if (GeneralCasteMaster.ActionName == "Create" || GeneralCasteMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.CategoryID = $('#CategoryID').val();
//            Data.SelectedCategoryID = $('#SelectedCategoryID').val();
//            Data.Description = $('#CastName').val();
//        }
//        else if (GeneralCasteMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralCasteMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralCasteMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        GeneralCasteMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        GeneralCasteMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

////////////new js////////////////


//this class contain methods related to nationality functionality
var GeneralCasteMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralCasteMaster.constructor();
        //GeneralCasteMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SelectedCategoryID').val('');
            $('#SelectedCategoryID').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralCasteMasterRecord').on("click", function () {
            GeneralCasteMaster.ActionName = "Create";
            GeneralCasteMaster.AjaxCallGeneralCasteMaster();
        });

        $('#EditGeneralCasteMasterRecord').on("click", function () {

            GeneralCasteMaster.ActionName = "Edit";
            GeneralCasteMaster.AjaxCallGeneralCasteMaster();
        });

        $('#DeleteGeneralCasteMasterRecord').on("click", function () {

            GeneralCasteMaster.ActionName = "Delete";
            GeneralCasteMaster.AjaxCallGeneralCasteMaster();
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

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#CastName').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralCasteMaster/List',
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
            url: '/GeneralCasteMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralCasteMaster: function () {
        var GeneralCasteMasterData = null;
        if (GeneralCasteMaster.ActionName == "Create") {
            $("#FormCreateGeneralCasteMaster").validate();
            if ($("#FormCreateGeneralCasteMaster").valid()) {
                GeneralCasteMasterData = null;
                GeneralCasteMasterData = GeneralCasteMaster.GetGeneralCasteMaster();
                ajaxRequest.makeRequest("/GeneralCasteMaster/Create", "POST", GeneralCasteMasterData, GeneralCasteMaster.Success);
            }
        }
        else if (GeneralCasteMaster.ActionName == "Edit") {
            $("#FormEditGeneralCasteMaster").validate();
            if ($("#FormEditGeneralCasteMaster").valid()) {
                GeneralCasteMasterData = null;
                GeneralCasteMasterData = GeneralCasteMaster.GetGeneralCasteMaster();
                ajaxRequest.makeRequest("/GeneralCasteMaster/Edit", "POST", GeneralCasteMasterData, GeneralCasteMaster.Success);
            }
        }
        else if (GeneralCasteMaster.ActionName == "Delete") {
            GeneralCasteMasterData = null;
            //$("#FormCreateGeneralCasteMaster").validate();
            GeneralCasteMasterData = GeneralCasteMaster.GetGeneralCasteMaster();

            ajaxRequest.makeRequest("/GeneralCasteMaster/Delete", "POST", GeneralCasteMasterData, GeneralCasteMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralCasteMaster: function () {
        var Data = {
        };
        if (GeneralCasteMaster.ActionName == "Create" || GeneralCasteMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CategoryID = $('#CategoryID').val();
            Data.SelectedCategoryID = $('#SelectedCategoryID').val();
            Data.Description = $('#CastName').val();
        }
        else if (GeneralCasteMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralCasteMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralCasteMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    
    //    
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        GeneralCasteMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralCasteMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

