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
            foreach (var item in player.inventory)
            {
                ESX.DumpDynamicObject(item);
            }
        }
    }
}