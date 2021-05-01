using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.SaveSystem
{
    public class SaveManager : MonoBehaviour
    {

        public List<SaveFiles> saveFiles;

        public static void LoadGame(int saveFile)
        {
            SaveData data = SaveSystem.LoadPlayer(saveFile);
            // Convert basic variables to Unity variables and apply them
        }

        public static void SaveGame(int saveFile)
        {
            Debug.LogError("Saving Data...");
            SaveSystem.SavePlayer(saveFile);
            Debug.LogError("Data Saved");
        }

        [System.Serializable]
        public class SaveFiles
        {
            public string name;
            public string filepath;

            [Space(10)]

            public SaveData data;
        }
    }
}