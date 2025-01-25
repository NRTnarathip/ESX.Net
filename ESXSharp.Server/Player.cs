using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ESXSharp.Server;

public sealed class Player
{
    public readonly dynamic raw;

    // Auto Assign Field Value From Dynamic Player
    public readonly string group;
    public readonly string identifier;
    public readonly string name;
    public readonly int playerId;
    public readonly int source;
    public readonly int weight;
    public readonly int maxWeight;
    public readonly float lastPlaytime;
    public readonly bool admin;
    public readonly string license;
    public readonly List<object> inventory;

    //in server/common.lua
    public readonly bool spawned;

    static Dictionary<string, FieldInfo> _CacheFields;
    static Player()
    {
        var type = typeof(Player);
        _CacheFields = type.GetFields().ToDictionary((type) => type.Name, (type) => type);
    }

    public Player(dynamic raw)
    {
        ESX.DumpDynamicObject(raw);

        this.raw = raw;
        playerId = raw.playerId;
        name = raw.name;

        var rawDict = (IDictionary<string, object>)raw;

        //auto assign field from dynamic object
        rawDict.Where(item => _CacheFields.ContainsKey(item.Key))
                .ToList().ForEach((item) =>
        {
            var fieldName = item.Key;
            var value = item.Value;
            var field = _CacheFields[fieldName];
            field.SetValue(this, value);
            ESX.Print("set field:", fieldName, "value:", value);
        });
    }
}
