using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Object")]
    [SerializeField] public PoolManager Pool;
    [SerializeField] public HeartManager heartManager;
    [SerializeField] public PlayerController player;
    [SerializeField] public LevelUp uiLevelUP;
    [SerializeField] public int ItemVolum;
    public List<Image> ItemIcons;
    public ItemArray itemArray;

    [Header("Game Control")]
    [SerializeField] public bool isLive = true;
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
        isLive = true;
    }

    private void Update()
    {
        
    }

    private void Start()
    {
        uiLevelUP.Select(5);
    }

    public void GetExp()
    {
        exp++;
        if(exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
            uiLevelUP.show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
