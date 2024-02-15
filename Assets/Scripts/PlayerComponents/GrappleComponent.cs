using UnityEngine;

namespace PlayerComponents
{
    public class GrappleComponent : MonoBehaviour
    {
        [SerializeField] LayerMask hitLayer;
        [SerializeField] float grappleSpeed = 10;
        [SerializeField] float grappleRange = 100;
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] LineRenderer lineRenderer;

        Vector3 grappledPosition;
        public bool IsGrappled { get; private set; }


        public void Shoot(Vector3 origin, Vector3 direction)
        {
            var ray = new Ray(origin, direction);
            var hit = Physics.Raycast(ray, out var hitInfo, grappleRange, hitLayer);

            if (!hit) return;

            var hitPosition = hitInfo.point;
            grappledPosition = hitPosition;
            IsGrappled = true;
            rigidbody.useGravity = false;

            lineRenderer.positionCount = 2;
        }


        public void LetGo()
        {
            if (!IsGrappled) return;

            IsGrappled = false;
            rigidbody.useGravity = true;
            lineRenderer.positionCount = 0;
        }

        void Update()
        {
            if (transform.position.y >= grappledPosition.y)
            {
                LetGo();
            }
        }

        void FixedUpdate()
        {
            if (!IsGrappled) return;

            var direction = (grappledPosition - transform.position).normalized;

            rigidbody.AddForce(direction * grappleSpeed, ForceMode.VelocityChange);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, grappledPosition);
        }
    }
}