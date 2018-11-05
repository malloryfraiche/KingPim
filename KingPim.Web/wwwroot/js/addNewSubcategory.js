$(document).ready(function () {

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

                    $('button.addAttrGroupBtn').click(function (e) {
                        e.preventDefault();
                        var id = $(this).closest('tr').data('attributegroupid');
                        var name = $(this).closest('tr').data('attributegroupname');
                        console.log(id);
                        console.log(name);

                        var parentTr = $(this).closest('tr');
                        parentTr.hide();

                        $('#addedAttrGroupsTableId').show();

                        var addedTr = [
                            "<tr data-attributegroupid='" + id +
                            "'data-attributegroupname=" + name +
                            "><td><small><i>" + name +
                            "</i></small><button class='btn btn-sm btn-outline-danger' type='button' title='Take away attribute group.' style='float:right;'>Delete</button></td></tr>"
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

    getTheAttributeGroupTableData();
});