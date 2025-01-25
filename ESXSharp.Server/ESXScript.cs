using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESXSharp.Server;

public abstract class ESXScript : BaseScript
{
    protected static ESX core = ESX.GetInstance();
    protected ESXScript()
    {
        OnReady();
    }

    [Tick]
    public async Task OnTick()
    {

    }

    protected abstract void OnReady();

    public void Print(params object[] args) => ESX.Print(args);
}
