$(document).ready(function () {

    $('select[id="typeSelectValue"]').change(function () {
        var str = "";
        $('select[id="typeSelectValue"] option:selected').each(function () {
            str += $(this).val();
        });
        if (str === "predefined list") {
            $('#predefinedListOptionInputDiv').show();
        }
        else {
            $('#predefinedListOptionInputDiv input').val('');
            $('#usersAddedInputOptionDiv table[id="addedNameTable"] tbody').empty();
            $('#usersAddedInputOptionDiv table[id="addedOptionsTable"] tbody').empty();
            $('#addNameBtn').removeAttr('disabled');
            $('#predefinedListOptionInputDiv').hide();
        }
    });


    $('#addNameBtn').click(function () {
        var nameInputValue = $('#addNameInput').val();
        $('#usersAddedInputOptionDiv table[id="addedNameTable"] tbody').append("<tr><td><i>" + nameInputValue +
            "</i><button type='button' class='btn btn-sm btn-outline-danger nameRemoveBtn' style='float:right;'>Remove</button></td></tr>");
        $('#addNameInput').val('');
        $('#addNameBtn').attr('disabled', 'disabled');
    });
    $('#usersAddedInputOptionDiv tbody').on('click', 'button.nameRemoveBtn', function () {
        $(this).closest('tr').remove();
        $('#addNameBtn').removeAttr('disabled');
    });

    $('#addToListBtn').click(function () {
        var optionsInputValue = $('#addToListInput').val();
        $('#usersAddedInputOptionDiv table[id="addedOptionsTable"] tbody').append("<tr><td><i>" + optionsInputValue +
            "</i><button type='button' class='btn btn-sm btn-outline-danger optionsRemoveBtn' style='float:right;'>Remove</button></td></tr>");
        $('#addToListInput').val('');
    });
    $('#usersAddedInputOptionDiv tbody').on('click', 'button.optionsRemoveBtn', function () {
        $(this).closest('tr').remove();
    });







    // To POST the addNewProductAttrForm.
    $('#addNewProductAttrForm').submit(function (e) {
        e.preventDefault();
        var formData = new FormData();

        var nameInputValue = $('#addNewProductAttrForm input[id="nameInputValue"]').val();
        formData.append('name', nameInputValue);
        var attrGroupSelectValue = $('#addNewProductAttrForm select[id="attrGroupSelectValue"]').val();
        formData.append('attributeGroupId', attrGroupSelectValue);
        var textareaValue = $('#addNewProductAttrForm textarea').val();
        formData.append('description', textareaValue);


        //$('#addNewSubcatForm table[id="addedAttrGroupsTableId"] tr').each(function () {
        //    formData.append('attributegroupid', $(this).data('attributegroupid'));
        //});

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