using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Damageable damageable;
    private void Awake()
    {
        damageable = GetComponent<Damageable>();
    }

    private void LateUpdate()
    {
        if (!damageable.IsAlive)
        {
            GameManager.Instance.Stage++;
            GameManager.Instance.StartBoss = false;
            Destroy(gameObject);
        }
    }
}
