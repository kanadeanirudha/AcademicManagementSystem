////this class contain methods related to nationality functionality
//var GeneralCategoryMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralCategoryMaster.constructor();
//        //GeneralCategoryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
//            $('input:checkbox,input:radio').removeAttr('checked');
//            //$('#CategoryType').val('');           
//            $('#CategoryType').val('Open');
//            $('#CategoryName').focus();
//            return false;
//        });

//        // Create new record
//        $('#CreateGeneralCategoryMasterRecord').on("click", function () {
//            GeneralCategoryMaster.ActionName = "Create";
//            GeneralCategoryMaster.AjaxCallGeneralCategoryMaster();
//        });

//        $('#EditGeneralCategoryMasterRecord').on("click", function () {
            
//            GeneralCategoryMaster.ActionName = "Edit";
//            GeneralCategoryMaster.AjaxCallGeneralCategoryMaster();
//        });

//        $('#DeleteGeneralCategoryMasterRecord').on("click", function () {

//            GeneralCategoryMaster.ActionName = "Delete";
//            GeneralCategoryMaster.AjaxCallGeneralCategoryMaster();
//        });
//        $('#SeqNo').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

//        $("#UserSearch").keyup(function () {
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

//        $('#CategoryName').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#CategoryCode').on("keydown", function (e) {
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
//             url: '/GeneralCategoryMaster/List',
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
//            url: '/GeneralCategoryMaster/List',
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
//    AjaxCallGeneralCategoryMaster: function () {
//        var GeneralCategoryMasterData = null;
//        if (GeneralCategoryMaster.ActionName == "Create") {
//            $("#FormCreateGeneralCategoryMaster").validate();
//            if ($("#FormCreateGeneralCategoryMaster").valid()) {
//                GeneralCategoryMasterData = null;
//                GeneralCategoryMasterData = GeneralCategoryMaster.GetGeneralCategoryMaster();
//                ajaxRequest.makeRequest("/GeneralCategoryMaster/Create", "POST", GeneralCategoryMasterData, GeneralCategoryMaster.Success);
//            }
//        }
//        else if (GeneralCategoryMaster.ActionName == "Edit") {
//            $("#FormEditGeneralCategoryMaster").validate();
//            if ($("#FormEditGeneralCategoryMaster").valid()) {
//                GeneralCategoryMasterData = null;
//                GeneralCategoryMasterData = GeneralCategoryMaster.GetGeneralCategoryMaster();
//                ajaxRequest.makeRequest("/GeneralCategoryMaster/Edit", "POST", GeneralCategoryMasterData, GeneralCategoryMaster.Success);
//            }
//        }
//        else if (GeneralCategoryMaster.ActionName == "Delete") {
//            GeneralCategoryMasterData = null;
//            //$("#FormCreateGeneralCategoryMaster").validate();
//            GeneralCategoryMasterData = GeneralCategoryMaster.GetGeneralCategoryMaster();
            
//            ajaxRequest.makeRequest("/GeneralCategoryMaster/Delete", "POST", GeneralCategoryMasterData, GeneralCategoryMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralCategoryMaster: function () {
//        var Data = {
//        };
//        if (GeneralCategoryMaster.ActionName == "Create" || GeneralCategoryMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.CategoryName = $('#CategoryName').val();
//            Data.CategoryCode = $('#CategoryCode').val();
//            Data.CategoryType = $('#CategoryType').val();
//        }
//        else if (GeneralCategoryMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        var actionMode = "1";
//    //        GeneralCategoryMaster.ReloadList("Record Updated Sucessfully.",actionMode );
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        GeneralCategoryMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

///////////////////////new js///////////////////////


//this class contain methods related to nationality functionality
var GeneralCategoryMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralCategoryMaster.constructor();
        //GeneralCategoryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
            //$('#CategoryType').val('');           
            $('#CategoryType').val('Open');
            $('#CategoryName').focus();
            return false;
        });

        // Create new record
        $('#CreateGeneralCategoryMasterRecord').on("click", function () {
            GeneralCategoryMaster.ActionName = "Create";
            GeneralCategoryMaster.AjaxCallGeneralCategoryMaster();
        });

        $('#EditGeneralCategoryMasterRecord').on("click", function () {

            GeneralCategoryMaster.ActionName = "Edit";
            GeneralCategoryMaster.AjaxCallGeneralCategoryMaster();
        });

        $('#DeleteGeneralCategoryMasterRecord').on("click", function () {

            GeneralCategoryMaster.ActionName = "Delete";
            GeneralCategoryMaster.AjaxCallGeneralCategoryMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $("#UserSearch").keyup(function () {
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

        $('#CategoryName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#CategoryCode').on("keydown", function (e) {
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
             url: '/GeneralCategoryMaster/List',
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
            url: '/GeneralCategoryMaster/List',
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
    AjaxCallGeneralCategoryMaster: function () {
        var GeneralCategoryMasterData = null;
        if (GeneralCategoryMaster.ActionName == "Create") {
            $("#FormCreateGeneralCategoryMaster").validate();
            if ($("#FormCreateGeneralCategoryMaster").valid()) {
                GeneralCategoryMasterData = null;
                GeneralCategoryMasterData = GeneralCategoryMaster.GetGeneralCategoryMaster();
                ajaxRequest.makeRequest("/GeneralCategoryMaster/Create", "POST", GeneralCategoryMasterData, GeneralCategoryMaster.Success);
            }
        }
        else if (GeneralCategoryMaster.ActionName == "Edit") {
            $("#FormEditGeneralCategoryMaster").validate();
            if ($("#FormEditGeneralCategoryMaster").valid()) {
                GeneralCategoryMasterData = null;
                GeneralCategoryMasterData = GeneralCategoryMaster.GetGeneralCategoryMaster();
                ajaxRequest.makeRequest("/GeneralCategoryMaster/Edit", "POST", GeneralCategoryMasterData, GeneralCategoryMaster.Success);
            }
        }
        else if (GeneralCategoryMaster.ActionName == "Delete") {
            GeneralCategoryMasterData = null;
            //$("#FormCreateGeneralCategoryMaster").validate();
            GeneralCategoryMasterData = GeneralCategoryMaster.GetGeneralCategoryMaster();

            ajaxRequest.makeRequest("/GeneralCategoryMaster/Delete", "POST", GeneralCategoryMasterData, GeneralCategoryMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralCategoryMaster: function () {
        var Data = {
        };
        if (GeneralCategoryMaster.ActionName == "Create" || GeneralCategoryMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CategoryName = $('#CategoryName').val();
            Data.CategoryCode = $('#CategoryCode').val();
            Data.CategoryType = $('#CategoryType').val();
        }
        else if (GeneralCategoryMaster.ActionName == "Delete") {
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
            GeneralCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

