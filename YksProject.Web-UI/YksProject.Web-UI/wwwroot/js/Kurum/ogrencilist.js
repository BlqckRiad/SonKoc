var table
$(document).ready(function () {
    // Initialize DataTable

    table = new DataTable('#multi-filter-select');


    OgrencileriGetir();
});

function OgrencileriGetir() {
    var kurumid = localStorage.getItem("TabloID");
    var kurumidint = parseInt(kurumid, 10);

    var veri = {
        KurumID: kurumidint
    };

    $.ajax({
        url: '/Kurum/KurumaAitOgrencileriGetir',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Clear existing data
            table.clear();

            // Populate table with new data
            response.forEach(function (student) {
                table.row.add([
                    student.kisiKullaniciAdi,
                    student.kisiAdi + " " + student.kisiSoyAdi,

                    '<i class="fa fa-pencil" aria-hidden="true" class="icon-cell" onclick="detayliIncele(' + student.tabloID + ')"></i>',
                    '<i class="fa fa-cog" aria-hidden="true"class="icon-cell" onclick="duzenle(' + student.tabloID + ')"></i>',
                    '<i class="fa fa-comments-o" aria-hidden="true" class="icon-cell" onclick="mesajGonder(' + student.tabloID + ')"></i>',
                    '<i class="fa fa-trash" aria-hidden="true" class="icon-cell" onclick="sil(' + student.tabloID + ')"></i>'
                ]);
            });

            // Draw table to reflect changes
            table.draw();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

// Example functions for icon click events
function detayliIncele(id) {
    location.href = "/Kurum/OgrenciDetay/"+id;
}

function duzenle(id) {
    console.log("Düzenle clicked for ID:", id);
    // Implement your function here
}

function mesajGonder(id) {
    console.log("Mesaj Gönder clicked for ID:", id);
    // Implement your function here
}

function sil(id) {
    console.log("Sil clicked for ID:", id);
    // Implement your function here
}
   
