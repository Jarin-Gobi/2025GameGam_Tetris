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
    public float gameTime;
    [SerializeField] public float[] BossTime;
    [SerializeField] public GameObject[] Boss;
    [SerializeField] public BossManager BM;
    [SerializeField] public Ground[] grounds;
    [SerializeField] public ShowBoss showBoss;
    [SerializeField] public ShowEnding showE;

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
        if(!isLive)
        {
            return;
        }
        if (!StartBoss)
        {
            gameTime += Time.deltaTime;
        }
        else
        {
            gameTime = 0;
        }
        if(gameTime > BossTime[Stage])
        {
            BM.SpawnB();
            StartBoss = true;
            showBoss.StartCoroutine("ShowAndHide");
        }
    }

    private void Start()
    {
        uiLevelUP.Select(5);
        AudioManager.instance.PlayBGM(true, Stage);
    }

    public void GetExp()
    {
        exp++;
        if(exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            AudioManager.instance.PlaySFX(AudioManager.Sfx.LevelUp);
            level++;
            exp = 0;
            uiLevelUP.show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
        player.inputVec = Vector3.zero;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
