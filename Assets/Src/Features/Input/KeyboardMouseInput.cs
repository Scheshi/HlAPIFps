using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class KeyboardMouseInput : NetworkBehaviour
{
    [SerializeField] private UnityEvent<float, float> onMove;
    [SerializeField] private UnityEvent<float, float> onRotate;
    [SerializeField] private UnityEvent onShoot;

    private void Update()
    {
        if (!isLocalPlayer)
            return;
        onMove.Invoke(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        onRotate.Invoke(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if(Input.GetButtonDown("Fire1"))
            onShoot.Invoke();
    }
}
