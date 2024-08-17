function showPage() {
    gameName = document.getElementById("GameName").value;
    statusLogger = document.getElementById("StatusLog");
    
    statusLogger.innerHTML = "Загрузка...";

    const url = "/GetGamePage?name=" + gameName;

    let xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.onloadend = () => {
        if(xhr.status == 200){
            //document.getElementById("SteamPage").innerHTML = '<html>' + xhr.response + '</html>';
            document.documentElement.innerHTML += '<html>' + xhr.response + '</html>';
        }
        else if(xhr.status == 404){
            statusLogger.innerHTML = "Игра не найдена";
        }
    }
    xhr.onprogress = (event) => {
        statusLogger.innerHTML = 'Получено с сервера ' + event.loaded + ' байт из ' + event.total;
    }
    xhr.onerror = () => {
        statusLogger.innerHTML = "Error!";
    }
    xhr.send();
}