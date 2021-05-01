using UnityEngine;
using UnityEditor;
using sm = UnityEngine.SceneManagement;
using Core.SaveSystem;

namespace Core
{
    [ExecuteInEditMode] [RequireComponent(typeof(DiscordManager), typeof(SaveManager), typeof(SceneManager))]
    public class CoreManager : MonoBehaviour
    {
        public static CoreManager current;

        [Header("Managers")]
        public DiscordManager discord;

        public SaveManager save;
        public SceneManager scene;

        void Awake()
        {
            if (current == null)
            {
                current = this;
            }
            else
            {
                Destroy(this);
            }
        }

        void Start()
        {
        }

        private void Update()
        {
            for (int i = 0; i < save.saveFiles.Count; i++) save.saveFiles[i].name = $"SaveFile {i}";

            for (int i = 0; i < sm.SceneManager.sceneCountInBuildSettings; i++)
            {
                if (!scene.scenes.Exists(x => x.buildIndex == i))
                {
                    scene.scenes.Add(new SceneManager.Scene { name = SceneManager.NameFromIndex(i), buildIndex = i, details = "Exploring " + SceneManager.NameFromIndex(i) });
                }
                else
                {
                    scene.scenes[i] = new SceneManager.Scene
                    {
                        name = SceneManager.NameFromIndex(i),
                        buildIndex = i,
                        menuScene = scene.scenes[i].menuScene,
                        details = scene.scenes[i].details,
                        state = scene.scenes[i].state,
                        largeKey = scene.scenes[i].largeKey,
                        largeText = scene.scenes[i].largeText
                    };
                }
            }
        }
    }
}