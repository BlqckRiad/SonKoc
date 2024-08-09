function girisyap() {
    // Input değerlerini al
    var usernameOrEmail = $('#usernameoremail').val();
    var password = $('#password').val();

    // Boş giriş kontrolü
    if (!usernameOrEmail || !password) {
        console.error('Kullanıcı adı veya şifre boş olamaz.');
        return;
    }
    
    // Veri objesini oluştur
    var veri = {
        Password: password,
        UserNameOrEmail: usernameOrEmail
    };

    var jsonData = JSON.stringify(veri);

    // AJAX isteği gönder
    $.ajax({
        url: '/Account/Login',
        type: 'POST',
        contentType: 'application/json',
        data: jsonData, // Dönüştürülmüş JSON verilerini gönder
        success: function (response) {
            var secretKey = "SKSecretKey";
            var encryptedUserName = CryptoJS.AES.encrypt(response.data.userName, secretKey).toString();
            var encryptedRole = CryptoJS.AES.encrypt(response.data.role, secretKey).toString();
            if (response.success) {
                // LocalStorage'a verileri yaz
                localStorage.setItem('TabloID', response.data.tabloID);
                localStorage.setItem('UserName', encryptedUserName );
                localStorage.setItem('Token', response.data.token);
                localStorage.setItem('Role', encryptedRole);
                localStorage.setItem('KisiImageUrl', response.data.kisiImageUrl);

                // Kullanıcının rolüne göre yönlendirme yap
                if (response.data.role === 'Admin') {
                    location.href = "/Admin/Index";
                } else {
                    location.href = "/Home/Index";
                }
            } else {
                console.error('Giriş yapılırken bir hata oluştu:', response.message);
            }
        },
        error: function (xhr, status, error) {
            console.error('Giriş yapılırken bir hata oluştu:', error);
        }
    });
}

