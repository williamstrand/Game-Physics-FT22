using UnityEngine;

namespace PlayerComponents
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] float jumpForce = 10;
        [SerializeField] float acceleration = 25;
        [SerializeField] LayerMask groundLayer;

        public void Move(Vector3 direction, float speed)
        {
            if (direction.sqrMagnitude == 0) return;

            var velocity = direction * speed;
            var targetVelocity = new Vector3(velocity.x, rigidbody.velocity.y, velocity.z);
            rigidbody.velocity = Vector3.MoveTowards(rigidbody.velocity, targetVelocity, acceleration * Time.deltaTime);
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