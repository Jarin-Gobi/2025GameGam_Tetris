using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Object")]
    [SerializeField] public PoolManager Pool;
    [SerializeField] public HeartManager heartManager;
    [SerializeField] public PlayerController player;
    [SerializeField] public LevelUp uiLevelUP;

    [Header("Game Control")]
    [SerializeField] public bool StartBoss = false;
    [SerializeField] public int Stage = 0;

    [Header("Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 60, 100, 150, 210, 280, 360, 450, 600 };

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        
    }

    public void GetExp()
    {
        exp++;
        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
