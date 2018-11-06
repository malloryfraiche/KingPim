$(document).ready(function () {

    // -------- TODO --------- (consolidate - have this function in 2 different places..)
    function getTheAttributeGroupTableData() {
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

                    $('button.addAttrGroupBtn').click(function () {
                        var id = $(this).closest('tr').data('attributegroupid');
                        var name = $(this).closest('tr').data('attributegroupname');
                        //console.log(id);
                        //console.log(name);

                        var parentTr = $(this).closest('tr');
                        parentTr.hide();

                        $('#addedAttrGroupsTableId').show();

                        var addedTr = [
                            "<tr data-attributegroupid='" + id +
                            "'data-attributegroupname=" + name +
                            "><td><small><i>" + name +
                            "</i></small><button class='btn btn-sm btn-outline-danger removeAttrGroupBtn' type='button' style='float:right;'>Remove</button></td></tr>"
                        ];
                        $('#addedAttrGroupsTableId tbody').append(addedTr.join(''));

                    });
                    
                }
                else {
                    console.log('In the success function but data is NULL');
                }
            },
            error: function (response) {
                console.log(response.responseText);
            }
        });
    }
    
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
        getTheAttributeGroupTableData();
        
        $('#viewComponents').hide();
    });
});