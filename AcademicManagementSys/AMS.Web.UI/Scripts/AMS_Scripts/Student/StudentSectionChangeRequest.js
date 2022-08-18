//this class contain methods related to nationality functionality
var StudentSectionChangeRequest = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        StudentSectionChangeRequest.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#CreateStudentSectionChangeRequestRecord').on("click", function () {
            
            StudentSectionChangeRequest.ActionName = "Create";
            StudentSectionChangeRequest.AjaxCallStudentSectionChangeRequest();
        });
    },

    //LoadList method is used to load List page
    LoadReAdmissionForm: function () {
        var Balancesheet = $("#selectedBalsheetID").val();

        $.ajax(
       {
           cache: false,
           type: "POST",
           data: { "selectedBalsheet": Balancesheet },
           dataType: "html",
           url: '/StudentSectionChangeRequest/List',
           success: function (data) {
               //Rebind Grid Data
               $('#ListViewModel').html(data);
           }
       });
    },
    //Fire ajax call to insert update and delete record
    AjaxCallStudentSectionChangeRequest: function () {

        var StudentSectionChangeRequestData = null;
        if (StudentSectionChangeRequest.ActionName == "Create") {
            $("#FormCreateStudentSectionChangeRequest").validate();
            if ($("#FormCreateStudentSectionChangeRequest").valid()) {
                StudentSectionChangeRequestData = null;
                StudentSectionChangeRequestData = StudentSectionChangeRequest.GetStudentSectionChangeRequest();
                ajaxRequest.makeRequest("/StudentSectionChangeRequest/Index", "POST", StudentSectionChangeRequestData, StudentSectionChangeRequest.Success);
            }
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetStudentSectionChangeRequest: function () {
        var Data = {
        };

        if (StudentSectionChangeRequest.ActionName == "Create" || StudentSectionChangeRequest.ActionName == "Edit") {
            Data.SectionDetailID = $("#SectionDetailID").val();
            Data.StudentId = $("#StudentId").val();
            Data.CentreCode = $("#CentreCode").val();
            Data.SessionID = $("#SessionID").val();
            Data.OldSectionDetailID = $("#OldSectionDetailID").val();
           
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