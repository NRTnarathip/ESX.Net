using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESXSharp.Server;

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
    static dynamic esxDynamic;
    private ESX(dynamic esx)
    {
        esxDynamic = esx;
        isInitialized = true;

        //DumpDynamicObject(esx);
    }

    public new List<Player> Players => GetPlayers();
    public List<Player> GetPlayers()
    {
        List<object> xPlayers = esxDynamic.Players;
        List<Player> players = [];
        foreach (var xPlayer in xPlayers)
        {
            players.Add(new(xPlayer));
        }
        return players;
    }
    public static void DumpDynamicObject(object obj)
    {
        if (obj.GetType() != typeof(System.Dynamic.ExpandoObject))
        {
            Print("Can't Dump Dynamic Object: ", obj);
            return;
        }

        var dict = (IDictionary<string, object>)obj;
        Print("=== Dump Dynamic Object ===");
        int index = 0;
        Print("Element count: ", dict.Count);
        foreach (var item in dict)
        {
            Debug.WriteLine($"  [{index}] Key: {item.Key}, Value: {item.Value}");
            index++;
        }
    }

    public static void Print(params object[] args)
    {
        string printString = string.Join(" ", args.Select(arg => arg?.ToString() ?? "null"));
        Debug.WriteLine(printString);
    }
}
