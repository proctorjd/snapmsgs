import concurrent.futures

import aiohttp
import json

import websockets.http11
from aiohttp import web, WSCloseCode
import asyncio
import sqlite3
from urllib.parse import urlparse, parse_qs
con = sqlite3.connect('msgs.db')
cur = con.cursor()
connected = set()
removeConnections = set()


async def http_handler(request):
    post_data = await request.text()
    try:
        userobj = json.loads(post_data)
    except ValueError:
        return web.Response(text='Invalid json sent')
    # userTable.search( == )
    cur.execute("SELECT username FROM users WHERE username = ?", (userobj['username'],));
    row = cur.fetchone()
    if row is not None:
        username = row[0]
    else:
        cur.execute("INSERT INTO users (username, regkey) values (?, ?)", (userobj['username'], userobj['key']))
        con.commit()

    return web.Response(text='Success : '+post_data)


async def websocket_handler(request):
    ws = web.WebSocketResponse()
    await ws.prepare(request)
    qry = urlparse(request.query_string).query
    qcomp = parse_qs(urlparse(request.path_qs).query)
    uname = qcomp["uname"][0]
    ws.id = uname

    # connected.add
    await update_connections(ws)
    await process_messages()
    async for msg in ws:
        if msg.type == aiohttp.WSMsgType.TEXT:
            if msg.data == 'close':
                await ws.close()
            else:
                try:
                    payload = json.loads(msg.data)
                except ValueError:
                    return ws
                for pkg in payload:
                    cur.execute("INSERT INTO messages (json_msg) values (?)", (json.dumps(pkg),))
                con.commit()
                await process_messages()
                # await ws.send_str('messages sent...')
        elif msg.type == aiohttp.WSMsgType.ERROR:
            print('ws connection closed with exception %s' % ws.exception())

    return ws


async def update_connections(sock):
    found = False
    for conn in connected:
        if conn.id == sock.id:
            found = True

    if not found:
        connected.add(sock)


async def process_messages():
    cur.execute("SELECT * FROM messages");
    msgs = []
    for mm in cur.fetchall():
        msgs.append({"id": mm[0], "msg": json.loads(mm[1])})

    for conn in connected:
        for msg in msgs:
            if msg['msg']['payload']['recipients'] == conn.id:
                try:
                    await conn.send_json(msg)
                    # await conn.send(json.dumps(msg))
                except ConnectionResetError:
                    removeConnections.add(conn)
                else:
                    cur.execute("DELETE FROM messages WHERE id = ?", (msg['id'],))
                    con.commit()

    for rc in removeConnections:
        connected.remove(rc)
    removeConnections.clear()


def create_runner():
    app = web.Application()
    app.add_routes([
        web.post('/reg', http_handler),
        web.get('/ws', websocket_handler),
    ])
    return web.AppRunner(app)


async def start_server(host="localhost", port=5150):
    runner = create_runner()
    await runner.setup()
    site = web.TCPSite(runner, host, port)
    await site.start()


if __name__ == "__main__":
    loop = asyncio.get_event_loop()
    loop.run_until_complete(start_server())
    loop.run_forever()