using UnityEngine;

public class Face_Camera : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (cam == null)
            return;

        Vector3 direction = cam.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}