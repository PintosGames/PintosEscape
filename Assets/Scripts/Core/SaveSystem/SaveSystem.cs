using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core.SaveSystem
{
    public static class SaveSystem
    {
        public static void SavePlayer(int saveFile)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/" + SaveManager.current.saveFiles[saveFile].filepath;
            FileStream stream = new FileStream(path, FileMode.Create);

            SaveData data = new SaveData();

            // Get data and put them in "data"

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static SaveData LoadPlayer(int saveFile)
        {
            string path = Application.persistentDataPath + "/" + SaveManager.current.saveFiles[saveFile].filepath;
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SaveData data = formatter.Deserialize(stream) as SaveData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Save file not found in (" + path + ")");
                return null;
            }
        }
    }
}
