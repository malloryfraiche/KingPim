$(document).ready(function () {
    // To control the data that is shown in the edit modal.
    $('#editProductModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var priceRecipient = button.data('price');
        var textareaRecipient = button.data('textarea');
        var modal = $(this);
        modal.find('#inputId').val(idRecipient);
        modal.find('#inputName').val(nameRecipient);
        modal.find('#inputPrice').val(priceRecipient);
        modal.find('.modal-body textarea').val(textareaRecipient);
    });
    // To control the data that is shown in the delete modal.
    $('#deleteProductModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
    });
});