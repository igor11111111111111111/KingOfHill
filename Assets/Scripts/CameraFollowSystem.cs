using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class CameraFollowSystem : MonoBehaviour
    {
        private Transform _target;
        private Camera _camera;
        private Vector3 _offset = new Vector3(6, 5, 4.5f);

        [Inject]
        public void Init(Player player, Camera camera)
        {
            _camera = camera;
            _target = player.transform;
        }

        private void Update()
        {
            if (_target == null)
                return;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(_target.position.x, _target.position.y) + _offset, 1);
        }
    }
}

