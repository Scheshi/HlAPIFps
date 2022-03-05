using UnityEngine;
using UnityEngine.Networking;

namespace Src.Features.Shoot
{
    public class RaycastShooting: NetworkBehaviour
    {
        [SerializeField] private Camera mainCamera;
        private RaycastHit[] _hits = new RaycastHit[3];
        public void Shoot()
        {
            Ray centerPoint = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            ShootAuthoritary(centerPoint, 10);
        }

        [Command]
        private void ShootAuthoritary(Ray ray, int damage)
        {
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                hitInfo.rigidbody?.AddForce(-hitInfo.normal);
                    if (hitInfo.transform.TryGetComponent(out Damagable damagable))
                        damagable.DamageAuthoritary(damage);
            }
        }
    }
}