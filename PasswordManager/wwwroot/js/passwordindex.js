$(document).ready(function () {
    $("#passwordSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#passwordTable tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
});

function confirmDelete(id) {
    Swal.fire({
        title: 'Emin misiniz?',
        text: "Bu detayı silmek istiyor musunuz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/Password/DeleteMyPasswordDetail?id=${id}`, { method: 'POST' })
                .then(response => response.text())
                .then(data => {
                    Swal.fire({
                        title: 'Silindi!',
                        text: 'Şifre Detay silindi.',
                        icon: 'success',
                        showConfirmButton: false
                    });

                    setTimeout(function () {
                        location.href = '/Password/Index';
                    }, 2000);
                })
                .catch(error => {
                    Swal.fire('Hata!', 'Silme sırasında bir hata meydana geldi.', 'error');
                });
        }
    });
}


