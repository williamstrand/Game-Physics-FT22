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
        }

        void FixedUpdate()
        {
            var cameraDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            cameraComponent.Rotate(cameraDirection, cameraSpeed * Time.fixedDeltaTime);

            if (grappleComponent.IsGrappled) return;

            var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var translatedDirection = direction.x * Vector3.right + direction.y * Vector3.forward;
            movementComponent.Move(translatedDirection, speed * Time.fixedDeltaTime);
        }
    }
}