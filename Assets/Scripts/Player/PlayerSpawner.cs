using UnityEngine;

namespace KingOfHill
{
    public class PlayerSpawner
    {
        private Player _playerPrefab;
        public PlayerSpawner(Player playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public Player Create()
        {
            return Object.Instantiate(_playerPrefab, new Vector3(-4, 5, 0), Quaternion.identity);
        }
    }
}

