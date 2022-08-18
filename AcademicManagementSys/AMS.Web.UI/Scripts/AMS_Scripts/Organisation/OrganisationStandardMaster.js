////this class contain methods related to nationality functionality
//var OrganisationStandardMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationStandardMaster.constructor();
//        //OrganisationStandardMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {



//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#Description').focus();
//            //var dt = new Date();
//            // document.write("getYear() : " + dt.getYear());
//            //$('#SessionFrom').val(dt.getFullYear());
//            //$('#SessionUpto').val(dt.getFullYear() + 1);
//            $('#StandardNumber').val(0);
//            //$('#SelectedCityID').val('0');
//            return false;
//        });

//        // Create new record
//        $('#CreateOrganisationStandardMasterRecord').on("click", function () {
//            OrganisationStandardMaster.ActionName = "Create";
//            OrganisationStandardMaster.AjaxCallOrganisationStandardMaster();
//        });

//        $('#EditOrganisationStandardMasterRecord').on("click", function () {
            
//            OrganisationStandardMaster.ActionName = "Edit";
//            OrganisationStandardMaster.AjaxCallOrganisationStandardMaster();
//        });

//        $('#DeleteOrganisationStandardMasterRecord').on("click", function () {

//            OrganisationStandardMaster.ActionName = "Delete";
//            OrganisationStandardMaster.AjaxCallOrganisationStandardMaster();
//        });
//        $('#StandardNumber').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $("#UserSearch").keyup(function () {
//          var oTable = $("#myDataTable").dataTable();
//          oTable.fnFilter(this.value);
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
//             url: '/OrganisationStandardMaster/List',
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
//            url: '/OrganisationStandardMaster/List',
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
//    AjaxCallOrganisationStandardMaster: function () {
//        var OrganisationStandardMasterData = null;
//        if (OrganisationStandardMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationStandardMaster").validate();
//            if ($("#FormCreateOrganisationStandardMaster").valid()) {
//                OrganisationStandardMasterData = null;
//                OrganisationStandardMasterData = OrganisationStandardMaster.GetOrganisationStandardMaster();
//                ajaxRequest.makeRequest("/OrganisationStandardMaster/Create", "POST", OrganisationStandardMasterData, OrganisationStandardMaster.Success);
//            }
//        }
//        else if (OrganisationStandardMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationStandardMaster").validate();
//            if ($("#FormEditOrganisationStandardMaster").valid()) {
//                OrganisationStandardMasterData = null;
//                OrganisationStandardMasterData = OrganisationStandardMaster.GetOrganisationStandardMaster();
//                ajaxRequest.makeRequest("/OrganisationStandardMaster/Edit", "POST", OrganisationStandardMasterData, OrganisationStandardMaster.Success);
//            }
//        }
//        else if (OrganisationStandardMaster.ActionName == "Delete") {
//            OrganisationStandardMasterData = null;
//            //$("#FormCreateOrganisationStandardMaster").validate();
//            OrganisationStandardMasterData = OrganisationStandardMaster.GetOrganisationStandardMaster();
            
//            ajaxRequest.makeRequest("/OrganisationStandardMaster/Delete", "POST", OrganisationStandardMasterData, OrganisationStandardMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationStandardMaster: function () {
//        var Data = {
//        };
//        if (OrganisationStandardMaster.ActionName == "Create" || OrganisationStandardMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.Description = $('#Description').val();
//            Data.StandardNumber = $('#StandardNumber').val();
//            Data.CodeShortCode = $('#CodeShortCode').val();
//            Data.PrintShortCode = $('#PrintShortCode').val();
//        }
//        else if (OrganisationStandardMaster.ActionName == "Delete") {
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
//            OrganisationStandardMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationStandardMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    
//    //    
//    //    if (data == "True") {

//    //        parent.$.colorbox.close();
//    //        OrganisationStandardMaster.ReloadList("Record Updated Sucessfully.");
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
//    //        OrganisationStandardMaster.ReloadList("Record Deleted Sucessfully.");
//    //        //  alert("Record Deleted Sucessfully.");

//    //    } else {
//    //        parent.$.colorbox.close();
//    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
//    //    }


//    //},
//};

//////////new js////////

//this class contain methods related to nationality functionality
var OrganisationStandardMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationStandardMaster.constructor();
        //OrganisationStandardMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            //var dt = new Date();
            // document.write("getYear() : " + dt.getYear());
            //$('#SessionFrom').val(dt.getFullYear());
            //$('#SessionUpto').val(dt.getFullYear() + 1);
            $('#StandardNumber').val(0);
            //$('#SelectedCityID').val('0');
            return false;
        });

        // Create new record
        $('#CreateOrganisationStandardMasterRecord').on("click", function () {
            OrganisationStandardMaster.ActionName = "Create";
            OrganisationStandardMaster.AjaxCallOrganisationStandardMaster();
        });

        $('#EditOrganisationStandardMasterRecord').on("click", function () {

            OrganisationStandardMaster.ActionName = "Edit";
            OrganisationStandardMaster.AjaxCallOrganisationStandardMaster();
        });

        $('#DeleteOrganisationStandardMasterRecord').on("click", function () {

            OrganisationStandardMaster.ActionName = "Delete";
            OrganisationStandardMaster.AjaxCallOrganisationStandardMaster();
        });
        $('#StandardNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $("#UserSearch").keyup(function () {
            //var oTable = $("#myDataTable").dataTable();
            //oTable.fnFilter(this.value);
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
             url: '/OrganisationStandardMaster/List',
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
            url: '/OrganisationStandardMaster/List',
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
    AjaxCallOrganisationStandardMaster: function () {
        var OrganisationStandardMasterData = null;
        if (OrganisationStandardMaster.ActionName == "Create") {
            $("#FormCreateOrganisationStandardMaster").validate();
            if ($("#FormCreateOrganisationStandardMaster").valid()) {
                OrganisationStandardMasterData = null;
                OrganisationStandardMasterData = OrganisationStandardMaster.GetOrganisationStandardMaster();
                ajaxRequest.makeRequest("/OrganisationStandardMaster/Create", "POST", OrganisationStandardMasterData, OrganisationStandardMaster.Success);
            }
        }
        else if (OrganisationStandardMaster.ActionName == "Edit") {
            $("#FormEditOrganisationStandardMaster").validate();
            if ($("#FormEditOrganisationStandardMaster").valid()) {
                OrganisationStandardMasterData = null;
                OrganisationStandardMasterData = OrganisationStandardMaster.GetOrganisationStandardMaster();
                ajaxRequest.makeRequest("/OrganisationStandardMaster/Edit", "POST", OrganisationStandardMasterData, OrganisationStandardMaster.Success);
            }
        }
        else if (OrganisationStandardMaster.ActionName == "Delete") {
            OrganisationStandardMasterData = null;
            //$("#FormCreateOrganisationStandardMaster").validate();
            OrganisationStandardMasterData = OrganisationStandardMaster.GetOrganisationStandardMaster();

            ajaxRequest.makeRequest("/OrganisationStandardMaster/Delete", "POST", OrganisationStandardMasterData, OrganisationStandardMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationStandardMaster: function () {
        var Data = {
        };
        if (OrganisationStandardMaster.ActionName == "Create" || OrganisationStandardMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
            Data.StandardNumber = $('#StandardNumber').val();
            Data.CodeShortCode = $('#CodeShortCode').val();
            Data.PrintShortCode = $('#PrintShortCode').val();
        }
        else if (OrganisationStandardMaster.ActionName == "Delete") {
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
            $.magnificPopup.close();
            OrganisationStandardMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            $.magnificPopup.close();
            OrganisationStandardMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    
};

