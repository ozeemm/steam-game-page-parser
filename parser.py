import requests
from bs4 import BeautifulSoup
from exceptions import *

def GetClearedUrl(url):
    url = url.split("/")
    newUrl = url[0] + "//"

    for i in range(2, 6):
        newUrl += url[i] + "/"
            
    newUrl += "?l=russian"
    return newUrl

# # Больше не работает
# def GetPageUrlFromSearch(name):
#     query = name.replace(" ", "+")
#     query += "+steam"
#     url = f"https://www.google.com/search?q={query}"

#     response = requests.get(url)
#     response.raise_for_status()

#     soup = BeautifulSoup(response.content, "html.parser")
#     s = "/url?q=https://store.steampowered.com/app"

#     for a in soup.find_all("a", href=True):
#         print(a['href'])
#         if(a['href'][0:len(s)] == s):
#             gameUrl = a['href'][7:]
#             gameUrl = GetClearedUrl(gameUrl)
#             return gameUrl
    
#     raise Exception("Game not found")

def GetPageUrlById(id, language = "russian"):
    return f"https://store.steampowered.com/app/{id}?l={language}"

def GetGamePageFromUrl(url):
    response = requests.get(url)
    response.raise_for_status()

    if(response.headers['Set-Cookie'].find('recentapps') == -1):
        raise GameNotFoundException()
    
    page = response.text
    return page