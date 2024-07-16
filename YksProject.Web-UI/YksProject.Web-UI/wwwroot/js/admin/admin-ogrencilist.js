$(document).ready(function () {
    DataGetir();
});

function DataGetir() {
    $.ajax({
        type: "GET",
        url: "/Admin/GetOgrListForAdmin",
        success: function (result) {
            var data = result;
            $("#OgrenciGenelTable").DataTable().destroy();
            var satirlar = "";

            for (var i = 0; i < data.length; i++) {
                var formattedDate = formatDate(data[i].olusturulmaTarihi);
                satirlar += "<tr>\
                        <td>"+ data[i].tabloID + "</td>\
                        <td>"+ data[i].kisiAdi + "</td>\
                        <td>"+ data[i].kisiSoyAdi + "</td>\
                        <td>"+ data[i].kisiKullaniciAdi + "</td>\
                        <td>"+ data[i].kisiEmail + "</td>\
                        <td>"+ data[i].kisiTelNo + "</td>\
                        <td>"+ formattedDate + "</td>\
                        </tr>";
            }
            $("#tbody").html(satirlar);

            $('#OgrenciGenelTable').DataTable({
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

function formatDate(tarih) {
    var date = new Date(tarih);
    var gun = date.getDate();
    var ay = date.getMonth() + 1; // Aylar 0'dan başladığı için +1 ekliyoruz
    var yil = date.getFullYear();

    // Gün ve ayı iki haneli olarak formatla
    gun = gun < 10 ? '0' + gun : gun;
    ay = ay < 10 ? '0' + ay : ay;

    return gun + '/' + ay + '/' + yil;
}

