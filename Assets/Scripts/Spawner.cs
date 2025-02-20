using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    public SpawnData[] spawnData;
    float timer;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isLive)
        {
            return;
        }
        timer += Time.deltaTime;
        if (GameManager.Instance.StartBoss && gameObject.CompareTag("PlayerSpawner"))
        {
            return;
        }

        if(GameManager.Instance.player.damageable.IsAlive)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if(timer > spawnData[GameManager.Instance.Stage].spawnTime && GameManager.Instance.StartBoss)
        {
            timer = 0;
            GameObject enemy = GameManager.Instance.Pool.Get(Random.Range(8, 10));
            enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
            enemy.GetComponent<Enemy>().Init(spawnData[GameManager.Instance.Stage]);
        }
        else if (timer > spawnData[GameManager.Instance.Stage].spawnTime)
        {
            timer = 0;
            GameObject enemy = GameManager.Instance.Pool.Get(GameManager.Instance.Stage);
            enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
            enemy.GetComponent<Enemy>().Init(spawnData[GameManager.Instance.Stage]);
        }
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int health;
    public float speed;
}
