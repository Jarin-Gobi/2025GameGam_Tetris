using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D target;
    private Damageable damageable;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    public float knockBackSpan = 1.0f;
    public bool isKnockBacking = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (!damageable.IsAlive)
        {
            GameManager.Instance.kill++;
            GameManager.Instance.GetExp();
            Dead();
        }


        if (isKnockBacking || !GameManager.Instance.player.damageable.IsAlive || !GameManager.Instance.isLive)
        {
            return;
        }
        if (gameObject.CompareTag("Enemy"))
        {
            Vector2 dirVec = target.position - rb.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + nextVec);
            rb.velocity = Vector2.zero;

            transform.right = -dirVec;
        }
        else
        {
            Vector2 dirVec = target.position - rb.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + nextVec);
            rb.velocity = Vector2.zero;
        }
        
    }

    private void LateUpdate()
    {
        if (!GameManager.Instance.isLive)
        {
            return;
        }
        if (gameObject.CompareTag("EnemyP"))
        {
            spriteRenderer.flipX = target.position.x < rb.position.x;
        }
    }

    private void OnEnable()
    {
        target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
        damageable.IsAlive = true;
        isKnockBacking = false;
        damageable.Health = damageable.MaxHealth;
    }

    public void Init(SpawnData spawnData)
    {
        speed = spawnData.speed;
        damageable.MaxHealth = spawnData.health;
        damageable.Health = spawnData.health;
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator KnockBackCo()
    {
        isKnockBacking = true;
        yield return new WaitForSeconds(knockBackSpan);
        isKnockBacking = false;
    }
}
