using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int per;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(int per, Vector3 dir)
    {
        this.per = per;

        if(per > -1)
        {
            rb.velocity = dir * 15f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy") || per == -1)
        {
            if (collision.CompareTag("EnemyP"))
            {
            }
            else if (collision.CompareTag("Boss"))
            {
            }
            else
            {
                return;
            }
        }

        per--;

        if(per == -1)
        {
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        gameObject.SetActive(false);
    }
}
