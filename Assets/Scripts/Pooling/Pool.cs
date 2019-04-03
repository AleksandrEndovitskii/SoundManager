using UnityEngine;

namespace Pooling
{
    public static class Pool
    {
        public static GameObject Spawn(GameObject prefab)
        {
            return Object.Instantiate(prefab);
        }

        public static T Spawn<T>(T prefab)
            where T : Component
        {
            return Object.Instantiate(prefab);
        }

        public static void Despawn(GameObject clone)
        {
            Object.Destroy(clone);
        }
    }
}
