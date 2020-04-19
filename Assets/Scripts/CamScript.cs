using UnityEngine;

public class CamScript : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothSpeed = 0;

    [SerializeField]
    private Vector3 offset;

    private Vector3 followPos;

    private void FixedUpdate()
    {
        followPos = target.position + offset;
        Vector3 smoothedFollow = Vector3.Lerp(transform.position, followPos, smoothSpeed);
        transform.position = smoothedFollow;
    }
}
