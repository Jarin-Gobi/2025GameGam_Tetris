using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownFolk : MonoBehaviour
{
    RectTransform rec;
    [SerializeField] private float FolkDown;
    [SerializeField] private float FolkTime;

    private void Awake()
    {
        rec = GetComponent<RectTransform>();
    }

    private void Start()
    {
        BadEndingAudio.instance.PlayBGM(true, 0);
        BadEndingAudio.instance.PlayBGM(true, 1);
        BadEndingAudio.instance.PlayBGM(true, 2);
        StartCoroutine("Audio");
    }

    IEnumerator Audio()
    {
        yield return new WaitForSeconds(0.1f);
        BadEndingAudio.instance.PlaySFX(BadEndingAudio.Sfx.FolkDown1);
        yield return new WaitForSeconds(0.1f);
        BadEndingAudio.instance.PlaySFX(BadEndingAudio.Sfx.FolkDown2);
    }
}
