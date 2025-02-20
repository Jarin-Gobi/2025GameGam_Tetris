using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public LoopType looptype;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public Text text2;
    private void Start()
    {
        if (text == null)
        {
            text2.DOFade(0, 1).SetLoops(-1, looptype);
        }
        else
        {
            text.DOFade(0, 1).SetLoops(-1, looptype);
        }
    }
}
