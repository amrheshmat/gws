$(".dashboard-menu-btn").on("click", function () {
    $(".dashbard-menu-wrap").css("left", "0px");
    $(".dashbard-menu-overlay").fadeIn(100);
});
$(".dashbard-menu-close , .dashbard-menu-overlay").on("click", function () {

    $(".dashbard-menu-wrap").css("left", "-350px");
    $(".dashbard-menu-overlay").fadeOut(100);
});

//   css ------------------
var $window2 = $(window);

$window2.on("resize", function () {

    var ww3 = $window2.width();
    if (ww3 > 1270) {
        $(".dashbard-menu-overlay").css({
            display: "none"
        });
        $(".dashbard-menu-wrap").css("left", "-350px");
    }

});