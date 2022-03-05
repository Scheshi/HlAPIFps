using UnityEngine;
using UnityEngine.Networking;


public class EntityPhisycController : NetworkBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float moveSpeed = 3;

    private void Start()
    {
        if(!isLocalPlayer)
            mainCamera.gameObject.SetActive(false);
    }

    public void Move(float xAxis, float zAxis)
    {
        Vector3 right = transform.right * xAxis;
        Vector3 forward = transform.forward * zAxis;
        Vector3 velocity = (right + forward) * moveSpeed;
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }

    public void Rotate(float yaw, float pitch)
    {
        Vector3 rotation = mainCamera.transform.rotation.eulerAngles;
        rotation.x -= pitch;
        mainCamera.transform.rotation = Quaternion.Euler(rotation);
        rotation = transform.rotation.eulerAngles;
        rotation.y += yaw;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
