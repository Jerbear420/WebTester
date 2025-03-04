function showConfirmationModal(message, confirmCallback) {
    $('#confirmationMessage').text(message);
    $('#confirmationModal').modal('show');

    $('#confirmButton').off('click').on('click', function () {
        $('#confirmationModal').modal('hide');
        if (confirmCallback) {
            confirmCallback();
        }
    });
}