//var OrganisationSyllabusGroupMaster = {

//    ActionName: null,

//    Initialize: function () {
   
//        OrganisationSyllabusGroupMaster.constructor();
     
//    },

//    constructor: function () {
      
//        $('#UnitWeightage').change(function () {
         
//            var SelectedVal = $(this).val();
//            $('#UnitPercentage').val(SelectedVal);
//        });

//        $('#UnitPercentage').prop('disabled', true);

//        $('#CreateNewUnit').on("click", function (){
//            $('#aaa').show(true);
//            $('#DivCreateHead').show(true);
//            $('#DivEditHead').hide(true);

//            $('#SyllabusGrpDetailsID').val(0);
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
            
//        });
        

//        $('#CreateNewTopic').on("click", function () {
//            $('#bbb').show(true);
//            $('#DivCreateHead').show(true);
//            $('#DivEditHead').hide(true);

//            $('#SyllabusGrpTopicsID').val(0);
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');

//        });



//        $('#DivClose').on("click", function () {
//            $('#aaa').hide(true);
           
//        });
//        $('#CreateOrganisationSyllabusGroupDetailsRecord').on("click", function () {

//            try {
//                OrganisationSyllabusGroupMaster.ActionName = "CreateSyllabusGroupDetails";
//                OrganisationSyllabusGroupMaster.AjaxCallOrganisationSyllabusGroupMaster();

//            }
//            catch (e) {
               
//            }
//            finally {
//                $('input[name=SyllabusGrpDetailsID]').val(0);
//                $('#UnitDescription').val('');
//                $('#NoOfLecturesForUnit').val("");
//                $('#UnitWeightage').val("");
//                $('#UnitPercentage').val("");
//                $('#UnitStatus').attr('checked',false);
//                return false;
//            }

//        });

//        $('#TopicWeightage').change(function () {

//            var SelectedVal = $(this).val();
//            $('#TopicPercentage').val(SelectedVal);
//        });

//        $('#TopicPercentage').prop('disabled', true);

//        $('#CreateOrganisationSyllabusGroupTopicsRecord').on("click", function () {
            
//            try {
//                OrganisationSyllabusGroupMaster.ActionName = "CreateSyllabusGroupTopics";
//                OrganisationSyllabusGroupMaster.AjaxCallOrganisationSyllabusGroupMaster();

//            }
//            catch (e) {

//            }
//            finally {
//                $('input[name=SyllabusGrpTopicsID]').val(0);
//                $('#TopicName').val('');
//                $('#TopicDescription').val('');
//                $('#NoOfLecturesForTopic').val("");
//                $('#TopicWeightage').val("");
//                $('#TopicPercentage').val("");
//                $('#TopicStatus').attr('checked',false);
//                return false;

//            }
//        });
//        $("#SelectedCentreCode").change(function () {
            
//            var selectedItem = $(this).val();
//            var $ddlUniversity = $("#SelectedUniversityID");
//            var $UniversityProgress = $("#states-loading-progress");
//            $UniversityProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationSyllabusGroupMaster/GetUniversityByCentreCode",

//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
//                        $ddlUniversity.append('<option value="">--------Select University-------</option>');
//                        $.each(data, function (id, option) {

//                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $UniversityProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve University.');
//                        $UniversityProgress.hide();
//                    }
//                });
//            }

//            //if ($("#SelectedCentreCode").val() != "") {
//            //    $.ajax({
//            //        cache: false,
//            //        type: "GET",
//            //        url: "/StudentQuickRegistration/GetSessionDetails",

//            //        data: { "SelectedCentreCode": selectedItem },
//            //        success: function (data) {
//            //            $ddlSessionDetails.html('');
//            //            $ddlSessionDetails.append('<option value="">--Select Session--</option>');
//            //            $.each(data, function (id, option) {

//            //                $ddlSessionDetails.append($('<option></option>').val(option.id).html(option.name));
//            //            });

//            //            $SessionDetailsProgress.hide();
//            //        },
//            //        error: function (xhr, ajaxOptions, thrownError) {
//            //            alert('Failed to retrieve Session.');
//            //            $SessionDetailsProgress.hide();
//            //        }
//            //    });
//            //}
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---------Select University---------</option>');
//                $('#btnCreate').hide();
//            }
//            $('#LiSessionName').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });
//        $('#SelectedUniversityID').on("change", function () {
//            $('#LiSessionName').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });
//        $('#btnShowList').click(function () {
            
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID').val();
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSyllabusGroupMaster.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }
//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#LiSessionName').hide(true);
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#LiSessionName').hide(true);
//            }
//        });
//        $('#UnitWeightage').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#NoOfLecturesForUnit').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#TopicWeightage').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#NoOfLecturesForTopic').on("keydown", function (e) {
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
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#StreamID').focus();
//            var dt = new Date();
//            $('#StreamID').val("");
//            $('#MediumID').val("");
//            $('#StandardID').val("");
//            $('#StreamID').val("");
//            return false;
//        });
//        $(".ajax").colorbox();

//        $('#myTableForSyllabusTopics tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        });
//        $('#myTableForSyllabusDetails tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        });
//    },

  

//    LoadList: function () {
//        $.ajax(
//         {
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             url: '/OrganisationSyllabusGroupMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },

//    ReloadList: function (message) {
//        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
//        var SelectedUniversityID = $('#SelectedUniversityID option:selected').val();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
//            dataType: "html",
//            url: '/OrganisationSyllabusGroupMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#commonMessage').html(message);
//                $('#commonMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', '#5C8AE6');
//            }
//        });
//    },

//    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

//        var selectedText = $('#SelectedUniversityID').text();
//        var selectedVal = $('#SelectedUniversityID').val();
//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
//              dataType: "html",
//              url: '/OrganisationSyllabusGroupMaster/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);
//                  $('#LiSessionName').show(true);
//              }
//          });
//    },

//    AjaxCallOrganisationSyllabusGroupMaster: function () {
//        var OrganisationSyllabusGroupMasterData = null;
//        if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupDetails") {
//            $("#FormCreateOrganisationSyllabusGroupDetails").validate();
//            if ($("#FormCreateOrganisationSyllabusGroupDetails").valid()) {
//                OrganisationSyllabusGroupMasterData = null;
//                OrganisationSyllabusGroupMasterData = OrganisationSyllabusGroupMaster.GetOrganisationSyllabusGroupMaster();

//                ajaxRequest.makeRequest("/OrganisationSyllabusGroupMaster/CreateSyllabusGroupDetails", "POST", OrganisationSyllabusGroupMasterData, OrganisationSyllabusGroupMaster.createSyllabusDetailsSuccess);
//            }


//        }
//        else if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupTopics") {
//            $("#FormCreateOrganisationSyllabusGroupTopics").validate();
//            if ($("#FormCreateOrganisationSyllabusGroupTopics").valid()) {
//                OrganisationSyllabusGroupMasterData = null;              
//                OrganisationSyllabusGroupMasterData = OrganisationSyllabusGroupMaster.GetOrganisationSyllabusGroupMaster();
//                ajaxRequest.makeRequest("/OrganisationSyllabusGroupMaster/CreateSyllabusGroupTopics", "POST", OrganisationSyllabusGroupMasterData, OrganisationSyllabusGroupMaster.createSyllabusTopicsSuccess);


//            }
//        }

//    },

//    GetOrganisationSyllabusGroupMaster: function () {
        
//        var Data = {
//        };
//        if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupDetails") {

//            // Properties of table OrgSyllabusGroupDetails
//            Data.SyllabusGroupID = $('input[name=SyllabusGroupID]').val();
//            Data.SyllabusGrpDetailsID = $('input[name=SyllabusGrpDetailsID]').val();
//            Data.UnitDescription = $('#UnitDescription').val();
//            Data.NoOfLecturesForUnit = $('#NoOfLecturesForUnit').val();
//            Data.UnitWeightage = $('#UnitWeightage').val();
//            Data.UnitPercentage = $('#UnitPercentage').val();   
//            Data.UnitStatus = $('input[name=UnitStatus]:checked').val() ? true : false;

//        }
//        else if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupTopics") {

//            // Properties of table OrgSyllabusGroupTopics
//            Data.SyllabusGroupDetID = $('input[name=SyllabusGroupDetID]').val();
//            Data.SyllabusGrpTopicsID = $('input[name=SyllabusGrpTopicsID]').val();   
//            Data.SubjectGroupID = $('input[name=SubjectGroupID]').val();
//            Data.SubjectTypeNumber = $('input[name=SubjectTypeNumber]').val();
//            Data.OrgSemesterMstID = $('input[name=OrgSemesterMstID]').val();
//            Data.TopicName = $('#TopicName').val();
//            Data.TopicDescription = $('#TopicDescription').val();
//            Data.NoOfLecturesForTopic = $('#NoOfLecturesForTopic').val();
//            Data.TopicWeightage = $('#TopicWeightage').val();
//            Data.TopicPercentage = $('#TopicPercentage').val();
//            Data.TopicStatus = $('input[name=TopicStatus]:checked').val() ? true : false;
//        }

//        return Data;
//    },

//    createSyllabusDetailsSuccess: function (data) {

//        SyllabusGroupDetailsTable();
//        var splitData = data.split(',');
//        $('#SuccessMessageSyllabusGroupDetails').html(splitData[0]);
//        $('#SuccessMessageSyllabusGroupDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
//        $('#myTableForSyllabusDetails tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        });
//        $("#aaa").hide(true);
//    },
//    createSyllabusTopicsSuccess: function (data) {
        
//        SyllabusGroupTopicsTable();
//        var splitData = data.split(',');
//        $('#SuccessMessageSyllabusTopics').html(splitData[0]);
//        $('#SuccessMessageSyllabusTopics').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
//        $('#myTableForSyllabusTopics tr').hover(function () {
//            $(this).css('cursor', 'pointer');
//        });
//        $("#bbb").hide(true);
//    },

//};

////////////new js////////////////


var OrganisationSyllabusGroupMaster = {

    ActionName: null,

    Initialize: function () {

        OrganisationSyllabusGroupMaster.constructor();

    },

    constructor: function () {

        $('#UnitWeightage').change(function () {

            var SelectedVal = $(this).val();
            $('#UnitPercentage').val(SelectedVal);
        });

        $('#UnitPercentage').prop('disabled', true);

        $('#CreateNewUnit').on("click", function () {
            $('#aaa').show(true);
            $('#DivCreateHead').show(true);
            $('#DivEditHead').hide(true);

            $('#SyllabusGrpDetailsID').val(0);
            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');

        });


        $('#CreateNewTopic').on("click", function () {
            
            $('#bbb').show(true);
            $('#DivCreateHead').show(true);
            $('#DivEditHead').hide(true);

            $('#SyllabusGrpTopicsID').val(0);
            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');

        });



        $('#DivClose').on("click", function () {
            $('#aaa').hide(true);

        });
        $('#CreateOrganisationSyllabusGroupDetailsRecord').on("click", function () {

            try {
                OrganisationSyllabusGroupMaster.ActionName = "CreateSyllabusGroupDetails";
                OrganisationSyllabusGroupMaster.AjaxCallOrganisationSyllabusGroupMaster();

            }
            catch (e) {

            }
            finally {
                $('input[name=SyllabusGrpDetailsID]').val(0);
                $('#UnitDescription').val('');
                $('#NoOfLecturesForUnit').val("");
                $('#UnitWeightage').val("");
                $('#UnitPercentage').val("");
                $('#UnitStatus').attr('checked', false);
                return false;
            }

        });

        $('#TopicWeightage').change(function () {

            var SelectedVal = $(this).val();
            $('#TopicPercentage').val(SelectedVal);
        });

        $('#TopicPercentage').prop('disabled', true);

        $('#CreateOrganisationSyllabusGroupTopicsRecord').on("click", function () {

            try {
                OrganisationSyllabusGroupMaster.ActionName = "CreateSyllabusGroupTopics";
                OrganisationSyllabusGroupMaster.AjaxCallOrganisationSyllabusGroupMaster();

            }
            catch (e) {

            }
            finally {
                $('input[name=SyllabusGrpTopicsID]').val(0);
                $('#TopicName').val('');
                $('#TopicDescription').val('');
                $('#NoOfLecturesForTopic').val("");
                $('#TopicWeightage').val("");
                $('#TopicPercentage').val("");
                $('#TopicStatus').attr('checked', false);
                return false;

            }
        });
        $("#SelectedCentreCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationSyllabusGroupMaster/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--------Select University-------</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UniversityProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }

                //if ($("#SelectedCentreCode").val() != "") {
                //    $.ajax({
                //        cache: false,
                //        type: "GET",
                //        url: "/StudentQuickRegistration/GetSessionDetails",

                //        data: { "SelectedCentreCode": selectedItem },
                //        success: function (data) {
                //            $ddlSessionDetails.html('');
                //            $ddlSessionDetails.append('<option value="">--Select Session--</option>');
                //            $.each(data, function (id, option) {

                //                $ddlSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                //            });

                //            $SessionDetailsProgress.hide();
                //        },
                //        error: function (xhr, ajaxOptions, thrownError) {
                //            alert('Failed to retrieve Session.');
                //            $SessionDetailsProgress.hide();
                //        }
                //    });
                //}
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---------Select University---------</option>');
                $('#btnCreate').hide();
            }
            $('#LiSessionName').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });
        $('#SelectedUniversityID').on("change", function () {
            $('#LiSessionName').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });
        $('#btnShowList').click(function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSyllabusGroupMaster.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#LiSessionName').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#LiSessionName').hide(true);
            }
        });
        $('#UnitWeightage').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#NoOfLecturesForUnit').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#TopicWeightage').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#NoOfLecturesForTopic').on("keydown", function (e) {
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
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamID').focus();
            var dt = new Date();
            $('#StreamID').val("");
            $('#MediumID').val("");
            $('#StandardID').val("");
            $('#StreamID').val("");
            return false;
        });
        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#myTableForSyllabusTopics tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });
        $('#myTableForSyllabusDetails tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });
    },



    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/OrganisationSyllabusGroupMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    ReloadList: function (message) {
        var SelectedCentreCode = $('#SelectedCentreCode :selected').val();
        var SelectedUniversityID = $('#SelectedUniversityID option:selected').val();
        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
            dataType: "html",
            url: '/OrganisationSyllabusGroupMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#commonMessage').html(message);
                $('#commonMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', '#5C8AE6');
            }
        });
    },

    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

        var selectedText = $('#SelectedUniversityID').text();
        var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
              dataType: "html",
              url: '/OrganisationSyllabusGroupMaster/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
                  $('#LiSessionName').show(true);
              }
          });
    },

    AjaxCallOrganisationSyllabusGroupMaster: function () {
        var OrganisationSyllabusGroupMasterData = null;
        if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupDetails") {
            $("#FormCreateOrganisationSyllabusGroupDetails").validate();
            if ($("#FormCreateOrganisationSyllabusGroupDetails").valid()) {
                OrganisationSyllabusGroupMasterData = null;
                OrganisationSyllabusGroupMasterData = OrganisationSyllabusGroupMaster.GetOrganisationSyllabusGroupMaster();

                ajaxRequest.makeRequest("/OrganisationSyllabusGroupMaster/CreateSyllabusGroupDetails", "POST", OrganisationSyllabusGroupMasterData, OrganisationSyllabusGroupMaster.createSyllabusDetailsSuccess);
            }


        }
        else if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupTopics") {
            $("#FormCreateOrganisationSyllabusGroupTopics").validate();
            if ($("#FormCreateOrganisationSyllabusGroupTopics").valid()) {
                OrganisationSyllabusGroupMasterData = null;
                OrganisationSyllabusGroupMasterData = OrganisationSyllabusGroupMaster.GetOrganisationSyllabusGroupMaster();
                ajaxRequest.makeRequest("/OrganisationSyllabusGroupMaster/CreateSyllabusGroupTopics", "POST", OrganisationSyllabusGroupMasterData, OrganisationSyllabusGroupMaster.createSyllabusTopicsSuccess);


            }
        }

    },

    GetOrganisationSyllabusGroupMaster: function () {

        var Data = {
        };
        if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupDetails") {

            // Properties of table OrgSyllabusGroupDetails
            Data.SyllabusGroupID = $('input[name=SyllabusGroupID]').val();
            Data.SyllabusGrpDetailsID = $('input[name=SyllabusGrpDetailsID]').val();
            Data.UnitDescription = $('#UnitDescription').val();
            Data.NoOfLecturesForUnit = $('#NoOfLecturesForUnit').val();
            Data.UnitWeightage = $('#UnitWeightage').val();
            Data.UnitPercentage = $('#UnitPercentage').val();
            //Data.UnitStatus = $('input[name=UnitStatus]:checked').val() ? true : false;
            Data.UnitStatus = $('input[id=UnitStatus]:checked').val() ? true : false;

        }
        else if (OrganisationSyllabusGroupMaster.ActionName == "CreateSyllabusGroupTopics") {

            // Properties of table OrgSyllabusGroupTopics
            Data.SyllabusGroupDetID = $('input[name=SyllabusGroupDetID]').val();
            Data.SyllabusGrpTopicsID = $('input[name=SyllabusGrpTopicsID]').val();
            Data.SubjectGroupID = $('input[name=SubjectGroupID]').val();
            Data.SubjectTypeNumber = $('input[name=SubjectTypeNumber]').val();
            Data.OrgSemesterMstID = $('input[name=OrgSemesterMstID]').val();
            Data.TopicName = $('#TopicName').val();
            Data.TopicDescription = $('#TopicDescription').val();
            Data.NoOfLecturesForTopic = $('#NoOfLecturesForTopic').val();
            Data.TopicWeightage = $('#TopicWeightage').val();
            Data.TopicPercentage = $('#TopicPercentage').val();
            //Data.TopicStatus = $('input[name=TopicStatus]:checked').val() ? true : false;
            Data.TopicStatus = $('input[id=TopicStatus]:checked').val() ? true : false;
        }

        return Data;
    },

    createSyllabusDetailsSuccess: function (data) {

        SyllabusGroupDetailsTable();
        var splitData = data.split(',');
        $('#SuccessMessageSyllabusGroupDetails').html(splitData[0]);
        $('#SuccessMessageSyllabusGroupDetails').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        $('#myTableForSyllabusDetails tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });
        $("#aaa").hide(true);
    },
    createSyllabusTopicsSuccess: function (data) {

        SyllabusGroupTopicsTable();
        var splitData = data.split(',');
        $('#SuccessMessageSyllabusTopics').html(splitData[0]);
        $('#SuccessMessageSyllabusTopics').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
        $('#myTableForSyllabusTopics tr').hover(function () {
            $(this).css('cursor', 'pointer');
        });
        $("#bbb").hide(true);
    },

};

