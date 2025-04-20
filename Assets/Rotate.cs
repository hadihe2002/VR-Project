﻿using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;

    public float speed = 50f;

    void Update()
    {
        Vector3 rotation = Vector3.zero;
        if (rotateX)
        {
            rotation += Vector3.right;
        }

        if (rotateY)
        {
            rotation += Vector3.up;
        }

        if (rotateZ)
        {
            rotation += Vector3.forward;
        }

        Debug.Log(transform.rotation);
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}
