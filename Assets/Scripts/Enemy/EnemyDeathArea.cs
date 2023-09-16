using System;
using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class EnemyDeathArea : MonoBehaviour
    {
        [Inject]
        private void Init(Player player, MoveStairsSystem stairs)
        {
            player.Trigger.OnLandedNewRung += () =>
            {
                transform.position = stairs.GetLowerPoint() + new Vector3(1, -2f, 0);
            };
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.CustomDestroy();
            }
        }
    }
}

