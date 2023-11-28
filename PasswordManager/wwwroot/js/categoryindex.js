$(document).ready(function () {
    $("#categorySearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#categoryTable tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
});

function confirmDelete(id) {
    Swal.fire({
        title: 'Emin misiniz?',
        text: "Bu kategoriyi silmek istiyor musunuz?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/Category/DeleteCategory?id=${id}`, { method: 'POST' })
                .then(response => response.text())
                .then(data => {
                    if (data == "true") {
                        Swal.fire({
                            title: 'Silindi!',
                            text: 'Kategori silindi.',
                            icon: 'success',
                            showConfirmButton: false
                        });

                        setTimeout(function () {
                            location.href = '/Category/Index';
                        }, 3000);
                    }
                    else {
                        Swal.fire({
                            title: 'Hata!',
                            text: 'Kategoriye ait şifre olduğu için silinemedi.Lütfen önce ilgili şifreleri silin veya kategorisini değiştirin',
                            icon: 'error',
                            showConfirmButton: false
                        });

                        setTimeout(function () {
                            location.href = '/Category/Index';
                        }, 2000);
                    }
                })
                .catch(error => {
                    Swal.fire('Hata!', 'Silme sırasında bir hata meydana geldi.', 'error');
                });
        }
    });
}