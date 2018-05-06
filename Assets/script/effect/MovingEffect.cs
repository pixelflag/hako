using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEffect : MonoBehaviour
{
    [SerializeField]
    protected float gravity = 0.1f;

    [SerializeField]
    protected float friction = 0.95f;

    protected int count;
    protected float virturlZ = 0.0f;
    protected Vector3 speed = new Vector3();

    public void addForce(Vector3 force)
    {
        speed = force;
    }

    public void randomOffset(float offsetRange)
    {
        float randX = Random.Range(-offsetRange, offsetRange);
        float randY = Random.Range(-offsetRange, offsetRange);
        transform.Translate(new Vector3(randX, randY, 0));
    }

    protected virtual void Update()
    {
        count++;

        speed.x *= friction;
        speed.y *= friction;

        virturlZ += speed.z;
        if (virturlZ <= 0)
        {
            speed.z = -speed.z;
        }
        else
        {
            speed.z -= gravity;
        }

        if (Mathf.Abs(speed.x) <= 0.1) speed.x = 0;
        if (Mathf.Abs(speed.y) <= 0.1) speed.y = 0;

        Vector3 pos = new Vector3();
        pos.x = speed.x;
        pos.y = speed.y;
        pos.z = 0.0f;

        transform.Translate(pos);
    }
}
