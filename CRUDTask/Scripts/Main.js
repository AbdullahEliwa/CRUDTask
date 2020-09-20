$(document).ready(function () {

    // Check for click events on the navbar burger icon
    $(".navbar-burger").click(function () {
        // Toggle the "is-active" class on both the "navbar-burger" and the "navbar-menu"
        $(".navbar-burger").toggleClass("is-active");
        $(".navbar-menu").toggleClass("is-active");

    });

    $(window).scroll(function () {
        if ($(window).scrollTop() >= $("#header").outerHeight()) {
            $("#header").removeClass("big-nav").addClass("small-nav");
            $(".big-item").removeClass("big-item").addClass("small-item");
            $(".navbar-burger").css("margin-top", "0%");
            
        }
        else if (($(window).scrollTop() <= $("#header").outerHeight())) {
            $("#header").removeClass("small-nav").addClass("big-nav");
            $(".small-item").removeClass("small-item").addClass("big-item");
            $(".navbar-burger").css("margin-top", "4%");
        }
    });


    $("#account-image").click(function () {
        $("#account-manager").toggleClass("is-active");

    });


    // for Drop Down

    $("#user-name").click(function () {
        $(".dropdown").toggleClass("is-active");
    });
});