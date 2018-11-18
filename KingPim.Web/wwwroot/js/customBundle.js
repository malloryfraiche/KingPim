$(document).ready(function () {
    attrGroupHelper.getTheAttributeGroupTableData();
    // To POST the addNewSubcatForm.
    $('#addNewSubcatForm').submit(function (e) {
        e.preventDefault();
        var formData = new FormData();
        var inputAreaData = $('#addNewSubcatForm input[name="Name"]').val();
        formData.append('name', inputAreaData);
        var selectData = $('#addNewSubcatForm select').val();
        formData.append('categoryid', selectData);
        $('#addNewSubcatForm table[id="addedAttrGroupsTableId"] tr').each(function () {
            formData.append('attributegroupid', $(this).data('attributegroupid'));
        });
        $.ajax({
            url: '/Subcategory/AddSubcategory',
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
        $('#usersAddedInputOptionDiv table[id="addedNameTable"] tbody').append("<tr><td name='PredefinedListName'><i>" + nameInputValue +
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
        var typeSelectValue = $('#addNewProductAttrForm select[id="typeSelectValue"]').val();
        formData.append('type', typeSelectValue);
        var addedPredefinedListNameValue = $('#usersAddedInputOptionDiv table[id="addedNameTable"] tbody i').text();
        formData.append('predefinedListName', addedPredefinedListNameValue);
        $('#usersAddedInputOptionDiv table[id="addedOptionsTable"] tbody tr i').each(function () {
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
var attrGroupHelper = {
    getTheAttributeGroupTableData: function () {
        // To fill the AttributeGroup table with data from the AttributeGroup DB.
        $.ajax({
            url: '/AttributeGroup/GetAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    $.each(response, function (r, attrGroup) {
                        var tr = [
                            "<tr data-attributegroupid='" + attrGroup.id +
                            "'data-attributegroupname=" + attrGroup.name +
                            "><td><small><i>" + attrGroup.name +
                            "</i></small><button class='btn btn-sm btn-outline-success addAttrGroupBtn' type='button' style='float:right;'>Add</button></td></tr>"
                        ];
                        $('#attrGroupTableBody').append(tr.join(''));
                    });
                    // To add the desired attribute group to the list.
                    $('button.addAttrGroupBtn').click(function () {
                        var id = $(this).closest('tr').data('attributegroupid');
                        var name = $(this).closest('tr').data('attributegroupname');
                        var parentTr = $(this).closest('tr');
                        parentTr.hide();
                        $('#addedAttrGroupsTableId').show();
                        var addedTr = [
                            "<tr name='AttributeGroupId' data-attributegroupid='" + id +
                            "'data-attributegroupname=" + name +
                            "><td><small><i>" + name +
                            "</i></small><button class='btn btn-sm btn-outline-danger removeAttrGroupBtn' type='button' title='Take away attribute group.' style='float:right;'>Remove</button></td></tr>"
                        ];
                        $('#addedAttrGroupsTableId tbody').append(addedTr.join(''));
                    });
                    // To remove the added attribute off the list.
                    $('#addedAttrGroupsTableId tbody').on('click', 'button.removeAttrGroupBtn', function () {
                        var addedId = $(this).closest('tr').data('attributegroupid');
                        $($(this).closest('tr')).hide();
                        $('#attrGroupTableBody tr').each(function () {
                            var originalId = $(this).data('attributegroupid');
                            if (addedId === originalId) {
                                $('#attrGroupTableBody tr').show();
                            }
                        });
                    });
                }
                else {
                    console.log('In the success function but there is no data to present');
                    $('#attrGroupTableBody').append("<tr><td><small><i>No attribute groups added yet. Please create an attribute group.</i></small></td></tr>");
                }
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });
    }
};
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
                url: '/Category/EditCategory',
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
$(document).ready(function () {
    var attrGroups = [];
    function fillAttrGroupDropdown(idRecipient) {
        // To fill the attrGroup dropdown with data from the AttributeGroup DB.
        $.ajax({
            url: '/AttributeGroup/GetAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                attrGroups = response;
                if (response !== null) {
                    $.each(attrGroups, function (i, attrGroup) {
                        var added = false;
                        $.each(subcatAttrGroups, function (j, subcatAttrGroup) {
                            if (subcatAttrGroup.subcategoryId === idRecipient) {
                                if (attrGroup.id === subcatAttrGroup.attributeGroupId) {
                                    added = true;
                                }
                            }
                        });
                        if (!added) {
                            var tr = [
                                "<tr data-subcategoryattributegroupattributegroupid='" + attrGroup.id +
                                "'data-subcategoryattributegroupsubcategoryid='" + idRecipient +
                                "'data-subcategoryattributegroupattributegroupname='" + attrGroup.name +
                                "'><td><small><i>" + attrGroup.name +
                                "</i></small><button type='button' class='btn btn-sm btn-outline-success editModalAddAttrGroupBtn' style='float:right;'>Add</button></td></tr>"
                            ];
                            $('#allAttrGroupsTableBody').append(tr.join(''));
                        }
                    });
                }
                else {
                    console.log('In the success function but there is no data to present');
                }
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });
    }
    var subcatAttrGroups = [];
    function fillSubcatAttrGroupTable(idRecipient) {
        // To fill the subcategories attribute groups table with data from the SubcategoryAttributeGroup DB.
        $.ajax({
            url: '/Subcategory/GetSubcategoryAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                subcatAttrGroups = response;
                if (response !== null) {
                    $.each(response, function (r, subcatAttrGroup) {
                        if (idRecipient === subcatAttrGroup.subcategoryId) {
                            // Add the connected rows to the subcatAttrGroup table.
                            var tr = [
                                "<tr data-subcategoryattributegroupattributegroupid='" + subcatAttrGroup.attributeGroupId +
                                "'data-subcategoryattributegroupsubcategoryid='" + subcatAttrGroup.subcategoryId +
                                "'data-subcategoryattributegroupattributegroupname='" + subcatAttrGroup.attributeGroup.name +
                                "'><td><small><i>" + subcatAttrGroup.attributeGroup.name +
                                "</i></small><button type='button' class='close editModalRemoveAttrGroupBtn' style='float:right;'><span aria-hidden='true'>&times;</span></button></td></tr>"
                            ];
                            $('#subcategoriesAttrGroupsTableBody').append(tr.join(''));
                        }
                    });
                }
                else {
                    console.log('In the success function but there is no data to present');
                }
                // To fill the dropdown list after the table loaded..
                fillAttrGroupDropdown(idRecipient);
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });
    }
    // To add the desired AttrGroup to the list to left.
    $('#allAttrGroupsTableBody').on('click', 'button.editModalAddAttrGroupBtn', function () {
        var id = $(this).closest('tr').data('subcategoryattributegroupattributegroupid');
        var name = $(this).closest('tr').data('subcategoryattributegroupattributegroupname');
        var subCatId = $(this).closest('tr').data('subcategoryattributegroupsubcategoryid');
        $($(this).closest('tr')).remove();
        var addedTr = [
            "<tr data-subcategoryattributegroupattributegroupid='" + id +
            "'data-subcategoryattributegroupsubcategoryid='" + subCatId +
            "'data-subcategoryattributegroupattributegroupname='" + name +
            "'><td><small><i>" + name +
            "</i></small><button type='button' class='close editModalRemoveAttrGroupBtn' style='float:right;'><span aria-hidden='true'>&times;</span></button></td></tr>"
        ];
        $('#subcategoriesAttrGroupsTableBody').append(addedTr.join(''));
    });
    // To remove the added AttrGroup off of the list.
    $('#subcategoriesAttrGroupsTableBody').on('click', 'button.editModalRemoveAttrGroupBtn', function () {
        var addedOrAlreadyThereId = $(this).closest('tr').data('subcategoryattributegroupattributegroupid');
        var addedOrAlreadyThereName = $(this).closest('tr').data('subcategoryattributegroupattributegroupname');
        var subCatId = $(this).closest('tr').data('subcategoryattributegroupsubcategoryid');
        $($(this).closest('tr')).remove();
        $('#allAttrGroupsTableBody').append(
            "<tr data-subcategoryattributegroupattributegroupid='" + addedOrAlreadyThereId +
            "'data-subcategoryattributegroupsubcategoryid='" + subCatId +
            "'data-subcategoryattributegroupattributegroupname='" + addedOrAlreadyThereName +
            "'><td><small><i>" + addedOrAlreadyThereName +
            "</i></small><button type='button' class='btn btn-sm btn-outline-success editModalAddAttrGroupBtn' style='float:right;'>Add</button></td></tr>");
    });
    // To control the data that is shown in the edit modal.
    $('#editSubcategoryModal').on('show.bs.modal', function (event) {
        $('#subcategoriesAttrGroupsTableBody').empty();
        $('#allAttrGroupsTableBody').empty();
        var button = $(event.relatedTarget);
        var idRecipient = button.data('id');
        var nameRecipient = button.data('name');
        var modal = $(this);
        modal.find('.modal-body input').val(nameRecipient);
        $('#subcategoriesAttrGroupsTableBody').empty();
        // To fill the category dropdown with data from the Category DB.
        $.ajax({
            url: '/Category/GetCategoriesToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    var length = response.length;
                    $('#editSubcatForm select.categorySelect').empty();
                    $('#editSubcatForm select.categorySelect').append("<option value='' selected>Please select...</option>");
                    for (var i = 0; i < length; i++) {
                        var id = response[i]['id'];
                        var name = response[i]['name'];
                        $('#editSubcatForm select.categorySelect').append("<option value='" + id + "'>" + name + "</option>");
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
        fillSubcatAttrGroupTable(idRecipient);
        // To POST the editSubcatForm from the modal.
        $('#editSubcatForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            formData.append('id', idRecipient);
            var inputAreaData = $('#editSubcatForm input').val();
            formData.append('name', inputAreaData);
            var catSelectData = $('#editSubcatForm select.categorySelect').val();
            formData.append('categoryid', catSelectData);
            $('#editSubcatForm tbody[id="subcategoriesAttrGroupsTableBody"] tr').each(function () {
                formData.append('attributegroupid', $(this).data('subcategoryattributegroupattributegroupid'));
            });
            $.ajax({
                url: '/Subcategory/AddSubcategory',
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
        modal.find('.modal-content h5').text('Are you sure you want to delete ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });
});
$(document).ready(function () {
    // Hide and show the view components.
    $('#addNewBtn').on('click', function () {
        $('#viewComponents').show();
    });
    $('#cancelBtn').on('click', function () {
        $('#addNewCatForm').find('input').val('');
        $('#addNewSubcatForm').find('input').val('');
        $('#addNewSubcatForm').find('select').val('');
        $('#addNewAttrGroupForm').find('input').val('');
        $('#addNewAttrGroupForm').find('select').val('');
        $('#addNewAttrGroupForm').find('textarea').val('');
        $('#addNewProductAttrForm').find('input').val('');
        $('#addNewProductAttrForm').find('select').val('');
        $('#addNewProductAttrForm').find('textarea').val('');
        $('#addNewProductForm').find('input').val('');
        $('#addNewProductForm').find('select').val('');
        $('#addNewProductForm').find('textarea').val('');
        $('#addedAttrGroupsTableId').hide();
        $('#addedAttrGroupsTableId').find('tbody').empty();
        $('#attrGroupTableBody').empty();
        attrGroupHelper.getTheAttributeGroupTableData();
        $('#viewComponents').hide();
        $('#predefinedListOptionInputDiv').hide();
        $('#usersAddedInputOptionDiv table[id="addedNameTable"] tbody').empty();
        $('#usersAddedInputOptionDiv table[id="addedOptionsTable"] tbody').empty();
        $('#addNameBtn').removeAttr('disabled');
    });
    $('#changePasswordBtn').on('click', function () {
        $('#changePasswordDiv').show();
    });
    $('#closeChangePasswordBtn').on('click', function () {
        $('#changePasswordForm input').each(function () {
            $(this).val('');
        });
        $('#changePasswordDiv').hide();
    });
});