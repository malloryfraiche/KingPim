$(document).ready(function () {
    // To control the data that is shown in the edit modal.
    $('#editAttrGroupModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var textareaRecipient = button.data('textarea');
        var modal = $(this);
        modal.find('.modal-body input').val(nameRecipient);
        modal.find('.modal-body textarea').val(textareaRecipient);
        // To POST the editAttrGroupForm from the modal.
        $('#editAttrGroupForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            formData.append('id', idRecipient);
            $('#editAttrGroupForm input').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            var testTextarea = $('#editAttrGroupForm textarea').val();
            formData.append('description', testTextarea);
            $.ajax({
                url: '/AttributeGroup/EditAttributeGroup',
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
    });
    // To control the data that is shown in the delete modal.
    $('#deleteAttrGroupModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete attribute group ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });
});