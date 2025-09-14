function showPage(gameName) {
    statusLogger.innerHTML = "Загрузка..."

    const url = "/getGamePage?name=" + gameName

    let xhr = new XMLHttpRequest()
    xhr.open("GET", url, true)
    xhr.onloadend = () => {
        if(xhr.status == 200){
            statusLogger.innerHTML = ""
            document.documentElement.innerHTML += '<html>' + xhr.response + '</html>'
        }
        else if(xhr.status == 404){
            statusLogger.innerHTML = "Игра не найдена"
        }
    }
    xhr.onerror = () => {
        statusLogger.innerHTML = "Error!"
    }
    xhr.send()
}

const searchForm = document.getElementById("SearchForm")
const gameNameInput = document.getElementById("GameName")
const statusLogger = document.getElementById("StatusLog")

searchForm.addEventListener('submit', e => {
    e.preventDefault()
    showPage(gameNameInput.value)
})