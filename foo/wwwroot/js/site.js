// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    //$('.tikla').click(function () {
    //    //console.log($('.tikla').text()[0]);
    //    var element = "<div class='form-group kaydir'> </div >";
    //    var element = $('.tikla').after(element);
    //    var element2 = "<label for='comment'>Comment:</label>"
    //    var element3 = "<textarea class='form-control rows='5' id='comment'></textarea>"

    //    element.append(element2, element3);
    //})
    $(".tikla").click(function () {
        let id = $(this).attr('id');
        console.log(id);
        $('.'+id).slideToggle();
    });
  
});

