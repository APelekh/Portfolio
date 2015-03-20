var fixright = function()
{
	$('div#copyright').css('padding-top',($('body').height()-$('div#right').height()-$('div#right').position().top)+'px');
}

$(document).ready(function()
{
	fixright();
	$(window).resize(fixright);
	
	$('#contact-info-title').mouseenter(function()
	{
	    $('#contact-area').slideToggle();
	});
	$('#contact-menu').mouseenter(function()
	{
		$('#contact-area').slideToggle();
	});
});