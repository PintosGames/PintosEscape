using UnityEngine;
using UnityEditor;
using Core.SaveSystem;

namespace Core
{
    [ExecuteInEditMode]
    public class CoreManager : MonoBehaviour
    {
        public static CoreManager current;

        public CoreManagers managers;

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
            for (int i = 0; i < managers.save.saveFiles.Count; i++) managers.save.saveFiles[i].name = $"SaveFile {i}";
        }

        [System.Serializable]
        public class CoreManagers
        {
            public SaveManager save;
        }
    }
}