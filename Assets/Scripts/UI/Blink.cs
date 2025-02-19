using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Blink : MonoBehaviour
{
    public LoopType looptype;
    [SerializeField] public TextMeshProUGUI text;

    private void Start()
    {
        text.DOFade(0, 1).SetLoops(-1, looptype);
    }
}
