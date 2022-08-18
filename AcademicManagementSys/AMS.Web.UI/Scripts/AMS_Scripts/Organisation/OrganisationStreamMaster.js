////this class contain methods related to nationality functionality
//var OrganisationStreamMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationStreamMaster.constructor();
//        //OrganisationStreamMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {


//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#StreamDescription').focus();
//            $('#SelectedDivisionID').val("");
//            return false;
//        });

//        // Create new record
//        $('#CreateOrganisationStreamMasterRecord').on("click", function () {
//            OrganisationStreamMaster.ActionName = "Create";
//            OrganisationStreamMaster.AjaxCallOrganisationStreamMaster();
//        });

//        $('#EditOrganisationStreamMasterRecord').on("click", function () {
//            OrganisationStreamMaster.ActionName = "Edit";
//            OrganisationStreamMaster.AjaxCallOrganisationStreamMaster();
//        });

//        $('#DeleteOrganisationStreamMasterRecord').on("click", function () {

//            OrganisationStreamMaster.ActionName = "Delete";
//            OrganisationStreamMaster.AjaxCallOrganisationStreamMaster();
//        });
//        $('#SeqNo').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });
//        $('#StreamDescription').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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
//             url: '/OrganisationStreamMaster/List',
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
//            url: '/OrganisationStreamMaster/List',
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
//    AjaxCallOrganisationStreamMaster: function () {
//        var OrganisationStreamMasterData = null;
//        if (OrganisationStreamMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationStreamMaster").validate();
//            if ($("#FormCreateOrganisationStreamMaster").valid()) {
//                OrganisationStreamMasterData = null;
//                OrganisationStreamMasterData = OrganisationStreamMaster.GetOrganisationStreamMaster();
//                ajaxRequest.makeRequest("/OrganisationStreamMaster/Create", "POST", OrganisationStreamMasterData, OrganisationStreamMaster.Success);
//            }
//        }
//        else if (OrganisationStreamMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationStreamMaster").validate();
//            if ($("#FormEditOrganisationStreamMaster").valid()) {
//                OrganisationStreamMasterData = null;
//                OrganisationStreamMasterData = OrganisationStreamMaster.GetOrganisationStreamMaster();
//                ajaxRequest.makeRequest("/OrganisationStreamMaster/Edit", "POST", OrganisationStreamMasterData, OrganisationStreamMaster.Success);
//            }
//        }
//        else if (OrganisationStreamMaster.ActionName == "Delete") {
//            OrganisationStreamMasterData = null;
//            //$("#FormCreateOrganisationStreamMaster").validate();
//            OrganisationStreamMasterData = OrganisationStreamMaster.GetOrganisationStreamMaster();
//            ajaxRequest.makeRequest("/OrganisationStreamMaster/Delete", "POST", OrganisationStreamMasterData, OrganisationStreamMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page

//    GetOrganisationStreamMaster: function () {
//        var Data = {
//        };
//        if (OrganisationStreamMaster.ActionName == "Create" || OrganisationStreamMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.StreamDescription = $('#StreamDescription').val();
//            Data.DivisionID = $('#DivisionID').val();
//            Data.StreamShortCode = $('#StreamShortCode').val();
//            Data.PrintShortCode = $('#PrintShortCode').val();
//            Data.SelectedDivisionID = $('#SelectedDivisionID').val();
//        }
//        else if (OrganisationStreamMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {

//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationStreamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationStreamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        OrganisationStreamMaster.ReloadList("Record Updated Sucessfully.");
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
//    //        OrganisationStreamMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};



/////////new js///////////////


//this class contain methods related to nationality functionality
var OrganisationStreamMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationStreamMaster.constructor();
        //OrganisationStreamMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {


        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamDescription').focus();
            $('#SelectedDivisionID').val("");
            return false;
        });

        // Create new record
        $('#CreateOrganisationStreamMasterRecord').on("click", function () {
            OrganisationStreamMaster.ActionName = "Create";
            OrganisationStreamMaster.AjaxCallOrganisationStreamMaster();
        });

        $('#EditOrganisationStreamMasterRecord').on("click", function () {
            OrganisationStreamMaster.ActionName = "Edit";
            OrganisationStreamMaster.AjaxCallOrganisationStreamMaster();
        });

        $('#DeleteOrganisationStreamMasterRecord').on("click", function () {

            OrganisationStreamMaster.ActionName = "Delete";
            OrganisationStreamMaster.AjaxCallOrganisationStreamMaster();
        });
        $('#SeqNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $('#StreamDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

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
             url: '/OrganisationStreamMaster/List',
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
            url: '/OrganisationStreamMaster/List',
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
    AjaxCallOrganisationStreamMaster: function () {
        var OrganisationStreamMasterData = null;
        if (OrganisationStreamMaster.ActionName == "Create") {
            $("#FormCreateOrganisationStreamMaster").validate();
            if ($("#FormCreateOrganisationStreamMaster").valid()) {
                OrganisationStreamMasterData = null;
                OrganisationStreamMasterData = OrganisationStreamMaster.GetOrganisationStreamMaster();
                ajaxRequest.makeRequest("/OrganisationStreamMaster/Create", "POST", OrganisationStreamMasterData, OrganisationStreamMaster.Success);
            }
        }
        else if (OrganisationStreamMaster.ActionName == "Edit") {
            $("#FormEditOrganisationStreamMaster").validate();
            if ($("#FormEditOrganisationStreamMaster").valid()) {
                OrganisationStreamMasterData = null;
                OrganisationStreamMasterData = OrganisationStreamMaster.GetOrganisationStreamMaster();
                ajaxRequest.makeRequest("/OrganisationStreamMaster/Edit", "POST", OrganisationStreamMasterData, OrganisationStreamMaster.Success);
            }
        }
        else if (OrganisationStreamMaster.ActionName == "Delete") {
            OrganisationStreamMasterData = null;
            //$("#FormCreateOrganisationStreamMaster").validate();
            OrganisationStreamMasterData = OrganisationStreamMaster.GetOrganisationStreamMaster();
            ajaxRequest.makeRequest("/OrganisationStreamMaster/Delete", "POST", OrganisationStreamMasterData, OrganisationStreamMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page

    GetOrganisationStreamMaster: function () {
        var Data = {
        };
        if (OrganisationStreamMaster.ActionName == "Create" || OrganisationStreamMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.StreamDescription = $('#StreamDescription').val();
            Data.DivisionID = $('#DivisionID').val();
            Data.StreamShortCode = $('#StreamShortCode').val();
            Data.PrintShortCode = $('#PrintShortCode').val();
            Data.SelectedDivisionID = $('#SelectedDivisionID').val();
        }
        else if (OrganisationStreamMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            $.magnificPopup.close();
            OrganisationStreamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            OrganisationStreamMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

