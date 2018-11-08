$(document).ready(function () {

    // To control the data that is shown in the edit modal.
    $('#editProductModal').on('show.bs.modal', function (event) {

        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var priceRecipient = button.data('price');
        var textareaRecipient = button.data('textarea');
        //var selectRecipient = button.data('select');
        var modal = $(this);

        console.log("Product Id: " + idRecipient);

        modal.find('#inputId').val(idRecipient);
        modal.find('#inputName').val(nameRecipient);
        modal.find('#inputPrice').val(priceRecipient);
        modal.find('.modal-body textarea').val(textareaRecipient);
        //modal.find('select').val(selectRecipient);

    });

});