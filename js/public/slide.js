$(function () {
    // Xác định số lượng hình của slide
    var count = $('.slide-image').length;

    // Thêm số nút điều khiển bằng với số hình của slide
    for (x = 0; x < count ; x++) {
        $('.slide-pager ul').prepend("<li class='slide-pager-slot'></li>");
    }

    $('.slide-pager-slot:first-child').addClass('focus');

    // Khai báo biến dùng để đồng bộ hóa giữa hình ảnh và điều khiển
    var eindex = 0;

    // Click vào điều khiển sẽ hiện hình tương ứng
    $('.slide-pager-slot').click(function () {
        eindex = $('.slide-pager-slot').index(this);
        $('.slide-image').stop().animate({ opacity: 0 });
        $('.slide-image:eq(' + eindex + ')').stop().animate({ opacity: 1 });
        $('.slide-pager-slot').removeClass('focus');
        $(this).addClass('focus');
    });

    // Function xử lý hiển thị cho hình slide và các nút điều khiển tương ứng với eindex
    // Được dùng lại một số lần ở các đoạn code bên dưới
    function setimagefocus() {
        $('.slide-pager-slot').removeClass('focus');
        $('.slide-pager-slot:eq(' + eindex + ')').addClass('focus');
        $('.slide-image').stop().animate({ opacity: 0 });
        $('.slide-image:eq(' + eindex + ')').stop().animate({ opacity: 1 });
    }

    // function xử lý quay vòng hình ảnh
    function slideswap() {
        // Nếu vị trí hiện tại đã là hình cuối cùng của slide thì sẽ chuyển eindex về -1
        // để sau eindex++ thì eindex sẽ là 0, tương ứng với hình slide đầu tiên
        if (eindex == count - 1) { eindex = -1; }
        eindex++;
        setimagefocus();
    }

    start_slideswap();
    // Thay đổi giá trị biến timeinterval bên dưới để thay đổi thời gian chuyển đổi giữa 2 hình
    function start_slideswap() {
        timeinterval = 4000;
        play = setInterval(slideswap, timeinterval);
    }

    // Xử lý khi đưa chuột vào slide thì dừng lại quá trình tự động chuyển hình
    $(".slide-container").hover(function () {
        clearInterval(play);
    }, function () {
        start_slideswap();
    });

    // Xử lý khi click nút next và prev
    $('.slide-control-prev').click(function () {
        eindex--;
        // Nếu vị trí hiện tại đã là hình đầu tiên của slide thì sẽ chuyển eindex về hình cuối
        if (eindex == -1) { eindex = count - 1; }
        setimagefocus();
    });
    $('.slide-control-next').click(function () {
        eindex++;
        // Nếu vị trí hiện tại đã là hình đầu tiên của slide thì sẽ chuyển eindex về hình cuối
        if (eindex == count) { eindex = 0; }
        setimagefocus();
    });

})