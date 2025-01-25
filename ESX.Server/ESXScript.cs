using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESX.Server;

public abstract class ESXScript : BaseScript
{
    protected static ESX esx = ESX.GetInstance();
    protected ESXScript()
    {
        OnReady();
    }

    [Tick]
    public async Task OnTick()
    {

    }

    protected abstract void OnReady();
}
