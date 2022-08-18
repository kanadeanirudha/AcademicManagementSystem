//var OrganisationCentrewiseDepartment = {
//    variable: null,
//    Initialize: function () {
//        OrganisationCentrewiseDepartment.constructor();
//    },
//    constructor: function () {

       
//        $("#btnShowList").on("click", function () {
            
//            var SelectedCentreCode = $("#SelectedCentreCode").val();
//            var SelectedCentreName = $("#SelectedCentreCode option:selected").text();
//            if (SelectedCentreCode != "" && SelectedCentreName !="") {
//                $.ajax(
//                     {
//                         cache: false,
//                         type: "GET",
//                         data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName },
//                         dataType: "html",
//                         url: '/OrganisationCentrewiseDepartment/List',
//                         success: function (data) {
//                             //Rebind Grid Data
//                             $('#ListViewModel').html(data);
//                         }
//                     });
//            }
           
//            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }
           
//        });

//        $("#SelectedCentreCode").change( function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });


        

//        $('#CreateOrganisationCentrewiseDepartmentRecord').on("click", function () {
            
//            OrganisationCentrewiseDepartment.ActionName = "Create";
//            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
//        });
//        $('#EditOrganisationCentrewiseDepartmentRecord').on("click", function () {
            
//            OrganisationCentrewiseDepartment.ActionName = "Edit";
//            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
//        });
//        $('#DeleteOrganisationCentrewiseDepartmentRecord').on("click", function () {
//            OrganisationCentrewiseDepartment.ActionName = "Delete";
//            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
//        });
//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").on("keyup", function () {
//            var oTable = $("#myDataTable").dataTable();
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
      

   
//    },
//    LoadList: function () {
     

//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            dataType: "html",
//            url: '/OrganisationCentrewiseDepartment/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $('#ListViewModel').html(data);
//            }
//        });
//    },
//    ReloadList: function (message, colorCode, actionMode,centreCode) {
        
//        var aaa = centreCode.split('~');
//        var SelectedCentreCode = aaa[0];
//        var SelectedCentreName = aaa[1];
//        $.ajax(
//       {
//           cache: false,
//           type: "POST",
//           data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName, "actionMode": actionMode },
//           dataType: "html",
//           url: '/OrganisationCentrewiseDepartment/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $("#ListViewModel").empty().append(data);
//               //twitter type notification
//               $('#SuccessMessage').html(message);
//               $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//           }
//       });
//    },

//    AjaxCallOrganisationCentrewiseDepartment: function () {
//        var OrganisationCentrewiseDepartmentMasterData = null;
//        if (OrganisationCentrewiseDepartment.ActionName == "Create") {
//            $("#FormCreateOrganisationCentrewiseDepartment").validate();
//            if ($("#FormCreateOrganisationCentrewiseDepartment").valid()) {

//                OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
//                ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Create", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
//            }
//        }
//        else if (OrganisationCentrewiseDepartment.ActionName == "Edit") {
//            $("#FormEditOrganisationCentrewiseDepartmentMaster").validate();
           

//                OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
//                ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Edit", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
            
//        }
//        else if (OrganisationCentrewiseDepartment.ActionName == "Delete") {

//            OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
//            ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Delete", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
//        }
//    },

//    GetOrganisationCentrewiseDepartmentMaster: function () {
//            var Data = {};       
//            Data.ID = $('input[name=ID]').val();
//            Data.CentrewiseDepartmentID = $('input[name=CentrewiseDepartmentID]').val();
//            Data.DepartmentID = $('input[name=DepartmentID]').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.ActiveFlag = $('#ActiveFlag:checked').val() ? true : false;
//            Data.DepartmentSeqNo = $('#DepartmentSeqNo').val();
//            Data.SelectedCentreName = $('#SelectedCentreName').val();

//            return Data;
//    },

//    Success: function (data) {
        
//        var CentreCode = data.CentreCodeWithName;
//        var splitData = data.errorMessage.split(',');
//        parent.$.colorbox.close();
//        OrganisationCentrewiseDepartment.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
//    },
  
//};


/////////////new js/////////////////

var OrganisationCentrewiseDepartment = {
    variable: null,
    Initialize: function () {
        OrganisationCentrewiseDepartment.constructor();
    },
    constructor: function () {


        $("#btnShowList").on("click", function () {

            var SelectedCentreCode = $("#SelectedCentreCode").val();
            var SelectedCentreName = $("#SelectedCentreCode option:selected").text();
            if (SelectedCentreCode != "" && SelectedCentreName != "") {
                $.ajax(
                     {
                         cache: false,
                         type: "GET",
                         data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName },
                         dataType: "html",
                         url: '/OrganisationCentrewiseDepartment/List',
                         success: function (data) {
                             //Rebind Grid Data
                             $('#ListViewModel').html(data);
                         }
                     });
            }

            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }

        });

        $("#SelectedCentreCode").change(function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });




        $('#CreateOrganisationCentrewiseDepartmentRecord').on("click", function () {

            OrganisationCentrewiseDepartment.ActionName = "Create";
            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
        });
        $('#EditOrganisationCentrewiseDepartmentRecord').on("click", function () {

            OrganisationCentrewiseDepartment.ActionName = "Edit";
            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
        });
        $('#DeleteOrganisationCentrewiseDepartmentRecord').on("click", function () {
            OrganisationCentrewiseDepartment.ActionName = "Delete";
            OrganisationCentrewiseDepartment.AjaxCallOrganisationCentrewiseDepartment();
        });
        $('#closeBtn').on("click", function () {
            $.magnificPopup.close();
        });
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
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



    },
    LoadList: function () {


        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            url: '/OrganisationCentrewiseDepartment/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode, centreCode) {

        var aaa = centreCode.split('~');
        var SelectedCentreCode = aaa[0];
        var SelectedCentreName = aaa[1];
        $.ajax(
       {
           cache: false,
           type: "POST",
           data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName, "actionMode": actionMode },
           dataType: "html",
           url: '/OrganisationCentrewiseDepartment/List',
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

    AjaxCallOrganisationCentrewiseDepartment: function () {
        var OrganisationCentrewiseDepartmentMasterData = null;
        if (OrganisationCentrewiseDepartment.ActionName == "Create") {
            $("#FormCreateOrganisationCentrewiseDepartment").validate();
            if ($("#FormCreateOrganisationCentrewiseDepartment").valid()) {

                OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
                ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Create", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
            }
        }
        else if (OrganisationCentrewiseDepartment.ActionName == "Edit") {
            $("#FormEditOrganisationCentrewiseDepartmentMaster").validate();


            OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
            ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Edit", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);

        }
        else if (OrganisationCentrewiseDepartment.ActionName == "Delete") {

            OrganisationCentrewiseDepartmentMasterData = OrganisationCentrewiseDepartment.GetOrganisationCentrewiseDepartmentMaster();
            ajaxRequest.makeRequest("/OrganisationCentrewiseDepartment/Delete", "POST", OrganisationCentrewiseDepartmentMasterData, OrganisationCentrewiseDepartment.Success);
        }
    },

    GetOrganisationCentrewiseDepartmentMaster: function () {
        var Data = {};
        Data.ID = $('input[name=ID]').val();
        Data.CentrewiseDepartmentID = $('input[name=CentrewiseDepartmentID]').val();
        Data.DepartmentID = $('input[name=DepartmentID]').val();
        Data.CentreCode = $('#CentreCode').val();
        Data.ActiveFlag = $('#ActiveFlag:checked').val() ? true : false;
        Data.DepartmentSeqNo = $('#DepartmentSeqNo').val();
        Data.SelectedCentreName = $('#SelectedCentreName').val();

        return Data;
    },

    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;
        var splitData = data.errorMessage.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        OrganisationCentrewiseDepartment.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
    },

};


