$(function () {
    $(".carousel").carousel({
      interval: 2000,
    });


    $('.form__item--prefixes label').click(function(){
       var text = $(this).find('span:last-child').text()
      $('#prefix').text(text);
      $('#prefixes').removeClass('active')
      $('.form__item--prefix>span').removeClass('active')
    })

    $(window).click(function(e){
      if(e.target.id !== 'prefix' && e.target.id !== 'prefixes' && e.target.id !== 'prefix-search'){
        $('#prefixes').removeClass('active')
      $('.form__item--prefix>span').removeClass('active')
      }
    })


    $('.form__item--prefix>span').click(function(){
      $(this).toggleClass('active')
      $('#prefixes').toggleClass('active');
    })

    $("#prefix-search").keyup(function() {

  var value = $(this).val().toLowerCase();
  console.log(value);
  $("#prefixes label").find('span:first-child').filter(function() {
    $(this).parent().toggle($(this).text().toLowerCase().indexOf(value) > -1)
  });
});









    var swiper = new Swiper(".mySwiper", {
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
    });

    var swiper2 = new Swiper(".mySwiper2", {
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
    });

    $(window).scroll(function () {
      if ($(window).scrollTop() > 0) {
          $('.header').addClass('active')
          $('.header').addClass('shadow')
          $('.active-3').addClass('toure-bg')
      } else {
          $('.active-3').removeClass('toure-bg')
        $('.header').removeClass('active')
        $('.header').removeClass('shadow')
      }
    });

    $(".nav__hamburger").click(function () {
      $(".overlay").addClass("active");
      setTimeout(function () {
        $(".sidebar").addClass("active");
        $(".sidebar__header--close").addClass("active");
      }, 300);
    });

    $(".sidebar__header--close").click(function () {
      $(".sidebar").removeClass("active");
      $(".sidebar__header--close").removeClass("active");
      setTimeout(function () {
        $(".overlay").removeClass("active");
      }, 300);
    });

    $(".overlay").click(function () {
      $(".sidebar").removeClass("active");
      $(".sidebar__header--close").removeClass("active");
      setTimeout(function () {
        $(".overlay").removeClass("active");
      }, 300);
    });
  });






  var swiper3 = new Swiper(".mySwiper3", {
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });

  var swiper4 = new Swiper(".mySwiper4", {
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });
  var swiper5 = new Swiper(".mySwiper5", {
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
  });