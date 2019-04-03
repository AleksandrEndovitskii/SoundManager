using System;
using UnityEngine;

namespace Pooling
{
    public static class Pool
    {
        public static GameObject Spawn(GameObject prefab)
        {
            if (prefab == null)
            {
                throw new ArgumentNullException("prefab", "Can't instantiate null prefab.");
            }

            var gameObjectPool = GameObjectPool.GetPoolByPrefab(prefab);

            var instance = gameObjectPool.Spawn();

            return instance;
        }

        public static T Spawn<T>(T prefab)
            where T : Component
        {
            return Spawn(prefab.gameObject).GetComponent<T>();
        }

        public static void Despawn(GameObject instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("prefab", "Can't destroy null instance.");
            }

            var gameObjectPool = GameObjectPool.GetPoolByInstance(instance);

            gameObjectPool.Despawn(instance);
        }

        public static void Despawn<T>(T instance)
            where T : Component
        {
            Despawn(instance.gameObject);
        }
    }
}
