//this class contain methods related to nationality functionality.

var OnlineEntranceExamQuestionBankMaster = {
    ActionName: null,
    OptionImageFileName: null,
    QuestionImageFileName: null,
    QuestionImageFileSize: null,
    XMLstring: null,

    Initialize: function () {
        OnlineEntranceExamQuestionBankMaster.constructor();
    },

    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {
            return false;
        });

        $("#SelectedCentreCode").change(function () {
            //
            var selectedCentreCode = $(this).val();
            var $ddlUniversitys = $("#SelectedUniversityID");
            var $ddlDepartmentID = $("#DepartmentID");
            var $ddlSelectedCourseID = $("#SelectedCourseID");
            var $ddlSelectedCourseYearID = $("#SelectedCourseYearID");

            if ($("#SelectedCentreCode").val() != "") {

                //Get University from centre code.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetUniversityByCentreCode",
                    data: { "centreCode": selectedCentreCode },
                    success: function (data) {                        
                        $ddlUniversitys.html('');
                        $ddlUniversitys.append('<option value="">----Select University----</option>');
                        $.each(data, function (id, option) {
                            $ddlUniversitys.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                    }
                });

                if (selectedCentreCode != "") {
                    //Get Department on center code.
                    $.ajax({
                        cache: false,
                        type: "GET",
                        url: "/OnlineEntranceExamQuestionBankMaster/GetDepartmentByCentreCode",
                        data: { "centreCode": selectedCentreCode },
                        success: function (data) {                           
                            $ddlDepartmentID.html('');
                            $ddlDepartmentID.append('<option value="">----Select department----</option>');
                            $ddlSelectedCourseID.html('');
                            $ddlSelectedCourseID.append('<option value="">----Select course----</option>');
                            $ddlSelectedCourseYearID.html('');
                            $ddlSelectedCourseYearID.append('<option value="">----Select course year----</option>');
                            $.each(data, function (id, option) {
                                $ddlDepartmentID.append($('<option></option>').val(option.id).html(option.name));

                            });
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve Departments.');
                        }
                    });
                }

            }
        });

        $("#SelectedUniversityID").change(function () {
            //
            var selectedCentreCode = $("#SelectedCentreCode").val();
            var selectedUniversity = $(this).val();
            var $ddlSelectedCourseID = $("#SelectedCourseID");           
            var $ddlSelectedCourseYearID = $("#SelectedCourseYearID");

            if (selectedCentreCode != "" && selectedUniversity != "") {
                //Get Department on center code.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetCourseFromCentreCodeAndUniversity",
                    data: { "centreCode": selectedCentreCode, "universityID": selectedUniversity },
                    success: function (data) {                                        
                        $ddlSelectedCourseID.html('');
                        $ddlSelectedCourseID.append('<option value="">----Select course----</option>');
                        
                        $ddlSelectedCourseYearID.html('');
                        $ddlSelectedCourseYearID.append('<option value="">----Select course year----</option>');
                        $.each(data, function (id, option) {
                            $ddlSelectedCourseID.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve course.');
                    }
                });
            }
        });


        $("#SelectedCourseID").change(function () {
            //
            var selectedCourseID = $(this).val();
            var $ddlSelectedCourseYearID = $("#SelectedCourseYearID");
            if (selectedCourseID != "") {

                //Get Course Year from Course.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetCourseYearFromBranchMaster",
                    data: { "branchMasterID": selectedCourseID },
                    success: function (data) {
                        
                        $ddlSelectedCourseYearID.html('');
                        $ddlSelectedCourseYearID.append('<option value="">----Select course year----</option>');
                        $.each(data, function (id, option) {
                            $ddlSelectedCourseYearID.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve course year.');
                    }
                });
            }
        });


        $("#btnShowList").on("click", function () {
            //
            if ($("#SelectedCentreCode").val() != "") {
                if ($("#SelectedUniversityID").val() != "") {
                    if ($("#DepartmentID").val() != "") {
                        if ($("#SelectedCourseID").val() != "") {
                            if ($("#SelectedCourseYearID").val() != "") {
                                //$("#createSubject").show();
                                $.ajax({
                                    cache: false,
                                    type: "POST",
                                    data: { actionMode: null, centreCode: $("#SelectedCentreCode").val(), universityID: $("#SelectedUniversityID").val(), departmentID: $("#DepartmentID").val(), course: $("#SelectedCourseID").val(), courseYr: $("#SelectedCourseYearID").val(), subjectID: $("#SubjectID").val(), subjectName: $("#SubjectName").val() },
                                    dataType: "html",
                                    url: '/OnlineEntranceExamQuestionBankMaster/List',
                                    success: function (result) {
                                        //Rebind Grid Data                
                                        $('#ListViewModel').html(result);
                                    }
                                });
                            } else {
                                $('#SuccessMessage').html("Please select course year.");
                                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                            }
                        } else {
                            $('#SuccessMessage').html("Please select course.");
                            $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                        }
                    } else {
                        $('#SuccessMessage').html("Please select department.");
                        $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    }
                } else {
                    $('#SuccessMessage').html("Please select university.");
                    $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
            } else {
                $('#SuccessMessage').html("Please select center.");
                $('#SuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });


        $("#SubjectName").autocomplete({
            source: function (request, response) {
                //
                $.ajax({
                    url: "/OnlineEntranceExamQuestionBankMaster/GetSubjectSearchList",
                    type: "Post",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data.Data, function (item) {
                            return { label: item.name, value: item.name, id: item.id };
                        }))
                    }
                })
            },
            select: function (event, ui) {                
                $(this).val(ui.item.label);                                             // display the selected text
                $("#SubjectID").val(ui.item.id);
            }
        });

        $("#SubjectName").on("keydown keypress", function (e) {           
            var inputKeyCode = e.keyCode ? e.keyCode : e.which;
            if (inputKeyCode == 8 || inputKeyCode == 46) {
                $(this).val('');
                $("#SubjectID").val(0);
            }
        });
        

        $("#CourseYearID").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/OnlineEntranceExamQuestionBankMaster/GetCourseYearDetailList",
                    type: "Post",
                    dataType: "json",
                    data: { term: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.name, value: item.name, id: item.id };
                        }))
                    }
                })
            },
            select: function (event, ui) {
                $(this).val(ui.item.label);                                             // display the selected text
                $("#CourseYearDetailID").val(ui.item.id);

                //Fill Subject on Course Select.
                if ($("#CourseYearDetailID").val() != "")
                    $.ajax({
                        cache: false,
                        type: "GET",
                        url: "/OnlineEntranceExamQuestionBankMaster/GetSubjectFromCourse",
                        data: { "selectedCourseID": $("#CourseYearDetailID").val() },
                        success: function (data) {
                            
                            $ddlSelectedSubjectName.html('');
                            $ddlSelectedSubjectName.append('<option value="">----Select subject----</option>');
                            $.each(data, function (id, option) {
                                $ddlSelectedSubjectName.append($('<option></option>').val(option.id).html(option.name));
                            });
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve course year.');
                        }
                    });
            }
        });


        $("#CentreCode").change(function () {
            
            var centreCode = $(this).val();
            var $ddlUniversitys = $("#University");
            var $ddlDepartment = $("#Department");            
            if (centreCode != "") {

                //Get University from centre code.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetUniversityByCentreCode",
                    data: { "centreCode": centreCode },
                    success: function (data) {                       
                        $ddlUniversitys.html('');
                        $ddlUniversitys.append('<option value="">----Select University----</option>');
                        $.each(data, function (id, option) {
                            $ddlUniversitys.append($('<option></option>').val(option.id).html(option.name));

                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                    }
                });

                if (centreCode != "") {
                    //Get Department on center code.
                    $.ajax({
                        cache: false,
                        type: "GET",
                        url: "/OnlineEntranceExamQuestionBankMaster/GetDepartmentByCentreCode",
                        data: { "centreCode": centreCode },
                        success: function (data) {                            
                            $ddlDepartment.html('');
                            $ddlDepartment.append('<option value="">----Select Department----</option>');
                            $.each(data, function (id, option) {
                                $ddlDepartment.append($('<option></option>').val(option.id).html(option.name));
                            });
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert('Failed to retrieve Departments.');
                        }
                    });
                }
            }
        });

        $("#University").change(function () {
            
            var centreCode = $("#CentreCode").val();
            var university = $(this).val();
            var $ddlCourse = $("#Course");
            if (centreCode != "" && university != "") {
                //Get Department on center code.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetCourseFromCentreCodeAndUniversity",
                    data: { "centreCode": centreCode, "universityID": university },
                    success: function (data) {
                        
                        $ddlCourse.html('');
                        $ddlCourse.append('<option value="">----Select course----</option>');
                        $.each(data, function (id, option) {
                            $ddlCourse.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve course.');
                    }
                });
            }
        });


        $("#Course").change(function () {
            //
            var Course = $(this).val();
            var $ddlCourseYearID = $("#CourseYearID");
            if (Course != "") {
                //Get Course Year from Course.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetCourseYearFromBranchMaster",
                    data: { "branchMasterID": Course },
                    success: function (data) {
                        
                        $ddlCourseYearID.html('');
                        $ddlCourseYearID.append('<option value="">----Select course year----</option>');
                        $.each(data, function (id, option) {
                            $ddlCourseYearID.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve course year.');
                    }
                });
            }
        });

        $("#CourseYearID").change(function () {
            //
            var courseYearID = $(this).val();
            var $ddlSubject = $("#Subject");
            if (courseYearID != "") {
                //Get subject from Course yr.
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetSubjectFromCourseYearDetail",
                    data: { "courseYearID": courseYearID },
                    success: function (data) {
                        
                        $ddlSubject.html('');
                        $ddlSubject.append('<option value="">----Select subject----</option>');
                        $.each(data, function (id, option) {
                            $ddlSubject.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve course year.');
                    }
                });
            }
        });


        $("#CreateQuestionBankSubject").on("click", function () {
            OnlineEntranceExamQuestionBankMaster.ActionName = "CreateSubject";
            if ($("#CentreCode").val() != null && $("#CentreCode").val() != "") {
                if ($("#University").val() != null && $("#University").val() != "") {
                    if ($("#Course").val() != null && $("#Course").val() != "") {
                        if ($("#CourseYearID").val() != null && $("#CourseYearID").val() != "") {
                            if ($("#Academic").val() != null && $("#Academic").val() != "") {
                                if ($("#Department").val() != null && $("#Department").val() != "") {
                                    if ($("#Subject").val() != null && $("#Subject").val() != "") {
                                        OnlineEntranceExamQuestionBankMaster.AjaxCallOnlineEntranceExamSubject();
                                    } else {
                                        $('#DivSuccessMessage').html("Please select subject.");
                                        $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                                    }
                                } else {
                                    $('#DivSuccessMessage').html("Please select department.");
                                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                                }
                            } else {
                                $('#DivSuccessMessage').html("Please select academic.");
                                $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                            }
                        } else {
                            $('#DivSuccessMessage').html("Please select course year.");
                            $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                        }
                    } else {
                        $('#DivSuccessMessage').html("Please select course.");
                        $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    }
                } else {
                    $('#DivSuccessMessage').html("Please select university.");
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                $('#DivSuccessMessage').html("Please select center.");
                $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }

        });

        $("#DeleteOnlineQuestionBankRecord").on("click", function () {
            OnlineEntranceExamQuestionBankMaster.ActionName = "DeleteQuestion";
            OnlineEntranceExamQuestionBankMaster.AjaxCallOnlineEntranceExamQuestionBankMaster();
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

        $('#IsQuestionInImage').change(function () {
            if (this.checked) {
                $('#DivQuestionLableText').hide(true);
                $('#DivQuestionImage').show(true);
                $('#QuestionLableText').val('');
            }
            else {
                $('#DivQuestionLableText').show(true);
                $('#DivQuestionImage').hide(true);
                $('#DivQuestionLableText').val('');
                $('#previewQuestionImage').removeAttr('src');;
                $('#QuestionImageFile').val('');
            }
        });

        $('#IsOptionInImage').change(function () {
            if (this.checked) {
                $('#DivOptionText').hide(true);
                $('#DivOptionImage').show(true);
                $('#OptionText').val('');
                $('#IsAnswer').removeAttr('checked');
            }
            else {
                $('#DivOptionText').show(true);
                $('#DivOptionImage').hide(true);
                $('#DivOptionText').val('');
                $('#OptionImageFile').val('');
                $('#IsAnswer').removeAttr('checked');
            }
        });

        $('#SyllabusGroupDetail').change(function () {
            //
            var syllabusGroupDetail = $(this).val();
            var $ddlSyllabusTopicGroupID = $("#SyllabusTopicGroupID");
            if (syllabusGroupDetail != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OnlineEntranceExamQuestionBankMaster/GetSyllabusGroupTopicList",
                    data: { "syllabusGroupDetail": syllabusGroupDetail },
                    success: function (data) {
                        
                        $ddlSyllabusTopicGroupID.html('');
                        $ddlSyllabusTopicGroupID.append('<option value="">-----Select topic-----</option>');
                        $.each(data, function (id, option) {
                            $ddlSyllabusTopicGroupID.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve course year.');
                    }
                });
            }
        });

        // Create new record
        $('#addItem').on("click", function () {
            //
            var IsOptionInImage = document.getElementById("IsOptionInImage").checked;

            if (IsOptionInImage == true && $("#OptionImageFile").get(0).files.length == 0) {
                $('#DisplayMessage').html("Option image must be selected");
                $('#DisplayMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                $('#OptionImageFile').focus();
                return false;
            }
            else if (IsOptionInImage == false && ($("#OptionText").val() == "" || $("#OptionText").val() == null)) {
                $('#DisplayMessage').html("Option text should not be blank");
                $('#DisplayMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
                $("#OptionText").focus();
                return false;
            }
            var data = new FormData();
            var files = $("#OptionImageFile").get(0).files;
            if (files.length > 0) {
                data.append("MyImages", files[0]);
            }
            if (IsOptionInImage == true) {

                $.ajax({
                    url: "/OnlineEntranceExamQuestionBankMaster/UploadFile",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,
                    dataType: 'json',
                    success: function (data) {
                        //code after success                       
                        OnlineEntranceExamQuestionBankMaster.OptionImageFileName = data;
                    },
                    error: function (er) {
                        alert(er);
                    }
                });
            }
            var IsAns = '';
            var IsAnsVal = '';
            var isDisabled = '';
            if ((document.getElementById("IsAnswer").disabled == true)) {
                isDisabled = 'disabled';
            }

            if (document.getElementById("IsAnswer").checked == true) {
                IsAns = 'checked';
                IsAnsVal = 1;
                $("#IsAnswer").prop("disabled", true);
                $("#tblData tbody tr td input[id='IsAns']").prop("disabled", true);
            }
            else {
                IsAns = '';
                IsAnsVal = 0;
            };

            var IsOptionInImage = document.getElementById("IsOptionInImage").checked;

            if (IsOptionInImage == true) {
                if (OnlineEntranceExamQuestionBankMaster.OptionImageFileName != null) {
                    //
                    $("#tblData tbody").append(
                        "<tr>" +
                        "<td ><input type='checkbox' class='IsImg' value=" + IsOptionInImage + " checked='checked' disabled= 'disabled'/> " + "</td>" +
                        "<td><input type='text' style='width:94%' value='" + OnlineEntranceExamQuestionBankMaster.OptionImageFileName + "'/></td>" +
                        "<td><input type='checkbox' id='IsAns' class='EnableDisable' value=" + IsAnsVal + " " + IsAns + " " + isDisabled + " > " + "</td>" +
                        "<td  style='text-align:center;cursor:pointer; '> <i class='icon-trash' title = Delete></td>" +
                        "</tr>");

                    $("#IsOptionInImage").prop("checked", false);
                    $("#IsAnswer").prop("checked", false);
                    $("#OptionImageFile").replaceWith($("#OptionImageFile").val('').clone(true));
                    $('#DivOptionText').show(true);
                    $('#DivOptionImage').hide(true);
                    $('#DivOptionText').val('');
                }
            }
            else {                
                $("#tblData tbody").append(

                "<tr>" +
                    "<td ><input type='checkbox' class='IsImg' value=" + IsOptionInImage + " disabled= 'disabled' /> " + "</td>" +
                    "<td><input id='optionText' type='text' style='width:94%' value='" + $("#OptionText").val() + "'/></td>" +
                    "<td ><input type='checkbox' id='IsAns' class='EnableDisable' value=" + IsAnsVal + " " + IsAns + " " + isDisabled + " > " + "</td>" +
                    "<td  style='text-align:center;cursor:pointer; '> <i class='icon-trash' title = Delete></td>" +
                    "</tr>");
                $("#OptionText").val('');
                $("#IsAnswer").prop("checked", false);
            }

            OnlineEntranceExamQuestionBankMaster.EnableDisable();
            OnlineEntranceExamQuestionBankMaster.DeleteAnswerOption();
            $('#IsOptionInImage').focus();

        });


        $("#CreateOnlineExamQuestionBankRecord").on("click", function () {
            if ($("#GeneralQuestionTypeID").val() != "" && $("#GeneralQuestionLevelID").val() != "" && $("#SyllabusGroupDetail").val() != "" && $("#SyllabusTopicGroupID").val() != "") {
                if ($("#QuestionLableText").val() != "" || $("#QuestionImageFile").val() != "") {
                    OnlineEntranceExamQuestionBankMaster.ActionName = "CreateQuestions";
                    OnlineEntranceExamQuestionBankMaster.GetXmlData();
                    if (OnlineEntranceExamQuestionBankMaster.XMLstring != null && OnlineEntranceExamQuestionBankMaster.XMLstring != "") {
                        OnlineEntranceExamQuestionBankMaster.AjaxCallOnlineEntranceExamQuestionBankMaster();
                    }
                    else {
                        $('#DisplayMessage').html("Data is not availble.");
                        $('#DisplayMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                    }
                }
                else {
                    $('#DivSuccessMessage').html("Please entre question.");
                    $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
                }
            }
            else {
                $('#DivSuccessMessage').html("Please select valid input.");
                $('#DivSuccessMessage').delay(400).slideDown(400).delay(1200).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $(".ajax").colorbox();
    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             data: { "actionMode": null },
             url: '/OnlineEntranceExamQuestionBankMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {       
        $.ajax({
            cache: false,
            type: "POST",
            data: { actionMode: null, centreCode: $("#SelectedCentreCode").val(), universityID: $("#SelectedUniversityID").val(), departmentID: $("#DepartmentID").val(), course: $("#SelectedCourseID").val(), courseYr: $("#SelectedCourseYearID").val(), subjectID: $("#SubjectID").val(), subjectName: $("#SubjectName").val() },
            dataType: "html",
            url: '/OnlineEntranceExamQuestionBankMaster/List',
            success: function (result) {
                //Rebind Grid Data                
                $('#ListViewModel').html(result);
            }
        });
    },

    AjaxCallOnlineEntranceExamSubject: function () {
       // 
        var OnlineExamSubjectData = null;
        if (OnlineEntranceExamQuestionBankMaster.ActionName == "CreateSubject") {
            OnlineExamSubjectData = null;
            OnlineExamSubjectData = OnlineEntranceExamQuestionBankMaster.GetOnlineExamSubjectData();

            $("#FormCreateOnlineExamQuestionBankSubject").validate();
            if ($("#FormCreateOnlineExamQuestionBankSubject").valid()) {
                ajaxRequest.makeRequest("/OnlineEntranceExamQuestionBankMaster/CreateSubject", "POST", OnlineExamSubjectData, OnlineEntranceExamQuestionBankMaster.Success);
            }
            else {
                $('#DivSuccessMessage').html("Data is not proper formate.");
                $('#DivSuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
            }
        }
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOnlineEntranceExamQuestionBankMaster: function () {
        //
        var OnlineEntranceExamQuestionBankMasterData = null;
        if (OnlineEntranceExamQuestionBankMaster.ActionName == "CreateQuestions") {
            OnlineEntranceExamQuestionBankMasterData = null;
            OnlineEntranceExamQuestionBankMasterData = OnlineEntranceExamQuestionBankMaster.GetOnlineExamQuestionBankMasterAndDetails();
            if (OnlineEntranceExamQuestionBankMasterData != null) {
                ajaxRequest.makeRequest("/OnlineEntranceExamQuestionBankMaster/CreateQuestionBank", "POST", OnlineEntranceExamQuestionBankMasterData, OnlineEntranceExamQuestionBankMaster.Success);
            }
            else {
                $('#DivSuccessMessage').html("Data is not proper formate.");
                $('#DivSuccessMessage').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', '#F5CCCC');
            }
        }
        if(OnlineEntranceExamQuestionBankMaster.ActionName == "DeleteQuestion")
        {
            OnlineEntranceExamQuestionBankMasterData = null;
            OnlineEntranceExamQuestionBankMasterData = OnlineEntranceExamQuestionBankMaster.GetOnlineExamQuestionBankMasterAndDetails();
            if (OnlineEntranceExamQuestionBankMasterData != null) {
                ajaxRequest.makeRequest("/OnlineEntranceExamQuestionBankMaster/Delete", "POST", OnlineEntranceExamQuestionBankMasterData, OnlineEntranceExamQuestionBankMaster.Success);
            }
        }
    },

    //Create XML for Question option.
    GetXmlData: function () {
        //
        var DataArray = [];
        $('#tblData input').each(function () {            
            DataArray.push($(this).val());
        });
        var DatatableData, TotalRecord, TotalRow;
        TotalRecord = DataArray.length;
        ParameterXml = "<rows>";

        for (var i = 0; i < TotalRecord; i = i + 3) {
            //
            if (DataArray[i] == 'true') {
                ParameterXml = ParameterXml + "<row><ID>0</ID><OptionText></OptionText><OptionImage>" + DataArray[i + 1] + "</OptionImage><IsAnswer>" + DataArray[i + 2] + "</IsAnswer></row>";
            }
            else {
                ParameterXml = ParameterXml + "<row><ID>0</ID><OptionText>" + DataArray[i + 1] + "</OptionText><OptionImage></OptionImage><IsAnswer>" + DataArray[i + 2] + "</IsAnswer></row>";
            }
            OnlineEntranceExamQuestionBankMaster.XMLstring = ParameterXml + "</rows>";
        }
    },


    //Get Subject Data 
    GetOnlineExamSubjectData: function () {
        //
        var Data = {
        };
        if (OnlineEntranceExamQuestionBankMaster.ActionName == "CreateSubject") {           
            var Subject = ($("#Subject").val()).split("~");
            Data.SubjectID = Subject[0];
            Data.SubjectgroupID = Subject[1];
            Data.CourseYearDetailID = $("#CourseYearID").val();
            Data.DepartmentID = $("#Department").val();
            Data.IsAcademic = $("#Academic").val();
            Data.OldOnlineExamQuestionBankMasterID = 0;

        }
        return Data;
    },

    //Get properties data from the Create, Update and Delete page
    GetOnlineExamQuestionBankMasterAndDetails: function () {
        //
        var Data = {
        };
        if (OnlineEntranceExamQuestionBankMaster.ActionName == "CreateQuestions") {            
            Data.OnlineExamQuestionBankMasterID = $("#OnlineExamQuestionBankMasterID").val();
            Data.GeneralQuestionTypeID = $("#GeneralQuestionTypeID").val();
            Data.GeneralQuestionLevelID = $("#GeneralQuestionLevelID").val();
            var SyllabusGroupDetail = $("#SyllabusGroupDetail").val().split('~');

            Data.SyllabusGroupID = SyllabusGroupDetail[0];
            Data.SyllabusGroupDetID = SyllabusGroupDetail[1];
            Data.SyllabusTopicGroupID = $("#SyllabusTopicGroupID").val();
            Data.IsQuestionInImage = $('#IsQuestionInImage:checked').val() ? true : false;

            var QuestionImageFileSize = null;
            var QuestionImageFilename = null;
            var QuestionImageType = null;

            if (Data.IsQuestionInImage == false) {
                Data.QuestionLableText = $('#QuestionLableText').val();
                Data.ImageType = QuestionImageType;
                Data.ImageName = null;

            }
            else {
                //if Question in img
                if ($("#QuestionImageFile").val() != "") {
                    if (typeof ($("#QuestionImageFile")[0].files) != "undefined") {
                        QuestionImageFileSize = $("#QuestionImageFile")[0].files[0].size;
                        QuestionImageType = $('#QuestionImageFile')[0].files[0].type;
                        QuestionImageFilename = $('#QuestionImageFile')[0].files[0].name;
                    }
                    var data = new FormData();
                    var files = $("#QuestionImageFile").get(0).files;
                    if (files.length > 0 && QuestionImageFileSize <= 50000) {
                        data.append("MyImages", files[0]);
                       
                        $.ajax({
                            url: "/OnlineEntranceExamQuestionBankMaster/UploadQuestionFile",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,               //Q => Question
                            dataType: 'json',
                            success: function (data) {
                                OnlineEntranceExamQuestionBankMaster.QuestionImageFileName = data;
                            },
                            error: function (er) {
                                // alert(er);
                            }
                        });
                    }
                    Data.QuestionLableText = "-";
                    Data.ImageType = QuestionImageType;
                    Data.ImageName = OnlineEntranceExamQuestionBankMaster.QuestionImageFileName;
                }
            }

            Data.SelectedXml = OnlineEntranceExamQuestionBankMaster.XMLstring;
        }
        if (OnlineEntranceExamQuestionBankMaster.ActionName == "DeleteQuestion")
        {
            Data.OnlineExamQuestionBankAnsDetailsID = $("#OnlineExamQuestionBankAnsDetailsID").val();
        }
        return Data;

    },

    showQueImageOnHover: function () {
        $("#myDataTable tbody").on("mouseenter", "tr td p img[id=QueImage]", function () {
            var img = this,
                $img = $(img),
                offset = $img.offset();
            $(this).removeClass('imageclass');
        });
        $("#myDataTable tbody").on("mouseleave", "tr td p img[id=QueImage]", function () {
            $(this).addClass('imageclass');
        });
    },

    showAnsImageOnHover: function () {
        $("#myDataTable tbody").on("mouseenter", "tr td p img[id=AnsImage]", function () {
            var img = this,
                $img = $(img),
                offset = $img.offset();
            $(this).removeClass('imageclass');
        });
        $("#myDataTable tbody").on("mouseleave", "tr td p img[id=AnsImage]", function () {
            $(this).addClass('imageclass');
        });
    },

    EnableDisable: function () {
        $("#tblData tbody tr td input[id='IsAns']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#tblData tbody tr td input[id='IsAns']").prop("disabled", true);
                $("#IsAnswer").prop("disabled", true);
                $this.val(1);
                $this.prop("disabled", false);
            }
            else {
                $("#tblData tbody tr td input[id='IsAns']").prop("disabled", false);
                $("#IsAnswer").prop("disabled", false);
                $this.val(0);
            }
        });
    },


    DeleteAnswerOption: function () {
        $("#tblData tbody").on("click", "tr td i[class=icon-trash]", function () {
            $(this).closest('tr').remove();
        });
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {       
        var splitData = data.split(',');
        parent.$.colorbox.close();
      
        OnlineEntranceExamQuestionBankMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },


}