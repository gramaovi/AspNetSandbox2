"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("Connection established.");
}).catch(function (err) {
    return console.error(err.toString());
});
connection.on("BookCreated", function (book) {
    console.log('Book Created: $(JSON.stringify(book)}');
});