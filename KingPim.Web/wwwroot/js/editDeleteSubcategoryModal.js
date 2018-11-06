$(document).ready(function () {

    // To control the data that is shown in the edit modal.
    $('#editModal').on('show.bs.modal', function (event) {
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
                    //console.log(response);
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


        // To fill the subcategories attribute groups table with data from the SubcategoryAttributeGroup DB.
        $.ajax({
            url: '/Subcategory/GetSubcategoryAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {

                    $.each(response, function (r, subcatAttrGroup) {

                        if (idRecipient === subcatAttrGroup.subcategoryId) {
                            console.log(subcatAttrGroup);

                            // Add the connected rows to the subcatAttrGroup table.
                            var tr = [
                                "<tr data-subcategoryattributegroupattributegroupid='" + subcatAttrGroup.attributeGroupId +
                                "'data-subcategoryattributegroupsubcategoryid=" + subcatAttrGroup.subcategoryId +
                                "><td><small><i>" + subcatAttrGroup.attributeGroup.name +
                                "</i></small><button type='button' class='close' style='float:right;'><span aria-hidden='true'>&times;</span></button></td></tr>"
                            ];
                            $('#subcategoriesAttrGroupsTableBody').append(tr.join(''));



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






        // To fill the attrGroup dropdown with data from the AttributeGroup DB.
        $.ajax({
            url: '/AttributeGroup/GetAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    $('#editSubcatForm select.attrGroupsSelect').append("<option value='' selected>Please select...</option>");

                    $.each(response, function (r, attrGroup) {
                        $('#editSubcatForm select.attrGroupsSelect').append("<option value='" + attrGroup.id + "'>" + attrGroup.name + "</option>");
                    });

                }
                else {
                    console.log('In the success function but there is no data to present');
                    $('#editSubcatForm select.attrGroupsSelect').append("<option value='' selected>There are no attribute groups to select from.</option>");
                }
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });








        // To POST the editSubcatForm from the modal.
        $('#editSubcatForm').submit(function (e) {
            e.preventDefault();
            var formData = new FormData();
            formData.append('id', idRecipient);
            $('#editSubcatForm input').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            $('#editSubcatForm select').each(function () {
                formData.append($(this).attr('name'), $(this).val());
            });
            $.ajax({
                url: '/Subcategory/EditSubcategory',
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
        modal.find('.modal-content h5').text('Are you sure you want to delete subcategory ' + nameRecipient + '?');
        modal.find('.modal-body input').val(idRecipient);
        console.log(idRecipient);
    });
});