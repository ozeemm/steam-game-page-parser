import sys
import requests
import os.path

def TempFolderChecker():
    if(not os.path.isdir("temp")):
        os.mkdir("temp")

def GetFilePath():
    TempFolderChecker()
    index = 0
    fileName = f"./temp/{index}.html"

    while(os.path.exists(fileName)):
        index += 1
        fileName = f"./temp/{index}.html"

    return fileName

def WritePageToFile(page):
    fileName = GetFilePath()
    f = open(fileName, "w", encoding="utf-8")
    f.write(page)
    f.close()

    return fileName

#url = "https://store.steampowered.com/app/413150/Stardew_Valley/"
url = sys.argv[1]

response = requests.get(url)
response.raise_for_status()

page = response.text
fileName = WritePageToFile(page)
print(fileName)