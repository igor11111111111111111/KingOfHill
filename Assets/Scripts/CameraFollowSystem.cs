using UnityEngine;

namespace KingOfHill
{
    public class CameraFollowSystem : MonoBehaviour
    {
        private Player _player;
        private Camera _camera;
        private Vector3 _offset = new Vector3(6, 5, 4.5f);

        public void Init(Player player, Camera camera)
        {
            _player = player;
            _camera = camera;
        }

        private void Update()
        {
            if (_player == null)
                return;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y) + _offset, 1);
        }
    }
}

