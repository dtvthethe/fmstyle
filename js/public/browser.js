﻿// kiểm tra xem duang dùng trình duyệt gì và add thêm 1 class để nhận biết nó

$(document).ready(function () {

    var userAgent = navigator.userAgent.toLowerCase();
    $.browser.chrome = /chrome/.test(navigator.userAgent.toLowerCase());

    // kiểm tra xem có phải ie ko 
    if ($.browser.msie) {
        $('body').addClass('browserIE');

        // thêm class để nhận biết nó theo phiên bản
        $('body').addClass('browserIE' + $.browser.version.substring(0, 1));
    }


    // xem có phải là chrome ko 
    if ($.browser.chrome) {

        $('body').addClass('browserChrome');

        //thêm class để nhận biết nó theo phiên bản
        userAgent = userAgent.substring(userAgent.indexOf('chrome/') + 7);
        userAgent = userAgent.substring(0, 1);
        $('body').addClass('browserChrome' + userAgent);
        $.browser.safari = false;
    }

    //  xem có phải là Safari?
    if ($.browser.safari) {
        $('body').addClass('browserSafari');

        //thêm class để nhận biết nó theo phiên bản
        userAgent = userAgent.substring(userAgent.indexOf('version/') + 8);
        userAgent = userAgent.substring(0, 1);
        $('body').addClass('browserSafari' + userAgent);
    }

    // xem có phải là firefox ko
    if ($.browser.mozilla) {
        if (navigator.userAgent.toLowerCase().indexOf('firefox') != -1) {
            $('body').addClass('browserFirefox');

            //thêm class để nhận biết nó theo phiên bản
            userAgent = userAgent.substring(userAgent.indexOf('firefox/') + 8);
            userAgent = userAgent.substring(0, 1);
            $('body').addClass('browserFirefox' + userAgent);
        }
        else {
            $('body').addClass('browserMozilla');
        }
    }

    // xem có phải là Opera?
    if ($.browser.opera) {
        $('body').addClass('browserOpera');
    }

});


//.browserIE
//.browserIE6
//.browserIE7
//.browserIE8
//.browserChrome
//.browserChrome1
//.browserSafari
//.browserSafari1
//.browserSafari2
//.browserSafari3
//.browserMozilla
//.browserFirefox
//.browserFirefox1
//.browserFirefox2
//.browserFirefox3
//.browserOpera


//#myInput {background:black;}
//.browserSafari #myInput{background:black; position:relative; top:2px;}