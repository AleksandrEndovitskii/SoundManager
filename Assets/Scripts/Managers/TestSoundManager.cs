using System.Collections;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class TestSoundManager : MonoBehaviour, IInitializable, IUninitializable
    {
        private Coroutine _stopwatchCoroutine;

        private static System.Random _random = new System.Random();

        private IEnumerator Countdown()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                PerformRandomAction();
            }
        }

        private void PerformRandomAction()
        {
            var actionIndex = _random.Next(0, 3);

            var randomSoundName = GameManager.Instance.SoundManagerInstance.GetRandomSoundName();

            switch (actionIndex)
            {
                case 0:
                    GameManager.Instance.SoundManagerInstance.PlaySound2D(randomSoundName, 1, true);
                    break;
                case 1:
                    var go = GameManager.Instance.GameObjectManagerInstance.CreateRandomlyMovedGameObject();
                    GameManager.Instance.SoundManagerInstance.PlaySound3D(randomSoundName, 1, true, go, true);
                    break;
                case 2:
                    if (GameManager.Instance.SoundManagerInstance.IsPlayingSomething)
                    {
                        GameManager.Instance.SoundManagerInstance.StopSound(GameManager.Instance.SoundManagerInstance.GetRandomcurrentlyPlaingAudioSourceName()); 
                    }
                    break;
            }
        }

        public void Initialize()
        {
            _stopwatchCoroutine = StartCoroutine(Countdown());
        }

        public void Uninitialize()
        {
            if (_stopwatchCoroutine != null)
            {
                StopCoroutine(_stopwatchCoroutine);
                _stopwatchCoroutine = null;
            }
        }
    }
}
