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

        $('#viewComponents').hide();
    });
});