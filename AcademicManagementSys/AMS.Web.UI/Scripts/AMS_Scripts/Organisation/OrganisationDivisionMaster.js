////this class contain methods related to nationality functionality
//var OrganisationDivisionMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationDivisionMaster.constructor();
//        //OrganisationDivisionMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#DivisionDescription').focus();
//            return false;
//        });


//        // Create new record
//        $('#CreateOrganisationDivisionMasterRecord').on("click", function () {
//            OrganisationDivisionMaster.ActionName = "Create";
//            OrganisationDivisionMaster.AjaxCallOrganisationDivisionMaster();
//        });

//        $('#EditOrganisationDivisionMasterRecord').on("click", function () {
            
//            OrganisationDivisionMaster.ActionName = "Edit";
//            OrganisationDivisionMaster.AjaxCallOrganisationDivisionMaster();
//        });

//        $('#DeleteOrganisationDivisionMasterRecord').on("click", function () {

//            OrganisationDivisionMaster.ActionName = "Delete";
//            OrganisationDivisionMaster.AjaxCallOrganisationDivisionMaster();
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
//             url: '/OrganisationDivisionMaster/List',
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
//            url: '/OrganisationDivisionMaster/List',
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
//    AjaxCallOrganisationDivisionMaster: function () {
//        var OrganisationDivisionMasterData = null;
//        if (OrganisationDivisionMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationDivisionMaster").validate();
//            if ($("#FormCreateOrganisationDivisionMaster").valid()) {
//                OrganisationDivisionMasterData = null;
//                OrganisationDivisionMasterData = OrganisationDivisionMaster.GetOrganisationDivisionMaster();
//                ajaxRequest.makeRequest("/OrganisationDivisionMaster/Create", "POST", OrganisationDivisionMasterData, OrganisationDivisionMaster.Success);
//            }
//        }
//        else if (OrganisationDivisionMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationDivisionMaster").validate();
//            if ($("#FormEditOrganisationDivisionMaster").valid()) {
//                OrganisationDivisionMasterData = null;
//                OrganisationDivisionMasterData = OrganisationDivisionMaster.GetOrganisationDivisionMaster();
//                ajaxRequest.makeRequest("/OrganisationDivisionMaster/Edit", "POST", OrganisationDivisionMasterData, OrganisationDivisionMaster.Success);
//            }
//        }
//        else if (OrganisationDivisionMaster.ActionName == "Delete") {
//            OrganisationDivisionMasterData = null;
//            //$("#FormCreateOrganisationDivisionMaster").validate();
//            OrganisationDivisionMasterData = OrganisationDivisionMaster.GetOrganisationDivisionMaster();
            
//            ajaxRequest.makeRequest("/OrganisationDivisionMaster/Delete", "POST", OrganisationDivisionMasterData, OrganisationDivisionMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page

//    GetOrganisationDivisionMaster: function () {
//        var Data = {
//        };
//        if (OrganisationDivisionMaster.ActionName == "Create" || OrganisationDivisionMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.DivisionDescription = $('#DivisionDescription').val();
//            Data.DivShortCode = $('#DivShortCode').val();
//            Data.PrintShortCode = $('#PrintShortCode').val();
//        }
//        else if (OrganisationDivisionMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//            Data.DivisionDescription = $('#ID').val();
//            Data.DivShortCode = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationDivisionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationDivisionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

        
        
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        OrganisationDivisionMaster.ReloadList("Record Updated Sucessfully.");
//    //        //  alert("Record Created Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Updated Sucessfully. Please Try Again..");
//    //    }

//    //},
//    //this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {

        
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        OrganisationDivisionMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////////////new js/////////////////////////


//this class contain methods related to nationality functionality
var OrganisationDivisionMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationDivisionMaster.constructor();
        //OrganisationDivisionMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DivisionDescription').focus();
            return false;
        });


        // Create new record
        $('#CreateOrganisationDivisionMasterRecord').on("click", function () {
            OrganisationDivisionMaster.ActionName = "Create";
            OrganisationDivisionMaster.AjaxCallOrganisationDivisionMaster();
        });

        $('#EditOrganisationDivisionMasterRecord').on("click", function () {

            OrganisationDivisionMaster.ActionName = "Edit";
            OrganisationDivisionMaster.AjaxCallOrganisationDivisionMaster();
        });

        $('#DeleteOrganisationDivisionMasterRecord').on("click", function () {

            OrganisationDivisionMaster.ActionName = "Delete";
            OrganisationDivisionMaster.AjaxCallOrganisationDivisionMaster();
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
             url: '/OrganisationDivisionMaster/List',
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
            url: '/OrganisationDivisionMaster/List',
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
    AjaxCallOrganisationDivisionMaster: function () {
        var OrganisationDivisionMasterData = null;
        if (OrganisationDivisionMaster.ActionName == "Create") {
            $("#FormCreateOrganisationDivisionMaster").validate();
            if ($("#FormCreateOrganisationDivisionMaster").valid()) {
                OrganisationDivisionMasterData = null;
                OrganisationDivisionMasterData = OrganisationDivisionMaster.GetOrganisationDivisionMaster();
                ajaxRequest.makeRequest("/OrganisationDivisionMaster/Create", "POST", OrganisationDivisionMasterData, OrganisationDivisionMaster.Success);
            }
        }
        else if (OrganisationDivisionMaster.ActionName == "Edit") {
            $("#FormEditOrganisationDivisionMaster").validate();
            if ($("#FormEditOrganisationDivisionMaster").valid()) {
                OrganisationDivisionMasterData = null;
                OrganisationDivisionMasterData = OrganisationDivisionMaster.GetOrganisationDivisionMaster();
                ajaxRequest.makeRequest("/OrganisationDivisionMaster/Edit", "POST", OrganisationDivisionMasterData, OrganisationDivisionMaster.Success);
            }
        }
        else if (OrganisationDivisionMaster.ActionName == "Delete") {
            OrganisationDivisionMasterData = null;
            //$("#FormCreateOrganisationDivisionMaster").validate();
            OrganisationDivisionMasterData = OrganisationDivisionMaster.GetOrganisationDivisionMaster();

            ajaxRequest.makeRequest("/OrganisationDivisionMaster/Delete", "POST", OrganisationDivisionMasterData, OrganisationDivisionMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page

    GetOrganisationDivisionMaster: function () {
        var Data = {
        };
        if (OrganisationDivisionMaster.ActionName == "Create" || OrganisationDivisionMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.DivisionDescription = $('#DivisionDescription').val();
            Data.DivShortCode = $('#DivShortCode').val();
            Data.PrintShortCode = $('#PrintShortCode').val();
        }
        else if (OrganisationDivisionMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
            Data.DivisionDescription = $('#ID').val();
            Data.DivShortCode = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationDivisionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            OrganisationDivisionMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

