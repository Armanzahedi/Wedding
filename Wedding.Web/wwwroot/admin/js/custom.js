'use strict';

(function ($) {

    //$(document).on('click', '.layout-builder .layout-builder-toggle', function () {
    //    $('.layout-builder').toggleClass('show');
    //});

    //$(window).on('load', function () {
    //    setTimeout(function () {
    //        $('.layout-builder').removeClass('show');
    //    }, 500);
    //});

    //$('body').append(''+
    //'<div class="layout-builder show">'+
    //    '<div class="layout-builder-toggle shw">'+
    //        '<i class="ti-settings"></i>'+
    //    '</div>'+
    //    '<div class="layout-builder-toggle hdn">'+
    //        '<i class="ti-close"></i>'+
    //    '</div>'+
    //    '<div class="layout-builder-body">'+
    //        '<h5>سفارشی سازی</h5>'+
    //        '<div class="mb-3">'+
    //            '<p>طرح</p>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="horizontal-side-menu" data-layout="horizontal-side-menu">'+
    //              '<label class="custom-control-label" for="horizontal-side-menu">فهرست افقی</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="icon-side-menu" data-layout="icon-side-menu">'+
    //              '<label class="custom-control-label" for="icon-side-menu">فهرست آیکن</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="dark-side-menu" data-layout="dark-side-menu">'+
    //              '<label class="custom-control-label" for="dark-side-menu">فهرست تیره</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="hidden-side-menu" data-layout="hidden-side-menu">'+
    //              '<label class="custom-control-label" for="hidden-side-menu">فهرست پنهان</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="layout-container-1" data-layout="layout-container icon-side-menu">'+
    //              '<label class="custom-control-label" for="layout-container-1">طرح دربرگیرنده 1</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="layout-container-2" data-layout="layout-container horizontal-side-menu">'+
    //              '<label class="custom-control-label" for="layout-container-2">طرح دربرگیرنده 2</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="layout-container-3" data-layout="layout-container hidden-side-menu">'+
    //              '<label class="custom-control-label" for="layout-container-3">طرح دربرگیرنده 3</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="dark-1" data-layout="dark">'+
    //              '<label class="custom-control-label" for="dark-1">طرح تیره 1</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="dark-2" data-layout="layout-container dark icon-side-menu">'+
    //              '<label class="custom-control-label" for="dark-2">طرح تیره 2</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="dark-3" data-layout="layout-container dark horizontal-side-menu">'+
    //              '<label class="custom-control-label" for="dark-3">طرح تیره 3</label>'+
    //            '</div>'+
    //            '<div class="custom-control custom-radio">'+
    //              '<input type="radio" class="custom-control-input" name="layout" id="dark-4" data-layout="layout-container dark hidden-side-menu">'+
    //              '<label class="custom-control-label" for="dark-4">طرح تیره 4</label>'+
    //            '</div>'+
    //        '</div>'+
    //        '<button id="btn-layout-builder-reset" class="btn btn-danger btn-uppercase">بازنشانی</button>'+
    //        '<div class="layout-alert mt-3">'+
    //            '<i class="fa fa-warning m-l-5 text-warning"></i>برخی گزینه های قالب در صورت ترکیب با یکدیگر در صورتی که همخوانی نداشته باشند قابل نمایش نخواهند بود. بنابراین توصیه می شود گزینه های قالب را جدا جدا امتحان کنید.'+
    //        '</div>'+
    //    '</div>'+
    //'</div>');

    var site_layout = localStorage.getItem('site_layout');
    $('body').addClass(site_layout);
    var themeSelector = $("#theme-selector");
    themeSelector.empty();
    if (site_layout == "dark") {
        themeSelector.append("<i class='fa fa-sun-o'></i>")
    } else {
        themeSelector.append("<i class='fas fa-moon'></i>")
    }
    themeSelector.click(function () {
        if (site_layout == "dark") {
            localStorage.removeItem('site_layout');
        } else {
            localStorage.setItem('site_layout', "dark");
        }
        window.location.href = (window.location.href).replace('#', '');
    });
    $('.layout-builder .layout-builder-body input[type="radio"][data-layout="' + $('body').attr('class') + '"]').prop('checked', true);

    $('.layout-builder .layout-builder-body input[type="radio"]').click(function () {
        var class_names = '';

        $('.layout-builder .layout-builder-body input[type="radio"]:checked').each(function () {
            class_names += ' ' + $(this).data('layout');
        });

        localStorage.setItem('site_layout', class_names);

        window.location.href = (window.location.href).replace('#', '');
    });

    $(document).on('click', '#btn-layout-builder', function () {

    });

    $(document).on('click', '#btn-layout-builder-reset', function () {
        localStorage.removeItem('site_layout');
        localStorage.removeItem('site_layout_dark');

        window.location.href = (window.location.href).replace('#', '');
    });

    $(window).on('load', function () {
        if ($('body').hasClass('horizontal-side-menu') && $(window).width() > 768) {
            if ($('body').hasClass('layout-container')) {
                $('.side-menu .side-menu-body').wrap('<div class="container"></div>');
            } else {
                $('.side-menu .side-menu-body').wrap('<div class="container-fluid"></div>');
            }
            setTimeout(function () {
                $('.side-menu .side-menu-body > ul').append('<li><a href="#"><span>سایر</span></a><ul></ul></li>');
            }, 100);
            $('.side-menu .side-menu-body > ul > li').each(function () {
                var index = $(this).index(),
                    $this = $(this);
                if (index > 7) {
                    setTimeout(function () {
                        $('.side-menu .side-menu-body > ul > li:last-child > ul').append($this.clone());
                        $this.addClass('d-none');
                    }, 100);
                }
            });
        }
    });

    $(document).on('click', '[data-attr="layout-builder-toggle"]', function () {
        $('.layout-builder').toggleClass('show');
        return false;
    });
    $(document).ajaxError(function (event, xhr, ajaxOptions, thrownError) {
        if (xhr.status == 403 || xhr.status == 401) {
            toastr.error("شما دسترسی لازم برای ورود به این بخش را ندارید.", "خطا");
        }
        else {
            toastr.error(xhr.responseText.split(':')[0], "Error");
        }
    });
    $('.select2').select2({
        placeholder: 'انتخاب کنید'
    });

})(jQuery);

var navActive = $('#nav_active').val();
var navItemActive = $('#nav_item_active').val();
if (navActive != null && navActive != "") {
    $('#nav_' + navActive + '').addClass("active");
    if ($('#subnav_' + navActive + '').length) {
        $('#subnav_' + navActive + '').css("display", "block");
        $('#subnav_' + navActive + '').css("overflow", "");
    }
}
if (navItemActive != null && navItemActive != "") {
    $('#nav_item_' + navItemActive + '').addClass("active");
}
function accessDenied() {
    swal("Error!", "شما دسترسی لازم برای ورود به این بخش را ندارید", "error");
}

$.extend(true, $.fn.dataTable.defaults, {
    serverSide: true,
    processing: true,
    responsive: true,
    language: {
        "sEmptyTable": "هیچ داده ای در جدول وجود ندارد",
        "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
        "sInfoEmpty": "نمایش 0 تا 0 از 0 رکورد",
        "sInfoFiltered": "(فیلتر شده از _MAX_ رکورد)",
        "sInfoPostFix": "",
        "sInfoThousands": ",",
        "sLengthMenu": "نمایش _MENU_ رکورد",
        "sLoadingRecords": "در حال بارگزاری...",
        "sProcessing": "در حال پردازش...",
        "sSearch": "جستجو:",
        "sZeroRecords": "رکوردی با این مشخصات پیدا نشد",
        "oPaginate": {
            "sFirst": "ابتدا",
            "sLast": "انتها",
            "sNext": "بعدی",
            "sPrevious": "قبلی"
        },
        "oAria": {
            "sSortAscending": ": فعال سازی نمایش به صورت صعودی",
            "sSortDescending": ": فعال سازی نمایش به صورت نزولی"
        }
    },
    "initComplete": function (settings, json) {
        $("[name='datatable_length']").css("margin-left", "0.5rem")
    }
});
toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};


function openModal(link) {
    $.get(link, function (result) {
        $("#myModal").modal();
        //if (title != null) {
        //    $("#myModalLabel").html(title);
        //}
        $("#myModalBody").html(result);
        var title = $("#title").val();
        if (title != null && title != undefined) {
            $("#myModalLabel").html(title);
        } else {
            $("#myModalLabel").html("");    
        }

        $(".remove-image").click(function () {
            var input = $(this).data("input");
            var container = $(this).data("container");
            if (input != undefined) {
                $("#" + input).val("");
            }
            if (container != undefined) {
                $("#" + container).hide();
                var image = $("#" + container).find("img");
                image.attr("src", "");
            }
        });
    });
}
var tags = document.getElementById('tags');
if (tags != null) {
    var tagInput = new Tagify(tags,
        {
            whitelist: [],
            originalInputValueFormat: valuesArr => valuesArr.map(item => item.value).join(',')
        });
    tagInput.on('input', onTagInput);
}

var tagRemove = document.querySelector('.tags--removeAllBtn');
if (tagRemove != null) {
    tagRemove.addEventListener('click', tagInput.removeAllTags.bind(tagInput));
}
function onTagInput(e) {
    var value = e.detail.value;
    tagInput.settings.whitelist.length = 0;
    tagInput.loading(true).dropdown.hide.call(tagInput);
    var newWhitelist = [];
    $.get("/apanel/Home/GetTags?searchStr=" + value,
        {
        },
        function (data) {
            newWhitelist = data;
            tagInput.settings.whitelist.push(...newWhitelist, ...tagInput.value);
            tagInput.loading(false).dropdown.show.call(tagInput, value);
        });
};
$(".remove-image").click(function () {
    var input = $(this).data("input");
    var container = $(this).data("container");
    if (input != undefined) {
        $("#" + input).val("");
    }
    if (container != undefined) {
        $("#" + container).hide();
        var image = $("#" + container).find("img");
        image.attr("src", "");
    }
});
function toPrice(number) {
    var price = String(number).replace(/(.)(?=(\d{3})+$)/g, '$1,');
    return price;
}
function getTimeRemaining(endtime) {
    var total = Date.parse(endtime) - Date.parse(new Date());
    var seconds = Math.floor((total / 1000) % 60);
    var minutes = Math.floor((total / 1000 / 60) % 60);
    var hours = Math.floor((total / (1000 * 60 * 60)) % 24);
    var days = Math.floor(total / (1000 * 60 * 60 * 24));

    return {
        total,
        days,
        hours,
        minutes,
        seconds
    };
}

function initializeClock(id, endtime) {
    var clock = document.getElementById(id);
    var timeinterval = setInterval(() => {
        var t = getTimeRemaining(endtime);
        clock.innerHTML = t.hours + ':' + t.minutes + ':' + t.seconds;
        if (t.total <= 0) {
            clearInterval(timeinterval);
        }
    }, 1000);
}