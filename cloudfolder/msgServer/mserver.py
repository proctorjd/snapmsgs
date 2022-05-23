import asyncio
import websockets

connected = set()

msgList = []


async def server(websocket, path):
    # Register.
    connected.add(websocket)
    try:
        if path == "reg":

        elif path == "check":

        else:
            async for message in websocket:
                msgList.append(message)
                for conn in connected:
                    if conn != websocket:
                        await conn.send(f'Got a new MSG FOR YOU: {message}')
    finally:
        # Unregister.
        connected.remove(websocket)


start_server = websockets.serve(server, "localhost", 5150)

asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
