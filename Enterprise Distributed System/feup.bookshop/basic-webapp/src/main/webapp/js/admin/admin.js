$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "../restServices/orders",
        success: function (response) {
            if(response.success){
                response.information.forEach(order => {
                   $("#response").append(formOrderCard(order.id, order.email, order.bookID, order.state));  
                });
                $("#button_" + order.id).click(function (e) { 
                    e.preventDefault();
                    
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

function formOrderCard(id, email, bookID, state) {  
    return "<div " + "id='card_" + id +"' class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + "Order number " + id + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + email + "</h6> <p class='card-text'> Book ordered was " + bookID + ". Current state is " + state +  "</p>" + "<button " + "id='button_" + id +"' class='btn btn-primary'> Mark as updated </button>" + "</div> </div>"
}