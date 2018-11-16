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