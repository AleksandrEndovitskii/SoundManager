using UnityEngine;

namespace GameObjects
{
    public class RandomDirectionMover : MonoBehaviour
    {
        [SerializeField]
        private float Speed = 1f;

        private Vector3 _direction;

        private void Start()
        {
            var randomX = Random.Range(-1.0f, 1.0f);
            var randomZ = Random.Range(-1.0f, 1.0f);
            var randomDirection = (new Vector3(randomX, 0.0f, randomZ)).normalized;
            _direction = randomDirection;
        }

        private void Update()
        {
            transform.position += _direction * Speed * Time.deltaTime;
        }
    }
}
