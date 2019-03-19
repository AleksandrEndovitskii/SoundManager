using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameObjectManager : MonoBehaviour, IInitializable, IUninitializable
    {
        [SerializeField]
        private GameObject gameObjectPrefab;

        public void Initialize()
        {
            
        }

        public void Uninitialize()
        {
            
        }
    }
}
