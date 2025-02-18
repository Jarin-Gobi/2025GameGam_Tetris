using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public PoolManager Pool;
    [SerializeField] public PlayerController player;
    [SerializeField] public bool StartBoss = false;
    [SerializeField] public int level = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        
    }
}
