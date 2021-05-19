using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/" + player.name + ".bin";
        string path = Application.persistentDataPath + "/player.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        /*
        BinaryFormatter formatter_savesFile = new BinaryFormatter();
        string path_savesFile = Application.persistentDataPath + "/saves.dat";
        FileStream save_stream = new FileStream(path_savesFile, FileMode.Create);

        string save_data = System.DateTime.Now + "  " + player.name;

        formatter_savesFile.Serialize(save_stream, save_data);
        save_stream.Close();

        make a savefile static class to save saves a list of strings("filename" ==> player.name) and load them 
        then make a load game instead of continue then in that scene we will have 
        a list of saves generated from the savefile 
        */
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }

   
}
