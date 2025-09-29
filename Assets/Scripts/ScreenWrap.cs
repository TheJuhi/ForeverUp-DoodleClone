using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera cam;
    private float halfWidth;

    void Start()
    {
        cam = Camera.main;
        halfWidth = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        // Left -> Right wrap
        if (pos.x < -halfWidth)
        {
            pos.x = halfWidth;
        }
        // Right -> Left wrap
        else if (pos.x > halfWidth)
        {
            pos.x = -halfWidth;
        }

        transform.position = pos;
    }
}

