$(document).ready(function () {

    // To control the data that is shown in the edit modal.
    $('#editProductAttrModal').on('show.bs.modal', function (event) {

        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var typeRecipient = button.data('type');
        var textareaRecipient = button.data('textarea');
        var selectRecipient = button.data('attrgroupselect');
        var selectValRecipient = button.data('attrgroupvalue');
        var modal = $(this);

        console.log("Product Attr Id: " + idRecipient);
        console.log(typeRecipient);
        console.log("attrgroup Name: " + selectRecipient);
        console.log("attrgroup Id: " + selectValRecipient);
        console.log(textareaRecipient);

        var typeRecipientName;
        if (typeRecipient === 'int') {
            typeRecipientName = 'Number';
        }
        if (typeRecipient === 'string') {
            typeRecipientName = 'Text';
        }
        if (typeRecipient === 'bool') {
            typeRecipientName = 'Yes/No or True/False';
        }
        if (typeRecipient === 'byte') {
            typeRecipientName = 'Bytes';
        }
        console.log(typeRecipientName);

        modal.find('.modal-body select').html('');  // Clear out the dropdown if anything is there from before.
        modal.find('.modal-body input').val(nameRecipient);
        modal.find('.modal-body select[name="Type"]').append('"<option value="' + typeRecipient + '"selected>' + typeRecipientName + '</option>"');
        modal.find('.modal-body textarea').val(textareaRecipient);
        modal.find('.modal-body select[name="AttributeGroupId"]').append('"<option value="' + selectValRecipient + '"selected>' + selectRecipient + '</option>"');


        // TODO: To fill the Type dropdown with data.
        var selectedOptionValue = $('.modal-body select option[selected]').val();
        console.log("---" + selectedOptionValue);

        if (selectedOptionValue === 'int') {
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
        }
        if (selectedOptionValue === 'string') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
        }
        if (selectedOptionValue === 'bool') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
        }
        if (selectedOptionValue === 'byte') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
        }
        
        // To fill the Attribute group dropdown with data.
        $.ajax({
            url: '/AttributeGroup/GetAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    console.log(response);
                    var length = response.length;
                    for (var i = 0; i < length; i++) {
                        var id = response[i]['id'];
                        var name = response[i]['name'];
                        if (name !== selectRecipient) {     // So we won't have doubles in the dropdown select list.
                            $('#editProductAttrForm select[name="AttributeGroupId"]').append("<option value='" + id + "'>" + name + "</option>");
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

        // To POST the editProductAttrForm from the modal.
        $('#editProductAttrForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            
            formData.append('id', idRecipient);
            var nameInputValue = $('#editProductAttrForm input').val();
            formData.append('name', nameInputValue);
            var typeInputValue = $('#editProductAttrForm select[name="Type"]').val();
            formData.append('type', typeInputValue);
            var textareaValue = $('#editProductAttrForm textarea').val();
            formData.append('description', textareaValue);
            var attrGroupValue = $('#editProductAttrForm select[name="AttributeGroupId"]').val();
            formData.append('attributegroupid', attrGroupValue);
            
            $.ajax({
                url: '/ProductAttribute/EditProductAttribute',
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
    $('#deleteProductAttrModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-content h5').text('Are you sure you want to delete product attribute ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });

});