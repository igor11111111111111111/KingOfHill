using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KingOfHill
{
    public class MobileInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Action<Vector2> OnMove;
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _minDistance = 30;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _endPosition = eventData.position;

            if (Mathf.Abs(_startPosition.x - _endPosition.x) <= _minDistance &&
                Mathf.Abs(_startPosition.y - _endPosition.y) <= _minDistance)
            {
                OnMove?.Invoke(Vector2.zero);
            }
            else
            {
                OnMove?.Invoke(new Vector2(
                    Mathf.Sign(_endPosition.x - _startPosition.x),
                    Mathf.Sign(_endPosition.y - _startPosition.y)));
            }
        }
    }
}

