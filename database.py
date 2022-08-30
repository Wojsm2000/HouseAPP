from main import data
import sqlite3 as sl
import pandas
import winsound

con = sl.connect('my-test.db')

def deleteSqliteRecord(city):
    try:

        cursor = con.cursor()
        print("Connected to SQLite")

        sql_update_query = """DELETE from USER where city = ?"""
        cursor.execute(sql_update_query, (city,))
        con.commit()
        print("Record deleted successfully")

        cursor.close()

    except sqlite3.Error as error:
        print("Failed to delete reocord from a sqlite table", error)
    finally:
        if con:
            con.close()
            print("sqlite connection is closed")


con = sl.connect('my-test.db')

deleteSqliteRecord("Łódź")



# with con:
#     con.execute("""
#     CREATE TABLE IF NOT EXISTS  USER (
#     id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
#     link TEXT
#     price DOUBLE,
#     area DOUBLE,
#     city TEXT,
#     district TEXT
#     );
#     """)

city,dist,price,area,link=data()

df_user=pandas.DataFrame({
'city':city,
'district':dist,
'price':price,
'area':area



})
winsound.Beep(500,5000)
print(df_user)
df_user.to_sql('USER', con)

with con:
    data = con.execute("SELECT * FROM USER ")
    for row in data:
        print(row)


# create_users = """
# INSERT INTO
#   USER (id, link, gender, nationality)
# VALUES
#   ('James', 25, 'male', 'USA'),
#   ('Leila', 32, 'female', 'France'),
#   ('Brigitte', 35, 'female', 'England'),
#   ('Mike', 40, 'male', 'Denmark'),
#   ('Elizabeth', 21, 'female', 'Canada');
# """
#
# execute_query(connection, create_users)
