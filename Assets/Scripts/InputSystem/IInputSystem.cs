using System;
using UnityEngine;

namespace KingOfHill
{
    public interface IInputSystem
    {
        public Action<Vector2> OnMove { get; set; }
    }
}

