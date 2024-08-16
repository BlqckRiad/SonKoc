function Ekle() {
    var k1 = document.getElementById("soz").value;
    var olusturanKisiIDnoint = localStorage.getItem("TabloID");
    var olusturanKisiID = parseInt(olusturanKisiIDnoint, 10);
    var veri = {
        Soz: k1,
        OlusturanKisiID: olusturanKisiID,
    };
    var token = localStorage.getItem("Token");
    $.ajax({
        url: '/GununSozu/GununSozuAddData',
        headers: { "Authorization": "Bearer " + token },
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (response) {
            // Burada isterseniz başka bir işlem yapabilirsiniz, örneğin bir mesaj gösterebilirsiniz.
            location.href = "/GununSozu/GununSozuList";
        },
        error: function (xhr, status, error) {
            // Hata durumunda yapılacak işlemler
            console.error('GununSozu eklenirken bir hata oluştu:', error);
            // Burada isterseniz kullanıcıya bir hata mesajı gösterebilirsiniz.
        }
    });
}
