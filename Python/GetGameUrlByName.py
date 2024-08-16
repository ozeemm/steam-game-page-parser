import sys
import requests
from bs4 import BeautifulSoup

name = sys.argv[1]

query = name.replace(" ", "+")
query += "+steam"
url = f"https://www.google.com/search?q={query}"

response = requests.get(url)
response.raise_for_status()

soup = BeautifulSoup(response.content, "html.parser")
s = "/url?q=https://store.steampowered.com/app"

for a in soup.find_all("a", href=True):
    if(a['href'][0:len(s)] == s):
        gameUrl = a['href'][7:] + "/?l=russian"
        print(gameUrl)
        exit()
print("Game Not Found")