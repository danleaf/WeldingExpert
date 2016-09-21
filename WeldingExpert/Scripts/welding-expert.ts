/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/jquery/jquery.validation.d.ts" />
/// <reference path="typings/jquery/jquery.validation.unobtrusive.d.ts" />

$.validator.unobtrusive.adapters.addBool("socialidvalidate");
$.validator.addMethod("socialidvalidate", (value:string, element, params) => {
    var w = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
    var sig = ["1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2"];

    if (value.length != 18) {
        return false;
    }

    var sum = 0;
    for (var i = 0; i < 17; i++) {
        sum += parseInt(value[i]) * w[i];
    }

    sum %= 11;
    if (value[17] != sig[sum])
        return false;

    return true;
});

$.validator.unobtrusive.adapters.add("agevalidate", ["min", "max"], (opt)=> {
    opt.rules["agevalidate"] = {
        min: opt.params.min,
        max: opt.params.max
    };
    opt.messages["agevalidate"] = opt.message;
});

$.validator.addMethod("agevalidate", (value:number, element, params) => {
    var age = value;
    var min = params.min;
    var max = params.max;
    return age >= min && age <= max;
});

$(() => {
    $("#submenu").mouseleave((eevent) => {
        $(this).hide();
    });

    $("#header").mouseleave((event) => {
        $("#submenu").hide();
    });

    var subMenuWidthMap = new Array();
    var subMenuObjectMap = new Array();

    $("#submenu ul").each(() => {
        var width: number = 0;
        $("li", this).each( () => {
            width += $(this).outerWidth();
        });
        $(this).width(width + 10);
        subMenuWidthMap[$(this).attr("id")] = width;
        subMenuObjectMap[$(this).attr("id")] = $(this);
    });


    $("#submenu").hide();

    $("#mainmenu li").mouseover((event) => {
        var menu: JQuery;
        var width: number;

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
});

function showbox() {
    $("#box").show();
}

$(function () {
    $("body").append("<div id='box' style='display:none'><div id='boxbg'></div><div id='boxfg'><div id='boxcontent'></div><div id='boxclose'>关闭</div></div></div>");
    $("#boxclose").click(function () {
        $("#boxcontent").empty();
        $("#box").hide();
    });
});