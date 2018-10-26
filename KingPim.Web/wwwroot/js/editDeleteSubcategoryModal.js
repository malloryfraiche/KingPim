$(document).ready(function () {

    // To control the data that is shown in the edit modal.
    $('#editModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-body input').val(nameRecipient);


        $('#editCatForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            formData.append('id', idRecipient);
            $('#editCatForm input').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            $.ajax({
                url: '/Category/AddCategory',
                type: 'POST',
                data: formData,
                dataType: 'json',
                processData: false,
                contentType: false,
                success: function (data) {
                    console.log(data);
                    window.location.href = data;
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
        console.log(idRecipient);
    });

    //// To control the data that is shown in the delete modal.
    //$('#deleteModal').on('show.bs.modal', function (event) {
    //    var button = $(event.relatedTarget);
    //    var idRecipient = button.data('id');
    //    var nameRecipient = button.data('name');
    //    var modal = $(this);
    //    modal.find('.modal-content h5').text('Are you sure you want to delete category ' + nameRecipient + '?');
    //    modal.find('.modal-body input').val(idRecipient);
    //    console.log(idRecipient);
    //});
});