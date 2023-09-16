using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class EnemySpawner
    {
        private EnemyPool _enemyPool;
        private int _cdTime = 2000;
        private Transform _target;

        [Inject]
        public void Init(EnemyPool enemyPool, Player player)
        {
            _enemyPool = enemyPool;
            _target = player.transform;
            SpawnLoop();
        }

        private async void SpawnLoop()
        {
            while (true)
            {
                if (_target == null)
                    break;
                _enemyPool.Get().SetStartParameters(_target);
                await Task.Delay(_cdTime);
            }
        }
    }
}

