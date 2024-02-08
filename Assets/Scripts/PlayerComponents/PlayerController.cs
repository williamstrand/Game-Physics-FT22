using UnityEngine;

namespace PlayerComponents
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] MovementComponent movementComponent;
        [SerializeField] CameraComponent cameraComponent;
        [SerializeField] ShootComponent shootComponent;

        [SerializeField] float speed = 5;
        [SerializeField] float cameraSpeed = 5;

        void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var direction = transform.forward;
                direction.y = cameraComponent.CameraForward.y;
                shootComponent.Shoot(cameraComponent.CameraPosition, direction);
            }
        }

        void FixedUpdate()
        {
            var cameraDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            cameraComponent.Rotate(cameraDirection, cameraSpeed * Time.fixedDeltaTime);

            var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var translatedDirection = direction.x * Vector3.right + direction.y * Vector3.forward;
            movementComponent.Move(translatedDirection, speed * Time.fixedDeltaTime);
        }
    }
}