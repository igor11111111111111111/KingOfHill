using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KingOfHill
{
    public class EnemyPool
    {
        private List<Enemy> _enemys;
        private Enemy _prefab;
        private Transform _parent;
        private MoveStairsSystem _stairs;

        public EnemyPool(Enemy prefab, int size, Transform parent, MoveStairsSystem stairs)
        {
            _enemys = new List<Enemy>();
            _prefab = prefab;
            _parent = parent;
            _stairs = stairs;

            for (int i = 0; i < size; i++)
            {
                Create();
            }
        }

        public Enemy Get()
        {
            Enemy enemy = null;
            try
            {
                enemy = _enemys
                .Where(b => b != null && b.gameObject.activeInHierarchy == false)
                .First();
                enemy.gameObject.SetActive(true);
            }
            catch (System.Exception)
            {

            }

            if (enemy == null)
            {
                enemy = Create();
                enemy.gameObject.SetActive(true);
            }

            Vector3 offset = new Vector3(0.5f, 2, Random.Range(-2f, 2f));
            enemy.transform.position = _stairs.GetUpperPoint() + offset;

            return enemy;
        }

        private Enemy Create()
        {
            var enemy = Object.Instantiate(_prefab, _parent);
            enemy.gameObject.SetActive(false);
            _enemys.Add(enemy);
            return enemy;
        }
    }
}

