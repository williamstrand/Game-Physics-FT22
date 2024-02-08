using UnityEngine;

namespace PlayerComponents
{
    public class CameraComponent : MonoBehaviour
    {
        [SerializeField] new Camera camera;

        public void Rotate(Vector2 rotation, float speed)
        {
            transform.Rotate(Vector3.up, rotation.x * speed);
            camera.transform.Rotate(Vector3.right, -rotation.y * speed);
        }
    }
}