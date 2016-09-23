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

$(function () {
    $("#submenu").hide();

    $("#submenu").click((event) => {
        $("#submenu").hide();
    });

    var subMenuObjectMap = new Object();

    $("#submenu ul").each((index, elem) => {
        subMenuObjectMap[$(elem).attr("id")] = $(elem);
    });    


    $("#mainmenu li").mouseover((event) => {
        var menu: JQuery;
        var width: number;
        var sender = event.srcElement ? event.srcElement : event.target;

        for (var key in subMenuObjectMap) {
            if ("show_" + key == $(sender).attr("id")) {
                menu = subMenuObjectMap[key];
                //width = subMenuWidthMap[key];
            }
            else {
                subMenuObjectMap[key].hide();
            }
        }

        //$(sender).css("show_settingmenu

        if (menu) {
            var pos = $(sender).offset();
            var h = $(sender).outerHeight();
            menu.css("top", pos.top + h);
            menu.css("left", pos.left);
            menu.show();
        }

        $("#submenu").show();
    });
});

function showbox() {
    $("#box").show();
}
 
$(() => {
    $("body").append("<div id='box' style='display:none'><div id='boxbg'></div><div id='boxfg'><div id='boxcontent'></div><div id='boxclose'>关闭</div></div></div>");
    $("#boxclose").click(function () {
        $("#boxcontent").empty();
        $("#box").hide();
    }); 
});

class Greeter {
    greeting: string;
    static abc: number;
    constructor(message: string) {
        this.greeting = message;
    }
    greet() {
        return "Hello, " + this.greeting;
    }

    static getInde() {
        return 2;
    }
}

Greeter.abc = 1;

var greeter = new Greeter("world");

