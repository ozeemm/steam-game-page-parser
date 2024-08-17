function showPage() {
    statusLogger.innerHTML = "Загрузка...";

    const url = "/GetGamePage?name=" + gameName;

    let xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.onloadend = () => {
        if(xhr.status == 200){
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

gameNameInput = document.getElementById("GameName");
statusLogger = document.getElementById("StatusLog");

// По сути тут просто функция кнопки, но чтоб страница обновлялась и параметр был
let search = window.location.search;
let params = new URLSearchParams(search);
if(params.has('search')){
    gameName = params.get('search');
    gameNameInput.value = gameName;
    
    showPage();
}
