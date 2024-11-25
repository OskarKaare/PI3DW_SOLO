using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 250f;
    private float pitch = 0.0f;
    private float yaw = 0.0f;
    public Transform player;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
      
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        yaw += mouseX;
        pitch -= mouseY;

        //Clamp the pitch to prevent the camera from turning upside down
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        // Apply the rotation
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

       player.transform.Rotate(Vector3.up * mouseX);

    }
}
