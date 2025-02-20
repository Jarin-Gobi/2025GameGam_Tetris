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
        rec.DOMoveY(FolkDown, FolkTime);
    }
}
