"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/bolahub").build();


connection.on("ReceberX", x => {
    x *= 2;
    let bola = document.getElementById("box");
    console.log(bola)
    console.log(x)
    bola.style.marginLeft = x + "px";
});

connection.on("ReceberY", y => {
    y *= 2;
    let bola = document.getElementById("box");
    console.log(bola)
    console.log(y)
    bola.style.marginTop = y + "px";
});

connection.start().catch(erro => {
    console.log(erro);
});