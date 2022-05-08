using System.Text.Json;
using Websocket_Shared;
using WebSocketSharp.NetCore;

using (WebSocket ws = new WebSocket("ws://localhost:4200/CardsAgainstHumanity"))
{
    var loginMessage = new Message_Login(GetUserName());
    var rawMessageContent = JsonSerializer.Serialize(loginMessage);
    var message = JsonSerializer.Serialize(new RawMessage(loginMessage.MessageType, rawMessageContent));
    ws.OnMessage += Ws_OnMessage;

    ws.Connect();
    ws.Send(message);

    Console.ReadKey();
}

void Ws_OnMessage(object? sender, MessageEventArgs e)
{
    var message = JsonSerializer.Deserialize<RawMessage>(e.Data);

    var messageType = message.MessageType;

    switch (messageType)
    {
        case "Message_DisplayMainMenu":
            Message_DisplayMainMenu menu = JsonSerializer.Deserialize<Message_DisplayMainMenu>(message.MessageContent);
            Console.WriteLine(menu.Menu);
            break;
        default:
            break;
    }
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

