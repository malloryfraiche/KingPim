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