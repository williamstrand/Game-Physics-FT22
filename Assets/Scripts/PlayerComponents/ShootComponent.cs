using UnityEngine;

namespace PlayerComponents
{
    public class ShootComponent : MonoBehaviour
    {
        [SerializeField] LayerMask hitLayer;

        public void Shoot(Vector3 origin, Vector3 direction)
        {
            Debug.DrawRay(origin, direction * 100, Color.red, 1);
            var ray = new Ray(origin, direction);
            var hit = Physics.Raycast(ray, out var hitInfo, 100, hitLayer);

            if (!hit) return;

            var hitPosition = hitInfo.point;
            transform.position = hitPosition;
        }
    }
}