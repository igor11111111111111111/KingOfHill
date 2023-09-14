using System.Collections;
using UnityEngine;

namespace KingOfHill
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        private float _cdTime;
        private Transform _target;

        public EnemySpawner Init(EnemyPool enemyPool, Transform target)
        {
            _enemyPool = enemyPool;
            _target = target;
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
                if (_target == null)
                    break;
                _enemyPool.Get().SetStartParameters(_target);
                yield return new WaitForSeconds(_cdTime);
            }
        }
    }
}

