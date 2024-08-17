function showPage() {
    gameName = document.getElementById("GameName").value;
    statusLogger = document.getElementById("StatusLog");
    
    statusLogger.innerHTML = "Загрузка...";

    const url = "/GetGamePage?name=" + gameName;

    let xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.onload = () => {
        document.documentElement.innerHTML += '<html>' + xhr.response + '</html>';
    }
    xhr.onprogress = (event) => {
        statusLogger.innerHTML = 'Получено с сервера ' + event.loaded + ' байт из ' + event.total;
    }
    xhr.onerror = () => {
        statusLogger.innerHTML = "Error!";
    }
    xhr.send();
}