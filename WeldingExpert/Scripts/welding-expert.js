/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="typings/jquery/jquery.validation.d.ts" />
/// <reference path="typings/jquery/jquery.validation.unobtrusive.d.ts" />
var _this = this;
$.validator.unobtrusive.adapters.addBool("socialidvalidate");
$.validator.addMethod("socialidvalidate", function (value, element, params) {
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
$(function () {
    $("#submenu").mouseleave(function (eevent) {
        $(_this).hide();
    });
    $("#header").mouseleave(function (event) {
        $("#submenu").hide();
    });
    var subMenuWidthMap = new Array();
    var subMenuObjectMap = new Array();
    $("#submenu ul").each(function () {
        var width = 0;
        $("li", _this).each(function () {
            width += $(_this).outerWidth();
        });
        $(_this).width(width + 10);
        subMenuWidthMap[$(_this).attr("id")] = width;
        subMenuObjectMap[$(_this).attr("id")] = $(_this);
    });
    $("#submenu").hide();
    $("#mainmenu li").mouseover(function (event) {
        var menu;
        var width;
        for (var key in subMenuObjectMap) {
            if ("show_" + key == $(_this).attr("id")) {
                menu = subMenuObjectMap[key];
                width = subMenuWidthMap[key];
            }
            else {
                subMenuObjectMap[key].hide();
            }
        }
        if (menu) {
            var totalWidth = $("#header").width();
            var left = $(_this).position().left + $(_this).width() / 2 - width / 2;
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
//# sourceMappingURL=welding-expert.js.map