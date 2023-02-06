using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerModel player;
        [SerializeField] private Joystick horizontalJoystick;
        [SerializeField] private Joystick verticalJoystick;
        private void FixedUpdate()
        {
            var horizontal = horizontalJoystick.Horizontal * player.RotationSpeed * Time.fixedDeltaTime * player.Deceleration;
            var vertical = verticalJoystick.Vertical * player.Sped * Time.fixedDeltaTime* player.Deceleration;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                horizontal = player.Acceleration * horizontal;
                vertical = player.Acceleration * vertical;
            }

            transform.Translate(0f, 0f, vertical);
            transform.Rotate(0f, horizontal, 0f);
        }
    }
}