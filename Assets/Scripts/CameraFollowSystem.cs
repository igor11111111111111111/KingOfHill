using UnityEngine;

namespace KingOfHill
{
    public class CameraFollowSystem : MonoBehaviour
    {
        private Transform _target;
        private Camera _camera;
        private Vector3 _offset = new Vector3(6, 5, 4.5f);

        public void Init(Transform target, Camera camera)
        {
            _target = target;
            _camera = camera;
        }

        private void Update()
        {
            if (_target == null)
                return;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(_target.position.x, _target.position.y) + _offset, 1);
        }
    }
}

