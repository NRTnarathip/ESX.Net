using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESX.Server;
public sealed class ESX : BaseScript
{
    static ESX Instance;
    static bool isInitialized = false;

    internal static ESX GetInstance()
    {
        TryInitialize();
        return Instance;
    }

    private static void TryInitialize()
    {
        try
        {
            TriggerEvent("esx:getSharedObject", (dynamic esx) =>
            {
                Instance = new(esx);
            });

            while (isInitialized is false)
            {
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }

    private ESX(dynamic esx)
    {
        var dict = (IDictionary<string, object>)esx;
        foreach (var item in dict)
        {
            Debug.WriteLine($"item: Key:{item.Key}, Val:{item.Value}");
        }

        isInitialized = true;
    }
}
