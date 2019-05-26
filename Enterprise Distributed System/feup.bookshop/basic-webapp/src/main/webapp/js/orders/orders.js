var url = document.URL;
$(document).ready(function () {
    var url_parsed = new URL(url);
    var id = url_parsed.searchParams.get("id");
    if(id){
        $.ajax({
            type: "GET",
            url: "../restServices/orders/" + id
          }).done(function (msg) {
            if (msg.success) {
              msg.information.forEach(order => {
                $("#response").append(formOrderCard(order.id, order.email, order.bookID, order.state, order.quantity));
              });
            }
            else{
              $("#response").append(formErrorMessage(msg.information ));
            }
          });
    }
    else{
        $("#response").append(formErrorMessage("400 Bad Arguments")); 
    }
});


function formOrderCard(id, email, bookID, state, quantity) {  
    return "<div class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + "Order number " + id + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + email + "</h6> <p class='card-text'> Book ordered was " + bookID + ". Current state is " + state +  ". Order quantity is " + quantity + ". </p> </div> </div>"
}


function formErrorMessage(information){
    return "<div>"+ information +"</div>"
}