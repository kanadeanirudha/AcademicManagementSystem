//var OrganisationMediumMaster = {
//    variable: null,
//    Initialize: function () {
//        OrganisationMediumMaster.constructor();
//    },
//    constructor: function () {

//        $('#CreateOrganisationMediumMasterRecord').on("click", function () {
            
//            OrganisationMediumMaster.ActionName = "Create";
//            OrganisationMediumMaster.AjaxCallOrganisationMediumMaster();
//        });
//        $('#EditOrganisationMediumMasterRecord').on("click", function () {
//            OrganisationMediumMaster.ActionName = "Edit";
//             OrganisationMediumMaster.AjaxCallOrganisationMediumMaster();
//        });
//        $('#DeleteOrganisationMediumMasterRecord').on("click", function () {
//            OrganisationMediumMaster.ActionName = "Delete";
//            OrganisationMediumMaster.AjaxCallOrganisationMediumMaster();
//        });
//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").on("keyup", function () {
//            oTable.fnFilter(this.value);
//        });
//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });
//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });
//        $(".ajax").colorbox();
//        $('#reset').on("click", function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#Description').focus();
          
//        });

//        $('#Description').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//    },
//    LoadList: function () {
        
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            url: '/OrganisationMediumMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $('#ListViewModel').html(data);
//            }
//        });
//    },
//    ReloadList: function (message, colorCode, actionMode) {
        
//        $.ajax(
//       {
//           cache: false,
//           type: "POST",
//           data: { "actionMode": actionMode },
//           dataType: "html",
//           url: '/OrganisationMediumMaster/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $("#ListViewModel").empty().append(data);
//               //twitter type notification
//               $('#SuccessMessage').html(message);
//               $('#SuccessMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', colorCode);
//           }
//       });
//    },

//    AjaxCallOrganisationMediumMaster: function () {
//        var OrganisationMediumMasterMasterData = null;
//        if (OrganisationMediumMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationMediumMaster").validate();
//            if ($("#FormCreateOrganisationMediumMaster").valid()) {
               
//                OrganisationMediumMasterMasterData = OrganisationMediumMaster.GetOrganisationMediumMasterMaster();
//                ajaxRequest.makeRequest("/OrganisationMediumMaster/Create", "POST", OrganisationMediumMasterMasterData, OrganisationMediumMaster.Success);
//            }
//        }
//        else if (OrganisationMediumMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationMediumMasterMaster").validate();
//            if ($("#FormEditOrganisationMediumMasterMaster").valid()) {
                
//                OrganisationMediumMasterMasterData = OrganisationMediumMaster.GetOrganisationMediumMasterMaster();
//                ajaxRequest.makeRequest("/OrganisationMediumMaster/Edit", "POST", OrganisationMediumMasterMasterData, OrganisationMediumMaster.Success);
//            }
//        }
//        else if (OrganisationMediumMaster.ActionName == "Delete") {
            
//            OrganisationMediumMasterMasterData = OrganisationMediumMaster.GetOrganisationMediumMasterMaster();
//            ajaxRequest.makeRequest("/OrganisationMediumMaster/Delete", "POST", OrganisationMediumMasterMasterData, OrganisationMediumMaster.Success);
//        }
//    },

//    GetOrganisationMediumMasterMaster: function () {
//        var Data = {
//        };
//        if (OrganisationMediumMaster.ActionName == "Create" || OrganisationMediumMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.Description = $('#Description').val();
//            Data.CodeShortCode = $('#CodeShortCode').val();
//            Data.PrintShortCode = $('#PrintShortCode').val();
//        }
//        else if (OrganisationMediumMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//        }
//        return Data;
//    },

//    Success: function (data) {
//        var splitData = data.split(',');
//             parent.$.colorbox.close();
//            OrganisationMediumMaster.ReloadList(splitData[0], splitData[1], splitData[2]);

//    },
//    //editSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //     OrganisationMediumMaster.ReloadList("Record Updated Sucessfully.");
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//    //deleteSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    OrganisationMediumMaster.ReloadList("Record Deleted Sucessfully.");
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};


/////////new js/////////////

var OrganisationMediumMaster = {
    variable: null,
    Initialize: function () {
        OrganisationMediumMaster.constructor();
    },
    constructor: function () {

        $('#CreateOrganisationMediumMasterRecord').on("click", function () {

            OrganisationMediumMaster.ActionName = "Create";
            OrganisationMediumMaster.AjaxCallOrganisationMediumMaster();
        });
        $('#EditOrganisationMediumMasterRecord').on("click", function () {
            OrganisationMediumMaster.ActionName = "Edit";
            OrganisationMediumMaster.AjaxCallOrganisationMediumMaster();
        });
        $('#DeleteOrganisationMediumMasterRecord').on("click", function () {
            OrganisationMediumMaster.ActionName = "Delete";
            OrganisationMediumMaster.AjaxCallOrganisationMediumMaster();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        $("#UserSearch").on("keyup", function () {
            //oTable.fnFilter(this.value);
        });
        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });
        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });
        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();

        });

        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
    },
    LoadList: function () {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/OrganisationMediumMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
       {
           cache: false,
           type: "POST",
           data: { "actionMode": actionMode },
           dataType: "html",
           url: '/OrganisationMediumMaster/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               //$('#SuccessMessage').html(message);
               //$('#SuccessMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', colorCode);
               notify(message,colorCode);
           }
       });
    },

    AjaxCallOrganisationMediumMaster: function () {
        var OrganisationMediumMasterMasterData = null;
        if (OrganisationMediumMaster.ActionName == "Create") {
            $("#FormCreateOrganisationMediumMaster").validate();
            if ($("#FormCreateOrganisationMediumMaster").valid()) {

                OrganisationMediumMasterMasterData = OrganisationMediumMaster.GetOrganisationMediumMasterMaster();
                ajaxRequest.makeRequest("/OrganisationMediumMaster/Create", "POST", OrganisationMediumMasterMasterData, OrganisationMediumMaster.Success);
            }
        }
        else if (OrganisationMediumMaster.ActionName == "Edit") {
            $("#FormEditOrganisationMediumMasterMaster").validate();
            if ($("#FormEditOrganisationMediumMasterMaster").valid()) {

                OrganisationMediumMasterMasterData = OrganisationMediumMaster.GetOrganisationMediumMasterMaster();
                ajaxRequest.makeRequest("/OrganisationMediumMaster/Edit", "POST", OrganisationMediumMasterMasterData, OrganisationMediumMaster.Success);
            }
        }
        else if (OrganisationMediumMaster.ActionName == "Delete") {

            OrganisationMediumMasterMasterData = OrganisationMediumMaster.GetOrganisationMediumMasterMaster();
            ajaxRequest.makeRequest("/OrganisationMediumMaster/Delete", "POST", OrganisationMediumMasterMasterData, OrganisationMediumMaster.Success);
        }
    },

    GetOrganisationMediumMasterMaster: function () {
        var Data = {
        };
        if (OrganisationMediumMaster.ActionName == "Create" || OrganisationMediumMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.Description = $('#Description').val();
            Data.CodeShortCode = $('#CodeShortCode').val();
            Data.PrintShortCode = $('#PrintShortCode').val();
        }
        else if (OrganisationMediumMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    Success: function (data) {
        var splitData = data.split(',');
        $.magnificPopup.close();
        OrganisationMediumMaster.ReloadList(splitData[0], splitData[1], splitData[2]);

    },
    //editSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //     OrganisationMediumMaster.ReloadList("Record Updated Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
    //deleteSuccess: function (data) {
    //    parent.$.colorbox.close();
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List
    //    OrganisationMediumMaster.ReloadList("Record Deleted Sucessfully.");
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};


