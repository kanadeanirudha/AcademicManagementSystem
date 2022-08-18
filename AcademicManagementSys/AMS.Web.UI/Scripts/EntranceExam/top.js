$(document).bind("contextmenu",function(e){
	preventDefault(e);
});


function quizPageHeight(){
			var height = $(window).height()-($("#header").height()+$("#footer").height()+$("#sub-header").height());
	$('#questionContent').css({"height":height});
	//if(mockVar.curQuesBean.quesType=="TYPING TEST"){
	//	$('#questionCont').height($('#questionContent').height()-$('.profile-grouping-section').outerHeight(true)-2);
	//	$('#currentQues').height($('#questionCont').height()-1);
	//	$('#typingInstDiv').height(jQuery(window).height()-(jQuery("#header").outerHeight(true)+jQuery("#sub-header").outerHeight(true)+jQuery("#User_Hldr").outerHeight(true))-94);
	//} else {
	//	$('#questionCont').height($('#questionContent').height()-($('.profile-grouping-section').outerHeight(true))-2);
	//	$('#currentQues').css({height:$('#questionCont').height()-$('.buttons-div').outerHeight(true)+8,overflow:'hidden'});
	//}
	$('#questionCont').height($('#questionContent').height() - ($('.profile-grouping-section').outerHeight(true)) - 2);
	$('#currentQues').css({ height: $('#questionCont').height() - $('.buttons-div').outerHeight(true) + 8, overflow: 'hidden' });
	if($('#groups').height()!=0){
		$('#timer').height($('#groups').height()+$('#sectionsField').height());
	}
	$('#sectionSummaryDiv').height($('#questionCont').height()-5);
	$('#QPDiv').height($('#questionCont').height());
	var theDiv = jQuery('#question_area');
			var questionpanelheight = jQuery(window).height()-(jQuery("#header").outerHeight(true)+jQuery("#sub-header").outerHeight(true)+jQuery("#User_Hldr").outerHeight(true)+jQuery(".diff_type_notation_area_outer").outerHeight(true)+jQuery(".header").outerHeight(true)+jQuery(".subheader").outerHeight(true)+55+jQuery("#footer").outerHeight(true)+jQuery(".profile-header-tablet").outerHeight(true)+jQuery(".toolbar-header-tablet").outerHeight(true)+parseInt(jQuery(".collapsebel_panel").css("border-left-width"))+parseInt(jQuery(".collapsebel_panel").css('border-top-width')));
			theDiv.height(questionpanelheight);
			theDiv.nanoScroller();
	$('#instructionsDiv').height($('#questionCont').height());
	$('#typingInstDiv').height($('.numberpanel').height()-($('#viewSection').height()+$('#typingSubmit').height()+30));
	$('#breakTimeDiv').height(height);
	$('#scoreCardDiv').height(height);	
	var quesOuterDivHeight = $('#currentQues').height()-$('.questionTypeCont').outerHeight(true)-2;
	$('#quesOuterDiv').css({ height: ($('#currentQues').height() - $('.questionTypeCont').outerHeight(true) - 2) - 43, overflow: 'auto' }); $('.leftDiv').height($('#quesOuterDiv').height() - 10);
	$('.rightDiv').height($('#quesOuterDiv').height() - 10);
	$('#quesAnsContent').css({ overflow:'auto'});
	$('#progEditorDisplay').height($('#progRightPart').height()-$('#progDescriptionDiv').outerHeight(true)-2);
    $('#textareaforflip').height($('#progRightPart1').height()-$('#progDescriptionDiv').outerHeight(true)-27);
	$('#breakContentDiv').height($('#breakTimeDiv').height()-$('#brkPrcdBtnDiv').outerHeight(true)-$('#col1').outerHeight(true));
	$('#breakSummaryDiv').height($('#breakContentDiv').height()-$('#breakTimeCountDiv').outerHeight(true));
	$('#break_summary').height($('#breakSummaryDiv').height()-60-$('.examSummaryHeader').outerHeight(true));
	$('#group_summary').height($('#sectionSummaryDiv').height()-$('#confirmation_buttons').outerHeight(true)-$('.examSummaryHeader').outerHeight(true)-80);
}

	/*KeyboarLock Started*/
	
	/*KeyboarLock Completed*/