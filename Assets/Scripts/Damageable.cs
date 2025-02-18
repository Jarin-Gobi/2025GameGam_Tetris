using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    // public UnityEvent<int, Vector2> damageableHit;
    [SerializeField] private int _maxHealth = 10;
    private Rigidbody2D _rb;
    private Vector2 backDir;
    public Rigidbody2D rb => _rb ??= GetComponent<Rigidbody2D>();

    private Enemy _enemy;
    public Enemy enemy => _enemy ??= GetComponent<Enemy>();

    public int MaxHealth
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

    [SerializeField] private int _health = 10;

    public int Health
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

    public bool Hit(int damage, int knockback, Transform tr)
    {
        if (IsAlive)
        {
            Health -= damage;
            // damageableHit?.Invoke(damage, knockback);
            if (enemy != null)
            {
                KnockBack(tr, knockback);
            }
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

    public bool Heal(int healthRestore)
    {
        if (IsAlive && Health < MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actualHeal;
            return true;
        }
        return false;
    }
}
