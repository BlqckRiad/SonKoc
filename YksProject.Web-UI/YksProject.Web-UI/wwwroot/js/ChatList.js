

$(document).ready(function () {
    var user = localStorage.getItem('TabloID');
    var userint = parseInt(user, 10);
    GetUsers(userint);
});

function displayUserInfo(user) {
    const header = document.getElementById('user-header');
    const headerImg = header.querySelector('img');
    const headerUsername = header.querySelector('h2');
    const headerStatus = header.querySelector('#status');

    headerImg.src = user.kisiImageUrl || "http://localhost:6079/images/Logo.jpg";
    headerUsername.textContent = `Chat with ${user.kisiKullaniciAdi}`;
    headerStatus.textContent = user.userOnlineMi ? 'online' : 'offline';
    headerStatus.className = `status ${user.userOnlineMi ? 'online' : 'offline'}`;

    const sendButton = document.getElementById('send-button');
    if (sendButton) {
        sendButton.onclick = function () {
            SendMessage(user.tabloID);
        };
    }
    getMessages(user.tabloID);
    
}
function getMessages(tabloID) {
    var loginuser = localStorage.getItem("TabloID");
    var loginUserName = localStorage.getItem("UserName");
    var userint = parseInt(loginuser, 10);

    var queryString = $.param({
        MesajGondericiID: userint,
        MesajAliciID: tabloID
    });

    $.ajax({
        type: 'GET',
        url: "/Chat/GetMessageAsync?" + queryString,
        success: function (veri) {
            const chatList = document.getElementById('chat');
            chatList.innerHTML = ""; // Clear previous messages

            veri.forEach(message => {
                const li = document.createElement('li');
                const isCurrentUser = message.mesajGondericiID === userint;
                li.className = isCurrentUser ? 'me' : 'you';

                const enteteDiv = document.createElement('div');
                enteteDiv.className = 'entete';

                if (isCurrentUser) {
                    // If current user
                    const h3 = document.createElement('h3');
                    h3.textContent = new Date(message.olusturulmaTarihi).toLocaleString();

                  

                    const statusSpan = document.createElement('span');
                    statusSpan.className = 'status blue';

                    enteteDiv.appendChild(h3);
                    enteteDiv.appendChild(statusSpan);
                } else {
                    // If other user
                    const statusSpan = document.createElement('span');
                    statusSpan.className = 'status green';

                    

                    const h3 = document.createElement('h3');
                    h3.textContent = new Date(message.olusturulmaTarihi).toLocaleString();

                    enteteDiv.appendChild(statusSpan);
                  
                    enteteDiv.appendChild(h3);
                }

                const triangleDiv = document.createElement('div');
                triangleDiv.className = 'triangle';

                const messageDiv = document.createElement('div');
                messageDiv.className = 'message';
                messageDiv.textContent = message.mesajText;

                li.appendChild(enteteDiv);
                li.appendChild(triangleDiv);
                li.appendChild(messageDiv);

                chatList.appendChild(li);
                chatList.scrollTop = chatList.scrollHeight;
            });
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}


function GetUsers(userint) {
    $.ajax({
        type: 'GET',
        url: "/Chat/GetUsersAsync",
        data: { id: userint },
        success: function (data) {
            const userList = document.getElementById('user-list');
            userList.innerHTML = ""; // Önce mevcut içeriği temizle
            var defaultImageUrl = "http://localhost:6079/images/Logo.jpg";

            // İlk gelen kullanıcı verisi için displayUserInfo fonksiyonunu çağır
            if (data.length > 0) {
                displayUserInfo(data[0]);
            }

            data.forEach(user => {
                const li = document.createElement('li');
                li.className = 'user-list-item';
                li.addEventListener('click', () => {
                    displayUserInfo(user);
                });

                const img = document.createElement('img');
                img.src = user.kisiImageUrl || defaultImageUrl;
                img.alt = "";

                const div = document.createElement('div');
                div.className = 'user-info';

                const h2 = document.createElement('h2');
                h2.textContent = user.kisiKullaniciAdi;

                const h3 = document.createElement('h3');
                const span = document.createElement('span');
                span.className = `status ${user.userOnlineMi ? 'green' : 'orange'}`;
                h3.appendChild(span);
                h3.appendChild(document.createTextNode(user.userOnlineMi ? 'online' : 'offline'));

                div.appendChild(h2);
                div.appendChild(h3);

                li.appendChild(img);
                li.appendChild(div);

                userList.appendChild(li);
            });
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}
function SendMessage(id) {
    var userid = localStorage.getItem("TabloID");
    var senderid = parseInt(userid, 10);
    var messagesenderimageurl = localStorage.getItem("KisiImageUrl");
    var text = $('#messageArea').val();

    var veri = {
        MesajGondericiID: senderid,
        MesajAliciID: id, // Ensure this matches the property name expected by your API
        MesajText: text,
        MesajGonderenKisiImageUrl: messagesenderimageurl,
    };

    // POST işlemi
    // POST işlemi
    $.ajax({
        type: 'POST',
        url: "/Chat/PostMessageAsync",
        contentType: 'application/json',
        data: JSON.stringify(veri),
        success: function (newMessage) {
            
            var loginUserName = localStorage.getItem("UserName");
            const chatList = document.getElementById('chat');

            const li = document.createElement('li');
            li.className = 'me'; // Veya 'you' class'ı

            const enteteDiv = document.createElement('div');
            enteteDiv.className = 'entete';

            const h3 = document.createElement('h3');
            h3.textContent = new Date(newMessage.olusturulmaTarihi).toLocaleString();

       

            const statusSpan = document.createElement('span');
            statusSpan.className = 'status blue';

            enteteDiv.appendChild(h3);
            
            enteteDiv.appendChild(statusSpan);

            const triangleDiv = document.createElement('div');
            triangleDiv.className = 'triangle';

            const messageDiv = document.createElement('div');
            messageDiv.className = 'message';
            messageDiv.textContent = newMessage.mesajText;

            li.appendChild(enteteDiv);
            li.appendChild(triangleDiv);
            li.appendChild(messageDiv);

            chatList.appendChild(li);

            // Textarea'yı temizle
            document.getElementById('messageArea').value = '';

            // Scroll'u en aşağıya getir
            chatList.scrollTop = chatList.scrollHeight;
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });

}
