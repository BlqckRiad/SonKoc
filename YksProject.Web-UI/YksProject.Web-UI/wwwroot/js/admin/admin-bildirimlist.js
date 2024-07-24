$(document).ready(function () {
    var id = localStorage.getItem('TabloID');

    DataGetir(id);
});

function DataGetir(id) {
    $.ajax({
        url: '/Admin/GetNotificationsByAliciKisiID/' + id, // Burada id değerini kullanın
        type: 'GET',
        success: function (result) {
            var data = result;
            $("#BildirimlerGenelTable").DataTable().destroy();
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                satirlar += `
        <tr>
            <td>${data[i].tabloID}</td>
            <td>${data[i].aliciKisiID}</td>
            <td>${data[i].bildirimBasligi}</td>
            <td>${data[i].bildirimAciklamasi}</td>
            <td class='text-center'>
                <button type='button' class='btn mb-1 btn-rounded btn-danger' onclick='SilmeSayfasinaGit("${data[i].tabloID}")'>Sil</button>
            </td>
        </tr>`;
            }
            $("#tbody").html(satirlar);

            $('#BildirimlerGenelTable').DataTable({
                "paging": true,
                "responsive": true,
                "language": {
                    "lengthMenu": "Sayfa başına _MENU_ kayıt göster",
                    "info": "_TOTAL_ kayıttan _START_ - _END_ arası gösteriliyor",
                    "searchPlaceholder": "Ara",
                    "zeroRecords": "Kayıt bulunamadı",
                    "infoEmpty": "Kayıt yok",
                    "paginate": {
                        "first": "İlk",
                        "last": "Son",
                        "next": "Sonraki",
                        "previous": "Önceki"
                    }
                }
            });

        },
        error: function (xhr, textStatus, errorThrown) {
            alert("Giriş işleminde karşılaştık");
        }
    });

}


function SilmeSayfasinaGit(ifade) {
    var silenkisiID = localStorage.getItem("TabloID");

    // localStorage'dan alınan değeri integer tipine çevirme
    var silenkisiIDInteger = parseInt(silenkisiID, 10);

    var deleteDto = {
        TabloID: ifade,
        SilenKisiID: silenkisiIDInteger
    };

    $.ajax({
        type: "POST",
        url: "/Admin/DeleteNotification",
        contentType: "application/json",
        
        data: JSON.stringify(deleteDto),
        success: function (result) {
            // Başarılı olduğunda bildirim göster
            showNotification('Başarıyla Silindi!', 'delete');
            setTimeout(function () {
                location.href = "/Admin/BildirimList";
            }, 750);
        },
        error: function (xhr, textStatus, errorThrown) {
            showNotification('Silinemedi, bir hatayla karşılaştık.', 'error');
        }
    });
}


function showNotification(message, type) {
    var bgColor;
    if (type === 'success') {
        bgColor = '#43a889'; // Yeşil
    } else if (type === 'error') {
        bgColor = '#ff6b6b'; // Kırmızı
    } else if (type === 'delete') {
        bgColor = 'f0c54e';
    }

    
    var notification = $('<div></div>', {
        text: message,
        css: {
            position: 'fixed',
            top: '20px',
            right: '20px',
            padding: '20px',
            color: '#fff',
            backgroundColor: bgColor,
            borderRadius: '5px',
            zIndex: 1000
        }
    });
    $('body').append(notification);
    setTimeout(function () {
        notification.fadeOut(500, function () {
            $(this).remove();
        });
    }, 1500);
}
