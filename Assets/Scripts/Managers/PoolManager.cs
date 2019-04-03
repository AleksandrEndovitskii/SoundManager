using Pooling;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class PoolManager : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private GameObjectPool _audioSourcePoolPrefab;
        [SerializeField]
        private GameObjectPool _randomlyMovedObjectPoolPrefab;

        public void Initialize()
        {
            Instantiate(_audioSourcePoolPrefab);
            Instantiate(_randomlyMovedObjectPoolPrefab);
        }

        public void Uninitialize()
        {
            
        }
    }
}
