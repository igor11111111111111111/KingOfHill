using System;
using UnityEngine;

namespace KingOfHill
{
    public class EnemyDeathArea : DeathArea
    {
        public void Init(PlayerTrigger trigger, Stairs stairs)
        {
            trigger.OnLandedNewRung += () =>
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

