$(document).ready(function () {

    //function getTheAttributeGroupTableData() {
        // To fill the AttributeGroup table with data from the AttributeGroup DB.
        $.ajax({
            url: '/AttributeGroup/GetAttributeGroupsToJson',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response !== null) {
                    //console.log(response);
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



                    // -------- TODO --------- (add this updated function to infoTablePartialView.js)
                    // To remove the added attribute off the list.
                    $('button.removeAttrGroupBtn').click(function () {
                        var id = $(this).closest('tr').data('attributegroupid');
                        var name = $(this).closest('tr').data('attributegroupname');
                        console.log(id);
                        console.log(name);
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
    //}

    //getTheAttributeGroupTableData();
    
    // To POST the addNewSubcatForm.
    $('#addNewSubcatForm').submit(function (e) {
        e.preventDefault();
        var formData = new FormData();

        var inputAreaData = $('#addNewSubcatForm input').val();
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