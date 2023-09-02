using UnityEngine;

namespace KingOfHill
{
    public class PlayerSpawner
    {
        private Player _playerPrefab;
        private Vector3 _spawnPosition;

        public PlayerSpawner(Player playerPrefab)
        {
            _playerPrefab = playerPrefab;
            _spawnPosition = new Vector3(-4, 5, 0);
        }

        public Player Create(IInputSystem inputSystem)
        {
            return Object.Instantiate(_playerPrefab, _spawnPosition, Quaternion.identity)
                         .Init(inputSystem);
        }
    }
}

