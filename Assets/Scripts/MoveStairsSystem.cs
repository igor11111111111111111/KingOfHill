using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KingOfHill
{
    public class MoveStairsSystem : MonoBehaviour
    {
        [SerializeField]
        private Rung _rungPrefab;
        private List<Rung> _allRungs;

        public void Init(PlayerTrigger trigger)
        {
            _allRungs = new List<Rung>();
            for (int i = 0; i < 13; i++)
            {
                var rung = Instantiate(_rungPrefab, new Vector3(-i, i, 0), Quaternion.identity, transform);
                _allRungs.Add(rung);
            }

            trigger.OnLandedNewRung += Move;
        }

        private void Move()
        {
            GetLowerRung().transform.position = GetUpperRung().transform.position + new Vector3(-1, 1, 0);
        }

        public Vector3 GetUpperPoint()
        {
            return GetUpperRung().transform.position;
        }

        public Vector3 GetLowerPoint()
        {
            return GetLowerRung().transform.position;
        }

        private Rung GetUpperRung()
        {
            return _allRungs.OrderByDescending(rung => rung.transform.position.y).First();
        }

        private Rung GetLowerRung()
        {
            return _allRungs.OrderBy(rung => rung.transform.position.y).First();
        }
    }
}

