$(document).ready(function () {


    const dataTable = $('#servicesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Add',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            }
        ]
    });

    $(document).on('click', '.btn-delete', function (event) {
        event.preventDefault();
        const id = $(this).attr('data-id');
        const tableRow = $(`[name="${id}"]`);
        const serviceTitle = tableRow.find('td:eq(1)').text();
        Swal.fire({
            title: 'Xidməti silmək üçün əminsiniz?',
            text: `'${serviceTitle}' başlıqlı xidmət silinəcək!`,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Xeyr',
            confirmButtonText: 'Bəli, Sil!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { serviceId: id },
                    url: '/admin/service/delete/',
                    success: function (data) {
                        const serviceResult = jQuery.parseJSON(data);

                        if (serviceResult.ResultStatus === 0) {
                            Swal.fire(
                                'Silindi!',
                                `${serviceResult.Message}`,
                                'success'
                            );

                            dataTable.row(tableRow).remove().draw();
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Uğursuz Əməliyyat!',
                                text: `${serviceResult.Message}`
                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        toastr.error(`${err.responseText}`, "Error!");
                    }
                });
            }
        });
    });

    /* Ajax Post / Deleting the a Article ends here */
});