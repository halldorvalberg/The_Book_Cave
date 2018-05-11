// Write your JavaScript code.

$(document).ready(() => {

  console.log("js ready");
  $("#slideshow > div:gt(0)").hide();

  setInterval(function() { 
    $('#slideshow > div:first')
      .fadeOut(1000)
      .next()
      .fadeIn(1000)
      .end()
      .appendTo('#slideshow');
  },  12000);
      

 });

 $("#p2-btn").click(function() {

  $.get("Home/ShoppingCart",(data, status) => {
    $("#p2-btn").append("btn-block");
  })
  .fail((err) => {
    alert("Karfan er tóm");
  });

  $(this).addClass("disabled").prop("disabled", true);

});



