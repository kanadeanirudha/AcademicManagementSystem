////this class contain methods related to nationality functionality
//var GeneralSessionMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralSessionMaster.constructor();
//        //GeneralSessionMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#SessionFrom').focus();
//            $('#SessionFrom').val(dt.getFullYear());
//            $('#SessionUpto').val(dt.getFullYear() + 1);
//            $('#SessionOrder').val(0);
//        });

//        // Create new record
//        $('#CreateGeneralSessionMasterRecord').on("click", function () {
//            GeneralSessionMaster.ActionName = "Create";
//            GeneralSessionMaster.AjaxCallGeneralSessionMaster();
//        });

//        $('#EditGeneralSessionMasterRecord').on("click", function () {
//            GeneralSessionMaster.ActionName = "Edit";
//            GeneralSessionMaster.AjaxCallGeneralSessionMaster();
//        });

//        $('#DeleteGeneralSessionMasterRecord').on("click", function () {

//            GeneralSessionMaster.ActionName = "Delete";
//            GeneralSessionMaster.AjaxCallGeneralSessionMaster();
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


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

//        $('#SessionFrom').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#SessionOrder').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });

//        $('#SessionFrom').on("change", function (e) {
//            $('#SessionUpto').val(parseInt($('#SessionFrom').val()) + 1);           
//        });
//    },
//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/GeneralSessionMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { actionMode: actionMode },
//            url: '/GeneralSessionMaster/List',
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
//    AjaxCallGeneralSessionMaster: function () {
//        var GeneralSessionMasterData = null;
//        if (GeneralSessionMaster.ActionName == "Create") {
//            $("#FormCreateGeneralSessionMaster").validate();
//            if ($("#FormCreateGeneralSessionMaster").valid()) {
//                GeneralSessionMasterData = null;
//                GeneralSessionMasterData = GeneralSessionMaster.GetGeneralSessionMaster();
//                ajaxRequest.makeRequest("/GeneralSessionMaster/Create", "POST", GeneralSessionMasterData, GeneralSessionMaster.Success);
//            }
//        }
//        else if (GeneralSessionMaster.ActionName == "Edit") {
//            $("#FormEditGeneralSessionMaster").validate();
//            if ($("#FormEditGeneralSessionMaster").valid()) {
//                GeneralSessionMasterData = null;
//                GeneralSessionMasterData = GeneralSessionMaster.GetGeneralSessionMaster();
//                ajaxRequest.makeRequest("/GeneralSessionMaster/Edit", "POST", GeneralSessionMasterData, GeneralSessionMaster.Success);
//            }
//        }
//        else if (GeneralSessionMaster.ActionName == "Delete") {
//            GeneralSessionMasterData = null;
//            //$("#FormCreateGeneralSessionMaster").validate();
//            GeneralSessionMasterData = GeneralSessionMaster.GetGeneralSessionMaster();
            
//            ajaxRequest.makeRequest("/GeneralSessionMaster/Delete", "POST", GeneralSessionMasterData, GeneralSessionMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralSessionMaster: function () {
//        var Data = {
//        };
//        if (GeneralSessionMaster.ActionName == "Create" || GeneralSessionMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.SessionFrom = $('#SessionFrom').val();
//            Data.SessionUpto = $('#SessionUpto').val();
//            //Data.SessionOrder = $('#SessionOrder').val();
//            //Data.CurrentFlag = $('input[id=CurrentFlag]:checked').val();
//        }
//        else if (GeneralSessionMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralSessionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralSessionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    ////this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

        
//    //    if (data == "True") {

//    //        parent.$.colorbox.close(); 
//    //        var actionMode = "1";
//    //        GeneralSessionMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
//    //        GeneralSessionMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////////////new js//////////////

//this class contain methods related to nationality functionality
var GeneralSessionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralSessionMaster.constructor();
        //GeneralSessionMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#SessionFrom').focus();
            $('#SessionFrom').val(dt.getFullYear());
            $('#SessionUpto').val(dt.getFullYear() + 1);
            $('#SessionOrder').val(0);
        });

        // Create new record
        $('#CreateGeneralSessionMasterRecord').on("click", function () {
            GeneralSessionMaster.ActionName = "Create";
            GeneralSessionMaster.AjaxCallGeneralSessionMaster();
        });

        $('#EditGeneralSessionMasterRecord').on("click", function () {
            GeneralSessionMaster.ActionName = "Edit";
            GeneralSessionMaster.AjaxCallGeneralSessionMaster();
        });

        $('#DeleteGeneralSessionMasterRecord').on("click", function () {

            GeneralSessionMaster.ActionName = "Delete";
            GeneralSessionMaster.AjaxCallGeneralSessionMaster();
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


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#SessionFrom').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#SessionOrder').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#SessionFrom').on("change", function (e) {
            $('#SessionUpto').val(parseInt($('#SessionFrom').val()) + 1);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralSessionMaster/List',
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
            url: '/GeneralSessionMaster/List',
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
    AjaxCallGeneralSessionMaster: function () {
        var GeneralSessionMasterData = null;
        if (GeneralSessionMaster.ActionName == "Create") {
            $("#FormCreateGeneralSessionMaster").validate();
            if ($("#FormCreateGeneralSessionMaster").valid()) {
                GeneralSessionMasterData = null;
                GeneralSessionMasterData = GeneralSessionMaster.GetGeneralSessionMaster();
                ajaxRequest.makeRequest("/GeneralSessionMaster/Create", "POST", GeneralSessionMasterData, GeneralSessionMaster.Success);
            }
        }
        else if (GeneralSessionMaster.ActionName == "Edit") {
            $("#FormEditGeneralSessionMaster").validate();
            if ($("#FormEditGeneralSessionMaster").valid()) {
                GeneralSessionMasterData = null;
                GeneralSessionMasterData = GeneralSessionMaster.GetGeneralSessionMaster();
                ajaxRequest.makeRequest("/GeneralSessionMaster/Edit", "POST", GeneralSessionMasterData, GeneralSessionMaster.Success);
            }
        }
        else if (GeneralSessionMaster.ActionName == "Delete") {
            GeneralSessionMasterData = null;
            //$("#FormCreateGeneralSessionMaster").validate();
            GeneralSessionMasterData = GeneralSessionMaster.GetGeneralSessionMaster();

            ajaxRequest.makeRequest("/GeneralSessionMaster/Delete", "POST", GeneralSessionMasterData, GeneralSessionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralSessionMaster: function () {
        var Data = {
        };
        if (GeneralSessionMaster.ActionName == "Create" || GeneralSessionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.SessionFrom = $('#SessionFrom').val();
            Data.SessionUpto = $('#SessionUpto').val();
            //Data.SessionOrder = $('#SessionOrder').val();
            //Data.CurrentFlag = $('input[id=CurrentFlag]:checked').val();
        }
        else if (GeneralSessionMaster.ActionName == "Delete") {
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
            GeneralSessionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralSessionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    ////this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {


    //    if (data == "True") {

    //        parent.$.colorbox.close(); 
    //        var actionMode = "1";
    //        GeneralSessionMaster.ReloadList("Record Updated Sucessfully.", actionMode);
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
    //        GeneralSessionMaster.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }


    //},
};

