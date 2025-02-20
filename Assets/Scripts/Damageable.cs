using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    // public UnityEvent<int, Vector2> damageableHit;
    [SerializeField] private float _maxHealth = 10;
    private Rigidbody2D _rb;
    private Vector2 backDir;
    public Rigidbody2D rb => _rb ??= GetComponent<Rigidbody2D>();

    private Enemy _enemy;
    public Enemy enemy => _enemy ??= GetComponent<Enemy>();
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField] private float _health = 10;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    [SerializeField] private bool _isAlive = true;


    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
        }
    }

    public bool Hit(float damage, int knockback, Transform tr)
    {
        if (IsAlive)
        {
            Health -= damage;
            // damageableHit?.Invoke(damage, knockback);
            if (enemy != null && knockback != 0)
            {
                KnockBack(tr, knockback);
            }
            return true;
        }
        return false;
    }

    public bool Hit(float damage)
    {
        if (IsAlive)
        {
            if (gameObject.CompareTag("Player"))
            {
                GameManager.Instance.heartManager.ApplyHeart(damage);
                animator.SetTrigger("Hit");
            }
            Health -= damage;
            return true;
        }
        return false;
    }

    public void KnockBack(Transform PrevPos, int knockback)
    {
        backDir.x = transform.position.x - PrevPos.position.x > 0 ? 1 : -1;
        backDir.y = transform.position.y - PrevPos.position.y > 0 ? 1 : -1;
        rb.AddForce(new Vector2(backDir.x, backDir.y) * knockback, ForceMode2D.Impulse);

        StartCoroutine(enemy.KnockBackCo());
    }

    public bool Heal(float healthRestore)
    {
        if (IsAlive && Health < MaxHealth)
        {
            float maxHeal = Mathf.Max(MaxHealth - Health, 0);
            float actualHeal = Mathf.Min(maxHeal, healthRestore);
            GameManager.Instance.heartManager.Healheart(Health + actualHeal);
            Health += actualHeal;
            return true;
        }
        return false;
    }
}
