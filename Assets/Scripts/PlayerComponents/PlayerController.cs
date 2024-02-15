using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerComponents
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] MovementComponent movementComponent;
        [SerializeField] CameraComponent cameraComponent;
        [FormerlySerializedAs("shootComponent")][SerializeField]
        GrappleComponent grappleComponent;

        [SerializeField] float speed = 5;
        [SerializeField] float cameraSpeed = 5;

        void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            var cameraDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            cameraComponent.Rotate(cameraDirection, cameraSpeed * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                grappleComponent.Shoot(cameraComponent.CameraPosition, cameraComponent.CameraForward);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grappleComponent.IsGrappled)
                {
                    grappleComponent.LetGo();
                }
                else
                {
                    movementComponent.Jump();
                }
            }

            if (grappleComponent.IsGrappled) return;

            var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var right = Vector3.Cross(Vector3.up, cameraComponent.CameraForward);
            var translatedDirection = direction.x * right + direction.y * cameraComponent.CameraForward;
            movementComponent.Move(translatedDirection, speed);
        }
    }
}