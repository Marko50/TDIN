$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "../restServices/orders",
        success: function (response) {
            if(response.success){
                response.information.forEach(order => {
                   $("#response").append(formOrderCard(order.id, order.email, order.bookID, order.state, order.quantity));  
                   var today = new Date();
                   var dd = String(today.getDate()).padStart(2, '0');
                   var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
                   var yyyy = today.getFullYear();
                   $("#button_" + order.id).click(function (e) { 
                       $.ajax({
                           type: "PUT",
                           url: "../restServices/orders",
                           data: JSON.stringify({"order" : {"id" : order.id, "email" : order.email, "bookID" : order.bookID, "state" : mm + '/' + dd + '/' + yyyy, "quantity" : order.quantity}}),
                           contentType: "application/json; charset=utf-8"
                       }).done(function (msg) {
                            if(msg.success){
                                window.location.reload();
                            }
                            else{
                                window.location.replace(window.location.origin + "/error?message=" + msg.information);
                            }
                        });
                       e.preventDefault();
                   });
                });
            }
            else{
                $("#response").append(formErrorMessage(response.information));
            }
        }
    });
});

function formErrorMessage(information){
    return "<div>"+ information +"</div>"
}

function formOrderCard(id, email, bookID, state, quantity) {  
    return "<div " + "id='card_" + id +"' class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + "Order number " + id + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + email + "</h6> <p class='card-text'> Book ordered was " + bookID + ". Current state is " + state + ". Order quantity is " + quantity + ". </p>" + "<button " + "id='button_" + id +"' class='btn btn-primary'> Mark as accepted </button>" + "</div> </div>"
}