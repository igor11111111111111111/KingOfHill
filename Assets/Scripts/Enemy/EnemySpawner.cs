using System.Collections;
using UnityEngine;

namespace KingOfHill
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        private float _cdTime;
        private Player _player;

        public EnemySpawner Init(EnemyPool enemyPool, Player player)
        {
            _enemyPool = enemyPool;
            _player = player;
            _cdTime = 2f;
            return this;
        }

        public void StartSpawn()
        {
            StartCoroutine(nameof(SpawnLoop));
        }

        private IEnumerator SpawnLoop()
        {
            while (true)
            {
                if (_player == null)
                    break;
                _enemyPool.Get().Init(_player.transform);
                yield return new WaitForSeconds(_cdTime);
            }
        }
    }
}

