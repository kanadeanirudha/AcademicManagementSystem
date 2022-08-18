//this class contain methods related to nationality functionality
var StudentChangeCourseRequestApplication = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        StudentChangeCourseRequestApplication.constructor();
        //StudentChangeCourseRequestApplication.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $("#reset").on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#Description').focus();
            return false;
        });

        // Create new record
        $('#CreateStudentChangeCourseRequestApplicationRecord').on("click", function () {
            
            StudentChangeCourseRequestApplication.ActionName = "Create";
            StudentChangeCourseRequestApplication.AjaxCallStudentChangeCourseRequestApplication();
        });

        $('#EditStudentChangeCourseRequestApplicationRecord').on("click", function () {
            
            StudentChangeCourseRequestApplication.ActionName = "Edit";
            StudentChangeCourseRequestApplication.AjaxCallStudentChangeCourseRequestApplication();
        });

        $('#DeleteStudentChangeCourseRequestApplicationRecord').on("click", function () {
            
            StudentChangeCourseRequestApplication.ActionName = "Delete";
            StudentChangeCourseRequestApplication.AjaxCallStudentChangeCourseRequestApplication();
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

        $(".ajax").colorbox();

        $('#Description').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
    },
    //LoadList method is used to load List page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/StudentChangeCourseRequestApplication/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode,actionMode) {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/StudentChangeCourseRequestApplication/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallStudentChangeCourseRequestApplication: function () {
        
        var StudentChangeCourseRequestApplicationData = null;
        if (StudentChangeCourseRequestApplication.ActionName == "Create") {
            $("#FormCreateStudentChangeCourseRequestApplication").validate();
            if ($("#FormCreateStudentChangeCourseRequestApplication").valid()) {
                StudentChangeCourseRequestApplicationData = null;
                StudentChangeCourseRequestApplicationData = StudentChangeCourseRequestApplication.GetStudentChangeCourseRequestApplication();
                ajaxRequest.makeRequest("/StudentChangeCourseRequestApplication/Create", "POST", StudentChangeCourseRequestApplicationData, StudentChangeCourseRequestApplication.Success);
            }
        }
        else if (StudentChangeCourseRequestApplication.ActionName == "Edit") {
            $("#FormEditStudentChangeCourseRequestApplication").validate();
            if ($("#FormEditStudentChangeCourseRequestApplication").valid()) {
                StudentChangeCourseRequestApplicationData = null;
                StudentChangeCourseRequestApplicationData = StudentChangeCourseRequestApplication.GetStudentChangeCourseRequestApplication();
                ajaxRequest.makeRequest("/StudentChangeCourseRequestApplication/Edit", "POST", StudentChangeCourseRequestApplicationData, StudentChangeCourseRequestApplication.Success);
            }
        }
        else if (StudentChangeCourseRequestApplication.ActionName == "Delete") {
            StudentChangeCourseRequestApplicationData = null;
            //$("#FormCreateStudentChangeCourseRequestApplication").validate();
            StudentChangeCourseRequestApplicationData = StudentChangeCourseRequestApplication.GetStudentChangeCourseRequestApplication();
            
            ajaxRequest.makeRequest("/StudentChangeCourseRequestApplication/Delete", "POST", StudentChangeCourseRequestApplicationData, StudentChangeCourseRequestApplication.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetStudentChangeCourseRequestApplication: function () {
        
        var Data = {
        };
        if (StudentChangeCourseRequestApplication.ActionName == "Create" || StudentChangeCourseRequestApplication.ActionName == "Edit") {
            Data.CenterCode = $('input[name=CenterCode]').val();
            Data.NewCourseId = $('#NewCourseId').val();
            Data.OldCourseId = $('input[name=OldCourseId]').val();      
            Data.UniversityID = $('input[name=UniversityID]').val();
            Data.OldSectionDetailID = $('input[name=OldSectionDetailID]').val();
            Data.StudentId = $('input[name=StudentId]').val();
            
            
            Data.ApplicationReason = $('#ApplicationReason').val();
            Data.ApplicationStatus = $('#ApplicationStatus:checked').val() ? true : false;
            
            
           
        }
       
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            StudentChangeCourseRequestApplication.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            StudentChangeCourseRequestApplication.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {
        
        
    //    if (data == "True") {

    //        parent.$.colorbox.close();
    //        var actionMode = "1";
    //        StudentChangeCourseRequestApplication.ReloadList("Record Updated Sucessfully.",actionMode );
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
    //        StudentChangeCourseRequestApplication.ReloadList("Record Deleted Sucessfully.");
    //        //  alert("Record Deleted Sucessfully.");

    //    } else {
    //        parent.$.colorbox.close();
    //        // alert("Record Not Deleted Sucessfully. Please Try Again..");
    //    }
    //},
};

