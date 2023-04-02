using UnityEngine;

public class TopDownCamera : MonoBehaviour 
{
    public Transform target; // The target object to follow
    public float distance = 5.0f; // The distance from the target object
    public float height = 10.0f; // The height from the target object
    public float smoothSpeed = 0.5f; // The speed at which the camera moves

    private Vector3 offset; // The offset of the camera

    void Start()
    {
        offset = new Vector3(0f, height, -distance); // Calculate the offset
    }

    void LateUpdate() 
    {
        Vector3 desiredPosition = target.position + offset; // Calculate the desired position of the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly move the camera to the desired position
        transform.position = smoothedPosition;

        transform.LookAt(target); // Make the camera look at the target
    }
}