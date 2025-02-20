using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if(GameManager.Instance.Stage >= 2)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                GameManager.Instance.Stage++;
                GameManager.Instance.StartBoss = false;
                for (int i = 0; i < GameManager.Instance.grounds.Length; i++)
                {
                    GameManager.Instance.grounds[i].ChangeGround(GameManager.Instance.Stage);
                }
            }
            Destroy(gameObject);
        }
    }
}
