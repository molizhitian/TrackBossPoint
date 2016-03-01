using UnityEngine;
using System.Collections;

public class CameraFollowRole : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool isStartFllow = false;
    void Update()
    {
        if (isStartFllow)
        {
            if (!target)
                return;
            transform.position = target.position + offset;
        }
    }
}
