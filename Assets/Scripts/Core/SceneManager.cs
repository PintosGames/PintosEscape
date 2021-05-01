﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using sm = UnityEngine.SceneManagement;

namespace Core
{
    public class SceneManager : MonoBehaviour
    {
        public int currentBuildIndex;

        public List<Scene> scenes;

        public static SceneManager current;
        public int sceneCount;

        void Awake()
        {
            if (current == null)
            {
                current = this;
            }
            else
            {
                Destroy(gameObject);
            }

            if (sm.SceneManager.sceneCount == 1)
            {
                LoadScene(1);
            }
        }

        private void Update()
        {
            sceneCount = sm.SceneManager.sceneCount;
        }

        public static void LoadScene(int sceneBuildIndex)
        {
            sm.SceneManager.sceneLoaded += OnLevelFinishedLoading;

            var buildIndex = sm.SceneManager.GetActiveScene().buildIndex;

            sm.SceneManager.UnloadSceneAsync(current.currentBuildIndex);

            sm.SceneManager.LoadScene(sceneBuildIndex, sm.LoadSceneMode.Additive);
            current.currentBuildIndex = sceneBuildIndex;

            CoreManager.current.discord.SetPresence(new DiscordPresence()
            {
                details = current.scenes[current.currentBuildIndex].details,
                state = current.scenes[current.currentBuildIndex].state,
                largeAsset = new DiscordAsset()
                {
                    tooltip = current.scenes[current.currentBuildIndex].largeText,
                    image = current.scenes[current.currentBuildIndex].largeKey
                }
            });
        }

        static void OnLevelFinishedLoading(sm.Scene scene, sm.LoadSceneMode mode)
        {
            if (!current.scenes[current.currentBuildIndex].menuScene)
            {
                Debug.Log("Level Loaded");
            }

            sm.SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }


        public static void LoadNextScene() => LoadScene(current.currentBuildIndex + 1);
        public static void LoadPreviousScene() => LoadScene(current.currentBuildIndex - 1);

        public static string NameFromIndex(int BuildIndex)
        {
            string path = sm.SceneUtility.GetScenePathByBuildIndex(BuildIndex);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }

        public static sm.Scene GetScene(int buildIndex) => sm.SceneManager.GetSceneByBuildIndex(buildIndex);
        public static sm.Scene GetScene(string name) => sm.SceneManager.GetSceneByName(name);

        [System.Serializable]
        public class Scene
        {
            [Header("Basic Info")]
            public string name;
            public int buildIndex;
            public bool menuScene;

            [Header("Discord Info")]
            public string details;
            public string state;
            public string largeKey;
            public string largeText;
        }
    }

}