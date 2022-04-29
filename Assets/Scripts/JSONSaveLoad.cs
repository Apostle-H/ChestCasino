using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JSONSaveLoad
{
    public static string inventorySavePath = Application.persistentDataPath + "InventorySave.JSON";
    public static string poolSavePath = Application.persistentDataPath + "PoolSave.JSON";

    public static void WriteInventoryJSON()
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;

        using (StreamWriter sw = new StreamWriter(inventorySavePath))
        using (JsonWriter jsonWriter = new JsonTextWriter(sw))
        {
            serializer.Serialize(jsonWriter, Inventory.Instance.storedItems);
        }
    }

    public static void WritePoolJSON()
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;

        using (StreamWriter sw = new StreamWriter(poolSavePath))
        using (JsonWriter jsonWriter = new JsonTextWriter(sw))
        {
            serializer.Serialize(jsonWriter, ItemsPool.Instance.pool);
        }
    }

    public static Item[] ReadInventoryJSON()
    {
        if (!File.Exists(inventorySavePath))
            return null;

        Item[] storedItems;
        using (StreamReader file = File.OpenText(inventorySavePath))
        {
            JsonSerializer serializer = new JsonSerializer();
            storedItems = serializer.Deserialize(file, typeof(Item[])) as Item[];

            return storedItems;
        }
    }

    public static Item[] ReadPoolJSON()
    {
        if (!File.Exists(poolSavePath))
            return null;

        Item[] poolItems;
        using (StreamReader file = File.OpenText(poolSavePath))
        {
            JsonSerializer serializer = new JsonSerializer();
            poolItems = serializer.Deserialize(file, typeof(Item[])) as Item[];

            return poolItems;
        }
    }
}
