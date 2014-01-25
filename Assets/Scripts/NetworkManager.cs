using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class NetworkManager
{
    // The name we register our game types under with the master server
    private static readonly string  GAME_TYPE_NAME = "GGJ2014_Lepus";
    private const int               MAX_PLAYERS = 2;
    private const int               DEFAULT_SERVER_PORT = 80085;

    public static List<HostData> GetAvailableGames ()
    {
        MasterServer.RequestHostList (GAME_TYPE_NAME);
        return MasterServer.PollHostList ().ToList ();
    }

    public static void CreateServer ()
    {
        Network.InitializeServer (MAX_PLAYERS, DEFAULT_SERVER_PORT, !Network.HavePublicAddress ());
        MasterServer.RegisterHost (GAME_TYPE_NAME, System.Environment.MachineName);
    }

    public static void JoinGame (HostData game)
    {
        Network.Connect (game);
    }
}
