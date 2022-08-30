import requests
import math
from bs4 import BeautifulSoup
from numpy.core import double
import time


def has_numbers(inputString):
    return any(char.isdigit() for char in inputString)


def data():
    arr2 = []
    p_arr = []
    a_arr = []
    c_arr = []
    d_arr = []

    html_text = requests.get(
        "https://www.otodom.pl/pl/oferty/sprzedaz/mieszkanie/lodz?distanceRadius=0&market=ALL&locations=%5Bcities_6-1004%5D&viewType=listing&lang=pl&searchingCriteria=sprzedaz&searchingCriteria=mieszkanie&searchingCriteria=cala-polska&page=1&limit=36")
    soup = BeautifulSoup(html_text.text, 'lxml')
    Counter = soup.find_all('span', class_='css-klxieh e1ia8j2v11')

    for c in Counter:
        arr = (c.text.strip())

    j = math.ceil(float(arr) / 36)
    array = []
    print(j)

    for k in range(1, j + 1, 1):
        print(k)
        s=time.time()
        html_mlt = requests.get(
            "https://www.otodom.pl/pl/oferty/sprzedaz/mieszkanie/lodz?distanceRadius=0&market=ALL&locations=%5Bcities_6-1004%5D&viewType=listing&lang=pl&searchingCriteria=sprzedaz&searchingCriteria=mieszkanie&searchingCriteria=cala-polska&page=" + str(
                k) + "&limit=36")

        soup2 = BeautifulSoup(html_mlt.text, 'lxml')
        licznik = 0
        for a in soup2.find_all('a', href=True, class_='css-b2mfz3 es62z2j16'):
            if licznik != 0 and licznik != 1 and licznik != 2:
                array.append('https://www.otodom.pl/' + a['href'])
            licznik = licznik + 1
        e=time.time()
        print(e-s)
    print(array)
    x = 0
    for link in array:
        #     x = x + 1
        #     print(x)
        #     print(link)
        s=time.time()
        html = requests.get(
            link)
        soup3 = BeautifulSoup(html.text, 'lxml')
        price = soup3.find('strong', class_='css-8qi9av eu6swcv19')
        area = soup3.find('div', class_='css-1wi2w6s estckra5')
        place = soup3.find_all('a', class_='css-1in5nid e1je57sb6')

        if price is None and area is None:
            continue
        else:
            p = price.text.rsplit(' ', 1)[0]
            a = area.text.rsplit(' ', 1)[0]
            p = p.replace(" ", "")
            p = p.replace(",", ".")
            a = a.replace(",", ".")

            if has_numbers(p):
                p = double(p)
                a = double(a)
            else:
                p = None
                a = double(a)
            a_arr.append(a)
            p_arr.append(p)
            x = x + 1
            # print(x)
            print(link)
            e=time.time()
            print(e-s)
            i = 0

            s=time.time()
            for c in place:
                if i == 3:
                    print(c.text.strip())
                    d_arr.append(c.text.strip())

                elif i == 2:
                    c_arr.append(c.text.strip())
                i = i + 1
            print(len(c_arr))
            print(len(d_arr))
            print(len(p_arr))
            print(len(a_arr))
            if len(c_arr) != len(d_arr):
                d_arr.append(None)
            print("Dl d_arr" + str(len(d_arr)))
            e=time.time()
            print(e-s)
    return c_arr, d_arr, p_arr, a_arr, array
