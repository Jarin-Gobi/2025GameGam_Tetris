using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("BGM")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    public int bchannels;
    AudioSource[] bgmPlayer;
    AudioHighPassFilter bgmEffect;
    int bchannelIndex;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    public AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx
    {
        
        Button, Attack, PlayerHit, PlayerDeath, MonsterHit, MonsterDeath, LevelUp, BossSpawn, BossDeath
    }

    public enum Bgm
    {
        Stage1, Stage2, Stage3
    }

    private void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = new AudioSource[bchannels];
        for(int i = 0; i < bgmPlayer.Length; i++)
        {
            bgmPlayer[i] = bgmObject.AddComponent<AudioSource>();
            bgmPlayer[i].playOnAwake = false;
            bgmPlayer[i].loop = true;
            bgmPlayer[i].volume = bgmVolume;
        }
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();


        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVolume;
        }
    }


    public void PlayBGM(bool isPlay, int stage)
    {
        if (isPlay)
        {
            for (int i = 0; i < bchannels; i++)
            {
                int loopIndex = (i + bchannelIndex) % channels;

                if (bgmPlayer[loopIndex].isPlaying)
                    continue;

                bchannelIndex = loopIndex;
                bgmPlayer[loopIndex].clip = bgmClip[stage];
                bgmPlayer[loopIndex].Play();
                break;
            }
        }
        else
            bgmPlayer[stage].Stop();
    }

    public void EffectBGM(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }

    public void PlaySFX(Sfx sfx)
    {
        //쉬고있는 플레이어를 찝어서
        for (int i = 0; i < channels; i++)
        {
            int loopIndex = (i + channelIndex) % channels;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
