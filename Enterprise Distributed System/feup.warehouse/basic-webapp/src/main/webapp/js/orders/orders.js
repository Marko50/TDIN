$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "restServices/testServices/orders",
        success: function (response) {
            if(response.success){
                response.information.forEach(order => {
                   $("#response").append(formOrderCard(order.id, order.email, order.bookID, order.state, order.quantity)); 
                   $("#button_"+order.id).click(function (e) {
                        $.ajax({
                            type: "DELETE",
                            url: "restServices/testServices/orders",
                            data: JSON.stringify({"order": {"id" : order.id, "email" : order.email, "bookID": order.bookID, "state": order.state, "quantity": order.quantity }}),
                            contentType: "application/json; charset=utf-8",
                            success: function (response) {
                                console.log(response);
                               if(response.success){
                                    $("#card_"+order.id).remove();
                               }
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
    return "<div " + "id='card_" + id +"' class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + "Order number " + id + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + email + "</h6> <p class='card-text'> Book ordered was " + bookID + ". Current state is " + state +  ". Order quantity is " + quantity + ". </p>" + "<button " + "id='button_" + id +"' class='btn btn-primary'> Dispatch now </button>" + "</div> </div>"
}