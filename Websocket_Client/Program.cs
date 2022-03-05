using WebSocketSharp.NetCore;

using (WebSocket ws = new WebSocket("ws://localhost:4200/CardsAgainstHumanity"))
{
    string playerName;

    do
    {
      playerName = GetUserName();
    } while (playerName.IsNullOrEmpty());

    ws.OnMessage += Ws_OnMessage;

    ws.Connect();
    ws.Send(playerName);

    

    Console.ReadKey();
}

void Ws_OnMessage(object? sender, MessageEventArgs e)
{
    Console.WriteLine(e.Data);
}

string GetUserName()
{
    Console.Write("Geef uw speler naam: ");
    var playerName = Console.ReadLine();
    return playerName;
}

