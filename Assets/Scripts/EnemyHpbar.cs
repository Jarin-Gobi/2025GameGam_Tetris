using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpbar : MonoBehaviour
{
    [SerializeField]private Damageable damageable;
    [SerializeField]private Slider Hpbar;
    private void Awake()
    {
        damageable = GetComponentInParent<Damageable>();
        Hpbar = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        Hpbar.value = damageable.Health / damageable.MaxHealth;
    }
}
