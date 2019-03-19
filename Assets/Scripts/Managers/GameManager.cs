using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SoundManager soundManagerPrefab;
        [SerializeField]
        private GameObjectManager gameObjectManagerPrefab;

        private SoundManager _soundManagerInstance;
        private GameObjectManager _gameObjectManagerInstance;

        // Start is called before the first frame update
        private void Start()
        {
            _soundManagerInstance = Instantiate(soundManagerPrefab);
            _gameObjectManagerInstance = Instantiate(gameObjectManagerPrefab);
        }

        // Update is called once per frame
        private void Update()
        {
        
        }
    }
}
