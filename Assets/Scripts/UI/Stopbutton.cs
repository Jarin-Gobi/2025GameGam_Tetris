using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopbutton : MonoBehaviour
{
    RectTransform rec;
    [SerializeField] public Image image;

    private void Awake()
    {
        rec = GetComponent<RectTransform>();
    }
    public void OnClick()
    {
        rec.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }

    public void Tutorial()
    {
        image.rectTransform.localScale = Vector3.one;
        rec.localScale = Vector3.zero;
    }

    public void Restart()
    {
        rec.localScale = Vector3.zero;
        if(GameManager.Instance.uiLevelUP.rect.localScale != Vector3.one)
        {
            GameManager.Instance.Resume();

        }
    }
}
