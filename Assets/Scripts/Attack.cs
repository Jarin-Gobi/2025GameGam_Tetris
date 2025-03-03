using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] public float attackDamage = 0;
    [SerializeField] public int knockback;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Damageable>(out var damageable))
        {
            bool gotHit = damageable.Hit(attackDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable != null)
        {
            bool gotHit = damageable.Hit(attackDamage, knockback, transform);
        }
    }
}
