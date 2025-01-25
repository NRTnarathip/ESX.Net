using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using ESX.Server;

namespace Guy.Server;

public class ServerMain : ESXScript
{
    protected override void OnReady()
    {
        Debug.WriteLine("Server is on ready");
    }
}