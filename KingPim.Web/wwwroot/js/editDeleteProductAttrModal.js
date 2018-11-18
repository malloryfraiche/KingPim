$(document).ready(function () {
    
    // Getting the predefined list options from the db.
    var predefinedListOptionsJson = [];
    $.ajax({
        url: '/ProductAttribute/GetPredefinedListOptionsToJson',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            predefinedListOptionsJson = response;
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });



    
    $('#addPredefinedListNameBtn').click(function () {
        var addPredefinedListNameInput = $('#addPredefinedListNameInput').val();
        $('#predefinedListNameTableBody').append("<tr><td name='PredefinedListName'><small><i>" + addPredefinedListNameInput +
            "</i></small><button class='btn btn-sm btn-outline-danger modalPredefinedListNameRemoveBtn' type='button' style='float:right;'>Remove</button></td></tr>");
        $('#addPredefinedListNameInput').val('');
        $('#addPredefinedListNameBtn').attr('disabled', 'disabled');
    });
    $('#predefinedListNameTableBody').on('click', 'button.modalPredefinedListNameRemoveBtn', function () {
        $(this).closest('tr').remove();
        $('#addPredefinedListNameBtn').removeAttr('disabled');
    });

    $('#addToPredefinedListOptionsBtn').click(function () {
        var addToPredefinedListOptionsInput = $('#addToPredefinedListOptionsInput').val();
        $('#predefinedListOptionNamesTableBody').append("<tr><td name='PredefinedListOptionNames'><small><i>" + addToPredefinedListOptionsInput +
            "</i></small><button class='btn btn-sm btn-outline-danger modalPredefinedListOptionsRemoveBtn' type='button' style='float:right;'>Remove</button></td></tr>");
        $('#addToPredefinedListOptionsInput').val('');
    });
    $('#predefinedListOptionNamesTableBody').on('click', 'button.modalPredefinedListOptionsRemoveBtn', function () {
        $(this).closest('tr').remove();
    });


    // To control the data that is shown in the edit modal.
    $('#editProductAttrModal').on('show.bs.modal', function (event) {
        $('#editModalPredefinedListDiv').hide();
        //$('#predefinedListNameTableBody').empty();

        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var typeRecipient = button.data('type');
        var textareaRecipient = button.data('textarea');
        var selectRecipient = button.data('attrgroupselect');
        var selectValRecipient = button.data('attrgroupvalue');

        var predefinedListName = button.data('predefinedlistname');
        var predefinedListId = button.data('predefinedlistid');
        
        var modal = $(this);

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
        if (typeRecipient === 'predefined list') {
            typeRecipientName = 'Predefined List';
        }

        modal.find('.modal-body select').html('');  // Clear out the dropdown if anything is there from before.
        modal.find('.modal-body input[id="nameInputField"]').val(nameRecipient);
        modal.find('.modal-body textarea').val(textareaRecipient);
        modal.find('.modal-body select[name="AttributeGroupId"]').append('"<option value="' + selectValRecipient + '"selected>' + selectRecipient + '</option>"');
        modal.find('.modal-body select[name="Type"]').append('"<option value="' + typeRecipient + '"selected>' + typeRecipientName + '</option>"');

        
        var selectedOptionValue = $('.modal-body select[name="Type"] option[selected]').val();
        if (selectedOptionValue === 'int') {
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
            //predefinedListValue
            $('.modal-body select[name="Type"]').append('"<option value="predefined list">Predefined List</option>"');
        }
        if (selectedOptionValue === 'string') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
            //predefinedListValue
            $('.modal-body select[name="Type"]').append('"<option value="predefined list">Predefined List</option>"');
        }
        if (selectedOptionValue === 'bool') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
            //predefinedListValue
            $('.modal-body select[name="Type"]').append('"<option value="predefined list">Predefined List</option>"');
        }
        if (selectedOptionValue === 'byte') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
            //predefinedListValue
            $('.modal-body select[name="Type"]').append('"<option value="predefined list">Predefined List</option>"');
        }
        if (selectedOptionValue === 'predefined list') {
            //intValue
            $('.modal-body select[name="Type"]').append('"<option value="int">Number</option>"');
            //stringValue
            $('.modal-body select[name="Type"]').append('"<option value="string">Text</option>"');
            //boolValue
            $('.modal-body select[name="Type"]').append('"<option value="bool">Yes/No or True/False</option>"');
            //byteValue
            $('.modal-body select[name="Type"]').append('"<option value="byte">Bytes</option>"');
            $('#editModalPredefinedListDiv').show();
            $('#predefinedListNameTableBody').empty();
            $('#predefinedListOptionNamesTableBody').empty();
            $('#addPredefinedListNameBtn').removeAttr('disabled');
            $('#predefinedListNameTableBody').append("<tr><td name='PredefinedListName'><small><i>" + predefinedListName +
                "</i></small><button class='btn btn-sm btn-outline-danger modalPredefinedListNameRemoveBtn' type='button' style='float:right;'>Remove</button></td></tr>");
            $.each(predefinedListOptionsJson, function (i, listOption) {
                if (listOption.predefinedListId === predefinedListId) {
                    //console.log(listOption);
                    $('#predefinedListOptionNamesTableBody').append("<tr><td name='PredefinedListOptionNames'><small><i>" + listOption.name +
                        "</i></small><button class='btn btn-sm btn-outline-danger modalPredefinedListOptionsRemoveBtn' type='button' style='float:right;'>Remove</button></td></tr>");
                }
                else {
                    console.log("no predefined list connected!");
                }
            });
        }


        $('.modal-body select[name="Type"]').change(function () {
            $('#predefinedListNameTableBody').empty();
            $('#predefinedListOptionNamesTableBody').empty();
            $('#addPredefinedListNameBtn').removeAttr('disabled');

            var str = "";
            $('.modal-body select[name="Type"]  option:selected').each(function () {
                str += $(this).val();
            });
            if (str === "predefined list") {
                $('#editModalPredefinedListDiv').show();
                //$('#predefinedListNameTableBody').empty();
                //$('#predefinedListOptionNamesTableBody').empty();
                if (predefinedListName) {
                    $('#predefinedListNameTableBody').append("<tr><td name='PredefinedListName'><small><i>" + predefinedListName +
                        "</i></small><button class='btn btn-sm btn-outline-danger modalPredefinedListNameRemoveBtn' type='button' style='float:right;'>Remove</button></td></tr>");
                }
                $.each(predefinedListOptionsJson, function (i, listOption) {
                    if (listOption.predefinedListId === predefinedListId) {
                        $('#predefinedListOptionNamesTableBody').append("<tr><td name='PredefinedListOptionNames'><small><i>" + listOption.name +
                            "</i></small><button class='btn btn-sm btn-outline-danger modalPredefinedListOptionsRemoveBtn' type='button' style='float:right;'>Remove</button></td></tr>");
                    }
                    else {
                        console.log("no predefined list connected!");
                    }
                });
            }
            else {
                //$('#predefinedListOptionInputDiv input').val('');
                //$('#usersAddedInputOptionDiv table[id="addedNameTable"] tbody').empty();
                //$('#usersAddedInputOptionDiv table[id="addedOptionsTable"] tbody').empty();
                //$('#addNameBtn').removeAttr('disabled');
                $('#editModalPredefinedListDiv').hide();
            }
        });

        
        // To fill the Attribute group dropdown with data.
        $.ajax({
            url: '/AttributeGroup/GetAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    //console.log(response);
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

            var addedPredefinedListName = $('#predefinedListNameTableBody i').text();
            formData.append('predefinedListName', addedPredefinedListName);

            $('#predefinedListOptionNamesTableBody tr i').each(function () {
                formData.append('predefinedListOptionNames', $(this).text());
            });

            $.ajax({
                url: '/ProductAttribute/AddProductAttribute',
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