using UnityEngine;

namespace PlayerComponents
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] float jumpForce = 10;
        [SerializeField] LayerMask groundLayer;

        public void Move(Vector3 direction, float speed)
        {
            transform.Translate(direction * speed);
        }

        public void Jump()
        {
            if (!IsGrounded()) return;

            var velocity = rigidbody.velocity;
            rigidbody.velocity = new Vector3(velocity.x, jumpForce, velocity.z);
        }

        bool IsGrounded()
        {
            return Physics.CheckSphere(transform.position, .5f, groundLayer);
        }
    }
}