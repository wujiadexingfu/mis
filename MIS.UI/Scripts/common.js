var GLOBAL_TABLE_HEIGHT = "full-300";  //table的Height
var GLOBAL_TABLE_PAGE = true; //table的Page
var GLOBAL_TABLE_TOOBAR = true; //table的toobar
var GLOBAL_TABLE_LIMIT = 10;  //table每页的数据量
var GLOBAL_TABLE_LIMITS = [10, 20, 30];  //table每页的数据量数组
var GLOBAL_TABLE_EVEN = true;  //开启隔行背景
var GLOBAL_TABLE_SKIN ="row";  //表格风格line （行边框风格）,  row （列边框风格）,  nob （无边框风格）






(function ($) {
    $.extend({
        showLoading: function (id) {
            $("#" + id).mLoading("show");
        },

        hideLoading: function (id) {
            $("#" + id).mLoading("hide");
        }
    });
})(jQuery);

(function ($) {
    $.fn.extend({
        showLoading: function () {
            $(this).mLoading("show");
        },

        hideLoading: function () {
            $(this).mLoading("hide");
        }

    });

})(jQuery);