using WebSocketSharp.NetCore;

using (WebSocket ws = new WebSocket("ws://localhost:4200/EchoAll"))
{
    Console.WriteLine("Input Player name here: ");
    var playerName = Console.ReadLine();
    ws.OnMessage += Ws_OnMessage;

    ws.Connect();
    ws.Send(playerName);

    Console.ReadKey();
}

void Ws_OnMessage(object? sender, MessageEventArgs e)
{
    Console.WriteLine($"The server responded with: {e.Data}");
}

