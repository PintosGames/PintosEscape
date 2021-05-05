using UnityEngine;
using UnityEditor;
using sm = UnityEngine.SceneManagement;
using Core.SaveSystem;
using Core.HealthSystem;
using Core.DialogueSystem;

namespace Core
{
    [ExecuteInEditMode]
    public class CoreManager : MonoBehaviour
    {
        public static CoreManager current;

        public Player player;
        public bool inGame = false;

        public Animator gameOverAnimator;

        [Header("Managers")]
        public DiscordManager discord;

        public SaveManager save;
        public SceneManager scene;

        public HealthManager health;
        public DialogueManager dialogue;

        public PauseManager pause;

        [Header("DiscordRP")]
        public DiscordPresence presence;


    void Awake()
        {
            FindObjectOfType<AudioManager>().onSoundsLoaded += SoundsLoaded;

            if (current == null)
            {
                current = this;
            }
            else
            {
                Destroy(this);
            }

            Debug.Log(sm.SceneManager.GetActiveScene().name + sm.SceneManager.GetActiveScene().buildIndex);

            scene.currentBuildIndex = sm.SceneManager.GetActiveScene().buildIndex;

            if (scene.scenes[scene.currentBuildIndex].gameScene)
            {
                current.inGame = true;
                current.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }

            UpdatePresence();
        }

        private void SoundsLoaded(object sender, System.EventArgs e)
        {
            Debug.Log("sounds are loaded");

            if (scene.currentBuildIndex == 2)
            {
                FindObjectOfType<AudioManager>().Play("Song2");
            }
            else if (scene.currentBuildIndex == 3)
            {
                FindObjectOfType<AudioManager>().Play("Song1");
            }
            else if (scene.currentBuildIndex == 4)
            {
                FindObjectOfType<AudioManager>().Play("Song2");
            }
            else if (scene.currentBuildIndex == 5)
            {
                FindObjectOfType<AudioManager>().Play("Song1");
            }
            else if (scene.currentBuildIndex == 6)
            {
                FindObjectOfType<AudioManager>().Play("Credits");
            }
            else if (scene.currentBuildIndex == 7)
            {
                FindObjectOfType<AudioManager>().Play("Menu");
            }
        }

        #region FUF

        public static void DamagePlayer() => current.health.healthSystem.Damage();
        public static void HealPlayer() => current.health.healthSystem.Heal();
        public static void KnockbackPlayer(int enemyFacingDirection)
        {
            if (current.health.healthSystem.health != 0)
            {
                var player = current.player;
                if (player.FacingDirection != enemyFacingDirection) player.RB.AddForce(new Vector2(-player.playerData.knockbackPower * player.FacingDirection, player.playerData.knockbackPower));
                if (player.FacingDirection == enemyFacingDirection) player.RB.AddForce(new Vector2(player.playerData.knockbackPower * player.FacingDirection, player.playerData.knockbackPower));
            }
        }

        public static void GameOver()
        {
            current.gameOverAnimator.SetBool("open", true);
        }

        public static void UpdatePresence()
        {
            string state;
            if (current.scene.scenes[current.scene.currentBuildIndex].gameScene == true) state = current.health.healthSystem.health + " hearts left";
            else state = null;

            var presence = current.presence;

            presence.details = current.scene.scenes[current.scene.currentBuildIndex].details;
            presence.state = state;

            current.discord.SetPresence(presence);
        }

        #endregion

        private void Update()
        {

#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
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
                            gameScene = scene.scenes[i].gameScene,
                            details = scene.scenes[i].details,
                            state = scene.scenes[i].state,
                            largeKey = scene.scenes[i].largeKey,
                            largeText = scene.scenes[i].largeText
                        };
                    }
                }
            }
#endif
            if (inGame)
            {
                GetComponent<HealthSystem.HealthManager>().enabled = true;
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            }
            else
            {
                GetComponent<HealthSystem.HealthManager>().enabled = false;
            }
        }
    }
}