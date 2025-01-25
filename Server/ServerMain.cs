using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using ESXSharp.Server;

namespace Guy.Server;

public class ServerMain : ESXScript
{
    protected override void OnReady()
    {
        var players = core.Players;
        Print("Player count: ", players.Count);
        foreach (var player in players)
        {
            Print("player id: ", player.playerId);
            Print("player name: ", player.name);
            Print("player identifier: ", player.identifier);
            Print("player spawned: ", player.spawned);
        }
    }
}