using Lean.Pool;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class PoolManager : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private LeanGameObjectPool _audioSourcePoolPrefab;
        [SerializeField]
        private LeanGameObjectPool _randomlyMovedObjectPoolPrefab;

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
