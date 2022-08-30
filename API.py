import sqlite3 as sl
import pandas
from fastapi import FastAPI
con = sl.connect('my-test.db')
q=[]
with con:
    data = con.execute("SELECT * FROM USER ")
    for row in data:
        #print(row)
        q.append(row)
    print(q)

