
$(document).ready(function () {
    setTimeout(function () {
        $("#preloader").css("display", "none");
    },500);
});
function showLoader() {
    $("#nb-global-spinner").css("display", "flex");
}
function hideLoader() {
    $("#nb-global-spinner").css("display", "none");
}

function drawDynamicDataTable(tableId, apiUrl, columns, numberOfColumns, orderableFlag) {
    // Initialize the DataTable for the given tableId with dynamic configurations
    $(`#${tableId}`).DataTable({
        ajax: {
            url: apiUrl,            // API URL
            type: 'GET',
            dataSrc: 'data',        // Adjust this based on your response
            error: function (xhr, error, code) {
                console.error('Error loading data:', error, xhr.responseText);
            },
            beforeSend: function () {
                console.log('Sending request to API...');
            },
            complete: function (xhr, status) {
                console.log('Data loaded:', xhr.responseText);
            }
        },
        columns: columns,          // Dynamic columns configuration
        columnDefs: [
            { targets: [numberOfColumns], orderable: orderableFlag }  // Disable sorting on the 'Actions' column
        ], // Custom column definitions (like disabling sorting)
    });
}



