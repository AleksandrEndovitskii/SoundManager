using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pooling
{
    public class GameObjectPool : MonoBehaviour
    {
        public static List<GameObjectPool> Instances = new List<GameObjectPool>();

        [SerializeField]
        public GameObject gameObjectPrefab;

        [SerializeField]
        public int capacity = 3;

        [SerializeField]
        private List<GameObject> instantiatedGameObjects = new List<GameObject>();

        [SerializeField]
        private List<GameObject> storedGameObjects = new List<GameObject>();

        public static GameObjectPool GetPoolByPrefab(GameObject prefab)
        {
            var result = Instances.FirstOrDefault(x => x.gameObjectPrefab == prefab);

            if (result == null)
            {
                throw new ArgumentException("No GameObjectPool for specified prefab.");
            }

            return result;
        }

        public static GameObjectPool GetPoolByInstance(GameObject instance)
        {
            GameObjectPool result = null;

            foreach (var gameObjectPool in Instances)
            {
                foreach (var instantiatedGameObject in gameObjectPool.instantiatedGameObjects)
                {
                    if (instantiatedGameObject == instance)
                    {
                        result = gameObjectPool;
                    }
                }
            }

            if (result == null)
            {
                throw new ArgumentException("No GameObjectPool for specified instance.");
            }

            return result;
        }

        protected virtual void Awake()
        {
            PreloadInstances(capacity); // в начале создаёться пулл определённого размера
        }

        protected virtual void OnEnable()
        {
            Instances.Add(this);
        }

        protected virtual void OnDisable()
        {
            Instances.Remove(this);
        }

        public GameObject Spawn()
        {
            if (gameObjectPrefab == null)
            {
                throw new ArgumentNullException("gameObjectPrefab don't specified");
            }

            var instance = TryGetInstanceFromStore();

            if (instance == null)
            {
                instance = Object.Instantiate(gameObjectPrefab);
            }

            instantiatedGameObjects.Add(instance);

            return instance;
        }

        public void Despawn(GameObject instance)
        {
            instantiatedGameObjects.Remove(instance);

            StoreInstance(instance);
        }

        private void StoreInstance(GameObject instance)
        {
            if (storedGameObjects.Count < capacity) // в процессе работы если места мало - увеличить
            {
                storedGameObjects.Add(instance);
                instance.SetActive(false); 
            }
            else // если места много - уменьшить
            {
                Object.Destroy(instance);
            }
        }

        private GameObject TryGetInstanceFromStore()
        {
            GameObject instance = null;

            if (storedGameObjects.Any())
            {
                instance = storedGameObjects.First();
                storedGameObjects.Remove(instance);
                instance.SetActive(true);
            }

            return instance;
        }

        private void PreloadInstances(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var instance = Object.Instantiate(gameObjectPrefab);
                StoreInstance(instance);
            }
        }
    }
}
