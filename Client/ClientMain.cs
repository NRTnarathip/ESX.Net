using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Guy.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Hi from Guy.Client!");
        }

        [Tick]
        public Task OnTick()
        {
            Debug.WriteLine("Ticking");
            return Task.CompletedTask;
        }
    }
}