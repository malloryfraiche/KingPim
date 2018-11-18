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