import sqlite3
con = sqlite3.connect('msgs.db')

cur = con.cursor()

# Create table
cur.execute('''CREATE TABLE users
               (id integer primary key, username text, regkey text)''')

cur.execute('''CREATE TABLE messages
               (id integer primary key, json_msg text)''')

# Save (commit) the changes
con.commit()

# We can also close the connection if we are done with it.
# Just be sure any changes have been committed or they will be lost.
con.close()

