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


  
  
     
          // Document.ready -> link up remove event handler
          $(".RemoveLink").click(function () {
              // Get the id from the link
              var recordToDelete = $(this).attr("data-id");
              if (recordToDelete != '') {
                  // Perform the ajax post
                  $.post("/ShoppingCart/RemoveFromCart", {"id": recordToDelete },
                      function (data) {
                          // Successful requests get here
                          // Update the page elements
                          if (data.ItemCount == 0) {
                              $('#row-' + data.DeleteId).fadeOut('slow');
                          } else {
                              $('#item-count-' + data.DeleteId).text(data.ItemCount);
                          }
                          $('#cart-total').text(data.CartTotal);
                          $('#update-message').text(data.Message);
                          $('#cart-status').text('Cart (' + data.CartCount + ')');
                      });
              }
          });
      


});



