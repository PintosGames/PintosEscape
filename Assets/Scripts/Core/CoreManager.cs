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
        public bool inGame;

        public Animator gameOverAnimator;

        [Header("Managers")]
        public DiscordManager discord;

        public SaveManager save;
        public SceneManager scene;

        public HealthManager health;
        public DialogueManager dialogue;

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

        #region FUF

        public static void DamagePlayer() => current.health.healthSystem.Damage();
        public static void HealPlayer() => current.health.healthSystem.Heal();
        public static void KnockbackPlayer(int enemyFacingDirection)
        {
            var player = current.player;
            if (player.FacingDirection != enemyFacingDirection) player.RB.AddForce(new Vector2(-player.playerData.knockbackPower * player.FacingDirection, player.playerData.knockbackPower));
            if (player.FacingDirection == enemyFacingDirection) player.RB.AddForce(new Vector2(player.playerData.knockbackPower * player.FacingDirection, player.playerData.knockbackPower));
        }

        public static void GameOver()
        {
            current.gameOverAnimator.SetBool("open", true);
        }

        #endregion

        private void Update()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

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
            if (!inGame)
            {
                GetComponent<HealthSystem.HealthManager>().enabled = false;
            }
            else
            {
                GetComponent<HealthSystem.HealthManager>().enabled = true;
            }
        }
    }
}