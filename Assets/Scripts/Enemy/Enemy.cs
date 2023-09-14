using UnityEngine;
using UnityEngine.Audio;

namespace KingOfHill
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _mesh;
        [SerializeField]
        private Rigidbody _rigidbody;

        public void Init()
        {
            var collisionChecker = gameObject.AddComponent<CollisionChecker>();
            var audioSource = GetComponent<AudioSource>();
            new EnemySoundSystem(audioSource, collisionChecker);

            gameObject.SetActive(false);
        }

        public void SetStartParameters(Transform target)
        {
            var direction = -transform.position + target.position;
            _rigidbody.velocity = direction ;
            SetRandomColor();
        }

        private void SetRandomColor()
        {
            _mesh.material.SetColor("_Color", new Color(
                Random.Range(0, 255) / 256f, 
                Random.Range(0, 255) / 256f, 
                Random.Range(0, 255) / 256f));
        }

        public void CustomDestroy()
        {
            gameObject.SetActive(false);
        }
    }
}

