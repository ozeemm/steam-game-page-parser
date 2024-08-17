function showPage() {
    gameName = document.getElementById("GameName").value;
    statusLogger = document.getElementById("StatusLog");
    
    const url = "https://localhost:7103/GetGamePage?name=" + gameName;

    let xhr = new XMLHttpRequest();
    xhr.open("POST", url);
    xhr.send();
    xhr.onload = () => {
        document.body.innerHTML += xhr.response;
    }
    xhr.onprogress = (event) => {
        statusLogger.innerHTML = 'Получено с сервера ' + event.loaded + ' байт из ' + event.total;
    }
    xhr.onerror = () => {
        statusLogger.innerHTML += "Error!";
    }
}