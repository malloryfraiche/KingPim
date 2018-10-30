$(document).ready(function () {

    // To control the data that is shown in the edit modal.
    $('#editAttrGroupModal').on('show.bs.modal', function (event) {

        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var selectRecipient = button.data('select');
        var selectValRecipient = button.data('selectval');
        var textareaRecipient = button.data('textarea');
        var modal = $(this);

        console.log("AttrGroup Id: " + idRecipient);
        console.log(selectRecipient);
        console.log("Subcat Id: " + selectValRecipient);
        console.log(textareaRecipient);

        modal.find('.modal-body select').html('');  // Clear out the dropdown if anything is there from before.
        modal.find('.modal-body input').val(nameRecipient);
        modal.find('.modal-body select').append('"<option value="' + selectValRecipient + '"selected>' + selectRecipient + '</option>"');
        modal.find('.modal-body textarea').val(textareaRecipient);

        // To fill the Subcategory dropdown with data.
        $.ajax({
            url: '/Subcategory/GetSubcategoriesToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    console.log(response);
                    var length = response.length;
                    for (var i = 0; i < length; i++) {
                        var id = response[i]['id'];
                        var name = response[i]['name'];

                        console.log("NAME: " + name);
                        console.log(selectRecipient);

                        if (name !== selectRecipient) {     // So we won't have doubles in the dropdown select list.
                            $('#editAttrGroupForm select').append("<option value='" + id + "'>" + name + "</option>");
                        }
                    }
                }
                else {
                    console.log('In the success function but data is NULL');
                }
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });

        // To POST the editAttrGroupForm from the modal.
        $('#editAttrGroupForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();

            formData.append('id', idRecipient);
            $('#editAttrGroupForm input').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            $('#editAttrGroupForm select').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            //$('#editAttrGroupForm textarea').each(function () {
            //    formData.append($(this).attr('name'), $(this).val());
            //});
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
    $('#deleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete category ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });
});