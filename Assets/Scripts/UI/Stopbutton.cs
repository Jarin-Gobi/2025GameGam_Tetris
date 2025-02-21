using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        rec.localScale = Vector3.one;
        GameManager.Instance.Stop();
    }

    public void Tutorial()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        image.rectTransform.localScale = Vector3.one;
        rec.localScale = Vector3.zero;
    }

    public void Restart()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.Button);
        rec.localScale = Vector3.zero;
        if(GameManager.Instance.uiLevelUP.rect.localScale != Vector3.one)
        {
            GameManager.Instance.Resume();

        }
    }

    public void RealRestart()
    {
        SceneManager.LoadScene(1);
    }
}
