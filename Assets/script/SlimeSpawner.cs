using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    private CircleCollider2D m_collider;

    private bool isReady = true;
    public bool IsReady
    {
        set { isReady = value; }
        get { return isReady; }
    }

    void Start ()
    {
        m_collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReady = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReady = true;
        }
    }

    public Vector3 GetSlimeSpawnPosition()
    {
        Vector3 pos = transform.position;

        float radian = Random.Range(0, Mathf.PI * 2);
        pos.y = (Mathf.Sin(radian) * m_collider.radius * 0.8f) + transform.position.y;
        pos.x = (Mathf.Cos(radian) * m_collider.radius * 0.8f) + transform.position.x;

        return pos;
    }
}
