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

    connection.on("NewTask", chore => {
        $("#task-table").append(`<tr id="chore-${chore.Id}">
                                     <td>${chore.title} <td/>
                                     <td> <button class="btn btn-danger" data-id="${chore.Id}">I'm doing this one!</button><td/>
                                <tr/> `)
    });

    $('#tasks').on('click', '.btn-info', function () {
        const id = $(this).data('id');
        connection.invoke("UpdateStatus", { id, status: 1 })
    });

   
    
});