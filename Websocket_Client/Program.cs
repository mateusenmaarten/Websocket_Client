using System.Text.Json;
using Websocket_Shared;
using WebSocketSharp.NetCore;

using (WebSocket ws = new WebSocket("ws://localhost:4200/CardsAgainstHumanity"))
{
    var nameMessage = JsonSerializer.Serialize(new Message_Login(GetUserName()));
    ws.OnMessage += Ws_OnMessage;

    ws.Connect();
    ws.Send(nameMessage);

    Console.ReadKey();
}

void Ws_OnMessage(object? sender, MessageEventArgs e)
{
    Console.WriteLine(e.Data);
}

string GetUserName()
{
    var playerName = "";
    do
    {
        Console.Write("Geef uw speler naam: ");
        playerName = Console.ReadLine();
        
    } while (playerName.IsNullOrEmpty());
    return playerName;
}

