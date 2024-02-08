using UnityEngine;

namespace PlayerComponents
{
    public class MovementComponent : MonoBehaviour
    {
        public void Move(Vector3 direction, float speed)
        {

            transform.Translate(direction * speed);
        }
    }
}