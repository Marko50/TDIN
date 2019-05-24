var url = document.URL;
$(document).ready(function () {
    var url_parsed = new URL(url);
    var id = url_parsed.searchParams.get("id");
    if (id) {
        $("#catalogue").css("display", "none");
        $("#checkout").css("display", "block");
        $.ajax({
            type: "GET",
            url: "../restServices/testServices/books/" + id
          }).done(function (msg) {
            if (msg.success) {
              msg.information.forEach(book => {
                $("#checkout").append(formBookCardCheckout(book.Id, book.Title, book.Author, book.Price, book.Stock));
              });
            }
            else{
              $("#checkout").append(formErrorMessage(msg.information ));
            }
          });  
    }
    else{
        $("#checkout").css("display", "none");
        $("#catalogue").css("display", "block");
        $.ajax({
            type: "GET",
            url: "../restServices/testServices/books"
          }).done(function (msg) {
            if (msg.success) {
              msg.information.forEach(book => {
                $("#response").append(formBookCard(book.Id, book.Title, book.Author, book.Price, book.Stock));
              });
            }
            else{
              $("#response").append(formErrorMessage(msg.information ));
            }
          });  
    }  
});

function formBookCard(id, title, author, price, stock) {  
    return "<div class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + title + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + author + "</h6> <p class='card-text'> Very fancy book. Costs only " + price + "€. Current stock is " + stock +  "</p> <a href='" + document.URL +"?id="+ id + " 'class='btn btn-primary'>Buy now</a> </div> </div>"
}

function formBookCardCheckout(id, title, author, price, stock) {  
    return "<div class='card' style='width: 18rem;'> <div class='card-body'> <h5 class='card-title'>" + title + "</h5> <h6 class='card-subtitle mb-2 text-muted'> by " + author + "</h6> <p class='card-text'> Very fancy book. Costs only " + price + "€. Current stock is " + stock +  "</p>  </div> </div>"
}

function formErrorMessage(information){
    return "<div>"+ information +"</div>"
}

