using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public float damping = 0.5f;

    public Transform target;
    Vector3 velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);
    }
}
