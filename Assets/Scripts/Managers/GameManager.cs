using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameManager : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private SoundManager soundManagerPrefab;
        [SerializeField]
        private GameObjectManager gameObjectManagerPrefab;
        [SerializeField]
        private TestSoundManager testSoundManagerPrefab;
        [SerializeField]
        private PoolManager poolManagerPrefab;

        public SoundManager SoundManagerInstance;
        public GameObjectManager GameObjectManagerInstance;
        private TestSoundManager TestSoundManagerInstance;
        private PoolManager PoolManagerInstance;

        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(this.gameObject); // sets this to not be destroyed when reloading scene 
            }
            else
            {
                if (Instance != this)
                {
                    Instance.Uninitialize();

                    // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager 
                    Destroy(this.gameObject);
                }
            }

            Instance.Initialize();
        }

        public void Initialize()
        {
            SoundManagerInstance = Instantiate(soundManagerPrefab);
            SoundManagerInstance.Initialize();

            GameObjectManagerInstance = Instantiate(gameObjectManagerPrefab);
            GameObjectManagerInstance.Initialize();

            TestSoundManagerInstance = Instantiate(testSoundManagerPrefab);
            TestSoundManagerInstance.Initialize();

            PoolManagerInstance = Instantiate(poolManagerPrefab);
            PoolManagerInstance.Initialize();
        }

        public void Uninitialize()
        {
            SoundManagerInstance.Uninitialize();
            Destroy(SoundManagerInstance.gameObject);

            GameObjectManagerInstance.Initialize();
            Destroy(GameObjectManagerInstance.gameObject);

            TestSoundManagerInstance.Initialize();
            Destroy(TestSoundManagerInstance.gameObject);

            PoolManagerInstance.Initialize();
            Destroy(PoolManagerInstance.gameObject);
        }
    }
}
