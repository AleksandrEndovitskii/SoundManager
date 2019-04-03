using UnityEngine;

namespace Pooling
{
    public class GameObjectPool : MonoBehaviour
    {
        [SerializeField]
        public GameObject gameObjectPrefab;

        // в начале создаёться пулл определённого размера
        // в процессе работы если места мало - увеличить
        //                   если места много - уменьшить
        [SerializeField]
        public int capacity;
    }
}
