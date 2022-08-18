//this class contain methods related to nationality functionality
var GenerateStudentRollNumber = {
    //Member variables
    ActionName: null,
    PromotedStudentList: null,
    //Class intialisation method
    Initialize: function () {
        GenerateStudentRollNumber.constructor();
    },
    //Attach all event of page
    constructor: function () {

        //$("#firstYearStudentList").hide();

        $("#OtherThanFirstYearStudentList_processing").hide();

        $("#FirstYearStudentList_processing").hide();

        $("#dataTables_processing").hide();

        $("#IsFirstYearPromotion").on("click", function () {


            if (this.checked == true) {
                $("#otherThanFirstYearStudentList").hide();
                $("#firstYearStudentList").show();
                $(".SectionDetails").hide();
                $(".PromotedToNextSection").show();
            }
            else {
                $("#otherThanFirstYearStudentList").show();
                $("#firstYearStudentList").hide();
                $(".SectionDetails").show();
                $(".PromotedToNextSection").hide();
            }
        })

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();

            var $ddlBranchDetails = $("#SelectedBranchID");
            var $ddlUniversityList = $("#SelectedUniversityID");
            var $ddlSessionDetails = $("#SelectedSessionID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            var $UniversityListProgress = $("#states-loading-progress");
            var $SessionDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();
            $UniversityListProgress.show();
            $SessionDetailsProgress.show();
            //if ($("#SelectedCentreCode").val() != "") {
            //    $.ajax({
            //        cache: false,
            //        type: "GET",
            //        url: "/GenerateStudentRollNumber/GetBranchDetails",

            //        data: { "SelectedCentreCode": selectedItem },
            //        success: function (data) {
            //            $ddlBranchDetails.html('');
            //            $ddlBranchDetails.append('<option value="">--Select Course--</option>');
            //            $.each(data, function (id, option) {

            //                $ddlBranchDetails.append($('<option></option>').val(option.id).html(option.name));
            //            });

            //            $BranchDetailsProgress.hide();
            //        },
            //        error: function (xhr, ajaxOptions, thrownError) {
            //            alert('Failed to retrieve Branch.');
            //            $BranchDetailsProgress.hide();
            //        }
            //    });
            //}
            //else {
            //    $('#myDataTable tbody').empty();
            //    $('#SelectedBranchID').find('option').remove().end().append('<option value>---Select Branch---</option>');
            //    $('#btnCreate').hide();
            //}

            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversityList.html('');
                        $ddlUniversityList.append('<option value="">--Select University--</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversityList.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $UniversityListProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $UniversityListProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }

            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/GetSessionDetails",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlSessionDetails.html('');
                        $ddlSessionDetails.append('<option value="">--Select Session--</option>');
                        $.each(data, function (id, option) {

                            $ddlSessionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $SessionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Session.');
                        $SessionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedSessionID').find('option').remove().end().append('<option value>---Select Session---</option>');
                $('#btnCreate').hide();
            }

            var $ddlSectionDetails = $("#SelectedSectionDetRoleWiseID");
            var $SectionDetailsProgress = $("#states-loading-progress");
            $SectionDetailsProgress.show();
            $ddlBranchDetails.empty().append('<option value="">--Select Course--</option>');
            $ddlSectionDetails.empty().append('<option value="">--Select Section--</option>');
        });

        $("#SelectedUniversityID").change(function () {
            var selectedItem = $(this).val();
            var selectedItem1 = $("#SelectedCentreCode").val();
            var selectedItem2 = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;

            var $ddlBranchDetails = $("#SelectedBranchID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();

            if ($("#SelectedUniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/GetBranchDetails",

                    data: { "SelectedCentreCode": selectedItem1, "selectedUniversityID": selectedItem, "isFirstYearPromotion": selectedItem2 },
                    success: function (data) {
                        $ddlBranchDetails.html('');
                        $ddlBranchDetails.append('<option value="">--Select Course--</option>');
                        $.each(data, function (id, option) {

                            $ddlBranchDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $BranchDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $BranchDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedBranchID').find('option').remove().end().append('<option value>---Select Branch---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#SelectedBranchID").change(function () {
            var selectedItem1 = $(this).val();
            var selectedItem2 = $("#SelectedCentreCode").val();
            var selectedItem3 = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;
            var selectedItem4 = $("#SelectedUniversityID").val();
            var $ddlSectionDetails = $("#SelectedSectionDetRoleWiseID");
            var $SectionDetailsProgress = $("#states-loading-progress");
            $SectionDetailsProgress.show();
            if ($("#SelectedBranchID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/GetSectionDetails",
                    data: { "SelectedBranchID": selectedItem1, "SelectedCentreCode": selectedItem2, "isFirstYearPromotion": selectedItem3, "UniversityDetails": selectedItem4 },
                    success: function (data) {
                        $ddlSectionDetails.html('');
                        $ddlSectionDetails.append('<option value="">--Select Section--</option>');
                        $.each(data, function (id, option) {
                            $ddlSectionDetails.append($('<option></option>').val(option.id).html(option.name));
                        });

                        $SectionDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Section.');
                        $SectionDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedSectionDetRoleWiseID').find('option').remove().end().append('<option value>---Select Section---</option>');
                $('#btnCreate').hide();
            }
        });

        $("#SelectedSectionDetRoleWiseID").change(function () {

            var selectedItem1 = $(this).val();
            var selectedItem2 = $("#SelectedCentreCode").val();
            var selectedItem3 = $("#SelectedSessionID").val();
            var selectedItem4 = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;
            if (selectedItem4 == false) {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/AjaxHandlerOtherThanFirstYear",
                    data: { "sectionDetailsID": selectedItem1, "centreCode": selectedItem2, "sessionID": selectedItem3, "isFirstYearPromotion": selectedItem4 },
                    success: function (data) {
                        ReloadListOtherThanFistYear();
                        $("input[class=selectedAllCheck]").attr("checked", false);
                    },

                });
            }
            else {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/AjaxHandlerFirstYearStudent",
                    data: { "sectionDetailsID": selectedItem1, "centreCode": selectedItem2, "sessionID": selectedItem3, "isFirstYearPromotion": selectedItem4 },
                    success: function (data) {
                        ReloadListFirstYearStudent();
                        $("input[class=selectedAllCheck]").attr("checked", false);
                    },

                });
            }



        });

        $("#SelectedSessionID").change(function () {

            var selectedItem1 = $(this).val();
            var selectedItem2 = $("#SelectedCentreCode").val();
            var selectedItem3 = $("#SelectedSectionDetRoleWiseID").val();
            var selectedItem4 = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;
            if (selectedItem4 == true) {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/AjaxHandlerFirstYearStudent",
                    data: { "sectionDetailsID": selectedItem3, "centreCode": selectedItem2, "sessionID": selectedItem1, "isFirstYearPromotion": selectedItem4 },
                    success: function (data) {
                        ReloadListFirstYearStudent();
                        $("input[class=selectedAllCheck]").attr("checked", false);
                    },

                });
            }
            else {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/AjaxHandlerOtherThanFirstYear",
                    data: { "sectionDetailsID": selectedItem3, "centreCode": selectedItem2, "sessionID": selectedItem1, "isFirstYearPromotion": selectedItem4 },
                    success: function (data) {
                        ReloadListOtherThanFistYear();
                        $("input[class=selectedAllCheck]").attr("checked", false);
                    },

                });
            }


        });

        $("#SelectedBranchID").change(function () {

            var selectedItem1 = $(this).val();
            var selectedItem2 = $("#SelectedCentreCode").val();
            var selectedItem3 = $("#SelectedSectionDetRoleWiseID").val();
            var selectedItem4 = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;
            if (selectedItem4 == true) {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/GenerateStudentRollNumber/AjaxHandlerFirstYearStudent",
                    data: { "sectionDetailsID": selectedItem3, "centreCode": selectedItem2, "sessionID": selectedItem1, "isFirstYearPromotion": selectedItem4 },
                    success: function (data) {
                        ReloadListFirstYearStudent();
                        $("input[class=selectedAllCheck]").attr("checked", false);
                    },

                });
            }


        });

        $("#IsFirstYearPromotion").on("click", function () {


            var selectedItem1 = $('input[name=IsFirstYearPromotion]:checked').val() ? true : false;

            $.ajax({
                cache: false,
                type: "GET",
                url: "/GenerateStudentRollNumber/List",
                data: { "isFirstYearPromotion": selectedItem1 },
                success: function (data) {

                    $('#ListView').html(data);
                    $("#SelectedCentreCode").val("");
                    $("#SelectedBranchID").val("");
                    $("#SelectedUniversityID").val("");
                    $("#SelectedSectionDetRoleWiseID").val("");
                    $("#SelectedSessionID").val("");
                    if (selectedItem1 == true) {
                        ReloadListFirstYearStudent();
                        $("input[class=selectedAllCheck]").attr("checked", false);
                    }
                    else {
                        ReloadListOtherThanFistYear();
                    }
                },

            });

        });

        $("#OtherThanFirstYearStudentList thead tr th").on("click", "input[id=selectAll]", function () {
            if (this.checked) {
                $(".check").each(function () {
                    this.checked = true;
                });
            }
            else {
                $(".check").each(function () {
                    this.checked = false;
                });
            }
        });

        $("#OtherThanFirstYearStudentList").on("click", "td .check", function () {

            var a = (parseInt($(".check").length));
            var b = parseInt($(".check:checked").length);
            if (a != b) {
                $("input[class=selectedAllCheck]").attr("checked", false);
            }
            else {

                $("input[id=selectAll]").attr("checked", "checked");
            }
        });

        function ReloadListOtherThanFistYear() {
            oTable1 = $('#OtherThanFirstYearStudentList').dataTable();
            oTable1.fnReloadAjax('GenerateStudentRollNumber/AjaxHandlerOtherThanFirstYear');
        };

        function ReloadListFirstYearStudent() {
            oTable2 = $('#FirstYearStudentList').dataTable();
            oTable2.fnReloadAjax('GenerateStudentRollNumber/AjaxHandlerFirstYearStudent');
        };

        $('#btnFirstYearStudent').on("click", function () {

            GenerateStudentRollNumber.ActionName = "PromotFirstYearStudent";
            GenerateStudentRollNumber.getDataFromDataTable();
            GenerateStudentRollNumber.AjaxCallGenerateStudentRollNumber();
        });

        $('#btnotherThanFirstYearStudentList').on("click", function () {

            GenerateStudentRollNumber.ActionName = "PromotOtherThanFirstYearStudent";
            GenerateStudentRollNumber.getDataFromDataTable();
            GenerateStudentRollNumber.AjaxCallGenerateStudentRollNumber();
        });
    },

    //LoadList method is used to load List page
    LoadList: function () {


        $.ajax(
       {
           cache: false,
           dataType: "html",
           url: '/GenerateStudentRollNumber/List',
           success: function (data) {
               //Rebind Grid Data
               $('#ListViewModel').html(data);
           }
       });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallGenerateStudentRollNumber: function () {
        
        var GenerateStudentRollNumberData = null;
        if (GenerateStudentRollNumber.ActionName == "PromotFirstYearStudent") {
            $("#FormGenerateStudentRollNumber").validate();
            if ($("#FormGenerateStudentRollNumber").valid()) {
                GenerateStudentRollNumberData = null;
                GenerateStudentRollNumberData = GenerateStudentRollNumber.GetGenerateStudentRollNumber();
                ajaxRequest.makeRequest("/GenerateStudentRollNumber/List", "POST", GenerateStudentRollNumberData, GenerateStudentRollNumber.Success);
            }
        }
        else if (GenerateStudentRollNumber.ActionName == "PromotOtherThanFirstYearStudent") {
            $("#FormGenerateStudentRollNumber").validate();
            if ($("#FormGenerateStudentRollNumber").valid()) {
                GenerateStudentRollNumberData = null;
                GenerateStudentRollNumberData = GenerateStudentRollNumber.GetGenerateStudentRollNumber();
                ajaxRequest.makeRequest("/GenerateStudentRollNumber/List", "POST", GenerateStudentRollNumberData, GenerateStudentRollNumber.Success);
            }
        }
    },
    //Create Xml string for insert update purpose
    getDataFromDataTable: function () {

        if (GenerateStudentRollNumber.ActionName == "PromotFirstYearStudent") {
            var DataArray = [];
            $('#FirstYearStudentList input[id=chkSelectedStudent]').each(function () {
                if (this.checked == true) {
                    DataArray.push($(this).val());
                }
            });
            var xmlParamList = "<rows>";
            var aa = [];
            var Count = DataArray.length
            for (var i = 0; i < Count; i++) {
                aa = DataArray[i].split('~');
                xmlParamList = xmlParamList + "<row><AdmissionDetailId>" + aa[0] + "</AdmissionDetailId><StudentId>" + aa[1] + "</StudentId><SectionDetailId>" + aa[2] + "</SectionDetailId><PromotedSectionDetailId>" + aa[3] + "</PromotedSectionDetailId></row>";
            }
            xmlParamList = xmlParamList + "</rows>";
        }
        else if (GenerateStudentRollNumber.ActionName == "PromotOtherThanFirstYearStudent") {
            var DataArray = [];
            $('#OtherThanFirstYearStudentList input[id=chkSelectedStudent]').each(function () {
                if (this.checked == true) {
                    DataArray.push($(this).val());
                }
            });
            var xmlParamList = "<rows>";
            var aa = [];
            var Count = DataArray.length
            for (var i = 0; i < Count; i++) {
                aa = DataArray[i].split('~');
                xmlParamList = xmlParamList + "<row><AdmissionDetailId>" + aa[0] + "</AdmissionDetailId><StudentId>" + aa[1] + "</StudentId><SectionDetailId>" + aa[2] + "</SectionDetailId><PromotedSectionDetailId>" + aa[3] + "</PromotedSectionDetailId></row>";
            }
            xmlParamList = xmlParamList + "</rows>";
        }
        GenerateStudentRollNumber.PromotedStudentList = xmlParamList;

    },
    //Get properties data from the Create, Update and Delete page
    GetGenerateStudentRollNumber: function () {
        var Data = {
        };

        if (GenerateStudentRollNumber.ActionName == "PromotFirstYearStudent" || GenerateStudentRollNumber.ActionName == "PromotOtherThanFirstYearStudent") {
            Data.CentreCode = $("#SelectedCentreCode").val();
            //Data.SectionDetailID = $("#SelectedSectionDetRoleWiseID").val();
            Data.SessionID = $("#SelectedSessionID").val();
            Data.PromotedStudentList = GenerateStudentRollNumber.PromotedStudentList;

        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        $("#SectionDetailID").val('');
        $('#SuccessMessage').html(splitData[0]);
        $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
    },

};









