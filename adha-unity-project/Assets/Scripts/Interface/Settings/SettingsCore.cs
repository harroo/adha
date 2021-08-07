
using UnityEngine;

using System.Collections.Generic;

using UltimateSerializer;

using IOManager;

public static class Settings {

    public static Dictionary<string, object> settings
        = new Dictionary<string, object>();

    [RuntimeInitializeOnLoadMethod]
    public static void Boot () {

        byte[] data = IOMFile.ReadAllBytes("settings.dat");
        settings = data == null ? new Dictionary<string, object>() : 
            (Dictionary<string, object>)USerialization.Deserialize<Dictionary<string, object>>(data);
    }

    public static void Set (string key, object val) {

        if (settings.ContainsKey(key)) settings[key] = val;
        else settings.Add(key, val);

        byte[] data = USerialization.Serialize(settings);
        IOMFile.WriteAllBytes("settings.dat", data);
    }

    public static object Get (string key, object defval) {

        if (settings.ContainsKey(key)) return settings[key];
        else return defval;
    }
}
