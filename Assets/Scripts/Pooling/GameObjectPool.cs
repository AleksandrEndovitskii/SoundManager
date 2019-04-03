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

        // в начале создаёться пулл определённого размера
        // в процессе работы если места мало - увеличить
        //                   если места много - уменьшить
        [SerializeField]
        public int capacity;

        public static GameObjectPool GetPoolByPrefab(GameObject prefab)
        {
            var result = Instances.FirstOrDefault(x => x.gameObjectPrefab == prefab);

            if (result == null)
            {
                throw new ArgumentException("No GameObjectPool for specified prefab.");
            }

            return result;
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

            var instance = Object.Instantiate(gameObjectPrefab);

            return instance;
        }
    }
}
