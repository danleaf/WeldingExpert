/// <reference path="jquery-1.5.1.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

$.validator.unobtrusive.adapters.addBool("socialidvalidate");
$.validator.addMethod("socialidvalidate", function (value, element, params) {

    var w = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
    var sig = ['1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2'];

    if (value.length != 18) {
        return false;
    }

    var sum = 0;
    for (var i = 0; i < 17; i++) {
        sum += (value[i] - '0') * w[i];
    }

    sum %= 11;
    if (value[17] != sig[sum])
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add("agevalidate", ["min", "max"], function (opt) {
    opt.rules["agevalidate"] = {
        min: opt.params.min,
        max: opt.params.max
    };
    opt.messages["agevalidate"] = opt.message;
});

$.validator.addMethod("agevalidate", function (value, element, params) {
    var age = value;
    var min = params.min;
    var max = params.max;
    return age >= min && age <= max;
});

//Create.cshtml

//$(function () {}) 是 $(document).ready(function () {})的简写  

$(function () {
    $("#Age").change(function (event) {
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
    $("#menu_quality").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/Home/About'>质量管理</a></li>");
    });

    $("#menu_setting").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/User/Index'>用户管理</a></li>");
    });

    $("#menu_material").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/ParentMetal/Index'>母材管理</a></li>");
        $("#menu").append("<li><a href='/WeldingMaterial/Index'>焊材管理</a></li>");
    });

    $("#menu_task").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/User/Index'>产品焊接工艺任务</a></li>");
    });

    $("#menu_welder").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/User/Index'>焊工管理</a></li>");
    });

    $("#menu_tech").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/User/Index'>焊接工艺技术</a></li>");
    });

    $("#menu_progress").mouseover(function (event) {
        $("#menu").empty();
        $("#menu").append("<li><a href='/User/Index'>进度控制</a></li>");
    });
});

$.fn.lightbox = function () {

    function removeLightBox() {
        $('.lightBoxMask').fadeTo(300, 0, function () {
            $(this).remove();
        });
        $('.lightBox').fadeTo(100, 0, function () {
            $(this).remove();
        });
    }

    $(this).click(function () {
        $(this).attr('href', 'javascript:;');

        var img = new Image();
        img.src = $(this).children('img').attr('src');

        $('body').append('<div class="lightBoxMask" style="width:' + $(window).width() + 'px;height:' + $(window).height() + 'px;"></div>')
                     .append('<div class="lightBox" style="width:' + img.width + 'px;height:' + img.height + 'px;"><div class="lightBoxContainer" style="width:' + img.width + 'px;height:' + img.height + 'px;"><img src="' + img.src + '" /></div><div class="lightBoxClose">关闭</div></div>');


        $('.lightBox').css({
            opacity: 0,
            left: ($(window).width() - $('.lightBox').width()) / 2,
            top: ($(window).height() - $('.lightBox').height()) / 2
        }).fadeTo(1000, 1);

        $('.lightBoxClose').click(removeLightBox);
        $('.lightBoxMask').css({ opacity: 0 }).fadeTo(500, 0.8).click(removeLightBox);
    });

    $(window).resize(function () {
        $('.lightBoxMask').css({
            width: $(window).width(),
            height: $(window).height()
        });

        $('.lightBox').css({
            left: ($(window).width() - $('.lightBox').width()) / 2,
            top: ($(window).height() - $('.lightBox').height()) / 2
        });
    });
};

$(function () {
    $('.test a').lightbox();
});