using UnityEngine;

namespace KingOfHill
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _mesh;
        [SerializeField]
        private Rigidbody _rigidbody;

        public void Init(Transform target)
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

