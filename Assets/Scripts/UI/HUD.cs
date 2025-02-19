using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        Exp, Level, Kill, Stage
    }

    public InfoType type;

    Text myText;
    Slider mySlider;


    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }


    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.Instance.exp;
                float maxExp = GameManager.Instance.nextExp[Mathf.Min(GameManager.Instance.level, GameManager.Instance.nextExp.Length - 1)];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = "Lv." + GameManager.Instance.level.ToString();
                break;
            case InfoType.Kill:
                myText.text = GameManager.Instance.kill.ToString();
                break;
            case InfoType.Stage:
                myText.text = "STAGE " + (GameManager.Instance.Stage + 1).ToString();
                break;
        }
    }
}
