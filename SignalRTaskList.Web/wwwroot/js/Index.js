//copied, didn't edit much yet.

$(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/taskhub").build();

    connection.start().then(() => {
        connection.invoke("NewUser");
    });

    $("#add").on('click', () => {
        const title = $("#title").val();
        connection.invoke("SendTask", { title });
    });

    connection.on("NewTask", addTask => {
        $("#task-table").append(`<h4>${chatMessage.name} says: ${chatMessage.message}</h4>`)
    });
    
});