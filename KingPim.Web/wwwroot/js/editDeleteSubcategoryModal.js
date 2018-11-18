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