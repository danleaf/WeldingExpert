/// <reference path="jquery-1.5.1.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

$.validator.unobtrusive.adapters.addBool("socialidvalidate");
$.validator.addMethod("socialidvalidate", function (value, element, params) 
{
    var w = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
    var sig = ["1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2"];

    if (value.length != 18) {
        return false;
    }

    var sum = 0;
    for (var i = 0; i < 17; i++) {
        sum += (value[i] - "0") * w[i];
    }

    sum %= 11;
    if (value[17] != sig[sum])
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add("agevalidate", ["min", "max"], function (opt) 
{
    opt.rules["agevalidate"] = {
        min: opt.params.min,
        max: opt.params.max
    };
    opt.messages["agevalidate"] = opt.message;
});

$.validator.addMethod("agevalidate", function (value, element, params) 
{
    var age = value;
    var min = params.min;
    var max = params.max;
    return age >= min && age <= max;
});

//Create.cshtml

//$(function () {}) 是 $(document).ready(function () {})的简写  

$(function () 
{
    $("#Age").change(function (event) 
    {
        $("#Level").empty();
        if (parseInt($("#Age").val()) < 30) {
            $("#Level").append("<option value='0'>初级焊工</option>");
            $("#Level").append("<option value='1'>中级焊工</option>");
            $("#Level").append("<option value='2'>高级焊工</option>");
        }
        else if (parseInt($("#Age").val()) >= 30) {
            $("#Level").append("<option value='3'>初级焊接工程师</option>");
            $("#Level").append("<option value='4'>中级焊接工程师</option>");
            $("#Level").append("<option value='5'>高级焊接工程师</option>");
        }
    });
});

$(function () {
    $("#submenu").mouseleave(function (event) {
        $(this).hide();
    });

    $("#header").mouseleave(function (event) {
        $("#submenu").hide();
    });

    var subMenuWidthMap = new Array();
    var subMenuObjectMap = new Array();

    $("#submenu ul").each(function () {
        var width = 0;
        $("li", this).each(function () {
            width += $(this).outerWidth();
        });
        $(this).css("width", width + 10);
        subMenuWidthMap[$(this).attr("id")] = width;
        subMenuObjectMap[$(this).attr("id")] = $(this);
    });


    $("#submenu").hide();

    $("#mainmenu li").mouseover(function (event) {
        var menu, width;

        for (var key in subMenuObjectMap) {
            if ("show_" + key == $(this).attr("id")) {
                menu = subMenuObjectMap[key];
                width = subMenuWidthMap[key];
            }
            else {
                subMenuObjectMap[key].hide();
            }
        }

        if (menu) {
            var totalWidth = $("#header").width();
            var left = $(this).position().left + $(this).width() / 2 - width / 2;

            if (left + width > totalWidth) {
                left -= left + width - totalWidth;
            }

            if (left < 0) {
                left = 0;
            }

            menu.css("padding", "0 " + left + "px 2px");
            menu.show();
        }

        $("#submenu").show();
    });

    /*
    $("#menu_quality").mouseover(function (event) {
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/Home/About">质量管理</a></li>");
    });

    $("#menu_setting").mouseover(function (event) {
    $("#submenu").show();
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/User/Index">用户管理</a></li>");
    });

    $("#menu_material").mouseover(function (event) {
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/ParentMetal/Index">母材管理</a></li>");
    $("#submenu").append("<li><a href="/WeldingMaterial/Index">焊材管理</a></li>");
    });

    $("#menu_task").mouseover(function (event) {
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/User/Index">产品焊接工艺任务</a></li>");
    });

    $("#menu_welder").mouseover(function (event) {
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/User/Index">焊工管理</a></li>");
    });

    $("#menu_tech").mouseover(function (event) {
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/User/Index">焊接工艺技术</a></li>");
    });

    $("#menu_progress").mouseover(function (event) {
    $("#submenu").empty();
    $("#submenu").append("<li><a href="/User/Index">进度控制</a></li>");
    });*/
});

function showbox() {
    $("#box").show();
}

$(function () {
    $("body").append("<div id='box' style='display:none'><div id='boxbg'></div><div id='boxfg'><div id='boxcontent'></div><div id='boxclose'>关闭</div></div></div>");
    $("#boxclose").click(function () {
        $("#boxcontent").empty();
        $("#box").css("display", "none");
    });
});

$.fn.lightbox0 = function () {
    function removeLightBox() {
        $('.lightboxmask').fadeTo(1, 0, function () {
            $(this).remove();
        });
        $('.lightbox').fadeTo(1, 0, function () {
            $(this).remove();
        });
    }

    $(this).click(function (event) {
        event.preventDefault();

        var img = new Image();
        img.onload = (function () {
            $('body').append('<div class="lightboxmask" style="width:' + $(window).width() + 'px;height:' + $(window).height() + 'px;"></div>')
                     .append('<div class="lightbox" style="width:' + img.width + 'px;height:' + img.height + 'px;"><div class="lightboxcontainer" style="width:' + img.width + 'px;height:' + img.height + 'px;"><img src="' + img.src + '" /></div><div class="lightboxclose">关闭</div></div>');

            $('.lightbox').css({
                opacity: 0,
                left: ($(window).width() - $('.lightbox').width()) / 2,
                top: ($(window).height() - $('.lightbox').height()) / 2
            }).fadeTo(1, 1);

            $('.lightboxclose').click(removeLightBox);
            $('.lightboxmask').css({ opacity: 0 }).fadeTo(1, 0.8).click(removeLightBox);
        });

        img.src = $(this).attr('href');
    });

    $(window).resize(function () {
        $('.lightboxmask').css({
            width: $(window).width(),
            height: $(window).height()
        });

        $('.lightbox').css({
            left: ($(window).width() - $('.lightbox').width()) / 2,
            top: ($(window).height() - $('.lightbox').height()) / 2
        });
    });
};

$(function () 
{
    $('.test a').lightbox0();
});

