using System.Collections;
using UnityEngine;

namespace KingOfHill
{
    public class PlayerMoveSystem : MonoBehaviour
    {
        private Vector3 _oldPosition;
        private Rigidbody _rigidbody;
        private PlayerTrigger _trigger;

        public void Init(MobileInput input, Rigidbody rigidbody, PlayerTrigger trigger)
        {
            _rigidbody = rigidbody;
            _trigger = trigger;

            trigger.OnLandedNewRung += () =>
            {
                _rigidbody.velocity = Vector3.zero;
                transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, transform.position.z);
            };
            input.OnMove += Move;
        }

        private void Move(Vector2 direction)
        {
            if (!_trigger.IsGrounded || _rigidbody == null)
                return;

            if (direction == Vector2.zero)
            {
                _rigidbody.AddForce(new Vector3(0f, 6f, 0), ForceMode.Impulse);
                _oldPosition = transform.position;
                StartCoroutine(nameof(HorizontalMove));
            }
            else if (direction.x == -1)
            {
                _rigidbody.AddForce(new Vector3(0, 3, -2), ForceMode.Impulse);
            }
            else if (direction.x == 1)
            {
                _rigidbody.AddForce(new Vector3(0, 3, 2), ForceMode.Impulse);
            }
        }

        private IEnumerator HorizontalMove()
        {
            while (true)
            {
                if (transform.position.y - _oldPosition.y >= 1.2f)
                {
                    _rigidbody.velocity += new Vector3(-1.5f, 0, 0);

                    break;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}

