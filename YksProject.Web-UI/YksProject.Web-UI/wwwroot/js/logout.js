function logout() {
    // Local Storage'ı temizle
    

    // Cookie'leri temizle
    document.cookie.split(";").forEach(function (c) {
        document.cookie = c.trim().split("=")[0] + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/';
    });

    var logoutid2 = localStorage.getItem("TabloID");

    // localStorage'dan alınan değeri integer tipine çevirme
    var logoutid = parseInt(logoutid2, 10);

    if (logoutid > 4999999) {
        $.ajax({
            type: "GET",
            url: "/Account/LogoutKurum/" + logoutid,
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir

                localStorage.clear();
                location.href = "/Home/Index";
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("Çıkış işleminde hata ile karşılaştık");
            }
        });
    } else {
        $.ajax({
            type: "GET",
            url: "/Account/Logout/" + logoutid,
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                // Silme işlemi başarılı olduysa, listedeki sayfaya yönlendir

                localStorage.clear();
                location.href = "/Home/Index";
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("Çıkış işleminde hata ile karşılaştık");
            }
        });
    }


   
}
