using Lean.Pool;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameObjectManager : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private GameObject gameObjectPrefab;

        [SerializeField]
        private GameObject _randomlyMovedGameObjectsContainerPrefab;

        private GameObject _randomlyMovedGameObjectsContainerInstance;

        public void Initialize()
        {
            _randomlyMovedGameObjectsContainerInstance = (_randomlyMovedGameObjectsContainerPrefab);
        }

        public void Uninitialize()
        {
            Destroy(_randomlyMovedGameObjectsContainerInstance.gameObject);
            _randomlyMovedGameObjectsContainerInstance = null;
        }

        public GameObject CreateRandomlyMovedGameObject()
        {
            var go = LeanPool.Spawn(gameObjectPrefab);
            go.gameObject.transform.SetParent(_randomlyMovedGameObjectsContainerInstance.transform);
            return go;
        }
    }
}
