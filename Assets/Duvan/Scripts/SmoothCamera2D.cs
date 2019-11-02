using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

    public float limitYUp;
    public float limitYDown;

    public float limitXRight;
    public float limitXLeft;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, limitXLeft, limitXRight), Mathf.Clamp(transform.position.y, limitYDown, limitYUp), -10);
        }

    }
}