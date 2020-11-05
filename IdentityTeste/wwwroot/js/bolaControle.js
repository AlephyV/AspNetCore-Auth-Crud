var connection = new signalR.HubConnectionBuilder().withUrl("/bolahub").build();

connection.start().catch(erro => {
    console.log(erro);
});

document.getElementById("X").addEventListener('change', event => {
    let x = document.getElementById("X").value;
    console.log(x)
    connection.invoke("SendX", x).catch(erro => {
        return console.error(erro.toString());
    });
    event.preventDefault();
});

document.getElementById("Y").addEventListener('change', event => {
    let y = document.getElementById("Y").value;
    console.log(y)
    connection.invoke("SendY", y).catch(erro => {
        return console.error(erro.toString());
    });
    event.preventDefault();
});