using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SoundManager soundManagerPrefab;

        private SoundManager _soundManagerInstance;

        // Start is called before the first frame update
        private void Start()
        {
            _soundManagerInstance = Instantiate(soundManagerPrefab);
        }

        // Update is called once per frame
        private void Update()
        {
        
        }
    }
}
