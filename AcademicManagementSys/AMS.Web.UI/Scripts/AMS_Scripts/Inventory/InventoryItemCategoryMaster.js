////this class contain methods related to nationality functionality
//var InventoryItemCategoryMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        InventoryItemCategoryMaster.constructor();
//        //InventoryItemCategoryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#CategoryCode').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#CategoryDescription').focus();
//            return false;
//        });


//        // Create new record
//        $('#CreateInventoryItemCategoryMasterRecord').on("click", function () {
//            InventoryItemCategoryMaster.ActionName = "Create";
//            InventoryItemCategoryMaster.AjaxCallInventoryItemCategoryMaster();
//        });

//        $('#EditInventoryItemCategoryMasterRecord').on("click", function () {

//            InventoryItemCategoryMaster.ActionName = "Edit";
//            InventoryItemCategoryMaster.AjaxCallInventoryItemCategoryMaster();
//        });

//        $('#DeleteInventoryItemCategoryMasterRecord').on("click", function () {

//            InventoryItemCategoryMaster.ActionName = "Delete";
//            InventoryItemCategoryMaster.AjaxCallInventoryItemCategoryMaster();
//        });


//        $('#CategoryCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#CategoryDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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


//    },
//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/InventoryItemCategoryMaster/List',
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
//            data: { "actionMode": actionMode },
//            url: '/InventoryItemCategoryMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallInventoryItemCategoryMaster: function () {
//        var InventoryItemCategoryMasterData = null;
//        if (InventoryItemCategoryMaster.ActionName == "Create") {
//            $("#FormCreateInventoryItemCategoryMaster").validate();
//            if ($("#FormCreateInventoryItemCategoryMaster").valid()) {
//                InventoryItemCategoryMasterData = null;
//                InventoryItemCategoryMasterData = InventoryItemCategoryMaster.GetInventoryItemCategoryMaster();
//                ajaxRequest.makeRequest("/InventoryItemCategoryMaster/Create", "POST", InventoryItemCategoryMasterData, InventoryItemCategoryMaster.Success);
//            }
//        }
//        else if (InventoryItemCategoryMaster.ActionName == "Edit") {
//            $("#FormEditInventoryItemCategoryMaster").validate();
//            if ($("#FormEditInventoryItemCategoryMaster").valid()) {
//                InventoryItemCategoryMasterData = null;
//                InventoryItemCategoryMasterData = InventoryItemCategoryMaster.GetInventoryItemCategoryMaster();
//                ajaxRequest.makeRequest("/InventoryItemCategoryMaster/Edit", "POST", InventoryItemCategoryMasterData, InventoryItemCategoryMaster.Success);
//            }
//        }
//        else if (InventoryItemCategoryMaster.ActionName == "Delete") {
//            InventoryItemCategoryMasterData = null;
//            //$("#FormCreateInventoryItemCategoryMaster").validate();
//            InventoryItemCategoryMasterData = InventoryItemCategoryMaster.GetInventoryItemCategoryMaster();
//            ajaxRequest.makeRequest("/InventoryItemCategoryMaster/Delete", "POST", InventoryItemCategoryMasterData, InventoryItemCategoryMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetInventoryItemCategoryMaster: function () {
//        var Data = {
//        };
//        if (InventoryItemCategoryMaster.ActionName == "Create" || InventoryItemCategoryMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.CategoryCode = $('#CategoryCode').val();
//            Data.CategoryDescription = $('#CategoryDescription').val();
//            //Data.SeqNo = $('#SeqNo').val();
//            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
//        }
//        else if (InventoryItemCategoryMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        debugger;
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            InventoryItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            InventoryItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },


//};


///////////////////new js////////////////////////


//this class contain methods related to nationality functionality
var InventoryItemCategoryMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryItemCategoryMaster.constructor();
        //InventoryItemCategoryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CategoryCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CategoryDescription').focus();
            return false;
        });


        // Create new record
        $('#CreateInventoryItemCategoryMasterRecord').on("click", function () {
            InventoryItemCategoryMaster.ActionName = "Create";
            InventoryItemCategoryMaster.AjaxCallInventoryItemCategoryMaster();
        });

        $('#EditInventoryItemCategoryMasterRecord').on("click", function () {

            InventoryItemCategoryMaster.ActionName = "Edit";
            InventoryItemCategoryMaster.AjaxCallInventoryItemCategoryMaster();
        });

        $('#DeleteInventoryItemCategoryMasterRecord').on("click", function () {

            InventoryItemCategoryMaster.ActionName = "Delete";
            InventoryItemCategoryMaster.AjaxCallInventoryItemCategoryMaster();
        });


        $('#CategoryCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#CategoryDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/InventoryItemCategoryMaster/List',
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
            url: '/InventoryItemCategoryMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallInventoryItemCategoryMaster: function () {
        var InventoryItemCategoryMasterData = null;
        if (InventoryItemCategoryMaster.ActionName == "Create") {
            $("#FormCreateInventoryItemCategoryMaster").validate();
            if ($("#FormCreateInventoryItemCategoryMaster").valid()) {
                InventoryItemCategoryMasterData = null;
                InventoryItemCategoryMasterData = InventoryItemCategoryMaster.GetInventoryItemCategoryMaster();
                ajaxRequest.makeRequest("/InventoryItemCategoryMaster/Create", "POST", InventoryItemCategoryMasterData, InventoryItemCategoryMaster.Success);
            }
        }
        else if (InventoryItemCategoryMaster.ActionName == "Edit") {
            $("#FormEditInventoryItemCategoryMaster").validate();
            if ($("#FormEditInventoryItemCategoryMaster").valid()) {
                InventoryItemCategoryMasterData = null;
                InventoryItemCategoryMasterData = InventoryItemCategoryMaster.GetInventoryItemCategoryMaster();
                ajaxRequest.makeRequest("/InventoryItemCategoryMaster/Edit", "POST", InventoryItemCategoryMasterData, InventoryItemCategoryMaster.Success);
            }
        }
        else if (InventoryItemCategoryMaster.ActionName == "Delete") {
            InventoryItemCategoryMasterData = null;
            //$("#FormCreateInventoryItemCategoryMaster").validate();
            InventoryItemCategoryMasterData = InventoryItemCategoryMaster.GetInventoryItemCategoryMaster();
            ajaxRequest.makeRequest("/InventoryItemCategoryMaster/Delete", "POST", InventoryItemCategoryMasterData, InventoryItemCategoryMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryItemCategoryMaster: function () {
        var Data = {
        };
        if (InventoryItemCategoryMaster.ActionName == "Create" || InventoryItemCategoryMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CategoryCode = $('#CategoryCode').val();
            Data.CategoryDescription = $('#CategoryDescription').val();
            //Data.SeqNo = $('#SeqNo').val();
            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (InventoryItemCategoryMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            InventoryItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            InventoryItemCategoryMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};


