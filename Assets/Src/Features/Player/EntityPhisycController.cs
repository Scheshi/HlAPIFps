using UnityEngine;
using UnityEngine.Networking;


public class EntityPhisycController : NetworkBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        if(!isLocalPlayer)
            mainCamera.gameObject.SetActive(false);
    }

    public void Move(float xAxis, float zAxis)
    {
        Vector3 velocity = rigidbody.velocity;
        velocity.x = xAxis;
        velocity.z = zAxis;
        rigidbody.velocity = velocity;
    }

    public void Rotate(float yaw, float pitch)
    {
        Vector3 rotation = mainCamera.transform.rotation.eulerAngles;
        rotation.x += yaw;
        mainCamera.transform.rotation = Quaternion.Euler(rotation);
        rotation = transform.rotation.eulerAngles;
        rotation.y = pitch;
        transform.rotation = Quaternion.Euler(rotation);
    }
}