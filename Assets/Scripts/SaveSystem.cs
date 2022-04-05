using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.hax";
        FileStream stream = new FileStream(path, FileMode.Create);

        Com.GCTC.Imprecision.SaveData data = new Com.GCTC.Imprecision.SaveData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Com.GCTC.Imprecision.SaveData LoadPlayer(string playerId)
    {
        string path = Application.persistentDataPath + "/playerData.hax";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Com.GCTC.Imprecision.SaveData data = formatter.Deserialize(stream) as Com.GCTC.Imprecision.SaveData;
            stream.Close();

            if(data.playerId != playerId)
            {
                data.playerId = playerId;
            }

            return data;
        }
        else
        {
            Com.GCTC.Imprecision.SaveData data = new Com.GCTC.Imprecision.SaveData(playerId);
            return data;
        }
    }
    
}
